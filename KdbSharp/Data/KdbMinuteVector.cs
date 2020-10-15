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

            var stringBuilder = new StringBuilder(Value.Length == 1 ? "," : "");
            for (var i = 0; i < Value.Length - 1; i++)
            {
                stringBuilder.Append(Value[i] switch
                {
                    Null => "0N",
                    NegativeInfinity => "-0W",
                    PositiveInfinity => "0W",
                    _ => Value[i].ToMinute().ToString("HH:mm"),
                });
                stringBuilder.Append(' ');
            }
            stringBuilder.Append(Value[^1] switch
            {
                Null => "0Nu",
                NegativeInfinity => "-0Wu",
                PositiveInfinity => "0Wu",
                _ => Value[^1].ToMinute().ToString("HH:mm"),
            });
            return stringBuilder.ToString();
        }
    }
}
