namespace KdbSharp.Data
{
    public class KdbTimeAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.TimeAtom;

        public KdbTimeAtom(int value) : base(value)
        {
        }

        public override string ToString() => Value switch
        {
            Null => "0Nt",
            NegativeInfinity => "-0Wt",
            PositiveInfinity => "0Wt",
            _ => Value.ToMinute().ToString("HH:mm:ss.fff"),
        };
    }
}
