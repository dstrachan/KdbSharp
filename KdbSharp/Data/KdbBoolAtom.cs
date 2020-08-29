namespace KdbSharp.Data
{
    public class KdbBoolAtom : IKdbAtom<byte>
    {
        public KdbType Type => KdbType.BoolAtom;

        public byte Value { get; }

        public KdbBoolAtom(byte value)
        {
            Value = value;
        }
    }
}
