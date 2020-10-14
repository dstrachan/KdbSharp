namespace KdbSharp.Data
{
    public class KdbCharVector : BaseCharVector
    {
        public override KdbType Type => KdbType.CharVector;

        public KdbCharVector(char[] value) : base(value)
        {
        }
    }
}
