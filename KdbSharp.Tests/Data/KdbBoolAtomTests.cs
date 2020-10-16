using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbBoolAtomTests
    {
        private readonly KdbBoolAtom _false = new KdbBoolAtom(0);
        private readonly KdbBoolAtom _true = new KdbBoolAtom(1);

        [TestMethod]
        public void TypeIsBoolAtom() => Assert.AreEqual(KdbType.BoolAtom, _false.Type);

        [TestMethod]
        public void ValueTypeIsByte() => Assert.AreEqual(typeof(byte), _false.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("0b", _false.ToString());
            Assert.AreEqual("1b", _true.ToString());
        }
    }
}
