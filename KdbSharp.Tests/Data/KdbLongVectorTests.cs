using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbLongVectorTests
    {
        private readonly KdbLongVector _instance = new KdbLongVector(new long[] { });

        [TestMethod]
        public void KdbTypeIsLongVector() => Assert.AreEqual(KdbType.LongVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsLongArray() => Assert.AreEqual(typeof(long[]), _instance.Value.GetType());
    }
}
