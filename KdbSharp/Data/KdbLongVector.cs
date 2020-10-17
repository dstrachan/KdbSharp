using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbLongVector : BaseLongVector
    {
        public override KdbType Type => KdbType.LongVector;

        public KdbLongVector(long[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`long$()";
            }

            var stringBuilder = new StringBuilder(Value.Length == 1 ? "," : "");
            stringBuilder.AppendJoin(' ', Value.Select(x =>
            {
                switch (x)
                {
                    case Null:
                        return "0N";
                    case NegativeInfinity:
                        return "-0W";
                    case PositiveInfinity:
                        return "0W";
                    default:
                        return $"{x}";
                }
            }));
            return stringBuilder.ToString();
        }
    }
}
