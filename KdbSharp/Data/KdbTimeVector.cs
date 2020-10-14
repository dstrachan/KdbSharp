namespace KdbSharp.Data
{
    public class KdbTimeVector : BaseIntVector
    {
        public override KdbType Type => KdbType.TimeVector;

        public KdbTimeVector(int[] value) : base(value)
        {
        }
    }
}
