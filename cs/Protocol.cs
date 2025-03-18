using System;
using System.Buffers;
using Google.Protobuf;

namespace spire.protocol;

public enum ProtocolCategory : byte
{
    None = 0,
    Auth = 1,
    Game = 2,
    Net = 3
}

public static class ProtocolHeader
{
    public const int HeaderSize = 4;
    private const byte Reserved = 0;

    public static void Write(ProtocolCategory category, ushort length, Span<byte> buffer)
    {
        if (buffer.Length < 4)
            throw new ArgumentOutOfRangeException("Buffer must be at least 4 bytes long.");

        buffer[0] = (byte)category;
        buffer[1] = Reserved;
        buffer[2] = (byte)(length >> 8);
        buffer[3] = (byte)length;
    }

    public static (ProtocolCategory, ushort) Read(ReadOnlySpan<byte> buffer)
    {
        if (buffer.Length < 4)
            throw new ArgumentOutOfRangeException("Buffer must be at least 4 bytes long.");

        var category = buffer[0] switch
        {
            1 => ProtocolCategory.Auth,
            2 => ProtocolCategory.Game,
            3 => ProtocolCategory.Net,
            _ => ProtocolCategory.None
        };
        var length = (ushort)((buffer[2] << 8) | buffer[3]);

        return (category, length);
    }
}

public static class ProtocolUtil
{
    public static byte[] Serialize(ProtocolCategory category, IMessage protocol)
    {
        var length = protocol.CalculateSize();
        if (length > ushort.MaxValue)
            throw new ArgumentOutOfRangeException($"Requested buffer length {length} exceed {ushort.MaxValue}.");
        
        var buffer = ArrayPool<byte>.Shared.Rent(ProtocolHeader.HeaderSize + length);
        ProtocolHeader.Write(category, (ushort)length, buffer);
        protocol.WriteTo(buffer.AsSpan()[ProtocolHeader.HeaderSize..]);

        return buffer;
    }
}