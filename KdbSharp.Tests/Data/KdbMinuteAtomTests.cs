using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbMinuteAtomTests
    {
        private readonly KdbMinuteAtom _instance = new KdbMinuteAtom(0);

        [TestMethod]
        public void KdbTypeIsMinuteAtom() => Assert.AreEqual(KdbType.MinuteAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsInt() => Assert.AreEqual(typeof(int), _instance.Value.GetType());
    }
}
