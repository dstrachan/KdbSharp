using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbTimespanAtomTests
    {
        private readonly KdbTimespanAtom _zero = new KdbTimespanAtom(0);
        private readonly KdbTimespanAtom _null = new KdbTimespanAtom(BaseLongAtom.Null);
        private readonly KdbTimespanAtom _negativeInfinity = new KdbTimespanAtom(BaseLongAtom.NegativeInfinity);
        private readonly KdbTimespanAtom _positiveInfinity = new KdbTimespanAtom(BaseLongAtom.PositiveInfinity);

        [TestMethod]
        public void TypeIsTimespanAtom() => Assert.AreEqual(KdbType.TimespanAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsLong() => Assert.AreEqual(typeof(long), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("0D00:00:00.000000000", _zero.ToString());
            Assert.AreEqual("0Nn", _null.ToString());
            Assert.AreEqual("-0Wn", _negativeInfinity.ToString());
            Assert.AreEqual("0Wn", _positiveInfinity.ToString());
        }
    }
}
