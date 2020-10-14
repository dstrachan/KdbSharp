namespace KdbSharp.Data
{
    public class KdbSecondVector : BaseIntVector
    {
        public override KdbType Type => KdbType.SecondVector;

        public KdbSecondVector(int[] value) : base(value)
        {
        }
    }
}
