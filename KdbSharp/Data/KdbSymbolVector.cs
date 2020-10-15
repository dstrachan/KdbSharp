using System.Text;

namespace KdbSharp.Data
{
    public class KdbSymbolVector : BaseStringVector
    {
        public override KdbType Type => KdbType.SymbolVector;

        public KdbSymbolVector(string[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`symbol$()";
            }

            var stringBuilder = new StringBuilder(Value.Length == 1 ? ",`" : "`");
            stringBuilder.AppendJoin('`', Value);
            return stringBuilder.ToString();
        }
    }
}
