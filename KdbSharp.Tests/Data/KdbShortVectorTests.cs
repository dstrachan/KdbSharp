using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbShortVectorTests
    {
        private readonly KdbShortVector _instance = new KdbShortVector(new short[] { });

        [TestMethod]
        public void KdbTypeIsShortVector() => Assert.AreEqual(KdbType.ShortVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsShortArray() => Assert.AreEqual(typeof(short[]), _instance.Value.GetType());
    }
}
