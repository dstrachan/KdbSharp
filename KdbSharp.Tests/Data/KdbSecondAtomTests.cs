using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbSecondAtomTests
    {
        private readonly KdbSecondAtom _instance = new KdbSecondAtom(0);

        [TestMethod]
        public void KdbTypeIsSecondAtom() => Assert.AreEqual(KdbType.SecondAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsInt() => Assert.AreEqual(typeof(int), _instance.Value.GetType());
    }
}
