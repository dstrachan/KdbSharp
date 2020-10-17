using System;

namespace KdbSharp.Data
{
    public class KdbFloatAtom : BaseDoubleAtom
    {
        public override KdbType Type => KdbType.FloatAtom;

        public KdbFloatAtom(double value) : base(value)
        {
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Null:
                    return "0n";
                case NegativeInfinity:
                    return "-0w";
                case PositiveInfinity:
                    return "0w";
                default:
                    return Math.Abs(Value - (int)Value) < double.Epsilon ? $"{Value}f" : $"{Value}";
            }
        }
    }
}
