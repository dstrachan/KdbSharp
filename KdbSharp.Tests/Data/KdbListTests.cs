using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbListTests
    {
        private readonly KdbList _empty = new KdbList(Array.Empty<IKdbType>());
        private KdbList _single;
        private KdbList _1d;
        private KdbList _2d;

        [TestInitialize]
        public void Init()
        {
            var shortAtom = new KdbShortAtom(0);
            var intAtom = new KdbIntAtom(0);
            var longAtom = new KdbLongAtom(0);

            _1d = new KdbList(new IKdbType[] { shortAtom, intAtom, longAtom });
            _2d = new KdbList(new IKdbType[] { _1d, _1d });
            _single = new KdbList(new IKdbType[] { _1d });
        }

        [TestMethod]
        public void TypeIsList() => Assert.AreEqual(KdbType.List, _empty.Type);

        [TestMethod]
        public void ValueTypeIsIKdbTypeArray() => Assert.AreEqual(typeof(IKdbType[]), _empty.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("()", _empty.ToString());
            Assert.AreEqual(",(0h;0i;0)", _single.ToString());
            Assert.AreEqual("(0h;0i;0)", _1d.ToString());
            Assert.AreEqual("((0h;0i;0);(0h;0i;0))", _2d.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect()
        {
            CollectionAssert.AreEqual(Array.Empty<byte>(), _empty.ValueBytes);
            CollectionAssert.AreEqual(_single.Value.SelectMany(x => x.ValueBytes).ToArray(), _single.ValueBytes);
            CollectionAssert.AreEqual(_1d.Value.SelectMany(x => x.ValueBytes).ToArray(), _1d.ValueBytes);
            CollectionAssert.AreEqual(_2d.Value.SelectMany(x => x.ValueBytes).ToArray(), _2d.ValueBytes);
        }
    }
}
