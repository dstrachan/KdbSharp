using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KdbSharp.Data.BaseIntVector;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbTimeVectorTests
    {
        private readonly KdbTimeVector _empty = new KdbTimeVector(Array.Empty<int>());
        private readonly KdbTimeVector _single = new KdbTimeVector(new[] { 0 });
        private readonly KdbTimeVector _many = new KdbTimeVector(new[] { 0, Null, NegativeInfinity, PositiveInfinity });
        private readonly KdbTimeVector _nulls = new KdbTimeVector(new[] { Null, NegativeInfinity, PositiveInfinity });

        [TestMethod]
        public void TypeIsTimeVector() => Assert.AreEqual(KdbType.TimeVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsIntArray() => Assert.AreEqual(typeof(int[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`time$()", _empty.ToString());
            Assert.AreEqual(",00:00:00.000", _single.ToString());
            Assert.AreEqual("00:00:00.000 0N -0W 0W", _many.ToString());
            Assert.AreEqual("0N -0W 0Wt", _nulls.ToString());
        }
    }
}
