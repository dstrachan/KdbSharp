using KdbSharp.IPC;
using System;
using System.Text;

namespace KdbSharp.Data
{
    public abstract class BaseAtom<T> : IKdbAtom<T> where T : notnull
    {
        public T Value { get; }

        public abstract KdbType Type { get; }
        public abstract byte[] ValueBytes { get; }

        protected abstract int SerializedLength { get; }

        protected BaseAtom(T value)
        {
            Value = value;
        }

        public virtual byte[] Serialize(KdbMessageType messageType)
        {
            var lengthBytes = BitConverter.GetBytes(SerializedLength);

            var result = new byte[SerializedLength];
            result[0] = 1;
            result[1] = (byte)messageType;
            Buffer.BlockCopy(lengthBytes, 0, result, 4, 4);
            result[8] = (byte)Type;
            Buffer.BlockCopy(ValueBytes, 0, result, 9, ValueBytes.Length);

            return result;
        }
    }

    public abstract class BaseByteAtom : BaseAtom<byte>
    {
        public override byte[] ValueBytes => new byte[] { Value };
        protected override int SerializedLength => 10;

        protected BaseByteAtom(byte value) : base(value)
        {
        }
    }

    public abstract class BaseGuidAtom : BaseAtom<Guid>
    {
        public override byte[] ValueBytes => Value.ToKdbGuidBytes();
        protected override int SerializedLength => 25;

        protected BaseGuidAtom(Guid value) : base(value)
        {
        }
    }

    public abstract class BaseShortAtom : BaseAtom<short>
    {
        public override byte[] ValueBytes => BitConverter.GetBytes(Value);
        protected override int SerializedLength => 11;

        protected BaseShortAtom(short value) : base(value)
        {
        }
    }

    public abstract class BaseIntAtom : BaseAtom<int>
    {
        public override byte[] ValueBytes => BitConverter.GetBytes(Value);
        protected override int SerializedLength => 13;

        protected BaseIntAtom(int value) : base(value)
        {
        }
    }

    public abstract class BaseLongAtom : BaseAtom<long>
    {
        public override byte[] ValueBytes => BitConverter.GetBytes(Value);
        protected override int SerializedLength => 17;

        protected BaseLongAtom(long value) : base(value)
        {
        }
    }

    public abstract class BaseFloatAtom : BaseAtom<float>
    {
        public override byte[] ValueBytes => BitConverter.GetBytes(Value);
        protected override int SerializedLength => 13;

        protected BaseFloatAtom(float value) : base(value)
        {
        }
    }

    public abstract class BaseDoubleAtom : BaseAtom<double>
    {
        public override byte[] ValueBytes => BitConverter.GetBytes(Value);
        protected override int SerializedLength => 17;

        protected BaseDoubleAtom(double value) : base(value)
        {
        }
    }

    public abstract class BaseCharAtom : BaseAtom<char>
    {
        public override byte[] ValueBytes => BitConverter.GetBytes(Value);
        protected override int SerializedLength => 11;

        protected BaseCharAtom(char value) : base(value)
        {
        }
    }

    public abstract class BaseStringAtom : BaseAtom<string>
    {
        public override byte[] ValueBytes => Encoding.ASCII.GetBytes(Value);
        protected override int SerializedLength => 9 + Encoding.ASCII.GetByteCount(Value);

        protected BaseStringAtom(string value) : base(value)
        {
        }
    }
}
