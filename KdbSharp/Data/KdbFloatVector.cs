namespace KdbSharp.Data
{
    public class KdbFloatVector : IKdbVector<double>
    {
        public KdbType Type => KdbType.FloatVector;

        public double[] Value { get; }

        public KdbFloatVector(double[] value)
        {
            Value = value;
        }
    }
}
