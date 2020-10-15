namespace KdbSharp.Data
{
    public class KdbLongVector : BaseLongVector
    {
        public override KdbType Type => KdbType.LongVector;

        public KdbLongVector(long[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }
    }
}
