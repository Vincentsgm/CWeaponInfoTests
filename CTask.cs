using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CWeaponInfoTests
{
    [StructLayout(LayoutKind.Explicit)]
    internal unsafe struct CTask
    {
        [FieldOffset(0x10)] public CPed* Owner;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct CTaskGun
    {
        [FieldOffset(0x110)] public eFiringPattern FiringPattern;
        [FieldOffset(0x114)] public bool HasFiringPatternOverride;

        public void SetFiringPatternOverride(string firingPatternName) => SetFiringPatternOverride((eFiringPattern)Game.GetHashKey(firingPatternName));

        public void SetFiringPatternOverride(eFiringPattern firingPatternHash)
        {
            FiringPattern = firingPatternHash;
            HasFiringPatternOverride = true;
        }
    }

    internal enum eFiringPattern : int
    {
        BurstFire = -687903391,
        BurstFireDriveby = -753768974,
        FullAuto = -957453492,
        SingleShot = 1566631136,
        DelayFireByOneSec = 2055493265,
        BurstFireHeli = -1857128337,
        ShortBursts = 445831135,
        BurstFireMicro = 1122960381,
        SlowFireTank = -490063247,
        TampaMortar = -1842093953
    }
}
