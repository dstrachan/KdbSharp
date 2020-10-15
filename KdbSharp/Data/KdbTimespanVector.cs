namespace KdbSharp.Data
{
    public class KdbTimespanVector : BaseLongVector
    {
        public override KdbType Type => KdbType.TimespanVector;

        public KdbTimespanVector(long[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }
    }
}
