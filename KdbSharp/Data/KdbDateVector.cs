namespace KdbSharp.Data
{
    public class KdbDateVector : IKdbVector<int>
    {
        public KdbType Type => KdbType.DateVector;

        public int[] Value { get; }

        public KdbDateVector(int[] value)
        {
            Value = value;
        }
    }
}
