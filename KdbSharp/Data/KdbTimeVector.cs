using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbTimeVector : BaseIntVector
    {
        public override KdbType Type => KdbType.TimeVector;

        public KdbTimeVector(int[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`time$()";
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
                        return x.ToTime().ToString("HH:mm:ss.fff");
                }
            }));
            if (requiresSuffix)
            {
                stringBuilder.Append('t');
            }
            return stringBuilder.ToString();
        }
    }
}
