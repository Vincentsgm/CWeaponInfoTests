using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CWeaponInfoTests
{
    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public unsafe struct CWeaponTintSpecValues
    {
        [FieldOffset(0x0000)] public uint Name;

        [FieldOffset(0x0008)] public CSimpleArray_CWeaponTintSpec Tints;
    }

    [StructLayout(LayoutKind.Sequential, Size = 24)]
    public unsafe struct CWeaponTintSpec
    {
        public float SpecFresnel;
        public float SpecFalloffMult;
        public float SpecIntMult;
        public float Spec2Factor;
        public float Spec2ColorInt;
        public uint Spec2Color;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CSimpleArray_CWeaponTintSpec
    {
        public CWeaponTintSpec* Offset;
        public ushort Count;
        public ushort Size;


        public CWeaponTintSpec* Get(ushort index)
        {
            if (index >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"The size of this {nameof(CSimpleArray_CWeaponTintSpec)} is {Size}, the index {index} is out of range.");
            }

            return &Offset[index];
        }
    }
}
