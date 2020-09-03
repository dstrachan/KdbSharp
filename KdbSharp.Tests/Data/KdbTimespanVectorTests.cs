using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbTimespanVectorTests
    {
        private readonly KdbTimespanVector _instance = new KdbTimespanVector(new long[] { });

        [TestMethod]
        public void KdbTypeIsTimespanVector() => Assert.AreEqual(KdbType.TimespanVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsLongArray() => Assert.AreEqual(typeof(long[]), _instance.Value.GetType());
    }
}
