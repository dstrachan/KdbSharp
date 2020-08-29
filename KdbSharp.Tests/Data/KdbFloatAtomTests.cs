using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbFloatAtomTests
    {
        private readonly KdbFloatAtom _instance = new KdbFloatAtom(0);

        [TestMethod]
        public void KdbTypeIsFloatAtom() => Assert.AreEqual(KdbType.FloatAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsFloat() => Assert.AreEqual(typeof(double), _instance.Value.GetType());
    }
}
