using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbByteAtomTests
    {
        private readonly KdbByteAtomWrapper _zero = new KdbByteAtomWrapper(0);
        private readonly KdbByteAtomWrapper _ff = new KdbByteAtomWrapper(255);

        [TestMethod]
        public void TypeIsByteAtom() => Assert.AreEqual(KdbType.ByteAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsByte() => Assert.AreEqual(typeof(byte), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("0x00", _zero.ToString());
            Assert.AreEqual("0xff", _ff.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect()
        {
            CollectionAssert.AreEqual(new[] { _zero.Value }, _zero.ValueBytes);
            CollectionAssert.AreEqual(new[] { _ff.Value }, _ff.ValueBytes);
        }

        [TestMethod]
        public void SerializedLengthIsCorrect()
        {
            Assert.AreEqual(10, _zero.SerializedLengthWrapper);
            Assert.AreEqual(10, _ff.SerializedLengthWrapper);
        }
    }

    public class KdbByteAtomWrapper : KdbByteAtom
    {
        public int SerializedLengthWrapper => SerializedLength;

        public KdbByteAtomWrapper(byte value) : base(value)
        {
        }
    }
}
