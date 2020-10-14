using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdbSharp.IPC
{
    // Reference: https://code.kx.com/q/basics/ipc/#handshake
    public enum KdbCapability
    {
        V2_5_NoCompression = 0,
        V2_6_WithCompression = 1,
        V3_0_WithCompression = 3,
        V3_4_32BitVectors = 5,
        V3_4_64BitVectors = 6,
    }
}
