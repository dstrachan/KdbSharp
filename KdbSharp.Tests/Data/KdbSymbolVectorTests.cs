using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbSymbolVectorTests
    {
        private readonly KdbSymbolVector _instance = new KdbSymbolVector(new string[] { });

        [TestMethod]
        public void KdbTypeIsSymbolVector() => Assert.AreEqual(KdbType.SymbolVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsStringArray() => Assert.AreEqual(typeof(string[]), _instance.Value.GetType());
    }
}
