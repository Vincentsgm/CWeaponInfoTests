﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Rage;
using static Rage.Native.NativeFunction;
using System.Runtime.InteropServices;
using EasyHook;

[assembly: Rage.Attributes.Plugin("CWeaponInfoTests", EntryPoint = "CWeaponInfoTests.EntryPoint.Main", ExitPoint = "CWeaponInfoTests.EntryPoint.Exit", PrefersSingleInstance = true)]

namespace CWeaponInfoTests
{
    internal unsafe static class EntryPoint
    {
        public static Ped MainPlayer => Game.LocalPlayer.Character;
        static bool SingleShot = false;
        static CPed* PlayerPed;

        public static string CWeaponInfoPattern = "48 8B 05 ?? ?? ?? ?? 41 8B 1E";
        public static atArrayOfPtrs<CWeaponInfo>* Weapons;
        public static IntPtr WeaponsAddress;
        public static CWeaponInfo* CarbineRifle;
        public static float OriginalTimeBetweenShots = 2000f;

        static Vector3 originalRNGOffset = new Vector3(0f, 0f, 0.01f);
        static Vector3 originalRNGRotationOffset = new Vector3(1.5f, 0f, 2f);
        static Vector3 originalLTOffset = new Vector3(0f, 0f, -0.035f);
        static Vector3 originalLTRotationOffset = new Vector3(1.5f, 0f, 2.5f);
        static Vector3 originalScopeOffset = new Vector3(0f, -0.02f, -0.023f);
        static Vector3 originalScopeAttachmentOffset = new Vector3(0f, -0.01f, -0.028f);
        static Vector3 originalScopeRotationOffset = new Vector3(-0.7f, 0f, 0f);
        static Vector3 originalScopeAttachmentRotationOffset = new Vector3(0f, 0f, 0f);

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
            CarbineRifle = GetWeaponInfo(WeaponHash.CarbineRifle);

            InitTaskAimGunOnFootHooks();

            originalRNGOffset = CarbineRifle->FirstPersonRNGOffset;
            originalRNGRotationOffset = CarbineRifle->FirstPersonRNGRotationOffset;
            originalLTOffset = CarbineRifle->FirstPersonLTOffset;
            originalLTRotationOffset = CarbineRifle->FirstPersonLTRotationOffset;
            originalScopeOffset = CarbineRifle->FirstPersonScopeOffset;
            originalScopeAttachmentOffset = CarbineRifle->FirstPersonScopeAttachmentOffset;
            originalScopeRotationOffset = CarbineRifle->FirstPersonScopeRotationOffset;
            originalScopeAttachmentRotationOffset = CarbineRifle->FirstPersonScopeAttachmentRotationOffset;

            Game.LogTrivial(originalRNGOffset.ToString());
            Game.LogTrivial(originalRNGRotationOffset.ToString());
            Game.LogTrivial(originalLTOffset.ToString());
            Game.LogTrivial(originalLTRotationOffset.ToString());
            Game.LogTrivial(originalScopeOffset.ToString());
            Game.LogTrivial(originalScopeAttachmentOffset.ToString());
            Game.LogTrivial(originalScopeRotationOffset.ToString());
            Game.LogTrivial(originalScopeAttachmentRotationOffset.ToString());
            /*SetWeaponFlag(CarbineRifle, eWeaponFlags1.OnlyFireOneShot, false);
            SetWeaponFlag(CarbineRifle, eWeaponFlags1.Automatic, true);
            SetWeaponFlag(CarbineRifle, eWeaponFlags1.OnlyFireOneShotPerTriggerPress, false);*/

            if (Game.LocalPlayer.Character.Inventory.EquippedWeapon == null) return;
            CPed* ped = (CPed*)Game.LocalPlayer.Character.MemoryAddress;
            CWeaponInfo* playerGun = ped->weaponManager->weaponInfo;
            Game.LogTrivial($"Address are the same: {(IntPtr)playerGun == (IntPtr)CarbineRifle}");
            IntPtr flagsAddress = (IntPtr)(&(playerGun->WeaponFlags1));
            Game.SetClipboardText(flagsAddress.ToString("X16"));
            /*CWeaponInfo carbine = *playerGun;
            carbine.WeaponFlags1 |= eWeaponFlags1.OnlyFireOneShotPerTriggerPress;
            ped->weaponManager->weaponInfo = &carbine;*/



