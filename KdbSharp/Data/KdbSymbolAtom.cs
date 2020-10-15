namespace KdbSharp.Data
{
    public class KdbSymbolAtom : BaseStringAtom
    {
        public override KdbType Type => KdbType.SymbolAtom;

        public KdbSymbolAtom(string value) : base(value)
        {
        }

        public override string ToString() => $"`{Value}";
    }
}
