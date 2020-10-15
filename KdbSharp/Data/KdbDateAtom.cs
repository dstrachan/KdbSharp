namespace KdbSharp.Data
{
    public class KdbDateAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.DateAtom;

        public KdbDateAtom(int value) : base(value)
        {
        }

        public override string ToString() => Value switch
        {
            Null => "0Nd",
            NegativeInfinity => "-0Wd",
            PositiveInfinity => "0Wd",
            _ => Value.ToDate().ToString("yyyy.MM.dd"),
        };
    }
}
