namespace KdbSharp.Data
{
    public class KdbIntAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.IntAtom;

        public KdbIntAtom(int value) : base(value)
        {
        }
    }
}
