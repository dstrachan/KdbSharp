namespace KdbSharp.Data
{
    public class KdbRealAtom : BaseFloatAtom
    {
        public override KdbType Type => KdbType.RealAtom;

        public KdbRealAtom(float value) : base(value)
        {
        }
    }
}
