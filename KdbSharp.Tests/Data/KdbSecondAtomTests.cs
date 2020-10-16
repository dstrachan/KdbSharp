using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbSecondAtomTests
    {
        private readonly KdbSecondAtom _zero = new KdbSecondAtom(0);
        private readonly KdbSecondAtom _null = new KdbSecondAtom(BaseIntAtom.Null);
        private readonly KdbSecondAtom _negativeInfinity = new KdbSecondAtom(BaseIntAtom.NegativeInfinity);
        private readonly KdbSecondAtom _positiveInfinity = new KdbSecondAtom(BaseIntAtom.PositiveInfinity);

        [TestMethod]
        public void TypeIsSecondAtom() => Assert.AreEqual(KdbType.SecondAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsInt() => Assert.AreEqual(typeof(int), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("00:00:00", _zero.ToString());
            Assert.AreEqual("0Nv", _null.ToString());
            Assert.AreEqual("-0Wv", _negativeInfinity.ToString());
            Assert.AreEqual("0Wv", _positiveInfinity.ToString());
        }
    }
}
