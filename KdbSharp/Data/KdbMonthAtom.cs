namespace KdbSharp.Data
{
    public class KdbMonthAtom : IKdbAtom<int>
    {
        public KdbType Type => KdbType.MonthAtom;

        public int Value { get; }

        public KdbMonthAtom(int value)
        {
            Value = value;
        }
    }
}
