using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbFloatAtomTests
    {
        private readonly KdbFloatAtomWrapper _zero = new KdbFloatAtomWrapper(0);
        private readonly KdbFloatAtomWrapper _null = new KdbFloatAtomWrapper(BaseDoubleAtom.Null);
        private readonly KdbFloatAtomWrapper _negativeInfinity = new KdbFloatAtomWrapper(BaseDoubleAtom.NegativeInfinity);
        private readonly KdbFloatAtomWrapper _positiveInfinity = new KdbFloatAtomWrapper(BaseDoubleAtom.PositiveInfinity);

        [TestMethod]
        public void TypeIsFloatAtom() => Assert.AreEqual(KdbType.FloatAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsDouble() => Assert.AreEqual(typeof(double), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("0f", _zero.ToString());
            Assert.AreEqual("0n", _null.ToString());
            Assert.AreEqual("-0w", _negativeInfinity.ToString());
            Assert.AreEqual("0w", _positiveInfinity.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect() => CollectionAssert.AreEqual(BitConverter.GetBytes(_zero.Value), _zero.ValueBytes);

        [TestMethod]
        public void SerializedLengthIsCorrect() => Assert.AreEqual(17, _zero.SerializedLengthWrapper);
    }

    public class KdbFloatAtomWrapper : KdbFloatAtom
    {
        public int SerializedLengthWrapper => SerializedLength;

        public KdbFloatAtomWrapper(double value) : base(value)
        {
        }
    }
}
