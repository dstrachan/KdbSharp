using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KdbSharp.Data.BaseLongVector;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbTimespanVectorTests
    {
        private readonly KdbTimespanVector _empty = new KdbTimespanVector(Array.Empty<long>());
        private readonly KdbTimespanVector _single = new KdbTimespanVector(new long[] { 0 });
        private readonly KdbTimespanVector _many = new KdbTimespanVector(new[] { 0, Null, NegativeInfinity, PositiveInfinity });
        private readonly KdbTimespanVector _nulls = new KdbTimespanVector(new[] { Null, NegativeInfinity, PositiveInfinity });

        [TestMethod]
        public void TypeIsTimespanVector() => Assert.AreEqual(KdbType.TimespanVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsLongArray() => Assert.AreEqual(typeof(long[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`timespan$()", _empty.ToString());
            Assert.AreEqual(",0D00:00:00.000000000", _single.ToString());
            Assert.AreEqual("0D00:00:00.000000000 0N -0W 0W", _many.ToString());
            Assert.AreEqual("0N -0W 0Wn", _nulls.ToString());
        }
    }
}
