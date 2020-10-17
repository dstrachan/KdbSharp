using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KdbSharp.Data.BaseIntAtom;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbMinuteAtomTests
    {
        private readonly KdbMinuteAtom _zero = new KdbMinuteAtom(0);
        private readonly KdbMinuteAtom _null = new KdbMinuteAtom(Null);
        private readonly KdbMinuteAtom _negativeInfinity = new KdbMinuteAtom(NegativeInfinity);
        private readonly KdbMinuteAtom _positiveInfinity = new KdbMinuteAtom(PositiveInfinity);

        [TestMethod]
        public void TypeIsMinuteAtom() => Assert.AreEqual(KdbType.MinuteAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsInt() => Assert.AreEqual(typeof(int), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("00:00", _zero.ToString());
            Assert.AreEqual("0Nu", _null.ToString());
            Assert.AreEqual("-0Wu", _negativeInfinity.ToString());
            Assert.AreEqual("0Wu", _positiveInfinity.ToString());
        }
    }
}
