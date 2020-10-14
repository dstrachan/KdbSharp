using KdbSharp.IPC;
using System;
using System.Text;

namespace KdbSharp.Data
{
    public abstract class BaseAtom<T> : IKdbAtom<T> where T : notnull
    {
        public T Value { get; }

        public abstract KdbType Type { get; }

        protected abstract int SerializedLength { get; }
        protected abstract byte[] ValueBytes { get; }

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
        protected override int SerializedLength => 10;
        protected override byte[] ValueBytes => new byte[] { Value };

        protected BaseByteAtom(byte value) : base(value)
        {
        }
    }

    public abstract class BaseShortAtom : BaseAtom<short>
    {
        protected override int SerializedLength => 11;
        protected override byte[] ValueBytes => BitConverter.GetBytes(Value);

        protected BaseShortAtom(short value) : base(value)
        {
        }
    }

    public abstract class BaseIntAtom : BaseAtom<int>
    {
        protected override int SerializedLength => 13;
        protected override byte[] ValueBytes => BitConverter.GetBytes(Value);

        protected BaseIntAtom(int value) : base(value)
        {
        }
    }

    public abstract class BaseLongAtom : BaseAtom<long>
    {
        protected override int SerializedLength => 17;
        protected override byte[] ValueBytes => BitConverter.GetBytes(Value);

        protected BaseLongAtom(long value) : base(value)
        {
        }
    }

    public abstract class BaseFloatAtom : BaseAtom<float>
    {
        protected override int SerializedLength => 13;
        protected override byte[] ValueBytes => BitConverter.GetBytes(Value);

        protected BaseFloatAtom(float value) : base(value)
        {
        }
    }

    public abstract class BaseDoubleAtom : BaseAtom<double>
    {
        protected override int SerializedLength => 17;
        protected override byte[] ValueBytes => BitConverter.GetBytes(Value);

        protected BaseDoubleAtom(double value) : base(value)
        {
        }
    }

    public abstract class BaseCharAtom : BaseAtom<char>
    {
        protected override int SerializedLength => 11;
        protected override byte[] ValueBytes => BitConverter.GetBytes(Value);

        protected BaseCharAtom(char value) : base(value)
        {
        }
    }

    public abstract class BaseStringAtom : BaseAtom<string>
    {
        protected override int SerializedLength => 9 + Encoding.ASCII.GetByteCount(Value);
        protected override byte[] ValueBytes => Encoding.ASCII.GetBytes(Value);

        protected BaseStringAtom(string value) : base(value)
        {
        }
    }
}
