namespace KdbSharp.Data
{
    public class KdbFloatVector : BaseDoubleVector
    {
        public override KdbType Type => KdbType.FloatVector;

        public KdbFloatVector(double[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }
    }
}
