namespace KdbSharp.Data
{
    public class KdbCharAtom : BaseCharAtom
    {
        public override KdbType Type => KdbType.CharAtom;

        public KdbCharAtom(char value) : base(value)
        {
        }
    }
}
