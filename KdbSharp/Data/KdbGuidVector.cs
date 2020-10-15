using System;

namespace KdbSharp.Data
{
    public class KdbGuidVector : BaseGuidVector
    {
        public override KdbType Type => KdbType.GuidVector;

        public KdbGuidVector(Guid[] value, KdbAttribute attribute) : base(value, attribute)
        {
        }
    }
}
