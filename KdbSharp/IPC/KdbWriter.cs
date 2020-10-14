using KdbSharp.Data;
using System.IO;

namespace KdbSharp.IPC
{
    public class KdbWriter
    {
        private readonly Stream _stream;

        public KdbWriter(Stream stream)
        {
            _stream = stream;
        }

        public int Write(IKdbType obj, KdbMessageType messageType)
        {
            var buffer = obj.Serialize(messageType);

            _stream.Write(buffer);
            _stream.Flush();

            return buffer.Length;
        }
    }
}
