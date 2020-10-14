namespace KdbSharp.Data
{
    public class KdbBoolAtom : BaseByteAtom
    {
        public override KdbType Type => KdbType.BoolAtom;

        public KdbBoolAtom(byte value) : base(value)
        {
        }
    }
}
