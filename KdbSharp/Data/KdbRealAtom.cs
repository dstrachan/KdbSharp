namespace KdbSharp.Data
{
    public class KdbRealAtom : BaseFloatAtom
    {
        public override KdbType Type => KdbType.RealAtom;

        public KdbRealAtom(float value) : base(value)
        {
        }
        public override string ToString() => Value switch
        {
            Null => "0Ne",
            NegativeInfinity => "-0We",
            PositiveInfinity => "0We",
            _ => $"{Value}e",
        };
    }
}
