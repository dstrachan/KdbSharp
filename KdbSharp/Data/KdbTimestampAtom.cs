namespace KdbSharp.Data
{
    public class KdbTimestampAtom : IKdbAtom<long>
    {
        public KdbType Type => KdbType.TimestampAtom;

        public long Value { get; }

        public KdbTimestampAtom(long value)
        {
            Value = value;
        }
    }
}
