namespace KdbSharp.Data
{
    public class KdbDatetimeAtom : BaseDoubleAtom
    {
        public override KdbType Type => KdbType.DatetimeAtom;

        public KdbDatetimeAtom(double value) : base(value)
        {
        }

        public override string ToString() => Value switch
        {
            Null => "0Nz",
            NegativeInfinity => "-0Wz",
            PositiveInfinity => "0Wz",
            _ => Value.ToDatetime().ToString("yyyy.MM.ddTHH:mm:ss.fff"),
        };
    }
}
