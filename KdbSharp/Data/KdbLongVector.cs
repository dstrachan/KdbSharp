namespace KdbSharp.Data
{
    public class KdbLongVector : BaseLongVector
    {
        public override KdbType Type => KdbType.LongVector;

        public KdbLongVector(long[] value) : base(value)
        {
        }
    }
}
