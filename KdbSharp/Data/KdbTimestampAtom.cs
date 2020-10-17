namespace KdbSharp.Data
{
    public class KdbTimestampAtom : BaseLongAtom
    {
        public override KdbType Type => KdbType.TimestampAtom;

        public KdbTimestampAtom(long value) : base(value)
        {
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Null:
                    return "0Np";
                case NegativeInfinity:
                    return "-0Wp";
                case PositiveInfinity:
                    return "0Wp";
                default:
                    return Value.ToTimestamp().ToString("yyyy.MM.dd'D'HH:mm:ss.ffffff000");
            }
        }
    }
}
