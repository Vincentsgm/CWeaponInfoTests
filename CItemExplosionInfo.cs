using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CWeaponInfoTests
{
    [StructLayout(LayoutKind.Sequential, Size = 24)]
    public struct CItemExplosionInfo
    {
        public int Default;
        public int HitCar;
        public int HitTruck;
        public int HitBike;
        public int HitBoat;
        public int HitPlane;
    }
}
