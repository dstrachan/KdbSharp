using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbIntVectorTests
    {
        private readonly KdbIntVector _instance = new KdbIntVector(new int[] { });

        [TestMethod]
        public void KdbTypeIsIntVector() => Assert.AreEqual(KdbType.IntVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsIntArray() => Assert.AreEqual(typeof(int[]), _instance.Value.GetType());
    }
}
