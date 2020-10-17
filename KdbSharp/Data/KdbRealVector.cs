using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbRealVector : BaseFloatVector
    {
        public override KdbType Type => KdbType.RealVector;

        public KdbRealVector(float[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`real$()";
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
            stringBuilder.Append('e');
            return stringBuilder.ToString();
        }
    }
}
