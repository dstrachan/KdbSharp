namespace KdbSharp.Data
{
    public class KdbSymbolVector : BaseStringVector
    {
        public override KdbType Type => KdbType.SymbolVector;

        public KdbSymbolVector(string[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }
    }
}
