namespace KdbSharp.Data
{
    public class KdbDatetimeAtom : IKdbAtom<double>
    {
        public KdbType Type => KdbType.DatetimeAtom;

        public double Value { get; }

        public KdbDatetimeAtom(double value)
        {
            Value = value;
        }
    }
}
