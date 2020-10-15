namespace KdbSharp.Data
{
    public class KdbTimestampAtom : BaseLongAtom
    {
        public override KdbType Type => KdbType.TimestampAtom;

        public KdbTimestampAtom(long value) : base(value)
        {
        }

        public override string ToString() => Value switch
        {
            Null => "0Np",
            NegativeInfinity => "-0Wp",
            PositiveInfinity => "0Wp",
            _ => Value.ToTimestamp().ToString("yyyy.MM.dd'D'HH:mm:ss.ffffff000"),
        };
    }
}
