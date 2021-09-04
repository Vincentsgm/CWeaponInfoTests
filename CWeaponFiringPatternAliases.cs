using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CWeaponInfoTests
{
    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public unsafe struct CWeaponFiringPatternAliases
    {
        [FieldOffset(0x0000)] public uint Name;

        [FieldOffset(0x0008)] public CSimpleArray_CWeaponFiringPatternAlias Aliases;
    }

    [StructLayout(LayoutKind.Sequential, Size = 8)]
    public unsafe struct CWeaponFiringPatternAlias
    {
        public uint FiringPattern;
        public uint Alias;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CSimpleArray_CWeaponFiringPatternAlias
    {
        public CWeaponFiringPatternAlias* Offset;
        public ushort Count;
        public ushort Size;


        public CWeaponFiringPatternAlias* Get(ushort index)
        {
            if (index >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"The size of this {nameof(CSimpleArray_CWeaponFiringPatternAlias)} is {Size}, the index {index} is out of range.");
            }

            return &Offset[index];
        }
    }
}
