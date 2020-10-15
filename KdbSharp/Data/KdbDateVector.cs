namespace KdbSharp.Data
{
    public class KdbDateVector : BaseIntVector
    {
        public override KdbType Type => KdbType.DateVector;

        public KdbDateVector(int[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }
    }
}
