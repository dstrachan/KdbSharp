using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KdbSharp.Data.BaseIntAtom;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbDateAtomTests
    {
        private readonly KdbDateAtom _zero = new KdbDateAtom(0);
        private readonly KdbDateAtom _null = new KdbDateAtom(Null);
        private readonly KdbDateAtom _negativeInfinity = new KdbDateAtom(NegativeInfinity);
        private readonly KdbDateAtom _positiveInfinity = new KdbDateAtom(PositiveInfinity);

        [TestMethod]
        public void TypeIsDateAtom() => Assert.AreEqual(KdbType.DateAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsInt() => Assert.AreEqual(typeof(int), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("2000.01.01", _zero.ToString());
            Assert.AreEqual("0Nd", _null.ToString());
            Assert.AreEqual("-0Wd", _negativeInfinity.ToString());
            Assert.AreEqual("0Wd", _positiveInfinity.ToString());
        }
    }
}
