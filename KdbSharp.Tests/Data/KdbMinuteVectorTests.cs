using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbMinuteVectorTests
    {
        private readonly KdbMinuteVector _instance = new KdbMinuteVector(new int[] { });

        [TestMethod]
        public void KdbTypeIsMinuteVector() => Assert.AreEqual(KdbType.MinuteVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsIntArray() => Assert.AreEqual(typeof(int[]), _instance.Value.GetType());
    }
}
