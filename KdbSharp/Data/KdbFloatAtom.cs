namespace KdbSharp.Data
{
    public class KdbFloatAtom : IKdbAtom<double>
    {
        public KdbType Type => KdbType.FloatAtom;

        public double Value { get; }

        public KdbFloatAtom(double value)
        {
            Value = value;
        }
    }
}
