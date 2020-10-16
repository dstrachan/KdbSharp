using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbBoolVectorTests
    {
        private readonly KdbBoolVector _empty = new KdbBoolVector(Array.Empty<byte>());
        private readonly KdbBoolVector _single = new KdbBoolVector(new byte[] { 0 });
        private readonly KdbBoolVector _many = new KdbBoolVector(new byte[] { 0, 1, 1, 0 });

        [TestMethod]
        public void TypeIsBoolVector() => Assert.AreEqual(KdbType.BoolVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsByteArray() => Assert.AreEqual(typeof(byte[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`bool$()", _empty.ToString());
            Assert.AreEqual(",0b", _single.ToString());
            Assert.AreEqual("0110b", _many.ToString());
        }
    }
}
