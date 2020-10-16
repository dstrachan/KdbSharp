using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbByteVectorTests
    {
        private readonly KdbByteVector _empty = new KdbByteVector(Array.Empty<byte>());
        private readonly KdbByteVector _single = new KdbByteVector(new byte[] { 0 });
        private readonly KdbByteVector _many = new KdbByteVector(new byte[] { 0, 1, 254, 255 });

        [TestMethod]
        public void TypeIsByteVector() => Assert.AreEqual(KdbType.ByteVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsByteArray() => Assert.AreEqual(typeof(byte[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`byte$()", _empty.ToString());
            Assert.AreEqual(",0x00", _single.ToString());
            Assert.AreEqual("0x0001feff", _many.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect()
        {
            CollectionAssert.AreEqual(_empty.Value, _empty.ValueBytes);
            CollectionAssert.AreEqual(_single.Value, _single.ValueBytes);
            CollectionAssert.AreEqual(_many.Value, _many.ValueBytes);
        }
    }
}
