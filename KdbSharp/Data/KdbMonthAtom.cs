namespace KdbSharp.Data
{
    public class KdbMonthAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.MonthAtom;

        public KdbMonthAtom(int value) : base(value)
        {
        }
        public override string ToString() => Value switch
        {
            Null => "0Nm",
            NegativeInfinity => "-0Wm",
            PositiveInfinity => "0Wm",
            _ => Value.ToMonth().ToString("yyyy.MM'm'"),
        };
    }
}
