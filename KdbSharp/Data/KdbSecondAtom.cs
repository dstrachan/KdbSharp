namespace KdbSharp.Data
{
    public class KdbSecondAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.SecondAtom;

        public KdbSecondAtom(int value) : base(value)
        {
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Null:
                    return "0Nv";
                case NegativeInfinity:
                    return "-0Wv";
                case PositiveInfinity:
                    return "0Wv";
                default:
                    return Value.ToSecond().ToString("HH:mm:ss");
            }
        }
    }
}
