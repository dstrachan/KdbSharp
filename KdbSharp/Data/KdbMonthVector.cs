namespace KdbSharp.Data
{
    public class KdbMonthVector : IKdbVector<int>
    {
        public KdbType Type => KdbType.MonthVector;

        public int[] Value { get; }

        public KdbMonthVector(int[] value)
        {
            Value = value;
        }
    }
}
