namespace KdbSharp.Data
{
    public class KdbMinuteAtom : IKdbAtom<int>
    {
        public KdbType Type => KdbType.MinuteAtom;

        public int Value { get; }

        public KdbMinuteAtom(int value)
        {
            Value = value;
        }
    }
}
