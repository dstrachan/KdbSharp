using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbLongAtomTests
    {
        private readonly KdbLongAtom _instance = new KdbLongAtom(0);

        [TestMethod]
        public void KdbTypeIsLongAtom() => Assert.AreEqual(KdbType.LongAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsLong() => Assert.AreEqual(typeof(long), _instance.Value.GetType());
    }
}
