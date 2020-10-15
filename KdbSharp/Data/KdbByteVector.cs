namespace KdbSharp.Data
{
    public class KdbByteVector : BaseByteVector
    {
        public override KdbType Type => KdbType.ByteVector;

        public KdbByteVector(byte[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }
    }
}
