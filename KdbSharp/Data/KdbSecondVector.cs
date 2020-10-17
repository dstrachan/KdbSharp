using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbSecondVector : BaseIntVector
    {
        public override KdbType Type => KdbType.SecondVector;

        public KdbSecondVector(int[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`second$()";
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
                        return x.ToSecond().ToString("HH:mm:ss");
                }
            }));
            if (requiresSuffix)
            {
                stringBuilder.Append('v');
            }
            return stringBuilder.ToString();
        }
    }
}
