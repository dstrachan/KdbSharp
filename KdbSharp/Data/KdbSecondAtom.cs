namespace KdbSharp.Data
{
    public class KdbSecondAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.SecondAtom;

        public KdbSecondAtom(int value) : base(value)
        {
        }
    }
}
