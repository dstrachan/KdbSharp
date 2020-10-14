namespace KdbSharp.Data
{
    public class KdbMinuteVector : BaseIntVector
    {
        public override KdbType Type => KdbType.MinuteVector;

        public KdbMinuteVector(int[] value) : base(value)
        {
        }
    }
}
