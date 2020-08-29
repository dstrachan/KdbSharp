namespace KdbSharp.Data
{
    public class KdbBoolVector : IKdbVector<byte>
    {
        public KdbType Type => KdbType.BoolVector;

        public byte[] Value { get; }

        public KdbBoolVector(byte[] value)
        {
            Value = value;
        }
    }
}
