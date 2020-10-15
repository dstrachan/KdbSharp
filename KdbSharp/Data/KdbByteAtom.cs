﻿namespace KdbSharp.Data
{
    public class KdbByteAtom : BaseByteAtom
    {
        public override KdbType Type => KdbType.ByteAtom;

        public KdbByteAtom(byte value) : base(value)
        {
        }

        public override string ToString() => $"0x{Value:x2}";
    }
}
