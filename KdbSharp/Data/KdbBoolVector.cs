namespace KdbSharp.Data
{
    public class KdbBoolVector : BaseByteVector
    {
        public override KdbType Type => KdbType.BoolVector;

        public KdbBoolVector(byte[] value) : base(value)
        {
        }
    }
}
