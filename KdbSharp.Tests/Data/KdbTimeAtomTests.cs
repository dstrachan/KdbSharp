using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KdbSharp.Data.BaseIntAtom;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbTimeAtomTests
    {
        private readonly KdbTimeAtom _zero = new KdbTimeAtom(0);
        private readonly KdbTimeAtom _null = new KdbTimeAtom(Null);
        private readonly KdbTimeAtom _negativeInfinity = new KdbTimeAtom(NegativeInfinity);
        private readonly KdbTimeAtom _positiveInfinity = new KdbTimeAtom(PositiveInfinity);

        [TestMethod]
        public void TypeIsTimeAtom() => Assert.AreEqual(KdbType.TimeAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsInt() => Assert.AreEqual(typeof(int), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("00:00:00.000", _zero.ToString());
            Assert.AreEqual("0Nt", _null.ToString());
            Assert.AreEqual("-0Wt", _negativeInfinity.ToString());
            Assert.AreEqual("0Wt", _positiveInfinity.ToString());
        }
    }
}
