using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbIntVector : BaseIntVector
    {
        public override KdbType Type => KdbType.IntVector;

        public KdbIntVector(int[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`int$()";
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
            stringBuilder.Append('i');
            return stringBuilder.ToString();
        }
    }
}
