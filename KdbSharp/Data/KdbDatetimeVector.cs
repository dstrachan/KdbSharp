using System.Text;

namespace KdbSharp.Data
{
    public class KdbDatetimeVector : BaseDoubleVector
    {
        public override KdbType Type => KdbType.DatetimeVector;

        public KdbDatetimeVector(double[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`datetime$()";
            }

            var stringBuilder = new StringBuilder(Value.Length == 1 ? "," : "");
            for (var i = 0; i < Value.Length - 1; i++)
            {
                stringBuilder.Append(Value[i] switch
                {
                    Null => "0N",
                    NegativeInfinity => "-0W",
                    PositiveInfinity => "0W",
                    _ => Value[i].ToDatetime().ToString("yyyy.MM.ddTHH:mm:ss.fff"),
                });
                stringBuilder.Append(' ');
            }
            stringBuilder.Append(Value[^1] switch
            {
                Null => "0Nz",
                NegativeInfinity => "-0Wz",
                PositiveInfinity => "0Wz",
                _ => Value[^1].ToDatetime().ToString("yyyy.MM.ddTHH:mm:ss.fff"),
            });
            return stringBuilder.ToString();
        }
    }
}
