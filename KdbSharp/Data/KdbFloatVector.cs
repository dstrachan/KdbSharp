namespace KdbSharp.Data
{
    public class KdbFloatVector : BaseDoubleVector
    {
        public override KdbType Type => KdbType.FloatVector;

        public KdbFloatVector(double[] value) : base(value)
        {
        }
    }
}
