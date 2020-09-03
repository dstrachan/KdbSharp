using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbSecondVectorTests
    {
        private readonly KdbSecondVector _instance = new KdbSecondVector(new int[] { });

        [TestMethod]
        public void KdbTypeIsSecondVector() => Assert.AreEqual(KdbType.SecondVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsIntArray() => Assert.AreEqual(typeof(int[]), _instance.Value.GetType());
    }
}
