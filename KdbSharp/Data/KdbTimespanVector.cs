﻿using System.Text;

namespace KdbSharp.Data
{
    public class KdbTimespanVector : BaseLongVector
    {
        public override KdbType Type => KdbType.TimespanVector;

        public KdbTimespanVector(long[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`timespan$()";
            }

            var stringBuilder = new StringBuilder(Value.Length == 1 ? "," : "");
            for (var i = 0; i < Value.Length - 1; i++)
            {
                stringBuilder.Append(Value[i] switch
                {
                    Null => "0N",
                    NegativeInfinity => "-0W",
                    PositiveInfinity => "0W",
                    _ => Value[i].ToTimespan().ToString(@$"{(Value[i] < 0 ? @"\-" : "")}d\Dhh\:mm\:ss\.fffffff\0\0"),
                });
                stringBuilder.Append(' ');
            }
            stringBuilder.Append(Value[^1] switch
            {
                Null => "0Nn",
                NegativeInfinity => "-0Wn",
                PositiveInfinity => "0Wn",
                _ => Value[^1].ToTimespan().ToString(@$"{(Value[^1] < 0 ? @"\-" : "")}d\Dhh\:mm\:ss\.fffffff\0\0"),
            });
            return stringBuilder.ToString();
        }
    }
}
