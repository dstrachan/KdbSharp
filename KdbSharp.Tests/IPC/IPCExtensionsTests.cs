using KdbSharp.IPC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KdbSharp.Tests.IPC
{
    [TestClass]
    public class IPCExtensionsTests
    {
        [TestMethod]
        public void ConvertToAndFromKdbGuidBytes()
        {
            var expected = Guid.Empty;
            ReadOnlySpan<byte> span = expected.ToKdbGuidBytes().AsSpan();
            Assert.AreEqual(expected, span.FromKdbGuidBytes());

            expected = Guid.NewGuid();
            span = expected.ToKdbGuidBytes().AsSpan();
            Assert.AreEqual(expected, span.FromKdbGuidBytes());
        }
    }
}
