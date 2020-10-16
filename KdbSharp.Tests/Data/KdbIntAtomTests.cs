using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KdbSharp.Data.BaseIntAtom;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbIntAtomTests
    {
        private readonly KdbIntAtomWrapper _zero = new KdbIntAtomWrapper(0);
        private readonly KdbIntAtomWrapper _null = new KdbIntAtomWrapper(Null);
        private readonly KdbIntAtomWrapper _negativeInfinity = new KdbIntAtomWrapper(NegativeInfinity);
        private readonly KdbIntAtomWrapper _positiveInfinity = new KdbIntAtomWrapper(PositiveInfinity);

        [TestMethod]
        public void TypeIsIntAtom() => Assert.AreEqual(KdbType.IntAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsInt() => Assert.AreEqual(typeof(int), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("0i", _zero.ToString());
            Assert.AreEqual("0Ni", _null.ToString());
            Assert.AreEqual("-0Wi", _negativeInfinity.ToString());
            Assert.AreEqual("0Wi", _positiveInfinity.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect() => CollectionAssert.AreEqual(BitConverter.GetBytes(_zero.Value), _zero.ValueBytes);

        [TestMethod]
        public void SerializedLengthIsCorrect() => Assert.AreEqual(13, _zero.SerializedLengthWrapper);
    }

    public class KdbIntAtomWrapper : KdbIntAtom
    {
        public int SerializedLengthWrapper => SerializedLength;

        public KdbIntAtomWrapper(int value) : base(value)
        {
        }
    }
}
