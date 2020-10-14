using KdbSharp.IPC;
using System;
using System.Linq;
using System.Text;

namespace KdbSharp.Data
{
    public abstract class BaseVector<T> : IKdbVector<T> where T : notnull
    {
        public T[] Value { get; }

        public KdbAttribute Attribute { get; }

        public abstract KdbType Type { get; }

        protected int SerializedLength => 14 + ValueBytes.Length;
        protected abstract byte[] ValueBytes { get; }

        protected BaseVector(T[] value)
        {
            Value = value;
        }

        public virtual byte[] Serialize(KdbMessageType messageType)
        {
            var lengthBytes = BitConverter.GetBytes(SerializedLength);
            var vectorLengthBytes = BitConverter.GetBytes(Value.Length);

            var result = new byte[SerializedLength];
            result[0] = 1;
            result[1] = (byte)messageType;
            Buffer.BlockCopy(lengthBytes, 0, result, 4, 4);
            result[8] = (byte)Type;
            result[9] = (byte)Attribute;
            Buffer.BlockCopy(vectorLengthBytes, 0, result, 10, 4);
            Buffer.BlockCopy(ValueBytes, 0, result, 14, ValueBytes.Length);

            return result;
        }
    }

    public abstract class BaseByteVector : BaseVector<byte>
    {
        protected override byte[] ValueBytes => Value;

        protected BaseByteVector(byte[] value) : base(value)
        {
        }
    }

    public abstract class BaseShortVector : BaseVector<short>
    {
        protected override byte[] ValueBytes
        {
            get
            {
                var result = new byte[Value.Length * sizeof(short)];
                Buffer.BlockCopy(Value, 0, result, 0, Value.Length);
                return result;
            }
        }

        protected BaseShortVector(short[] value) : base(value)
        {
        }
    }

    public abstract class BaseIntVector : BaseVector<int>
    {
        protected override byte[] ValueBytes
        {
            get
            {
                var result = new byte[Value.Length * sizeof(int)];
                Buffer.BlockCopy(Value, 0, result, 0, Value.Length);
                return result;
            }
        }

        protected BaseIntVector(int[] value) : base(value)
        {
        }
    }

    public abstract class BaseLongVector : BaseVector<long>
    {
        protected override byte[] ValueBytes
        {
            get
            {
                var result = new byte[Value.Length * sizeof(long)];
                Buffer.BlockCopy(Value, 0, result, 0, Value.Length);
                return result;
            }
        }

        protected BaseLongVector(long[] value) : base(value)
        {
        }
    }

    public abstract class BaseFloatVector : BaseVector<float>
    {
        protected override byte[] ValueBytes
        {
            get
            {
                var result = new byte[Value.Length * sizeof(float)];
                Buffer.BlockCopy(Value, 0, result, 0, Value.Length);
                return result;
            }
        }

        protected BaseFloatVector(float[] value) : base(value)
        {
        }
    }

    public abstract class BaseDoubleVector : BaseVector<double>
    {
        protected override byte[] ValueBytes
        {
            get
            {
                var result = new byte[Value.Length * sizeof(double)];
                Buffer.BlockCopy(Value, 0, result, 0, Value.Length);
                return result;
            }
        }

        protected BaseDoubleVector(double[] value) : base(value)
        {
        }
    }

    public abstract class BaseCharVector : BaseVector<char>
    {
        protected override byte[] ValueBytes => Encoding.ASCII.GetBytes(Value);

        protected BaseCharVector(char[] value) : base(value)
        {
        }
    }

    public abstract class BaseStringVector : BaseVector<string>
    {
        protected override byte[] ValueBytes => Value.SelectMany(x => Encoding.ASCII.GetBytes(x)).ToArray();

        protected BaseStringVector(string[] value) : base(value)
        {
        }
    }
}
