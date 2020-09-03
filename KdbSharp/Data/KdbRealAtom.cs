namespace KdbSharp.Data
{
    public class KdbRealAtom : IKdbAtom<float>
    {
        public KdbType Type => KdbType.RealAtom;

        public float Value { get; }

        public KdbRealAtom(float value)
        {
            Value = value;
        }
    }
}
