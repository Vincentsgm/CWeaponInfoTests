using System.Runtime.InteropServices;

namespace CWeaponInfoTests
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public unsafe struct CAimingInfo
    {
        [FieldOffset(0x0000)] public uint Name;
        [FieldOffset(0x0004)] public float HeadingLimit;
        [FieldOffset(0x0008)] public float SweepPitchMin;
        [FieldOffset(0x000C)] public float SweepPitchMax;
    }
}