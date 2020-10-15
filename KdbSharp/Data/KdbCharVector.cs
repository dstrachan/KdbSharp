namespace KdbSharp.Data
{
    public class KdbCharVector : BaseCharVector
    {
        public override KdbType Type => KdbType.CharVector;

        public KdbCharVector(char[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }
    }
}
