using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbShortAtomTests
    {
        private readonly KdbShortAtom _instance = new KdbShortAtom(0);

        [TestMethod]
        public void KdbTypeIsShortAtom() => Assert.AreEqual(KdbType.ShortAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsShort() => Assert.AreEqual(typeof(short), _instance.Value.GetType());
    }
}
