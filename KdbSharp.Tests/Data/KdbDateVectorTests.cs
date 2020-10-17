using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KdbSharp.Data.BaseIntVector;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbDateVectorTests
    {
        private readonly KdbDateVector _empty = new KdbDateVector(Array.Empty<int>());
        private readonly KdbDateVector _single = new KdbDateVector(new[] { 0 });
        private readonly KdbDateVector _many = new KdbDateVector(new[] { 0, Null, NegativeInfinity, PositiveInfinity });
        private readonly KdbDateVector _nulls = new KdbDateVector(new[] { Null, NegativeInfinity, PositiveInfinity });

        [TestMethod]
        public void TypeIsDateVector() => Assert.AreEqual(KdbType.DateVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsIntArray() => Assert.AreEqual(typeof(int[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`date$()", _empty.ToString());
            Assert.AreEqual(",2000.01.01", _single.ToString());
            Assert.AreEqual("2000.01.01 0N -0W 0W", _many.ToString());
            Assert.AreEqual("0N -0W 0Wd", _nulls.ToString());
        }
    }
}
