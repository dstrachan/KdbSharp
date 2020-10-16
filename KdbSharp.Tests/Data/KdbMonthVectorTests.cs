using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbMonthVectorTests
    {
        private readonly KdbMonthVector _instance = new KdbMonthVector(new int[] { });

        [TestMethod]
        public void TypeIsMonthVector() => Assert.AreEqual(KdbType.MonthVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsIntArray() => Assert.AreEqual(typeof(int[]), _instance.Value.GetType());
    }
}
