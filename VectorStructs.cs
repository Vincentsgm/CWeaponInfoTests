using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CWeaponInfoTests
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeVector2Float
    {
        public float X;
        public float Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NativeVector3Float
    {
        public float X;
        public float Y;
        public float Z;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct NativeColorRGBFloat
    {
        public float R;
        public float G;
        public float B;
    }
}
