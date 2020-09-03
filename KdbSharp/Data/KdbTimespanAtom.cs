namespace KdbSharp.Data
{
    public class KdbTimespanAtom : IKdbAtom<long>
    {
        public KdbType Type => KdbType.TimespanAtom;

        public long Value { get; }

        public KdbTimespanAtom(long value)
        {
            Value = value;
        }
    }
}
