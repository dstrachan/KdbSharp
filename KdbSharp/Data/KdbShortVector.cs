namespace KdbSharp.Data
{
    public class KdbShortVector : IKdbVector<short>
    {
        public KdbType Type => KdbType.ShortVector;

        public short[] Value { get; }

        public KdbShortVector(short[] value)
        {
            Value = value;
        }
    }
}
