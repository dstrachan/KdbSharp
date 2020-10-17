namespace KdbSharp.Data
{
    public class KdbShortAtom : BaseShortAtom
    {
        public override KdbType Type => KdbType.ShortAtom;

        public KdbShortAtom(short value) : base(value)
        {
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Null:
                    return "0Nh";
                case NegativeInfinity:
                    return "-0Wh";
                case PositiveInfinity:
                    return "0Wh";
                default:
                    return $"{Value}h";
            }
        }
    }
}
