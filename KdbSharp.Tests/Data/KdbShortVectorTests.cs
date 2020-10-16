using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbShortVectorTests
    {
        private readonly KdbShortVector _empty = new KdbShortVector(Array.Empty<short>());
        private readonly KdbShortVector _single = new KdbShortVector(new short[] { 0 });
        private readonly KdbShortVector _many = new KdbShortVector(new short[] { 0, BaseShortVector.Null, BaseShortVector.NegativeInfinity, BaseShortVector.PositiveInfinity });

        [TestMethod]
        public void TypeIsShortVector() => Assert.AreEqual(KdbType.ShortVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsShortArray() => Assert.AreEqual(typeof(short[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`short$()", _empty.ToString());
            Assert.AreEqual(",0h", _single.ToString());
            Assert.AreEqual("0 0N -0W 0Wh", _many.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect()
        {
            CollectionAssert.AreEqual(Array.Empty<byte>(), _empty.ValueBytes);
            CollectionAssert.AreEqual(_single.Value.SelectMany(x => BitConverter.GetBytes(x)).ToArray(), _single.ValueBytes);
            CollectionAssert.AreEqual(_many.Value.SelectMany(x => BitConverter.GetBytes(x)).ToArray(), _many.ValueBytes);
        }
    }
}
