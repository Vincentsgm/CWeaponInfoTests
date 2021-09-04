using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CWeaponInfoTests
{
    [StructLayout(LayoutKind.Explicit, Size = 52)]
    public unsafe struct CWeaponUpperBodyFixupExpressionData
    {
        [FieldOffset(0x0000)] public uint Name;
        [FieldOffset(0x0004)] private Item dataArrayStart; // 4 items

        public Item* GetData()
        {
            fixed (Item* data = &dataArrayStart)
            {
                return data;
            };
        }

        [StructLayout(LayoutKind.Sequential, Size = 12)]
        public struct Item
        {
            public float Idle;
            public float Walk;
            public float Run;
        }
    }
}
