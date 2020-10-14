namespace KdbSharp.Data
{
    public class KdbTimespanAtom : BaseLongAtom
    {
        public override KdbType Type => KdbType.TimespanAtom;

        public KdbTimespanAtom(long value) : base(value)
        {
        }
    }
}
