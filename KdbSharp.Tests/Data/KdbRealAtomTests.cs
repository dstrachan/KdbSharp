using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbRealAtomTests
    {
        private readonly KdbRealAtom _instance = new KdbRealAtom(0);

        [TestMethod]
        public void KdbTypeIsRealAtom() => Assert.AreEqual(KdbType.RealAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsFloat() => Assert.AreEqual(typeof(float), _instance.Value.GetType());
    }
}
