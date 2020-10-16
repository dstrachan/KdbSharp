using KdbSharp.Data;
using KdbSharp.IPC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static KdbSharp.Data.BaseLongVector;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbLongVectorTests
    {
        private readonly KdbLongVectorWrapper _empty = new KdbLongVectorWrapper(Array.Empty<long>());
        private readonly KdbLongVectorWrapper _single = new KdbLongVectorWrapper(new long[] { 0 });
        private readonly KdbLongVectorWrapper _many = new KdbLongVectorWrapper(new[] { 0, Null, NegativeInfinity, PositiveInfinity });

        [TestMethod]
        public void TypeIsLongVector() => Assert.AreEqual(KdbType.LongVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsLongArray() => Assert.AreEqual(typeof(long[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`long$()", _empty.ToString());
            Assert.AreEqual(",0", _single.ToString());
            Assert.AreEqual("0 0N -0W 0W", _many.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect()
        {
            CollectionAssert.AreEqual(Array.Empty<byte>(), _empty.ValueBytes);
            CollectionAssert.AreEqual(_single.Value.SelectMany(x => BitConverter.GetBytes(x)).ToArray(), _single.ValueBytes);
            CollectionAssert.AreEqual(_many.Value.SelectMany(x => BitConverter.GetBytes(x)).ToArray(), _many.ValueBytes);
        }

        [TestMethod]
        public void SerializedLengthIsCorrect() => Assert.AreEqual(14 + (_empty.Value.Length * sizeof(long)), _empty.SerializedLengthWrapper);

        [TestMethod]
        public void SerializeIsCorrect()
        {
            var expected = new byte[]
            {
                (byte)KdbEndianness.LittleEndian, // Encoding architecture
                (byte)KdbMessageType.Async, // Message type
                0, 0, // Compression
                (byte)(14 + (_empty.Value.Length * sizeof(long))), 0, 0, 0, // Message length
                (byte)KdbType.LongVector, // Type
                (byte)KdbAttribute.None, // Attribute
                (byte)_empty.Value.Length, 0, 0, 0, // Vector length
            };
            CollectionAssert.AreEqual(expected, _empty.Serialize(KdbMessageType.Async));
            expected[1] = (byte)KdbMessageType.Sync;
            CollectionAssert.AreEqual(expected, _empty.Serialize(KdbMessageType.Sync));
            expected[1] = (byte)KdbMessageType.Response;
            CollectionAssert.AreEqual(expected, _empty.Serialize(KdbMessageType.Response));
        }
    }

    public class KdbLongVectorWrapper : KdbLongVector
    {
        public int SerializedLengthWrapper => SerializedLength;

        public KdbLongVectorWrapper(long[] value, KdbAttribute attribute = KdbAttribute.None) : base(value, attribute)
        {
        }
    }
}
