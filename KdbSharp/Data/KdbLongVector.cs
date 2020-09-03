namespace KdbSharp.Data
{
    public class KdbLongVector : IKdbVector<long>
    {
        public KdbType Type => KdbType.LongVector;

        public long[] Value { get; }

        public KdbLongVector(long[] value)
        {
            Value = value;
        }
    }
}
