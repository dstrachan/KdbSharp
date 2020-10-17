using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static KdbSharp.Data.BaseStringAtom;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbSymbolAtomTests
    {
        private readonly KdbSymbolAtomWrapper _null = new KdbSymbolAtomWrapper(Null);
        private readonly KdbSymbolAtomWrapper _notNull = new KdbSymbolAtomWrapper("a");

        [TestMethod]
        public void TypeIsSymbolAtom() => Assert.AreEqual(KdbType.SymbolAtom, _null.Type);

        [TestMethod]
        public void ValueTypeIsString() => Assert.AreEqual(typeof(string), _null.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`", _null.ToString());
            Assert.AreEqual("`a", _notNull.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect()
        {
            CollectionAssert.AreEqual(Array.Empty<byte>(), _null.ValueBytes);
            CollectionAssert.AreEqual(_notNull.Value.Select(x => (byte)x).ToArray(), _notNull.ValueBytes);
        }

        [TestMethod]
        public void SerializedLengthIsCorrect()
        {
            Assert.AreEqual(_null.Value.Length + 9, _null.SerializedLengthWrapper);
            Assert.AreEqual(_notNull.Value.Length + 9, _notNull.SerializedLengthWrapper);
        }
    }

    public class KdbSymbolAtomWrapper : KdbSymbolAtom
    {
        public int SerializedLengthWrapper => SerializedLength;

        public KdbSymbolAtomWrapper(string value) : base(value)
        {
        }
    }
}
