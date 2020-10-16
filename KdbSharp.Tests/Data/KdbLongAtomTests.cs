using KdbSharp.Data;
using KdbSharp.IPC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbLongAtomTests
    {
        private readonly KdbLongAtomWrapper _zero = new KdbLongAtomWrapper(0);
        private readonly KdbLongAtomWrapper _null = new KdbLongAtomWrapper(BaseLongAtom.Null);
        private readonly KdbLongAtomWrapper _negativeInfinity = new KdbLongAtomWrapper(BaseLongAtom.NegativeInfinity);
        private readonly KdbLongAtomWrapper _positiveInfinity = new KdbLongAtomWrapper(BaseLongAtom.PositiveInfinity);

        [TestMethod]
        public void TypeIsLongAtom() => Assert.AreEqual(KdbType.LongAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsLong() => Assert.AreEqual(typeof(long), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("0", _zero.ToString());
            Assert.AreEqual("0N", _null.ToString());
            Assert.AreEqual("-0W", _negativeInfinity.ToString());
            Assert.AreEqual("0W", _positiveInfinity.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect() => CollectionAssert.AreEqual(BitConverter.GetBytes(_zero.Value), _zero.ValueBytes);

        [TestMethod]
        public void SerializedLengthIsCorrect() => Assert.AreEqual(17, _zero.SerializedLengthWrapper);

        [TestMethod]
        public void SerializeIsCorrect()
        {
            var expected = new byte[]
            {
                (byte)KdbEndianness.LittleEndian, // Encoding architecture
                (byte)KdbMessageType.Async, // Message type
                0, 0, // Compression
                17, 0, 0, 0, // Message length
                unchecked((byte)KdbType.LongAtom), // Type
                0, 0, 0, 0, 0, 0, 0, 0, // Value
            };
            CollectionAssert.AreEqual(expected, _zero.Serialize(KdbMessageType.Async));
            expected[1] = (byte)KdbMessageType.Sync;
            CollectionAssert.AreEqual(expected, _zero.Serialize(KdbMessageType.Sync));
            expected[1] = (byte)KdbMessageType.Response;
            CollectionAssert.AreEqual(expected, _zero.Serialize(KdbMessageType.Response));
        }
    }

    public class KdbLongAtomWrapper : KdbLongAtom
    {
        public int SerializedLengthWrapper => SerializedLength;

        public KdbLongAtomWrapper(long value) : base(value)
        {
        }
    }
}
