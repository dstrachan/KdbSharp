using System;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbGuidVector : BaseGuidVector
    {
        public override KdbType Type => KdbType.GuidVector;

        public KdbGuidVector(Guid[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`guid$()";
            }

            var stringBuilder = new StringBuilder(Value.Length == 1 ? "," : "");
            stringBuilder.AppendJoin(' ', Value);
            return stringBuilder.ToString();
        }
    }
}
