namespace KdbSharp.Data
{
    public class KdbTimeVector : IKdbVector<int>
    {
        public KdbType Type => KdbType.TimeVector;

        public int[] Value { get; }

        public KdbTimeVector(int[] value)
        {
            Value = value;
        }
    }
}
