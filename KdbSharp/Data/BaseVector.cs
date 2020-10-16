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

        public abstract override string ToString();

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
            result[0] = (byte)KdbEndianness.LittleEndian;
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
        public static readonly Guid Null = Guid.Empty;

        public override byte[] ValueBytes => Value.SelectMany(x => x.ToKdbGuidBytes()).ToArray();

        protected BaseGuidVector(Guid[] value, KdbAttribute attribute) : base(value, attribute)
        {
        }
    }

    public abstract class BaseShortVector : BaseVector<short>
    {
        public const short Null = short.MinValue;
        public const short NegativeInfinity = short.MinValue + 1;
        public const short PositiveInfinity = short.MaxValue;

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
        public const int Null = int.MinValue;
        public const int NegativeInfinity = int.MinValue + 1;
        public const int PositiveInfinity = int.MaxValue;

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
        public const long Null = long.MinValue;
        public const long NegativeInfinity = long.MinValue + 1;
        public const long PositiveInfinity = long.MaxValue;

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
        public const float Null = float.NaN;
        public const float NegativeInfinity = float.NegativeInfinity;
        public const float PositiveInfinity = float.PositiveInfinity;

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
        public const double Null = double.NaN;
        public const double NegativeInfinity = double.NegativeInfinity;
        public const double PositiveInfinity = double.PositiveInfinity;

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
        public const char Null = ' ';

        public override byte[] ValueBytes => Encoding.ASCII.GetBytes(Value);

        protected BaseCharVector(char[] value, KdbAttribute attribute) : base(value, attribute)
        {
        }
    }

    public abstract class BaseStringVector : BaseVector<string>
    {
        public const string Null = "";

        public override byte[] ValueBytes => Value.SelectMany(x => Encoding.ASCII.GetBytes(x)).ToArray();

        protected BaseStringVector(string[] value, KdbAttribute attribute) : base(value, attribute)
        {
        }
    }
}
