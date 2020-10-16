using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static KdbSharp.Data.BaseIntVector;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbIntVectorTests
    {
        private readonly KdbIntVector _empty = new KdbIntVector(Array.Empty<int>());
        private readonly KdbIntVector _single = new KdbIntVector(new[] { 0 });
        private readonly KdbIntVector _many = new KdbIntVector(new[] { 0, Null, NegativeInfinity, PositiveInfinity });

        [TestMethod]
        public void TypeIsIntVector() => Assert.AreEqual(KdbType.IntVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsIntArray() => Assert.AreEqual(typeof(int[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`int$()", _empty.ToString());
            Assert.AreEqual(",0i", _single.ToString());
            Assert.AreEqual("0 0N -0W 0Wi", _many.ToString());
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
