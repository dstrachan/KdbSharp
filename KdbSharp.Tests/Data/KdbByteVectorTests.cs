using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbByteVectorTests
    {
        private readonly KdbByteVector _instance = new KdbByteVector(new byte[] { });

        [TestMethod]
        public void KdbTypeIsByteVector() => Assert.AreEqual(KdbType.ByteVector, _instance.Type);

        [TestMethod]
        public void ValueTypeIsByteArray() => Assert.AreEqual(typeof(byte[]), _instance.Value.GetType());
    }
}
