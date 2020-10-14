namespace KdbSharp.Data
{
    public class KdbMonthAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.MonthAtom;

        public KdbMonthAtom(int value) : base(value)
        {
        }
    }
}
