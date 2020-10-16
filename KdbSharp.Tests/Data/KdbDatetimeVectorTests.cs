using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbDatetimeVectorTests
    {
        private readonly KdbDatetimeVector _instance = new KdbDatetimeVector(new double[] { });

        [TestMethod]
        public void TypeIsDatetimeVector() => Assert.AreEqual(KdbType.DatetimeVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsDoubleArray() => Assert.AreEqual(typeof(double[]), _instance.Value.GetType());
    }
}
