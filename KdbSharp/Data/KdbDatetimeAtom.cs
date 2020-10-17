namespace KdbSharp.Data
{
    public class KdbDatetimeAtom : BaseDoubleAtom
    {
        public override KdbType Type => KdbType.DatetimeAtom;

        public KdbDatetimeAtom(double value) : base(value)
        {
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Null:
                    return "0Nz";
                case NegativeInfinity:
                    return "-0Wz";
                case PositiveInfinity:
                    return "0Wz";
                default:
                    return Value.ToDatetime().ToString("yyyy.MM.ddTHH:mm:ss.fff");
            }
        }
    }
}
