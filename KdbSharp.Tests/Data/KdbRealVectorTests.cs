using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbRealVectorTests
    {
        private readonly KdbRealVector _instance = new KdbRealVector(new float[] { });

        [TestMethod]
        public void KdbTypeIsRealVector() => Assert.AreEqual(KdbType.RealVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsRealArray() => Assert.AreEqual(typeof(float[]), _instance.Value.GetType());
    }
}
