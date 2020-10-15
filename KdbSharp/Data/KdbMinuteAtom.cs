namespace KdbSharp.Data
{
    public class KdbMinuteAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.MinuteAtom;

        public KdbMinuteAtom(int value) : base(value)
        {
        }

        public override string ToString() => Value switch
        {
            Null => "0Nu",
            NegativeInfinity => "-0Wu",
            PositiveInfinity => "0Wu",
            _ => Value.ToMinute().ToString("HH:mm"),
        };
    }
}
