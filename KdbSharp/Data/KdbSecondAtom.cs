namespace KdbSharp.Data
{
    public class KdbSecondAtom : IKdbAtom<int>
    {
        public KdbType Type => KdbType.SecondAtom;

        public int Value { get; }

        public KdbSecondAtom(int value)
        {
            Value = value;
        }
    }
}
