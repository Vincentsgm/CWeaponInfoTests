using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWeaponInfoTests
{
    [Flags]
    public enum eWeaponFlags1 : ulong
    {
        None = 0,

        CarriedInHand = 0x0000000000000001,
        Automatic = 0x0000000000000002,
        Silenced = 0x0000000000000004,
        FirstPersonScope = 0x0000000000000008,

        ArmourPenetrating = 0x0000000000000010,
        ApplyBulletForce = 0x0000000000000020,
        Gun = 0x0000000000000040,
        CanLockonOnFoot = 0x0000000000000080,

        CanLockonInVehicle = 0x0000000000000100,
        Homing = 0x0000000000000200,
        CanFreeAim = 0x0000000000000400,
        Heavy = 0x0000000000000800,

        TwoHanded = 0x0000000000001000,
        Launched = 0x0000000000002000,
        MeleeBlade = 0x0000000000004000,
        MeleeClub = 0x0000000000008000,

        AnimReload = 0x0000000000010000,
        AnimCrouchFire = 0x0000000000020000,
        CreateVisibleOrdnance = 0x0000000000040000,
        TreatAsOneHandedInCover = 0x0000000000080000,

        // unk = 0x0000000000100000,
        Thrown = 0x0000000000200000,
        // unk = 0x0000000000400000,
        UsableOnFoot = 0x0000000000800000,

        UsableUnderwater = 0x0000000001000000,
        UsableClimbing = 0x0000000002000000,
        UsableInCover = 0x0000000004000000,
        AllowEarlyExitFromFireAnimAfterBulletFired = 0x0000000008000000,

        DisableRightHandIk = 0x0000000010000000,
        DisableLeftHandIkInCover = 0x0000000020000000,
        DontSwapWeaponIfNoAmmo = 0x0000000040000000,
        // unk = 0x0000000080000000,

        DoesRevivableDamage = 0x0000000100000000,
        NoFriendlyFireDamage = 0x0000000200000000,
        // unk = 0x0000000400000000,
        DisplayRechargeTimeHUD = 0x0000000800000000,

        OnlyFireOneShot = 0x0000001000000000,
        OnlyFireOneShotPerTriggerPress = 0x0000002000000000,
        UseLegDamageVoice = 0x0000004000000000,
        // unk = 0x0000008000000000,

        CanBeFiredLikeGun = 0x0000010000000000,
        OnlyAllowFiring = 0x0000020000000000,
        // unk = 0x0000040000000000,
        NoLeftHandIKWhenBlocked = 0x0000080000000000,

        // unk  = 0x0000100000000000,
        // unk  = 0x0000200000000000,
        Vehicle = 0x0000400000000000,
        EnforceAimingRestrictions = 0x0000800000000000,

        ForceEjectShellAfterFiring = 0x0001000000000000,
        NonViolent = 0x0002000000000000,
        NonLethal = 0x0004000000000000,
        Scary = 0x0008000000000000,

        AllowCloseQuarterKills = 0x0010000000000000,
        DisablePlayerBlockingInMP = 0x0020000000000000,
        StaticReticulePosition = 0x0040000000000000,
        CanPerformArrest = 0x0080000000000000,

        // unk = 0x0100000000000000,
        AllowMeleeIntroAnim = 0x0200000000000000,
        ManualDetonation = 0x0400000000000000,
        SuppressGunshotEvent = 0x0800000000000000,

        HiddenFromWeaponWheel = 0x1000000000000000,
        // unk = 0x2000000000000000,
        NeedsGunCockingInCover = 0x4000000000000000,
        ThrowOnly = 0x8000000000000000,
    }

    [Flags]
    public enum eWeaponFlags2 : ulong
    {
        None = 0,

        NoAutoRunWhenFiring = 0x0000000000000001,
        DisableIdleVariations = 0x0000000000000002,
        HasLowCoverReloads = 0x0000000000000004,
        HasLowCoverSwaps = 0x0000000000000008,

        DontBreakRopes = 0x0000000000000010,
        CookWhileAiming = 0x0000000000000020,
        UseLeftHandIkWhenAiming = 0x0000000000000040,
        DropWhenCooked = 0x0000000000000080,

        NotAWeapon = 0x0000000000000100,
        RemoveEarlyWhenEnteringVehicles = 0x0000000000000200,
        DontBlendFireOutro = 0x0000000000000400,
        DiscardWhenOutOfAmmo = 0x0000000000000800,

        DelayedFiringAfterAutoSwap = 0x0000000000001000,
        EnforceFiringAngularThreshold = 0x0000000000002000,
        ForcesActionMode = 0x0000000000004000,
        CreatesAPotentialExplosionEventWhenFired = 0x0000000000008000,

        CreateBulletExplosionWhenOutOfTime = 0x0000000000010000,
        DelayedFiringAfterAutoSwapPreviousWeapon = 0x0000000000020000,
        DisableCombatRoll = 0x0000000000040000,
        NoWheelStats = 0x0000000000080000,

        ProcessGripAnim = 0x0000000000100000,
        DisableStealth = 0x0000000000200000,
        DangerousLookingMeleeWeapon = 0x0000000000400000,
        QuitTransitionToIdleIntroOnWeaponChange = 0x0000000000800000,

        DisableLeftHandIkWhenOnFoot = 0x0000000001000000,
        IgnoreHelmets = 0x0000000002000000,
        Rpg = 0x0000000004000000,
        NoAmmoDisplay = 0x0000000008000000,

        TorsoIKForWeaponBlock = 0x0000000010000000,
        LongWeapon = 0x0000000020000000,
        // unk = 0x0000000040000000,
        // unk = 0x0000000080000000,

        // unk = 0x0000000100000000,
        AssistedAimVehicleWeapon = 0x0000000200000000,
        CanBlowUpVehicleAtZeroBodyHealth = 0x0000000400000000,
        IgnoreAnimReloadRateModifiers = 0x0000000800000000,

        DisableIdleAnimationFilter = 0x0000001000000000,
        // unk = 0x0000002000000000,
        // unk = 0x0000004000000000,
        HomingToggle = 0x0000008000000000,

        ApplyVehicleDamageToEngine = 0x0000010000000000,
        Turret = 0x0000020000000000,
        DisableAimAngleChecksForReticule = 0x0000040000000000,
        // unk = 0x0000080000000000,

        DriveByMPOnly = 0x0000100000000000,
        // unk = 0x0000200000000000,
        CreateWeaponWithNoModel = 0x0000400000000000,
        RemoveWhenUnequipped = 0x0000800000000000,

        BlockAmbientIdles = 0x0001000000000000,
        NotUnarmed = 0x0002000000000000,
        UseFPSAimIK = 0x0004000000000000,
        DisableFPSScope = 0x0008000000000000,

        DisableFPSAimForScope = 0x0010000000000000,
        EnableFPSRNGOnly = 0x0020000000000000,
        EnableFPSIdleOnly = 0x0040000000000000,
        MeleeHatchet = 0x0080000000000000,

        UseAlternateFPDrivebyClipset = 0x0100000000000000,
        AttachFPSLeftHandIKToRight = 0x0200000000000000,
        OnlyUseAimingInfoInFPS = 0x0400000000000000,
        UseFPSAnimatedRecoil = 0x0800000000000000,

        UseFPSSecondaryMotion = 0x1000000000000000,
        HasFPSProjectileWeaponAnims = 0x2000000000000000,
        AllowMeleeBlock = 0x4000000000000000,
        DontPlayDryFireAnim = 0x8000000000000000,
    }

    [Flags]
    public enum eWeaponFlags3 : uint
    {
        None = 0,

        SwapToUnarmedWhenOutOfThrownAmmo = 0x00000001,
        // unk = 0x00000002,
        DisableIdleAnimationFilterWhenReloading = 0x00000004,
        OnFootHoming = 0x00000008,

        DamageCausesDisputes = 0x00000010,
        UsePlaneExplosionDamageCapInMP = 0x00000020,
        FPSOnlyExitFireAnimAfterRecoilEnds = 0x00000040,
        SkipVehiclePetrolTankDamage = 0x00000080,

        DontAutoSwapOnPickUp = 0x00000100,
        DisableTorsoIKAboveAngleThreshold = 0x00000200,
        MeleeFist = 0x00000400,
        NotAllowedForDriveby = 0x00000800,

        // unk = 0x00001000,
        CanBeAimedLikeGunWithoutFiring = 0x00002000,
        MeleeMachete = 0x00004000,
        HideReticule = 0x00008000,

        UseHolsterAnimation = 0x00010000,
        BlockFirstPersonStateTransitionWhileFiring = 0x00020000,
        ForceFullFireAnimation = 0x00040000,
        DisableLeftHandIkInDriveby = 0x00080000,

        CanUseInVehMelee = 0x00100000,
        UseVehicleWeaponBoneForward = 0x00200000,
        UseManualTargetingMode = 0x00400000,
        IgnoreTracerVfxMuzzleDirectionCheck = 0x00800000,

        IgnoreHomingCloseThresholdCheck = 0x01000000,
        LockOnRequiresAim = 0x02000000,
        DisableCameraPullAround = 0x04000000,
        VehicleChargedLaunch = 0x08000000,

        ForcePedAsFiringEntity = 0x10000000,
        // unk = 0x20000000,
        // unk = 0x40000000,
        // unk = 0x80000000,
    }
}
