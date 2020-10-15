using System;

namespace KdbSharp.IPC
{
    public static class IPCExtensions
    {
        private static readonly int[] _guidByteOrder = new[] { 3, 2, 1, 0, 5, 4, 7, 6, 8, 9, 10, 11, 12, 13, 14, 15 };

        public static Guid FromKdbGuidBytes(this ReadOnlySpan<byte> data)
        {
            var b = new byte[16];
            for (var i = 0; i < 16; i++)
            {
                b[_guidByteOrder[i]] = data[i];
            }
            return new Guid(b);
        }

        public static byte[] ToKdbGuidBytes(this Guid guid)
        {
            var b = guid.ToByteArray();
            var value = new byte[16];
            for (var i = 0; i < 16; i++)
            {
                value[i] = b[_guidByteOrder[i]];
            }
            return value;
        }
    }
}
