namespace KdbSharp.Data
{
    public class KdbShortVector : BaseShortVector
    {
        public override KdbType Type => KdbType.ShortVector;

        public KdbShortVector(short[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }
    }
}
