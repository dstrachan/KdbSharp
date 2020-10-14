using KdbSharp.Data;
using System;
using System.IO;

namespace KdbSharp.IPC
{
    public class KdbReader
    {
        private readonly Stream _stream;

        public KdbReader(Stream stream)
        {
            _stream = stream;
        }

        public IKdbType Read()
        {
            var header = ReadBytes(4);
            var endianess = header[0];
            var messageType = header[1];
            var compressed = header[2] == 1;

            var reader = new BinaryReader(_stream);
            var messageSize = reader.ReadInt32();
            var dataSize = Math.Max(messageSize - 8, 0);

            var type = (KdbType)reader.ReadSByte();
            return type switch
            {
                KdbType.LongAtom => new KdbLongAtom(reader.ReadInt64()),
                _ => throw new NotImplementedException(),
            };
        }

        private byte[] ReadBytes(int length)
        {
            var buffer = new byte[length];

            var read = 0;
            int chunk;

            while ((chunk = _stream.Read(buffer, read, Math.Min(65536, buffer.Length - read))) > 0)
            {
                read += chunk;

                if (read == buffer.Length)
                {
                    break;
                }
            }

            return buffer;
        }
    }
}
