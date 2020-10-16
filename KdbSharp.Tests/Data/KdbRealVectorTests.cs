using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static KdbSharp.Data.BaseFloatVector;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbRealVectorTests
    {
        private readonly KdbRealVector _empty = new KdbRealVector(Array.Empty<float>());
        private readonly KdbRealVector _single = new KdbRealVector(new float[] { 0 });
        private readonly KdbRealVector _many = new KdbRealVector(new[] { 0, Null, NegativeInfinity, PositiveInfinity });

        [TestMethod]
        public void TypeIsRealVector() => Assert.AreEqual(KdbType.RealVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsFloatArray() => Assert.AreEqual(typeof(float[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`real$()", _empty.ToString());
            Assert.AreEqual(",0e", _single.ToString());
            Assert.AreEqual("0 0N -0W 0We", _many.ToString());
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
