namespace KdbSharp.Data
{
    public class KdbTimeAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.TimeAtom;

        public KdbTimeAtom(int value) : base(value)
        {
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Null:
                    return "0Nt";
                case NegativeInfinity:
                    return "-0Wt";
                case PositiveInfinity:
                    return "0Wt";
                default:
                    return Value.ToTime().ToString("HH:mm:ss.fff");
            }
        }
    }
}
