using System.Text;

namespace KdbSharp.Data
{
    public class KdbCharVector : BaseCharVector
    {
        public override KdbType Type => KdbType.CharVector;

        public KdbCharVector(char[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`char$()";
            }

            var stringBuilder = new StringBuilder(Value.Length == 1 ? ",\"" : "\"");
            stringBuilder.AppendJoin(string.Empty, Value);
            stringBuilder.Append('"');
            return stringBuilder.ToString();
        }
    }
}
