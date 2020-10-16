using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbMonthAtomTests
    {
        private readonly KdbMonthAtom _zero = new KdbMonthAtom(0);
        private readonly KdbMonthAtom _null = new KdbMonthAtom(BaseIntAtom.Null);
        private readonly KdbMonthAtom _negativeInfinity = new KdbMonthAtom(BaseIntAtom.NegativeInfinity);
        private readonly KdbMonthAtom _positiveInfinity = new KdbMonthAtom(BaseIntAtom.PositiveInfinity);

        [TestMethod]
        public void TypeIsMonthAtom() => Assert.AreEqual(KdbType.MonthAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsInt() => Assert.AreEqual(typeof(int), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("2000.01m", _zero.ToString());
            Assert.AreEqual("0Nm", _null.ToString());
            Assert.AreEqual("-0Wm", _negativeInfinity.ToString());
            Assert.AreEqual("0Wm", _positiveInfinity.ToString());
        }
    }
}
