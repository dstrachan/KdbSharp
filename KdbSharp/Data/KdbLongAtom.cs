namespace KdbSharp.Data
{
    public class KdbLongAtom : BaseLongAtom
    {
        public override KdbType Type => KdbType.LongAtom;

        public KdbLongAtom(long value) : base(value)
        {
        }

        public override string ToString() => Value switch
        {
            Null => "0N",
            NegativeInfinity => "-0W",
            PositiveInfinity => "0W",
            _ => $"{Value}",
        };
    }
}
