using System.Collections.Immutable;
using System.Text;
using System.Text.Json;
using Humanizer;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;


namespace Spire.ProtocolGenerator;

[Generator]
public class ProtocolGenerator : IIncrementalGenerator
{
    private const string Tab = "    ";
    
    private static readonly DiagnosticDescriptor InfoLog = new(
        id: "GEN001",
        title: "Generator Info",
        messageFormat: "{0}",
        category: "SourceGenerator",
        DiagnosticSeverity.Info,
        isEnabledByDefault: true);

    private record JsonFileData(string Path, string Content)
    {
        public string Path { get; } = Path;
        public string Content { get; } = Content;
    }

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var jsonFiles = context.AdditionalTextsProvider
            .Where(file => file.Path.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            .Select((file, ct) => new JsonFileData
            (
                file.Path,
                file.GetText(ct)?.ToString() ?? string.Empty
            ))
            .Collect();
        
        context.RegisterSourceOutput(jsonFiles, GenerateProtocolCode);
    }

    private void GenerateProtocolCode(
        SourceProductionContext context,
        ImmutableArray<JsonFileData> jsonFiles)
    {
        List<CategorySchema> categories = [];
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        context.ReportDiagnostic(Diagnostic.Create(InfoLog, Location.None, "JSON files..."));
        foreach (var file in jsonFiles)
        {
            context.ReportDiagnostic(Diagnostic.Create(InfoLog, Location.None, $"JSON file: {file.Path}"));
            
            try
            {
                var category = JsonSerializer.Deserialize<CategorySchema>(file.Content, options);
                if (category != null)
                {
                    categories.Add(category);
                }
            }
            catch (Exception ex)
            {
                ReportWarning(context, "SPG004", "Schema Parse Error",
                    $"Failed to parse {Path.GetFileName(file.Path)}: {ex.Message}");
            }
        }
        
        if (categories.Count == 0)
        {
            ReportWarning(context, "SPG003", "No Schema Files",
                $"No JSON schema files found");
            return;
        }
        
        categories.Sort((a, b) => a.Offset.CompareTo(b.Offset));
        
        List<(string category, string protocolName, ushort number)> protocols = [];
        foreach (var category in categories)
        {
            var number = category.Offset;
            foreach (var protocol in category.Protocols)
            {
                protocols.Add((category.Category, protocol, number));
                number += 1;
            }
        }
        
        var code = GenerateCode(protocols);
        context.AddSource("Protocol.impl.g.cs", SourceText.From(code, Encoding.UTF8));
    }

    private string GenerateCode(List<(string category, string protocolName, ushort number)> protocols)
    {
        List<string> decodes = [];
        List<string> cases = [];
        
        // Generate code fragments
        foreach (var (category, protocol, number) in protocols)
        {
            var categoryName = category.Pascalize();
            var recordName = $"{protocol}Protocol";
            
            decodes.Add($"{number} => new {recordName}({categoryName}.{protocol}.Parser.ParseFrom(data)),");
            
            cases.Add($@"
public record {recordName}({categoryName}.{protocol} Value) : IProtocol
{{
    public ushort ProtocolId => {number};
    public int Size => Value.CalculateSize();
    
    public void Encode(Span<byte> buffer)
    {{
        Value.WriteTo(buffer);
    }}
}}");
        }

        return $@"// Generated file
using Google.Protobuf;

namespace Spire.Protocol;

public interface IProtocol
{{
    public ushort ProtocolId {{ get; }}
    public int Size {{ get; }}

    public void Encode(Span<byte> buffer);

    public static IProtocol Decode(ushort id, ReadOnlySpan<byte> data) {{
        return id switch {{
            {string.Join($"\n{Tab}{Tab}{Tab}", decodes)}
            _ => throw new ProtocolException($""Unknown protocol id: {{id}}"")
        }};
    }}
}}

public class ProtocolException(string message) : Exception(message);

{string.Join("\n", cases)}
";
    }
    
    private void ReportError(SourceProductionContext context, string id, string title, string message)
    {
        context.ReportDiagnostic(Diagnostic.Create(
            new DiagnosticDescriptor(id, title, message, "Configuration", 
                DiagnosticSeverity.Error, isEnabledByDefault: true),
            Location.None));
    }

    private void ReportWarning(SourceProductionContext context, string id, string title, string message)
    {
        context.ReportDiagnostic(Diagnostic.Create(
            new DiagnosticDescriptor(id, title, message, "Configuration", 
                DiagnosticSeverity.Warning, isEnabledByDefault: true),
            Location.None));
    }
    
    private class CategorySchema
    {
        public string Category { get; set; } = string.Empty;
        public ushort Offset { get; set; }
        public List<string> Protocols { get; set; } = [];
    }
}
