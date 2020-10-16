using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static KdbSharp.Data.BaseDoubleVector;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbFloatVectorTests
    {
        private readonly KdbFloatVector _empty = new KdbFloatVector(Array.Empty<double>());
        private readonly KdbFloatVector _single = new KdbFloatVector(new double[] { 0 });
        private readonly KdbFloatVector _many = new KdbFloatVector(new[] { 0, Null, NegativeInfinity, PositiveInfinity });

        [TestMethod]
        public void TypeIsFloatVector() => Assert.AreEqual(KdbType.FloatVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsDoubleArray() => Assert.AreEqual(typeof(double[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`float$()", _empty.ToString());
            Assert.AreEqual(",0f", _single.ToString());
            Assert.AreEqual("0 NaN -0w 0w", _many.ToString()); // TODO: double.IsNaN()
        }

        [TestMethod]
        public void ValueBytesAreCorrect()
        {
            CollectionAssert.AreEqual(Array.Empty<byte>(), _empty.ValueBytes);
            CollectionAssert.AreEqual(_single.Value.SelectMany(x => BitConverter.GetBytes(x)).ToArray(), _single.ValueBytes);
            CollectionAssert.AreEqual(_many.Value.SelectMany(x => BitConverter.GetBytes(x)).ToArray(), _many.ValueBytes);
        }
    }
}
