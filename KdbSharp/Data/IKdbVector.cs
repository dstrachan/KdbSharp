namespace KdbSharp.Data
{
    interface IKdbVector<T> : IKdbType where T : struct
    {
        public T[] Value { get; }
    }
}
