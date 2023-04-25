using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace CWeaponInfoTests
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeVector2Float
    {
        public float X;
        public float Y;

        public static implicit operator Vector2(NativeVector2Float v) => new Vector2(v.X, v.Y);

        public static implicit operator NativeVector2Float(Vector2 v) => new NativeVector2Float() { X = v.X, Y = v.Y };
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NativeVector3Float
    {
        public float X;
        public float Y;
        public float Z;

        public static implicit operator Vector3(NativeVector3Float v) => new Vector3(v.X, v.Y, v.Z);

        public static implicit operator NativeVector3Float(Vector3 v) => new NativeVector3Float() { X = v.X, Y = v.Y, Z = v.Z };
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct NativeColorRGBFloat
    {
        public float R;
        public float G;
        public float B;

        public static implicit operator Color(NativeColorRGBFloat c) => Color.FromArgb((int)(255 * c.R), (int)(255 * c.G), (int)(255 * c.B));

        public static implicit operator NativeColorRGBFloat(Color c) => new NativeColorRGBFloat() { R = c.R / 255f, G = c.G / 255f, B = c.B / 255f };
    }
}
