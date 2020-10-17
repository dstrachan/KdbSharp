namespace KdbSharp.Data
{
    public class KdbRealAtom : BaseFloatAtom
    {
        public override KdbType Type => KdbType.RealAtom;

        public KdbRealAtom(float value) : base(value)
        {
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Null:
                    return "0Ne";
                case NegativeInfinity:
                    return "-0We";
                case PositiveInfinity:
                    return "0We";
                default:
                    return $"{Value}e";
            }
        }
    }
}
