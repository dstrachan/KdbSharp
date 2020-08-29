namespace KdbSharp.Data
{
    public class KdbIntAtom : IKdbAtom<int>
    {
        public KdbType Type => KdbType.IntAtom;

        public int Value { get; }

        public KdbIntAtom(int value)
        {
            Value = value;
        }
    }
}
