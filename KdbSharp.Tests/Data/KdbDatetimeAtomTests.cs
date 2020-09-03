using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbDatetimeAtomTests
    {
        private readonly KdbDatetimeAtom _instance = new KdbDatetimeAtom(0);

        [TestMethod]
        public void KdbTypeIsDatetimeAtom() => Assert.AreEqual(KdbType.DatetimeAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsDouble() => Assert.AreEqual(typeof(double), _instance.Value.GetType());
    }
}
