using System;

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
    public const uint HeaderSize = 4;
    private const byte Reserved = 0;

    public static void Write(ProtocolCategory protocolCategory, ushort length, Span<byte> buffer)
    {
        if (buffer.Length < 4)
            throw new ArgumentOutOfRangeException("Buffer must be at least 4 bytes long.");

        buffer[0] = (byte)protocolCategory;
        buffer[1] = Reserved;
        buffer[2] = (byte)(length >> 8);
        buffer[3] = (byte)length;
    }

    public static (ProtocolCategory, ushort) Read(ReadOnlySpan<byte> buffer)
    {
        if (buffer.Length < 4)
            throw new ArgumentOutOfRangeException("Buffer must be at least 4 bytes long.");

        var protocol = buffer[0] switch
        {
            1 => ProtocolCategory.Auth,
            2 => ProtocolCategory.Game,
            3 => ProtocolCategory.Net,
            _ => ProtocolCategory.None
        };
        var length = (ushort)((buffer[2] << 8) | buffer[3]);

        return (protocol, length);
    }
}