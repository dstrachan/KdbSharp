using KdbSharp.Data;
using KdbSharp.IPC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KdbSharp.Data.BaseGuidAtom;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbGuidAtomTests
    {
        private readonly KdbGuidAtomWrapper _null = new KdbGuidAtomWrapper(Null);
        private readonly KdbGuidAtomWrapper _notNull = new KdbGuidAtomWrapper(new Guid("8c6b8b64-6815-6084-0a3e-178401251b68"));

        [TestMethod]
        public void TypeIsGuidAtom() => Assert.AreEqual(KdbType.GuidAtom, _null.Type);

        [TestMethod]
        public void ValueTypeIsGuid() => Assert.AreEqual(typeof(Guid), _null.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", _null.ToString());
            Assert.AreEqual("8c6b8b64-6815-6084-0a3e-178401251b68", _notNull.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect() => CollectionAssert.AreEqual(_null.Value.ToKdbGuidBytes(), _null.ValueBytes);

        [TestMethod]
        public void SerializedLengthIsCorrect() => Assert.AreEqual(25, _null.SerializedLengthWrapper);
    }

    public class KdbGuidAtomWrapper : KdbGuidAtom
    {
        public int SerializedLengthWrapper => SerializedLength;

        public KdbGuidAtomWrapper(Guid value) : base(value)
        {
        }
    }
}
