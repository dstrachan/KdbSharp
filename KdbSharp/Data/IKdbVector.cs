namespace KdbSharp.Data
{
    public interface IKdbVector<T> : IKdbType where T : struct
    {
        public T[] Value { get; }
    }
}
