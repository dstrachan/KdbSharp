namespace KdbSharp.Data
{
    public class KdbTimeAtom : IKdbAtom<int>
    {
        public KdbType Type => KdbType.TimeAtom;

        public int Value { get; }

        public KdbTimeAtom(int value)
        {
            Value = value;
        }
    }
}
