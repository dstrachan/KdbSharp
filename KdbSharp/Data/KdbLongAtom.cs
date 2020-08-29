namespace KdbSharp.Data
{
    public class KdbLongAtom : IKdbAtom<long>
    {
        public KdbType Type => KdbType.LongAtom;

        public long Value { get; }

        public KdbLongAtom(long value)
        {
            Value = value;
        }
    }
}
