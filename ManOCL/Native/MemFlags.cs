namespace ManOCL.Native
{
    using System;

    [Flags]
    public enum MemFlags : ulong
    {
        AllocHostPtr = 0x10L,
        CopyHostPtr = 0x20L,
        ReadOnly = 4L,
        ReadWrite = 1L,
        UseHostPtr = 8L,
        WriteOnly = 2L
    }
}
