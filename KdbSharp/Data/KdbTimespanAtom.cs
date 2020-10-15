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
            _ => Value.ToTimespan().ToString(@$"{(Value < 0 ? @"\-" : "")}d\Dhh\:mm\:ss\.fffffff\0\0"),
        };
    }
}
