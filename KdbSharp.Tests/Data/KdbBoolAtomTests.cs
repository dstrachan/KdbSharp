using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbBoolAtomTests
    {
        private readonly KdbBoolAtom _instance = new KdbBoolAtom(0);

        [TestMethod]
        public void KdbTypeIsBoolAtom() => Assert.AreEqual(KdbType.BoolAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsByte() => Assert.AreEqual(typeof(byte), _instance.Value.GetType());
    }
}
