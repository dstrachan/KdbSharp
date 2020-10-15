using KdbSharp.IPC;

namespace KdbSharp.Data
{
    public interface IKdbType
    {
        public KdbType Type { get; }
        public byte[] ValueBytes { get; }

        public byte[] Serialize(KdbMessageType messageType);
    }

    public interface IKdbAtom<T> : IKdbType where T : notnull
    {
        public T Value { get; }
    }

    public interface IKdbVector<T> : IKdbType where T : notnull
    {
        public T[] Value { get; }

        public KdbAttribute Attribute { get; }
    }
}
