namespace KdbSharp.Data
{
    public class KdbIntAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.IntAtom;

        public KdbIntAtom(int value) : base(value)
        {
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Null:
                    return "0Ni";
                case NegativeInfinity:
                    return "-0Wi";
                case PositiveInfinity:
                    return "0Wi";
                default:
                    return $"{Value}i";
            }
        }
    }
}
