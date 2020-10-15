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
        public abstract byte[] ValueBytes { get; }

        protected int SerializedLength => 14 + ValueBytes.Length;

        protected BaseVector(T[] value, KdbAttribute attribute)
        {
            Value = value;
            Attribute = attribute;
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
        public override byte[] ValueBytes => Value;

        protected BaseByteVector(byte[] value, KdbAttribute attribute) : base(value, attribute)
        {
        }
    }

    public abstract class BaseGuidVector : BaseVector<Guid>
    {
        public override byte[] ValueBytes => Value.SelectMany(x => x.ToKdbGuidBytes()).ToArray();

        protected BaseGuidVector(Guid[] value, KdbAttribute attribute) : base(value, attribute)
        {
        }
    }

    public abstract class BaseShortVector : BaseVector<short>
    {
        public override byte[] ValueBytes
        {
            get
            {
                var result = new byte[Value.Length * sizeof(short)];
                Buffer.BlockCopy(Value, 0, result, 0, Value.Length);
                return result;
            }
        }

        protected BaseShortVector(short[] value, KdbAttribute attribute) : base(value, attribute)
        {
        }
    }

    public abstract class BaseIntVector : BaseVector<int>
    {
        public override byte[] ValueBytes
        {
            get
            {
                var result = new byte[Value.Length * sizeof(int)];
                Buffer.BlockCopy(Value, 0, result, 0, Value.Length);
                return result;
            }
        }

        protected BaseIntVector(int[] value, KdbAttribute attribute) : base(value, attribute)
        {
        }
    }

    public abstract class BaseLongVector : BaseVector<long>
    {
        public override byte[] ValueBytes
        {
            get
            {
                var result = new byte[Value.Length * sizeof(long)];
                Buffer.BlockCopy(Value, 0, result, 0, Value.Length);
                return result;
            }
        }

        protected BaseLongVector(long[] value, KdbAttribute attribute) : base(value, attribute)
        {
        }
    }

    public abstract class BaseFloatVector : BaseVector<float>
    {
        public override byte[] ValueBytes
        {
            get
            {
                var result = new byte[Value.Length * sizeof(float)];
                Buffer.BlockCopy(Value, 0, result, 0, Value.Length);
                return result;
            }
        }

        protected BaseFloatVector(float[] value, KdbAttribute attribute) : base(value, attribute)
        {
        }
    }

    public abstract class BaseDoubleVector : BaseVector<double>
    {
        public override byte[] ValueBytes
        {
            get
            {
                var result = new byte[Value.Length * sizeof(double)];
                Buffer.BlockCopy(Value, 0, result, 0, Value.Length);
                return result;
            }
        }

        protected BaseDoubleVector(double[] value, KdbAttribute attribute) : base(value, attribute)
        {
        }
    }

    public abstract class BaseCharVector : BaseVector<char>
    {
        public override byte[] ValueBytes => Encoding.ASCII.GetBytes(Value);

        protected BaseCharVector(char[] value, KdbAttribute attribute) : base(value, attribute)
        {
        }
    }

    public abstract class BaseStringVector : BaseVector<string>
    {
        public override byte[] ValueBytes => Value.SelectMany(x => Encoding.ASCII.GetBytes(x)).ToArray();

        protected BaseStringVector(string[] value, KdbAttribute attribute) : base(value, attribute)
        {
        }
    }
}
