using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbTimestampVector : BaseLongVector
    {
        public override KdbType Type => KdbType.TimestampVector;

        public KdbTimestampVector(long[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`timestamp$()";
            }

            var requiresSuffix = true;
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
                        requiresSuffix = false;
                        return x.ToTimestamp().ToString("yyyy.MM.dd'D'HH:mm:ss.fffffff00");
                }
            }));
            if (requiresSuffix)
            {
                stringBuilder.Append('p');
            }
            return stringBuilder.ToString();
        }
    }
}
