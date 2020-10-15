using System;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbFloatVector : BaseDoubleVector
    {
        public override KdbType Type => KdbType.FloatVector;

        public KdbFloatVector(double[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            if (Value.Length == 0)
            {
                return "`float$()";
            }

            var requireSuffix = true;
            var stringBuilder = new StringBuilder(Value.Length == 1 ? "," : "");
            for (var i = 0; i < Value.Length - 1; i++)
            {
                if (Value[i] == Null)
                {
                    requireSuffix = false;
                    stringBuilder.Append("0n");
                }
                else if (Value[i] == NegativeInfinity)
                {
                    requireSuffix = false;
                    stringBuilder.Append("-0w");
                }
                else if (Value[i] == PositiveInfinity)
                {
                    requireSuffix = false;
                    stringBuilder.Append("0w");
                }
                else
                {
                    stringBuilder.Append(Value[i]);
                    requireSuffix &= Math.Abs(Value[i] - (int)Value[i]) < double.Epsilon;
                }
                stringBuilder.Append(' ');
            }
            if (Value[^1] == Null)
            {
                requireSuffix = false;
                stringBuilder.Append("0n");
            }
            else if (Value[^1] == NegativeInfinity)
            {
                requireSuffix = false;
                stringBuilder.Append("-0w");
            }
            else if (Value[^1] == PositiveInfinity)
            {
                requireSuffix = false;
                stringBuilder.Append("0w");
            }
            else
            {
                stringBuilder.Append(Value[^1]);
                requireSuffix &= Math.Abs(Value[^1] - (int)Value[^1]) < double.Epsilon;
            }
            if (requireSuffix)
            {
                stringBuilder.Append('f');
            }
            return stringBuilder.ToString();
        }
    }
}
