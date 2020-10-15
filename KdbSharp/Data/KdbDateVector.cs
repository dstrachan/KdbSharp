using System.Text;

namespace KdbSharp.Data
{
    public class KdbDateVector : BaseIntVector
    {
        public override KdbType Type => KdbType.DateVector;

        public KdbDateVector(int[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`date$()";
            }

            var stringBuilder = new StringBuilder(Value.Length == 1 ? "," : "");
            for (var i = 0; i < Value.Length - 1; i++)
            {
                stringBuilder.Append(Value[i] switch
                {
                    Null => "0N",
                    NegativeInfinity => "-0W",
                    PositiveInfinity => "0W",
                    _ => Value[i].ToDate().ToString("yyyy.MM.dd"),
                });
                stringBuilder.Append(' ');
            }
            stringBuilder.Append(Value[^1] switch
            {
                Null => "0Nd",
                NegativeInfinity => "-0Wd",
                PositiveInfinity => "0Wd",
                _ => Value[^1].ToDate().ToString("yyyy.MM.dd"),
            });
            return stringBuilder.ToString();
        }
    }
}
