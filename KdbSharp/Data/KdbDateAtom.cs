namespace KdbSharp.Data
{
    public class KdbDateAtom : IKdbAtom<int>
    {
        public KdbType Type => KdbType.DateAtom;

        public int Value { get; }

        public KdbDateAtom(int value)
        {
            Value = value;
        }
    }
}
