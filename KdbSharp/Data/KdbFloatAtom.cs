using System;

namespace KdbSharp.Data
{
    public class KdbFloatAtom : BaseDoubleAtom
    {
        public override KdbType Type => KdbType.FloatAtom;

        public KdbFloatAtom(double value) : base(value)
        {
        }

        public override string ToString() => Value switch
        {
            Null => "0n",
            NegativeInfinity => "-0w",
            PositiveInfinity => "0w",
            _ => Math.Abs(Value - (int)Value) < double.Epsilon ? $"{Value}f" : $"{Value}",
        };
    }
}
