using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbIntAtomTests
    {
        private readonly KdbIntAtom _instance = new KdbIntAtom(0);

        [TestMethod]
        public void KdbTypeIsIntAtom() => Assert.AreEqual(KdbType.IntAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsInt() => Assert.AreEqual(typeof(int), _instance.Value.GetType());
    }
}
