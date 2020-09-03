using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbDateAtomTests
    {
        private readonly KdbDateAtom _instance = new KdbDateAtom(0);

        [TestMethod]
        public void KdbTypeIsDateAtom() => Assert.AreEqual(KdbType.DateAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsInt() => Assert.AreEqual(typeof(int), _instance.Value.GetType());
    }
}
