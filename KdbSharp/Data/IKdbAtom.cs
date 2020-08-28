namespace KdbSharp.Data
{
    public interface IKdbAtom<T> : IKdbType where T : struct
    {
        public T Value { get; }
    }
}
