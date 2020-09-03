namespace KdbSharp.Data
{
    public class KdbSymbolVector : IKdbVector<string>
    {
        public KdbType Type => KdbType.SymbolVector;

        public string[] Value { get; }

        public KdbSymbolVector(string[] value)
        {
            Value = value;
        }
    }
}
