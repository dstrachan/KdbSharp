using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbTimeAtomTests
    {
        private readonly KdbTimeAtom _instance = new KdbTimeAtom(0);

        [TestMethod]
        public void KdbTypeIsTimeAtom() => Assert.AreEqual(KdbType.TimeAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsInt() => Assert.AreEqual(typeof(int), _instance.Value.GetType());
    }
}
