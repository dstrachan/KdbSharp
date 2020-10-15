using System.Text;

namespace KdbSharp.Data
{
    public class KdbTimestampVector : BaseLongVector
    {
        public override KdbType Type => KdbType.TimestampVector;

        public KdbTimestampVector(long[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`timestamp$()";
            }

            var stringBuilder = new StringBuilder(Value.Length == 1 ? "," : "");
            for (var i = 0; i < Value.Length - 1; i++)
            {
                stringBuilder.Append(Value[i] switch
                {
                    Null => "0N",
                    NegativeInfinity => "-0W",
                    PositiveInfinity => "0W",
                    _ => Value[i].ToTimestamp().ToString("yyyy.MM.dd'D'HH:mm:ss.fffffffff"),
                });
                stringBuilder.Append(' ');
            }
            stringBuilder.Append(Value[^1] switch
            {
                Null => "0Np",
                NegativeInfinity => "-0Wp",
                PositiveInfinity => "0Wp",
                _ => Value[^1].ToTimestamp().ToString("yyyy.MM.dd'D'HH:mm:ss.fffffffff"),
            });
            return stringBuilder.ToString();
        }
    }
}
