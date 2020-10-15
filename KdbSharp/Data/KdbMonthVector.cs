using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbMonthVector : BaseIntVector
    {
        public override KdbType Type => KdbType.MonthVector;

        public KdbMonthVector(int[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`month$()";
            }

            var stringBuilder = new StringBuilder(Value.Length == 1 ? "," : "");
            stringBuilder.AppendJoin(' ', Value.Select(x => x switch
            {
                Null => "0N",
                NegativeInfinity => "-0W",
                PositiveInfinity => "0W",
                _ => x.ToMonth().ToString("yyyy.MM"),
            }));
            stringBuilder.Append('m');
            return stringBuilder.ToString();
        }
    }
}
