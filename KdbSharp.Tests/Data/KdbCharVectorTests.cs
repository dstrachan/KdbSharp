using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbCharVectorTests
    {
        private readonly KdbCharVector _empty = new KdbCharVector(Array.Empty<char>());
        private readonly KdbCharVector _single = new KdbCharVector(new[] { 'a' });
        private readonly KdbCharVector _many = new KdbCharVector(new[] { 't', 'e', 's', 't' });

        [TestMethod]
        public void TypeIsCharVector() => Assert.AreEqual(KdbType.CharVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsCharArray() => Assert.AreEqual(typeof(char[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`char$()", _empty.ToString());
            Assert.AreEqual(",\"a\"", _single.ToString());
            Assert.AreEqual("\"test\"", _many.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect()
        {
            CollectionAssert.AreEqual(Array.Empty<byte>(), _empty.ValueBytes);
            CollectionAssert.AreEqual(_single.Value.Select(x => (byte)x).ToArray(), _single.ValueBytes);
            CollectionAssert.AreEqual(_many.Value.Select(x => (byte)x).ToArray(), _many.ValueBytes);
        }
    }
}
