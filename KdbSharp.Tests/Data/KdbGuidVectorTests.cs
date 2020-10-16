using KdbSharp.Data;
using KdbSharp.IPC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbGuidVectorTests
    {
        private readonly KdbGuidVector _empty = new KdbGuidVector(Array.Empty<Guid>());
        private readonly KdbGuidVector _single = new KdbGuidVector(new[] { BaseGuidVector.Null });
        private readonly KdbGuidVector _many = new KdbGuidVector(new[] { BaseGuidVector.Null, BaseGuidVector.Null });

        [TestMethod]
        public void TypeIsGuidVector() => Assert.AreEqual(KdbType.GuidVector, _empty.Type);

        [TestMethod]
        public void ValueTypeIsGuidArray() => Assert.AreEqual(typeof(Guid[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("`guid$()", _empty.ToString());
            Assert.AreEqual(",00000000-0000-0000-0000-000000000000", _single.ToString());
            Assert.AreEqual("00000000-0000-0000-0000-000000000000 00000000-0000-0000-0000-000000000000", _many.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect()
        {
            CollectionAssert.AreEqual(Array.Empty<byte>(), _empty.ValueBytes);
            CollectionAssert.AreEqual(_single.Value.SelectMany(x => x.ToKdbGuidBytes()).ToArray(), _single.ValueBytes);
            CollectionAssert.AreEqual(_many.Value.SelectMany(x => x.ToKdbGuidBytes()).ToArray(), _many.ValueBytes);
        }
    }
}
