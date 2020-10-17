using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KdbSharp.Data.BaseLongVector;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbTimestampVectorTests
    {
        private readonly KdbTimestampVector _empty = new KdbTimestampVector(Array.Empty<long>());
        private readonly KdbTimestampVector _single = new KdbTimestampVector(new long[] { 0 });
        private readonly KdbTimestampVector _many = new KdbTimestampVector(new[] { 0, Null, NegativeInfinity, PositiveInfinity });
        private readonly KdbTimestampVector _nulls = new KdbTimestampVector(new[] { Null, NegativeInfinity, PositiveInfinity });

        [TestMethod]
        public void TypeIsTimestampVector() => Assert.AreEqual(KdbType.TimestampVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsLongArray() => Assert.AreEqual(typeof(long[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`timestamp$()", _empty.ToString());
            Assert.AreEqual(",2000.01.01D00:00:00.000000000", _single.ToString());
            Assert.AreEqual("2000.01.01D00:00:00.000000000 0N -0W 0W", _many.ToString());
            Assert.AreEqual("0N -0W 0Wp", _nulls.ToString());
        }
    }
}
