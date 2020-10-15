using System;

namespace KdbSharp.Data
{
    public class KdbGuidAtom : BaseGuidAtom
    {
        public override KdbType Type => KdbType.GuidAtom;

        public KdbGuidAtom(Guid value) : base(value)
        {
        }
    }
}
