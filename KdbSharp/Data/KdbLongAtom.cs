namespace KdbSharp.Data
{
    public class KdbLongAtom : BaseLongAtom
    {
        public override KdbType Type => KdbType.LongAtom;

        public KdbLongAtom(long value) : base(value)
        {
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Null:
                    return "0N";
                case NegativeInfinity:
                    return "-0W";
                case PositiveInfinity:
                    return "0W";
                default:
                    return $"{Value}";
            }
        }
    }
}
