namespace KdbSharp.Data
{
    public class KdbDatetimeVector : IKdbVector<double>
    {
        public KdbType Type => KdbType.DatetimeVector;

        public double[] Value { get; }

        public KdbDatetimeVector(double[] value)
        {
            Value = value;
        }
    }
}
