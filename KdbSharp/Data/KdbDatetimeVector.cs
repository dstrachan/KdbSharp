using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbDatetimeVector : BaseDoubleVector
    {
        public override KdbType Type => KdbType.DatetimeVector;

        public KdbDatetimeVector(double[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`datetime$()";
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
                        return x.ToDatetime().ToString("yyyy.MM.ddTHH:mm:ss.fff");
                }
            }));
            if (requiresSuffix)
            {
                stringBuilder.Append('z');
            }
            return stringBuilder.ToString();
        }
    }
}
