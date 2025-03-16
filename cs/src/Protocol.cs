using System;

namespace spire.protocol;

public enum Protocol : byte
{
    None = 0,
    Auth = 1,
    Game = 2,
    Net = 3
}

public static class ProtocolHeader
{
    private const byte RESERVED = 0;

    public static void Write(Protocol protocol, ushort length, Span<byte> buffer)
    {
        if (buffer.Length < 4)
            throw new ArgumentOutOfRangeException("Buffer must be at least 4 bytes long.");

        buffer[0] = (byte)protocol;
        buffer[1] = RESERVED;
        buffer[2] = (byte)(length >> 8);
        buffer[3] = (byte)length;
    }

    public static (Protocol, ushort) Read(ReadOnlySpan<byte> buffer)
    {
        if (buffer.Length < 4)
            throw new ArgumentOutOfRangeException("Buffer must be at least 4 bytes long.");

        var protocol = buffer[0] switch
        {
            1 => Protocol.Auth,
            2 => Protocol.Game,
            3 => Protocol.Net,
            _ => Protocol.None
        };
        var length = (ushort)((buffer[2] << 8) | buffer[3]);

        return (protocol, length);
    }
}