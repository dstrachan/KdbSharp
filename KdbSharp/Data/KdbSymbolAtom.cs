namespace KdbSharp.Data
{
    public class KdbSymbolAtom : IKdbAtom<string>
    {
        public KdbType Type => KdbType.SymbolAtom;

        public string Value { get; }

        public KdbSymbolAtom(string value)
        {
            Value = value;
        }
    }
}
