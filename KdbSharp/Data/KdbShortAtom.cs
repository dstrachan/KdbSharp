namespace KdbSharp.Data
{
    public class KdbShortAtom : BaseShortAtom
    {
        public override KdbType Type => KdbType.ShortAtom;

        public KdbShortAtom(short value) : base(value)
        {
        }

        public override string ToString() => Value switch
        {
            Null => "0Nh",
            NegativeInfinity => "-0Wh",
            PositiveInfinity => "0Wh",
            _ => $"{Value}h",
        };
    }
}
