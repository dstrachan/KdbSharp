namespace KdbSharp.Data
{
    public class KdbMinuteAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.MinuteAtom;

        public KdbMinuteAtom(int value) : base(value)
        {
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Null:
                    return "0Nu";
                case NegativeInfinity:
                    return "-0Wu";
                case PositiveInfinity:
                    return "0Wu";
                default:
                    return Value.ToMinute().ToString("HH:mm");
            }
        }
    }
}
