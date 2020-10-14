namespace KdbSharp.Data
{
    public class KdbMinuteAtom : BaseIntAtom
    {
        public override KdbType Type => KdbType.MinuteAtom;

        public KdbMinuteAtom(int value) : base(value)
        {
        }
    }
}
