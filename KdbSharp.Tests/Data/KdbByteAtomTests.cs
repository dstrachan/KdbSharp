using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbByteAtomTests
    {
        private readonly KdbByteAtom _instance = new KdbByteAtom(0);

        [TestMethod]
        public void KdbTypeIsByteAtom() => Assert.AreEqual(KdbType.ByteAtom, _instance.Type);

        [TestMethod]
        public void ValueTypeIsByte() => Assert.AreEqual(typeof(byte), _instance.Value.GetType());
    }
}
