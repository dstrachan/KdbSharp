using System.Text;

namespace KdbSharp.Data
{
    public class KdbBoolVector : BaseByteVector
    {
        public override KdbType Type => KdbType.BoolVector;

        public KdbBoolVector(byte[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`bool$()";
            }

            var stringBuilder = new StringBuilder(Value.Length == 1 ? "," : "");
            stringBuilder.AppendJoin(string.Empty, Value);
            stringBuilder.Append('b');
            return stringBuilder.ToString();
        }
    }
}
