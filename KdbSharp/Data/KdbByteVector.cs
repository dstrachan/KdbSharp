using System.Text;

namespace KdbSharp.Data
{
    public class KdbByteVector : BaseByteVector
    {
        public override KdbType Type => KdbType.ByteVector;

        public KdbByteVector(byte[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`byte$()";
            }

            var stringBuilder = new StringBuilder(Value.Length == 1 ? ",0x" : "0x");
            foreach (var element in Value)
            {
                stringBuilder.Append($"{element:x2}");
            }
            return stringBuilder.ToString();
        }
    }
}
