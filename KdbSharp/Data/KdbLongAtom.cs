namespace KdbSharp.Data
{
    public class KdbLongAtom : BaseLongAtom
    {
        public override KdbType Type => KdbType.LongAtom;

        public KdbLongAtom(long value) : base(value)
        {
        }
    }
}
