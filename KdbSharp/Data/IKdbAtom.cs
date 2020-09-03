namespace KdbSharp.Data
{
    public interface IKdbAtom<T> : IKdbType where T : notnull
    {
        public T Value { get; }
    }
}
