using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KdbSharp.Data.BaseShortAtom;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbShortAtomTests
    {
        private readonly KdbShortAtomWrapper _zero = new KdbShortAtomWrapper(0);
        private readonly KdbShortAtomWrapper _null = new KdbShortAtomWrapper(Null);
        private readonly KdbShortAtomWrapper _negativeInfinity = new KdbShortAtomWrapper(NegativeInfinity);
        private readonly KdbShortAtomWrapper _positiveInfinity = new KdbShortAtomWrapper(PositiveInfinity);

        [TestMethod]
        public void TypeIsShortAtom() => Assert.AreEqual(KdbType.ShortAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsShort() => Assert.AreEqual(typeof(short), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("0h", _zero.ToString());
            Assert.AreEqual("0Nh", _null.ToString());
            Assert.AreEqual("-0Wh", _negativeInfinity.ToString());
            Assert.AreEqual("0Wh", _positiveInfinity.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect() => CollectionAssert.AreEqual(BitConverter.GetBytes(_zero.Value), _zero.ValueBytes);

        [TestMethod]
        public void SerializedLengthIsCorrect() => Assert.AreEqual(11, _zero.SerializedLengthWrapper);
    }

    public class KdbShortAtomWrapper : KdbShortAtom
    {
        public int SerializedLengthWrapper => SerializedLength;

        public KdbShortAtomWrapper(short value) : base(value)
        {
        }
    }
}
