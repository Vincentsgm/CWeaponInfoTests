using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CWeaponInfoTests
{
    [StructLayout(LayoutKind.Explicit)]
    internal unsafe struct CPed
    {
        [FieldOffset(0x10D8)] public CPedWeaponManager* weaponManager;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal unsafe struct CPedWeaponManager
    {
        [FieldOffset(0x020)] public CWeaponInfo* weaponInfo;
    }
}
