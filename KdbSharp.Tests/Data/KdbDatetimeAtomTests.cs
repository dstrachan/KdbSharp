using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KdbSharp.Data.BaseDoubleAtom;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbDatetimeAtomTests
    {
        private readonly KdbDatetimeAtom _zero = new KdbDatetimeAtom(0);
        private readonly KdbDatetimeAtom _null = new KdbDatetimeAtom(Null);
        private readonly KdbDatetimeAtom _negativeInfinity = new KdbDatetimeAtom(NegativeInfinity);
        private readonly KdbDatetimeAtom _positiveInfinity = new KdbDatetimeAtom(PositiveInfinity);

        [TestMethod]
        public void TypeIsDatetimeAtom() => Assert.AreEqual(KdbType.DatetimeAtom, _zero.Type);

        [TestMethod]
        public void ValueTypeIsDouble() => Assert.AreEqual(typeof(double), _zero.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("2000.01.01T00:00:00.000", _zero.ToString());
            Assert.AreEqual("0Nz", _null.ToString());
            Assert.AreEqual("-0Wz", _negativeInfinity.ToString());
            Assert.AreEqual("0Wz", _positiveInfinity.ToString());
        }
    }
}
