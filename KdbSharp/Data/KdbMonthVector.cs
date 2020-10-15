namespace KdbSharp.Data
{
    public class KdbMonthVector : BaseIntVector
    {
        public override KdbType Type => KdbType.MonthVector;

        public KdbMonthVector(int[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }
    }
}
