namespace KdbSharp.Data
{
    public class KdbIntVector : BaseIntVector
    {
        public override KdbType Type => KdbType.IntVector;

        public KdbIntVector(int[] value) : base(value)
        {
        }
    }
}
