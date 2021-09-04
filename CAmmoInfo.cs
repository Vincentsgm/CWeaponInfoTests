using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CWeaponInfoTests
{
    [Flags]
    public enum eAmmoFlags : uint
    {
        None = 0,
        InfiniteAmmo = 1,
        AddSmokeOnExplosion = 2,
        Fuse = 4,
        FixedAfterExplosion = 8,
    }

    public enum eAmmoSpecialType : uint
    {
        None = 0,
        ArmorPiercing = 1,
        Explosive = 2,
        FMJ = 3, // Full Metal Jacket
        HollowPoint = 4,
        Incendiary = 5,
        Tracer = 6,
    }

    [StructLayout(LayoutKind.Explicit, Size = 64)]
    public unsafe struct CAmmoInfo
    {
        [FieldOffset(0x0010)] public uint Name;
        [FieldOffset(0x0014)] public uint Model;
        [FieldOffset(0x0018)] public uint Audio;
        [FieldOffset(0x001C)] public uint Slot;
        [FieldOffset(0x0020)] public uint AmmoMax;
        [FieldOffset(0x0024)] public uint AmmoMax50;
        [FieldOffset(0x0028)] public uint AmmoMax100;
        [FieldOffset(0x002C)] public uint AmmoMaxMP;
        [FieldOffset(0x0030)] public uint AmmoMax50MP;
        [FieldOffset(0x0034)] public uint AmmoMax100MP;
        [FieldOffset(0x0038)] public eAmmoFlags AmmoFlags;
        [FieldOffset(0x003C)] public eAmmoSpecialType AmmoSpecialType;
    }
}
