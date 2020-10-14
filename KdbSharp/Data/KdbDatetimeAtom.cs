namespace KdbSharp.Data
{
    public class KdbDatetimeAtom : BaseDoubleAtom
    {
        public override KdbType Type => KdbType.DatetimeAtom;

        public KdbDatetimeAtom(double value) : base(value)
        {
        }
    }
}