            while (true)
            {
                GameFiber.Yield();
                PlayerPed = (CPed*)MainPlayer.MemoryAddress;
                /*if (Game.LocalPlayer.Character.Inventory.EquippedWeapon == null) continue;
                CWeaponInfo* newPlayerGun = ped->weaponManager->weaponInfo;
                SetWeaponFlag(newPlayerGun, eWeaponFlags1.OnlyFireOneShotPerTriggerPress, true);
                Game.DisplaySubtitle($"Address are the same: {(IntPtr)newPlayerGun == (IntPtr)CarbineRifle}");
                if (Game.IsKeyDown(Keys.End)) Game.UnloadActivePlugin();*/

                var weapon = Game.LocalPlayer.Character.Inventory.EquippedWeaponObject;
                if (weapon)
                {
                    Game.DisplaySubtitle($"Position: {weapon.Position}\nRotation: {weapon.Rotation}");
                }

                if (Game.IsKeyDown(Keys.G))
                {
                    SingleShot = !SingleShot;
                    //SetWeaponFlag(CarbineRifle, eWeaponFlags1.OnlyFireOneShotPerTriggerPress, true);
                }

                if (Game.IsKeyDownRightNow(Keys.A))
                {
                    CarbineRifle->FirstPersonRNGOffset = new Vector3(-0.07f, 0f, 0.07f);
                    CarbineRifle->FirstPersonRNGRotationOffset = new Vector3(-6.5f, -1f, -4.7f);
                    CarbineRifle->FirstPersonLTOffset = new Vector3(-0.015f, -13.8f, 0.03f);
                    CarbineRifle->FirstPersonLTRotationOffset = new Vector3(-4.5f, -30f, -1.3f);
                    CarbineRifle->FirstPersonScopeOffset = new Vector3(0f, 0.07f, -0.025f);
                    CarbineRifle->FirstPersonScopeAttachmentOffset = new Vector3(0f, 0.15f, -0.03f);
                    CarbineRifle->FirstPersonScopeRotationOffset = new Vector3(0f, 0f, 0.0f);
                    CarbineRifle->FirstPersonScopeAttachmentRotationOffset = new Vector3(0f, 0f, 0f);

                    /*Game.LocalPlayer.Character.MovementAnimationSet = "weapons@heavy@rpg";
                    SetWeaponMovementClipset(Game.LocalPlayer.Character, "weapons@rifle@lo@carbine@stealth");*/
                }
                else
                {
                    ApplyDefaultRotations();
                }
            }
        }

        private static CWeaponInfo* GetWeaponInfo(WeaponHash weapon)
        {
            for (int i = 0; i < Weapons->Count; i++)
            {
                CWeaponInfo* wp = Weapons->Items[i];
                if (wp->Name == (uint)weapon)
                {
                    return wp;
                }
            }
            return null;
        }

        private delegate long CTaskAimGunOnFoot__Firing_OnUpdate_delegate(CTask* task, IntPtr a2, IntPtr a3);
        private static CTaskAimGunOnFoot__Firing_OnUpdate_delegate CTaskAimGunOnFoot__Firing_OnUpdate_orig;
        private static LocalHook hkCTaskAimGunOnFoot__Firing_OnUpdate = null;
        private static bool InitTaskAimGunOnFootHooks()
        {
            IntPtr addr = Game.FindPattern("48 8B C4 55 53 56 57 41 54 41 55 41 56 41 57 48 8D 68 A1 48 81 EC D8 00 00 00 48 8B F9");
            if (addr == IntPtr.Zero)
            {
                Game.LogTrivial("Can't find address for CTaskAimGunOnFoot__Firing_OnUpdate");
                return false;
            }
            CTaskAimGunOnFoot__Firing_OnUpdate_delegate detour = CTaskAimGunOnFoot__Firing_OnUpdate_Detour;
            hkCTaskAimGunOnFoot__Firing_OnUpdate = LocalHook.Create(addr, detour, null);
            hkCTaskAimGunOnFoot__Firing_OnUpdate.ThreadACL.SetExclusiveACL(new[] { 0 });
            return true;
        }

        private static long CTaskAimGunOnFoot__Firing_OnUpdate_Detour(CTask* task, IntPtr a2, IntPtr a3)
        {
            var ped = task->Owner;
            if (ped != PlayerPed) return CTaskAimGunOnFoot__Firing_OnUpdate_orig(task, a2, a3);
            var wpnManager = ped->weaponManager;
            var currentWeapon = wpnManager->weaponInfo;
            bool isSingleShot = currentWeapon != null ? GetWeaponFlag(currentWeapon, eWeaponFlags1.OnlyFireOneShotPerTriggerPress) : false;
            if (currentWeapon != null)
            {
                SetWeaponFlag(currentWeapon, eWeaponFlags1.OnlyFireOneShotPerTriggerPress, SingleShot);
            }
            var result = CTaskAimGunOnFoot__Firing_OnUpdate_orig(task, a2, a3);
            if (currentWeapon != null)
            {
                SetWeaponFlag(currentWeapon, eWeaponFlags1.OnlyFireOneShotPerTriggerPress, isSingleShot);
            }
            return result;
        }

