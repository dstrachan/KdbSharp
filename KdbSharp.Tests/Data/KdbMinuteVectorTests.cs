using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KdbSharp.Data.BaseIntVector;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbMinuteVectorTests
    {
        private readonly KdbMinuteVector _empty = new KdbMinuteVector(Array.Empty<int>());
        private readonly KdbMinuteVector _single = new KdbMinuteVector(new[] { 0 });
        private readonly KdbMinuteVector _many = new KdbMinuteVector(new[] { 0, Null, NegativeInfinity, PositiveInfinity });
        private readonly KdbMinuteVector _nulls = new KdbMinuteVector(new[] { Null, NegativeInfinity, PositiveInfinity });

        [TestMethod]
        public void TypeIsMinuteVector() => Assert.AreEqual(KdbType.MinuteVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsIntArray() => Assert.AreEqual(typeof(int[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`minute$()", _empty.ToString());
            Assert.AreEqual(",00:00", _single.ToString());
            Assert.AreEqual("00:00 0N -0W 0W", _many.ToString());
            Assert.AreEqual("0N -0W 0Wu", _nulls.ToString());
        }
    }
}
