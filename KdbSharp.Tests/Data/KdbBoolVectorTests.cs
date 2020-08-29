using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbBoolVectorTests
    {
        private readonly KdbBoolVector _instance = new KdbBoolVector(new byte[] { });

        [TestMethod]
        public void KdbTypeIsBoolVector() => Assert.AreEqual(KdbType.BoolVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsByteArray() => Assert.AreEqual(typeof(byte[]), _instance.Value.GetType());
    }
}
