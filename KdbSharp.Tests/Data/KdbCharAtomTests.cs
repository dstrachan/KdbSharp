using KdbSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KdbSharp.Data.BaseCharAtom;

namespace KdbSharp.Tests.Data
{
    [TestClass]
    public class KdbCharAtomTests
    {
        private readonly KdbCharAtomWrapper _null = new KdbCharAtomWrapper(Null);
        private readonly KdbCharAtomWrapper _notNull = new KdbCharAtomWrapper('a');

        [TestMethod]
        public void TypeIsCharAtom() => Assert.AreEqual(KdbType.CharAtom, _null.Type);

        [TestMethod]
        public void ValueTypeIsChar() => Assert.AreEqual(typeof(char), _null.Value.GetType());

        [TestMethod]
        public void ToStringIsCorrect()
        {
            Assert.AreEqual("\" \"", _null.ToString());
            Assert.AreEqual("\"a\"", _notNull.ToString());
        }

        [TestMethod]
        public void ValueBytesAreCorrect()
        {
            CollectionAssert.AreEqual(new[] { (byte)_null.Value }, _null.ValueBytes);
            CollectionAssert.AreEqual(new[] { (byte)_notNull.Value }, _notNull.ValueBytes);
        }

        [TestMethod]
        public void SerializedLengthIsCorrect()
        {
            Assert.AreEqual(10, _null.SerializedLengthWrapper);
            Assert.AreEqual(10, _notNull.SerializedLengthWrapper);
        }
    }

    public class KdbCharAtomWrapper : KdbCharAtom
    {
        public int SerializedLengthWrapper => SerializedLength;

        public KdbCharAtomWrapper(char value) : base(value)
        {
        }
    }
}
