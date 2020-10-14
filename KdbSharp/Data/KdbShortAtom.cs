namespace KdbSharp.Data
{
    public class KdbShortAtom : BaseShortAtom
    {
        public override KdbType Type => KdbType.ShortAtom;

        public KdbShortAtom(short value) : base(value)
        {
        }
    }
}
