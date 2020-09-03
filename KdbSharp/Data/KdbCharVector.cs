namespace KdbSharp.Data
{
    public class KdbCharVector : IKdbVector<char>
    {
        public KdbType Type => KdbType.CharVector;

        public char[] Value { get; }

        public KdbCharVector(char[] value)
        {
            Value = value;
        }
    }
}
