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

            for (int i = 0; i < Weapons->Count; i++)
            {
                CWeaponInfo* wp = Weapons->Items[i];
                if (wp->Name == (uint)WeaponHash.CarbineRifle)
                {
                    Game.LogTrivial($"Carbine rifle found");
                    CarbineRifle = wp;
                }
            }
            Game.LogTrivial($"Carbine rifle flags 1: {CarbineRifle->WeaponFlags1}");
            Game.LogTrivial($"Carbine rifle flags 2: {CarbineRifle->WeaponFlags2}");
            Game.LogTrivial($"Carbine rifle flags 3: {CarbineRifle->WeaponFlags3}");
            SetWeaponFlag(CarbineRifle, eWeaponFlags1.OnlyFireOneShot, false);
            SetWeaponFlag(CarbineRifle, eWeaponFlags1.Automatic, true);
            SetWeaponFlag(CarbineRifle, eWeaponFlags1.OnlyFireOneShotPerTriggerPress, false);

            if (Game.LocalPlayer.Character.Inventory.EquippedWeapon == null) return;
            CPed* ped = (CPed*)Game.LocalPlayer.Character.MemoryAddress;
            CWeaponInfo* playerGun = ped->weaponManager->weaponInfo;
            Game.LogTrivial($"Player's weapon hash: {(WeaponHash)playerGun->Name}");
            Game.LogTrivial($"Address are the same: {(IntPtr)playerGun == (IntPtr)CarbineRifle}");
            /*CWeaponInfo carbine = *playerGun;
            carbine.WeaponFlags1 |= eWeaponFlags1.OnlyFireOneShotPerTriggerPress;
            ped->weaponManager->weaponInfo = &carbine;*/
            


            while (true)
            {
                GameFiber.Yield();
                if (Game.LocalPlayer.Character.Inventory.EquippedWeapon == null) continue;
                CWeaponInfo* newPlayerGun = ped->weaponManager->weaponInfo;
                SetWeaponFlag(newPlayerGun, eWeaponFlags1.OnlyFireOneShotPerTriggerPress, true);
                Game.DisplaySubtitle($"Address are the same: {(IntPtr)newPlayerGun == (IntPtr)CarbineRifle}");
                if (Game.IsKeyDown(Keys.End)) Game.UnloadActivePlugin();
            }
        }

        public static void Exit()
        {
            CarbineRifle->Speed = OriginalTimeBetweenShots;
        }

        public static void SetWeaponFlag(CWeaponInfo* weapon, eWeaponFlags1 flag, bool enable)
        {
            if (enable) weapon->WeaponFlags1 |= flag;
            else weapon->WeaponFlags1 &= ~flag;
        }

        public static void SetWeaponFlag(CWeaponInfo* weapon, eWeaponFlags2 flag, bool enable)
        {
            if (enable) weapon->WeaponFlags2 |= flag;
            else weapon->WeaponFlags2 &= ~flag;
        }

        public static void SetWeaponFlag(CWeaponInfo* weapon, eWeaponFlags3 flag, bool enable)
        {
            if (enable) weapon->WeaponFlags3 |= flag;
            else weapon->WeaponFlags3 &= ~flag;
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
