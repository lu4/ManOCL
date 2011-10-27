using System;
using System.Collections.Generic;
using System.Text;

namespace ManOCL
{
    public enum AddressingMode : uint
    {
        Clamp = 0x1132,
        ClampToEdge = 0x1131,
        None = 0x1130,
        Repeat = 0x1133
    }
}
