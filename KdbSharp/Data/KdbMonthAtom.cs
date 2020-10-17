namespace KdbSharp.Data
{
    public class KdbMonthAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.MonthAtom;

        public KdbMonthAtom(int value) : base(value)
        {
        }
        public override string ToString()
        {
            switch (Value)
            {
                case Null:
                    return "0Nm";
                case NegativeInfinity:
                    return "-0Wm";
                case PositiveInfinity:
                    return "0Wm";
                default:
                    return Value.ToMonth().ToString("yyyy.MM'm'");
            }
        }
    }
}
