using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbTimespanAtomTests
    {
        private readonly KdbTimespanAtom _instance = new KdbTimespanAtom(0);

        [TestMethod]
        public void KdbTypeIsTimespanAtom() => Assert.AreEqual(KdbType.TimespanAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsLong() => Assert.AreEqual(typeof(long), _instance.Value.GetType());
    }
}
