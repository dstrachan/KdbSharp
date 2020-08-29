namespace KdbSharp.Data
{
    public class KdbIntVector : IKdbVector<int>
    {
        public KdbType Type => KdbType.IntVector;

        public int[] Value { get; }

        public KdbIntVector(int[] value)
        {
            Value = value;
        }
    }
}
