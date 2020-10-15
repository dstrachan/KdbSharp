using System;
using System.Linq;

namespace KdbSharp.Data
{
    public class KdbList : BaseVector<IKdbType>
    {
        public override KdbType Type => KdbType.List;

        public override byte[] ValueBytes => Value.SelectMany(x => x.ValueBytes).ToArray();

        public KdbList(IKdbType[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString() => throw new NotImplementedException();
    }
}
