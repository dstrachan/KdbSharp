using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbSymbolAtomTests
    {
        private readonly KdbSymbolAtom _instance = new KdbSymbolAtom("");

        [TestMethod]
        public void KdbTypeIsSymbolAtom() => Assert.AreEqual(KdbType.SymbolAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsString() => Assert.AreEqual(typeof(string), _instance.Value.GetType());
    }
}
