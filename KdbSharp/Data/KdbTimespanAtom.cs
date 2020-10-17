namespace KdbSharp.Data
{
    public class KdbTimespanAtom : BaseLongAtom
    {
        public override KdbType Type => KdbType.TimespanAtom;

        public KdbTimespanAtom(long value) : base(value)
        {
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Null:
                    return "0Nn";
                case NegativeInfinity:
                    return "-0Wn";
                case PositiveInfinity:
                    return "0Wn";
                default:
                    return Value.ToTimespan().ToString(@$"{(Value < 0 ? @"\-" : "")}d\Dhh\:mm\:ss\.fffffff\0\0");
            }
        }
    }
}
