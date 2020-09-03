namespace KdbSharp.Data
{
    public class KdbCharAtom : IKdbAtom<char>
    {
        public KdbType Type => KdbType.CharAtom;

        public char Value { get; }

        public KdbCharAtom(char value)
        {
            Value = value;
        }
    }
}
