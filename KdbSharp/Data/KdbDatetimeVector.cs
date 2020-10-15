namespace KdbSharp.Data
{
    public class KdbDatetimeVector : BaseDoubleVector
    {
        public override KdbType Type => KdbType.DatetimeVector;

        public KdbDatetimeVector(double[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }
    }
}
