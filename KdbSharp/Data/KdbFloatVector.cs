using System;
using System.Linq;
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

            var requiresSuffix = true;
            var stringBuilder = new StringBuilder(Value.Length == 1 ? "," : "");
            stringBuilder.AppendJoin(' ', Value.Select(x =>
            {
                switch (x)
                {
                    case Null:
                        requiresSuffix = false;
                        return "0n";
                    case NegativeInfinity:
                        requiresSuffix = false;
                        return "-0w";
                    case PositiveInfinity:
                        requiresSuffix = false;
                        return "0w";
                    default:
                        requiresSuffix &= Math.Abs(x - (int)x) < double.Epsilon;
                        return $"{x}";
                }
            }));
            if (requiresSuffix)
            {
                stringBuilder.Append('f');
            }
            return stringBuilder.ToString();
        }
    }
}
