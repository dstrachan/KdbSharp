using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbDateVectorTests
    {
        private readonly KdbDateVector _instance = new KdbDateVector(new int[] { });

        [TestMethod]
        public void KdbTypeIsDateVector() => Assert.AreEqual(KdbType.DateVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsIntArray() => Assert.AreEqual(typeof(int[]), _instance.Value.GetType());
    }
}
