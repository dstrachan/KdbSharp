namespace KdbSharp.Data
{
    public class KdbTimestampVector : IKdbVector<long>
    {
        public KdbType Type => KdbType.TimestampVector;

        public long[] Value { get; }

        public KdbTimestampVector(long[] value)
        {
            Value = value;
        }
    }
}
