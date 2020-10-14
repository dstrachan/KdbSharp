namespace KdbSharp.Data
{
    public class KdbSymbolVector : BaseStringVector
    {
        public override KdbType Type => KdbType.SymbolVector;

        public KdbSymbolVector(string[] value) : base(value)
        {
        }
    }
}
