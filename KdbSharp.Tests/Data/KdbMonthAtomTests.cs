using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbMonthAtomTests
    {
        private readonly KdbMonthAtom _instance = new KdbMonthAtom(0);

        [TestMethod]
        public void KdbTypeIsMonthAtom() => Assert.AreEqual(KdbType.MonthAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsInt() => Assert.AreEqual(typeof(int), _instance.Value.GetType());
    }
}
