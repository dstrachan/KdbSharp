namespace KdbSharp.Data
{
    public class KdbByteAtom : IKdbAtom<byte>
    {
        public KdbType Type => KdbType.ByteAtom;

        public byte Value { get; }

        public KdbByteAtom(byte value)
        {
            Value = value;
        }
    }
}
