using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CWeaponInfoTests
{
    [StructLayout(LayoutKind.Sequential, Size = 0x10)]
    public unsafe struct atArray<T> where T : unmanaged
    {
        public T* Items;
        public ushort Count;
        public ushort Size;
    }

    [StructLayout(LayoutKind.Sequential, Size = 0x10)]
    public unsafe struct atArrayOfPtrs<T> where T : unmanaged
    {
        public T** Items;
        public ushort Count;
        public ushort Size;
    }
}
