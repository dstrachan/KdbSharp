namespace KdbSharp.Data
{
    public class KdbRealVector : BaseFloatVector
    {
        public override KdbType Type => KdbType.RealVector;

        public KdbRealVector(float[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }
    }
}
