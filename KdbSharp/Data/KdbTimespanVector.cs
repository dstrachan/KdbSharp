using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbTimespanVector : BaseLongVector
    {
        public override KdbType Type => KdbType.TimespanVector;

        public KdbTimespanVector(long[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`timespan$()";
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
                        return x.ToTimespan().ToString(@$"{(x < 0 ? @"\-" : "")}d\Dhh\:mm\:ss\.fffffff\0\0");
                }
            }));
            if (requiresSuffix)
            {
                stringBuilder.Append('n');
            }
            return stringBuilder.ToString();
        }
    }
}
