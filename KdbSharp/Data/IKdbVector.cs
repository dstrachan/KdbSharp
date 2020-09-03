namespace KdbSharp.Data
{
    public interface IKdbVector<T> : IKdbType where T : notnull
    {
        public T[] Value { get; }
    }
}
