using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KdbSharp.Data.BaseIntVector;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbSecondVectorTests
    {
        private readonly KdbSecondVector _empty = new KdbSecondVector(Array.Empty<int>());
        private readonly KdbSecondVector _single = new KdbSecondVector(new[] { 0 });
        private readonly KdbSecondVector _many = new KdbSecondVector(new[] { 0, Null, NegativeInfinity, PositiveInfinity });
        private readonly KdbSecondVector _nulls = new KdbSecondVector(new[] { Null, NegativeInfinity, PositiveInfinity });

        [TestMethod]
        public void TypeIsSecondVector() => Assert.AreEqual(KdbType.SecondVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsIntArray() => Assert.AreEqual(typeof(int[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`second$()", _empty.ToString());
            Assert.AreEqual(",00:00:00", _single.ToString());
            Assert.AreEqual("00:00:00 0N -0W 0W", _many.ToString());
            Assert.AreEqual("0N -0W 0Wv", _nulls.ToString());
        }
    }
}
