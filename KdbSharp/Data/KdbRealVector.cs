namespace KdbSharp.Data
{
    public class KdbRealVector : IKdbVector<float>
    {
        public KdbType Type => KdbType.RealVector;

        public float[] Value { get; }

        public KdbRealVector(float[] value)
        {
            Value = value;
        }
    }
}
