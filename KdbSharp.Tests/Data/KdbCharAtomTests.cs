using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbCharAtomTests
    {
        private readonly KdbCharAtom _instance = new KdbCharAtom(' ');

        [TestMethod]
        public void KdbTypeIsCharAtom() => Assert.AreEqual(KdbType.CharAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsChar() => Assert.AreEqual(typeof(char), _instance.Value.GetType());
    }
}
