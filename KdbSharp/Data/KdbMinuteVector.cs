namespace KdbSharp.Data
{
    public class KdbMinuteVector : IKdbVector<int>
    {
        public KdbType Type => KdbType.MinuteVector;

        public int[] Value { get; }

        public KdbMinuteVector(int[] value)
        {
            Value = value;
        }
    }
}
