using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static KdbSharp.Data.BaseStringVector;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbSymbolVectorTests
    {
        private readonly KdbSymbolVector _empty = new KdbSymbolVector(Array.Empty<string>());
        private readonly KdbSymbolVector _single = new KdbSymbolVector(new[] { "a" });
        private readonly KdbSymbolVector _many = new KdbSymbolVector(new[] { "a", "b", "test", Null });

        [TestMethod]
        public void TypeIsSymbolVector() => Assert.AreEqual(KdbType.SymbolVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsStringArray() => Assert.AreEqual(typeof(string[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`symbol$()", _empty.ToString());
            Assert.AreEqual(",`a", _single.ToString());
            Assert.AreEqual("`a`b`test`", _many.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect()
        {
            CollectionAssert.AreEqual(Array.Empty<byte>(), _empty.ValueBytes);
            CollectionAssert.AreEqual(_single.Value.SelectMany(x => x.Select(y => (byte)y).ToArray()).ToArray(), _single.ValueBytes);
            CollectionAssert.AreEqual(_many.Value.SelectMany(x => x.Select(y => (byte)y).ToArray()).ToArray(), _many.ValueBytes);
        }
    }
}
