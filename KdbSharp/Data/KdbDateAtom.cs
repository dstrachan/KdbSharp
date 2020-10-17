namespace KdbSharp.Data
{
    public class KdbDateAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.DateAtom;

        public KdbDateAtom(int value) : base(value)
        {
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Null:
                    return "0Nd";
                case NegativeInfinity:
                    return "-0Wd";
                case PositiveInfinity:
                    return "0Wd";
                default:
                    return Value.ToDate().ToString("yyyy.MM.dd");
            }
        }
    }
}
