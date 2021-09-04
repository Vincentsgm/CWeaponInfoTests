using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Rage;
using static Rage.Native.NativeFunction;
using System.Runtime.InteropServices;

[assembly: Rage.Attributes.Plugin("CWeaponInfoTests", EntryPoint = "CWeaponInfoTests.EntryPoint.Main", ExitPoint = "CWeaponInfoTests.EntryPoint.Exit", PrefersSingleInstance = true)]

namespace CWeaponInfoTests
{
    internal unsafe static class EntryPoint
    {
        public static string CWeaponInfoPattern = "48 8B 05 ?? ?? ?? ?? 41 8B 1E";
        public static atArrayOfPtrs<CWeaponInfo>* Weapons;
        public static IntPtr WeaponsAddress;
        public static CWeaponInfo* CarbineRifle;
        public static float OriginalTimeBetweenShots = 2000f;

        public static void Main()
        {
            IntPtr addr = Game.FindPattern(CWeaponInfoPattern);

            if (addr == IntPtr.Zero)
            {
                Game.DisplaySubtitle("CWeaponInfo pattern not found");
                return;
            }
            WeaponsAddress = addr + *(int*)(addr + 0x03) + 0x07;

            Weapons = (atArrayOfPtrs<CWeaponInfo>*)WeaponsAddress;
            Game.LogTrivial($"{Weapons->Count}");

            for (CWeaponInfo** weapon = Weapons->Items; weapon < Weapons->Items + Weapons->Count; weapon++)
            {
                CWeaponInfo* wp = *weapon;
                if (wp->Name == (uint)WeaponHash.CarbineRifle)
                {
                    Game.LogTrivial($"Carbine rifle found");
                    CarbineRifle = wp;
                }
            }
            Game.LogTrivial($"Carbine rifle time between shots: {CarbineRifle->BulletsPerAnimLoop}");
            CarbineRifle->BulletsPerAnimLoop = 1;
            Game.LogTrivial($"Carbine rifle time between shots: {CarbineRifle->BulletsPerAnimLoop}");
            while (true)
            {
                GameFiber.Yield();
                if (Game.IsKeyDown(Keys.End)) Game.UnloadActivePlugin();
            }
        }

        public static void Exit()
        {
            CarbineRifle->Speed = OriginalTimeBetweenShots;
        }

        public static void ShowWeaponFXGroups()
        {
            for (CWeaponInfo** weapon = Weapons->Items; weapon < Weapons->Items + Weapons->Count; weapon++)
            {
                CWeaponInfo* wp = *weapon;
                Game.LogTrivial($"Weapon: {(WeaponHash)(wp->Name)}; FX Group: {wp->Fx.EffectGroup}");
            }
            
        }
    }
}
