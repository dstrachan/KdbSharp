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

            var stringBuilder = new StringBuilder(Value.Length == 1 ? "," : "");
            for (var i = 0; i < Value.Length - 1; i++)
            {
                stringBuilder.Append(Value[i] switch
                {
                    Null => "0N",
                    NegativeInfinity => "-0W",
                    PositiveInfinity => "0W",
                    _ => Value[i].ToSecond().ToString("HH:mm:ss"),
                });
                stringBuilder.Append(' ');
            }
            stringBuilder.Append(Value[^1] switch
            {
                Null => "0Nv",
                NegativeInfinity => "-0Wv",
                PositiveInfinity => "0Wv",
                _ => Value[^1].ToSecond().ToString("HH:mm:ss"),
            });
            return stringBuilder.ToString();
        }
    }
}
