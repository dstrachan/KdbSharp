namespace KdbSharp.Data
{
    public class KdbFloatAtom : BaseDoubleAtom
    {
        public override KdbType Type => KdbType.FloatAtom;

        public KdbFloatAtom(double value) : base(value)
        {
        }
    }
}
