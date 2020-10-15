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

        //public abstract override string ToString();

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
        public static readonly Guid Null = Guid.Empty;

        public override byte[] ValueBytes => Value.ToKdbGuidBytes();
        protected override int SerializedLength => 25;

        protected BaseGuidAtom(Guid value) : base(value)
        {
        }
    }

    public abstract class BaseShortAtom : BaseAtom<short>
    {
        public const short Null = short.MinValue;
        public const short NegativeInfinity = short.MinValue + 1;
        public const short PositiveInfinity = short.MaxValue;

        public override byte[] ValueBytes => BitConverter.GetBytes(Value);
        protected override int SerializedLength => 11;

        protected BaseShortAtom(short value) : base(value)
        {
        }
    }

    public abstract class BaseIntAtom : BaseAtom<int>
    {
        public const int Null = int.MinValue;
        public const int NegativeInfinity = int.MinValue + 1;
        public const int PositiveInfinity = int.MaxValue;

        public override byte[] ValueBytes => BitConverter.GetBytes(Value);
        protected override int SerializedLength => 13;

        protected BaseIntAtom(int value) : base(value)
        {
        }
    }

    public abstract class BaseLongAtom : BaseAtom<long>
    {
        public const long Null = long.MinValue;
        public const long NegativeInfinity = long.MinValue + 1;
        public const long PositiveInfinity = long.MaxValue;

        public override byte[] ValueBytes => BitConverter.GetBytes(Value);
        protected override int SerializedLength => 17;

        protected BaseLongAtom(long value) : base(value)
        {
        }
    }

    public abstract class BaseFloatAtom : BaseAtom<float>
    {
        public const float Null = float.NaN;
        public const float NegativeInfinity = float.NegativeInfinity;
        public const float PositiveInfinity = float.PositiveInfinity;

        public override byte[] ValueBytes => BitConverter.GetBytes(Value);
        protected override int SerializedLength => 13;

        protected BaseFloatAtom(float value) : base(value)
        {
        }
    }

    public abstract class BaseDoubleAtom : BaseAtom<double>
    {
        public const double Null = double.NaN;
        public const double NegativeInfinity = double.NegativeInfinity;
        public const double PositiveInfinity = double.PositiveInfinity;

        public override byte[] ValueBytes => BitConverter.GetBytes(Value);
        protected override int SerializedLength => 17;

        protected BaseDoubleAtom(double value) : base(value)
        {
        }
    }

    public abstract class BaseCharAtom : BaseAtom<char>
    {
        public const char Null = ' ';

        public override byte[] ValueBytes => BitConverter.GetBytes(Value);
        protected override int SerializedLength => 11;

        protected BaseCharAtom(char value) : base(value)
        {
        }
    }

    public abstract class BaseStringAtom : BaseAtom<string>
    {
        public const string Null = "";

        public override byte[] ValueBytes => Encoding.ASCII.GetBytes(Value);
        protected override int SerializedLength => 9 + Encoding.ASCII.GetByteCount(Value);

        protected BaseStringAtom(string value) : base(value)
        {
        }
    }
}
