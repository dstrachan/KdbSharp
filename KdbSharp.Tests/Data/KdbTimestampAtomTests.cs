using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbTimestampAtomTests
    {
        private readonly KdbTimestampAtom _instance = new KdbTimestampAtom(0);

        [TestMethod]
        public void KdbTypeIsTimestampAtom() => Assert.AreEqual(KdbType.TimestampAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsLong() => Assert.AreEqual(typeof(long), _instance.Value.GetType());
    }
}
