namespace KdbSharp.Data
{
    public class KdbDatetimeVector : BaseDoubleVector
    {
        public override KdbType Type => KdbType.DatetimeVector;

        public KdbDatetimeVector(double[] value) : base(value)
        {
        }
    }
}
