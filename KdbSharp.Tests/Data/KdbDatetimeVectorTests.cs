using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KdbSharp.Data.BaseDoubleVector;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbDatetimeVectorTests
    {
        private readonly KdbDatetimeVector _empty = new KdbDatetimeVector(Array.Empty<double>());
        private readonly KdbDatetimeVector _single = new KdbDatetimeVector(new double[] { 0 });
        private readonly KdbDatetimeVector _many = new KdbDatetimeVector(new[] { 0, Null, NegativeInfinity, PositiveInfinity });

        [TestMethod]
        public void TypeIsDatetimeVector() => Assert.AreEqual(KdbType.DatetimeVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsDoubleArray() => Assert.AreEqual(typeof(double[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`datetime$()", _empty.ToString());
            Assert.AreEqual(",2000.01.01T00:00:00.000", _single.ToString());
            Assert.AreEqual("2000.01.01T00:00:00.000 0N -0W 0Wz", _many.ToString()); // TODO: conditional suffix
        }
    }
}
