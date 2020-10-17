using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbShortVector : BaseShortVector
    {
        public override KdbType Type => KdbType.ShortVector;

        public KdbShortVector(short[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`short$()";
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
            stringBuilder.Append('h');
            return stringBuilder.ToString();
        }
    }
}
