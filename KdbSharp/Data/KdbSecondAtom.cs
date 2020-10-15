namespace KdbSharp.Data
{
    public class KdbSecondAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.SecondAtom;

        public KdbSecondAtom(int value) : base(value)
        {
        }

        public override string ToString() => Value switch
        {
            Null => "0Nv",
            NegativeInfinity => "-0Wv",
            PositiveInfinity => "0Wv",
            _ => Value.ToSecond().ToString("HH:mm:ss"),
        };
    }
}
