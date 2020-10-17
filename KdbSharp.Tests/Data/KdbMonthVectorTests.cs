using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KdbSharp.Data.BaseIntVector;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbMonthVectorTests
    {
        private readonly KdbMonthVector _empty = new KdbMonthVector(Array.Empty<int>());
        private readonly KdbMonthVector _single = new KdbMonthVector(new[] { 0 });
        private readonly KdbMonthVector _many = new KdbMonthVector(new[] { 0, Null, NegativeInfinity, PositiveInfinity });

        [TestMethod]
        public void TypeIsMonthVector() => Assert.AreEqual(KdbType.MonthVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsIntArray() => Assert.AreEqual(typeof(int[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`month$()", _empty.ToString());
            Assert.AreEqual(",2000.01m", _single.ToString());
            Assert.AreEqual("2000.01 0N -0W 0Wm", _many.ToString());
        }
    }
}
