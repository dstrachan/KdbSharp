using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbTimestampVectorTests
    {
        private readonly KdbTimestampVector _instance = new KdbTimestampVector(new long[] { });

        [TestMethod]
        public void KdbTypeIsTimestampVector() => Assert.AreEqual(KdbType.TimestampVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsLongArray() => Assert.AreEqual(typeof(long[]), _instance.Value.GetType());
    }
}
