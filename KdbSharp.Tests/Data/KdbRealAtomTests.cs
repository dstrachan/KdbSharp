using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KdbSharp.Data.BaseFloatAtom;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbRealAtomTests
    {
        private readonly KdbRealAtomWrapper _zero = new KdbRealAtomWrapper(0);
        private readonly KdbRealAtomWrapper _null = new KdbRealAtomWrapper(Null);
        private readonly KdbRealAtomWrapper _negativeInfinity = new KdbRealAtomWrapper(NegativeInfinity);
        private readonly KdbRealAtomWrapper _positiveInfinity = new KdbRealAtomWrapper(PositiveInfinity);

        [TestMethod]
        public void TypeIsRealAtom() => Assert.AreEqual(KdbType.RealAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsFloat() => Assert.AreEqual(typeof(float), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("0e", _zero.ToString());
            Assert.AreEqual("0Ne", _null.ToString());
            Assert.AreEqual("-0We", _negativeInfinity.ToString());
            Assert.AreEqual("0We", _positiveInfinity.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect() => CollectionAssert.AreEqual(BitConverter.GetBytes(_zero.Value), _zero.ValueBytes);

        [TestMethod]
        public void SerializedLengthIsCorrect() => Assert.AreEqual(13, _zero.SerializedLengthWrapper);
    }

    public class KdbRealAtomWrapper : KdbRealAtom
    {
        public int SerializedLengthWrapper => SerializedLength;

        public KdbRealAtomWrapper(float value) : base(value)
        {
        }
    }
}
