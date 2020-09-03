namespace KdbSharp.Data
{
    public class KdbTimespanVector : IKdbVector<long>
    {
        public KdbType Type => KdbType.TimespanVector;

        public long[] Value { get; }

        public KdbTimespanVector(long[] value)
        {
            Value = value;
        }
    }
}
