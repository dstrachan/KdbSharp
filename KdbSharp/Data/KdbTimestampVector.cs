namespace KdbSharp.Data
{
    public class KdbTimestampVector : BaseLongVector
    {
        public override KdbType Type => KdbType.TimestampVector;

        public KdbTimestampVector(long[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }
    }
}
