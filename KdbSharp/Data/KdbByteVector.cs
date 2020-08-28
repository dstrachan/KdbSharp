namespace KdbSharp.Data
{
    public class KdbByteVector : IKdbVector<byte>
    {
        public KdbType Type => KdbType.ByteVector;

        public byte[] Value { get; }

        public KdbByteVector(byte[] value)
        {
            Value = value;
        }
    }
}
