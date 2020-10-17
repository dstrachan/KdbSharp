using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbMinuteVector : BaseIntVector
    {
        public override KdbType Type => KdbType.MinuteVector;

        public KdbMinuteVector(int[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`minute$()";
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
                        return x.ToMinute().ToString("HH:mm");
                }
            }));
            if (requiresSuffix)
            {
                stringBuilder.Append('u');
            }
            return stringBuilder.ToString();
        }
    }
}
