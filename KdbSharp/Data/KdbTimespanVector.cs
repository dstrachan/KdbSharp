namespace KdbSharp.Data
{
    public class KdbTimespanVector : BaseLongVector
    {
        public override KdbType Type => KdbType.TimespanVector;

        public KdbTimespanVector(long[] value) : base(value)
        {
        }
    }
}
