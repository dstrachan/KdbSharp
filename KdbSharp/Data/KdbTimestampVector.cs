namespace KdbSharp.Data
{
    public class KdbTimestampVector : BaseLongVector
    {
        public override KdbType Type => KdbType.TimestampVector;

        public KdbTimestampVector(long[] value) : base(value)
        {
        }
    }
}
