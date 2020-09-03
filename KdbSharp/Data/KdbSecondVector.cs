namespace KdbSharp.Data
{
    public class KdbSecondVector : IKdbVector<int>
    {
        public KdbType Type => KdbType.SecondVector;

        public int[] Value { get; }

        public KdbSecondVector(int[] value)
        {
            Value = value;
        }
    }
}
