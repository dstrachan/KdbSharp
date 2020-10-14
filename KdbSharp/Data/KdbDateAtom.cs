namespace KdbSharp.Data
{
    public class KdbDateAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.DateAtom;

        public KdbDateAtom(int value) : base(value)
        {
        }
    }
}
