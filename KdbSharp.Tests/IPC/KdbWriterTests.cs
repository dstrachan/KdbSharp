using KdbSharp.Data;
using KdbSharp.IPC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;

namespace KdbSharp.Tests.IPC
{
    [TestClass]
    public class KdbWriterTests
    {
        private readonly Mock<IKdbType> _obj = new Mock<IKdbType>();

        private Stream _stream;
        private KdbWriter _writer;

        [TestInitialize]
        public void Init()
        {
            _stream = new MemoryStream();
            _writer = new KdbWriter(_stream);
        }

        [TestMethod]
        public void AsyncWriteReturnsCorrectLength() => Assert.AreEqual(0, _writer.Write(_obj.Object, KdbMessageType.Async));

        [TestMethod]
        public void SyncWriteReturnsCorrectLength() => Assert.AreEqual(0, _writer.Write(_obj.Object, KdbMessageType.Sync));
    }
}
