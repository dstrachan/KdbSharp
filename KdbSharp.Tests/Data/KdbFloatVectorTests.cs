using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbFloatVectorTests
    {
        private readonly KdbFloatVector _instance = new KdbFloatVector(new double[] { });

        [TestMethod]
        public void TypeIsFloatVector() => Assert.AreEqual(KdbType.FloatVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsDoubleArray() => Assert.AreEqual(typeof(double[]), _instance.Value.GetType());
    }
}
