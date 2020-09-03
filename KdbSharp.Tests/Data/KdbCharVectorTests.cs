using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbCharVectorTests
    {
        private readonly KdbCharVector _instance = new KdbCharVector(new char[] { });

        [TestMethod]
        public void KdbTypeIsCharVector() => Assert.AreEqual(KdbType.CharVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsCharArray() => Assert.AreEqual(typeof(char[]), _instance.Value.GetType());
    }
}
