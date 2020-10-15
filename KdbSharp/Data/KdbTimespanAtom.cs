namespace KdbSharp.Data
{
    public class KdbTimespanAtom : BaseLongAtom
    {
        public override KdbType Type => KdbType.TimespanAtom;

        public KdbTimespanAtom(long value) : base(value)
        {
        }

        public override string ToString() => Value switch
        {
            Null => "0Nn",
            NegativeInfinity => "-0Wn",
            PositiveInfinity => "0Wn",
            _ => Value.ToTimespan().ToString("-D'D'hh:mm:ss.fffffffff"),
        };
    }
}
