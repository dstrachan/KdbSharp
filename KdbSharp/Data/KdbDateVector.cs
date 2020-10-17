using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbDateVector : BaseIntVector
    {
        public override KdbType Type => KdbType.DateVector;

        public KdbDateVector(int[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`date$()";
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
                        return x.ToDate().ToString("yyyy.MM.dd");
                }
            }));
            if (requiresSuffix)
            {
                stringBuilder.Append('d');
            }
            return stringBuilder.ToString();
        }
    }
}
