namespace KdbSharp.Data
{
    public class KdbTimeAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.TimeAtom;

        public KdbTimeAtom(int value) : base(value)
        {
        }
    }
}
