namespace KdbSharp.Data
{
    public class KdbShortAtom : IKdbAtom<short>
    {
        public KdbType Type => KdbType.ShortAtom;

        public short Value { get; }

        public KdbShortAtom(short value)
        {
            Value = value;
        }
    }
}
