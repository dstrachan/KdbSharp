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
            stringBuilder.AppendJoin(' ', Value.Select(x => x switch
            {
                Null => "0N",
                NegativeInfinity => "-0W",
                PositiveInfinity => "0W",
                _ => $"{x}",
            }));
            return stringBuilder.ToString();
        }
    }
}
