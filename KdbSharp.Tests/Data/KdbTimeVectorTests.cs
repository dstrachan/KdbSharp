using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbTimeVectorTests
    {
        private readonly KdbTimeVector _instance = new KdbTimeVector(new int[] { });

        [TestMethod]
        public void KdbTypeIsTimeVector() => Assert.AreEqual(KdbType.TimeVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsIntArray() => Assert.AreEqual(typeof(int[]), _instance.Value.GetType());
    }
}
