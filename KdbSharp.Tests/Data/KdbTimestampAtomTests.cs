using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbTimestampAtomTests
    {
        private readonly KdbTimestampAtom _zero = new KdbTimestampAtom(0);
        private readonly KdbTimestampAtom _null = new KdbTimestampAtom(BaseLongAtom.Null);
        private readonly KdbTimestampAtom _negativeInfinity = new KdbTimestampAtom(BaseLongAtom.NegativeInfinity);
        private readonly KdbTimestampAtom _positiveInfinity = new KdbTimestampAtom(BaseLongAtom.PositiveInfinity);

        [TestMethod]
        public void TypeIsTimestampAtom() => Assert.AreEqual(KdbType.TimestampAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsLong() => Assert.AreEqual(typeof(long), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("2000.01.01D00:00:00.000000000", _zero.ToString());
            Assert.AreEqual("0Np", _null.ToString());
            Assert.AreEqual("-0Wp", _negativeInfinity.ToString());
            Assert.AreEqual("0Wp", _positiveInfinity.ToString());
        }
    }
}
