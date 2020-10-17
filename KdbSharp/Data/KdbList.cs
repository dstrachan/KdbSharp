using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public class KdbList : BaseVector<IKdbType>
    {
        public override KdbType Type => KdbType.List;

        public override byte[] ValueBytes => Value.SelectMany(x => x.ValueBytes).ToArray();

        public KdbList(IKdbType[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder(Value.Length == 1 ? "," : "(");
            stringBuilder.AppendJoin<IKdbType>(';', Value);
            if (Value.Length != 1)
            {
                stringBuilder.Append(')');
            }
            return stringBuilder.ToString();
        }
    }
}
