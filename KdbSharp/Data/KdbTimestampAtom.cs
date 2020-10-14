namespace KdbSharp.Data
{
    public class KdbTimestampAtom : BaseLongAtom
    {
        public override KdbType Type => KdbType.TimestampAtom;

        public KdbTimestampAtom(long value) : base(value)
        {
        }
    }
}