        private static void ApplyDefaultRotations()
        {
            CarbineRifle->FirstPersonRNGOffset = originalRNGOffset;
            CarbineRifle->FirstPersonRNGRotationOffset = originalRNGRotationOffset;
            CarbineRifle->FirstPersonLTOffset = originalLTOffset;
            CarbineRifle->FirstPersonLTRotationOffset = originalLTRotationOffset;
            CarbineRifle->FirstPersonScopeOffset = originalScopeOffset;
            CarbineRifle->FirstPersonScopeAttachmentOffset = originalScopeAttachmentOffset;
            CarbineRifle->FirstPersonScopeRotationOffset = originalScopeRotationOffset;
            CarbineRifle->FirstPersonScopeAttachmentRotationOffset = originalScopeAttachmentRotationOffset;
            /*SetWeaponMovementClipset(Game.LocalPlayer.Character, string.Empty);
            Game.LocalPlayer.Character.MovementAnimationSet = "move_ballistic_2h";*/
        }

        public static void Exit()
        {
            ApplyDefaultRotations();
            if (hkCTaskAimGunOnFoot__Firing_OnUpdate != null)
            {
                hkCTaskAimGunOnFoot__Firing_OnUpdate.Dispose();
                hkCTaskAimGunOnFoot__Firing_OnUpdate = null;
            }
            LocalHook.Release();
        }

        public static void ResetMovementClipset(this Ped ped) => Natives.RESET_PED_MOVEMENT_CLIPSET(ped, 0.0f);

        public static void SetStrafeClipset(Ped ped, string clipset)
        {
            if (clipset != string.Empty)
            {
                new AnimationSet(clipset).LoadAndWait();
                Natives.SET_PED_STRAFE_CLIPSET(ped, clipset);
            }
            else Natives.RESET_PED_STRAFE_CLIPSET(ped);
        }

        public static void SetWeaponMovementClipset(Ped ped, string clipset, bool loadClipset = true)
        {
            if (clipset != string.Empty)
            {
                if (loadClipset) new AnimationSet(clipset).LoadAndWait();
                Natives.SET_PED_WEAPON_MOVEMENT_CLIPSET(ped, clipset);
            }
            else Natives.RESET_PED_WEAPON_MOVEMENT_CLIPSET(ped);
        }

        public static void SetAlternateWalkAnim(Ped ped, string animDict, string animName, bool loadClipset = true)
        {
            if (animDict != string.Empty)
            {
                if (loadClipset) Natives.REQUEST_ANIM_SET(animDict);
                Natives.SET_PED_ALTERNATE_WALK_ANIM(ped, animDict, animName, 1f, false);
            }
            else Natives.CLEAR_PED_ALTERNATE_WALK_ANIM(ped, 1f);
        }

        public static void SetWeaponFlag(CWeaponInfo* weapon, eWeaponFlags1 flag, bool enable)
        {
            if (enable) weapon->WeaponFlags1 |= flag;
            else weapon->WeaponFlags1 &= ~flag;
        }

        public static bool GetWeaponFlag(CWeaponInfo* weapon, eWeaponFlags1 flag)
        {
            return weapon->WeaponFlags1.HasFlag(flag);
        }

        public static void SetWeaponFlag(CWeaponInfo* weapon, eWeaponFlags2 flag, bool enable)
        {
            if (enable) weapon->WeaponFlags2 |= flag;
            else weapon->WeaponFlags2 &= ~flag;
        }

        public static bool GetWeaponFlag(CWeaponInfo* weapon, eWeaponFlags2 flag)
        {
            return weapon->WeaponFlags2.HasFlag(flag);
        }

        public static void SetWeaponFlag(CWeaponInfo* weapon, eWeaponFlags3 flag, bool enable)
        {
            if (enable) weapon->WeaponFlags3 |= flag;
            else weapon->WeaponFlags3 &= ~flag;
        }

        public static bool GetWeaponFlag(CWeaponInfo* weapon, eWeaponFlags3 flag)
        {
            return weapon->WeaponFlags3.HasFlag(flag);
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
