namespace KdbSharp.Data
{
    public class KdbIntAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.IntAtom;

        public KdbIntAtom(int value) : base(value)
        {
        }

        public override string ToString() => Value switch
        {
            Null => "0Ni",
            NegativeInfinity => "-0Wi",
            PositiveInfinity => "0Wi",
            _ => $"{Value}i",
        };
    }
}
