using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CWeaponInfoTests
{

    public enum eWeaponDamageType : uint
    {
        UNKNOWN = 0,
        NONE = 1,
        MELEE = 2,
        BULLET = 3,
        UNK_4 = 4,
        EXPLOSIVE = 5,
        FIRE = 6,
        UNK_7 = 7,
        FALL = 8,
        UNK_9 = 9,
        ELECTRIC = 10,
        BARBED_WIRE = 11,
        FIRE_EXTINGUISHER = 12,
        SMOKE = 13,
        WATER_CANNON = 14
    }

    public enum eWeaponFireType : uint
    {
        NONE = 0,
        MELEE = 1,
        INSTANT_HIT = 2,
        DELAYED_HIT = 3,
        PROJECTILE = 4,
        VOLUMETRIC_PARTICLE = 5,
    }

    public enum eWeaponWheelSlot : uint
    {
        PISTOL = 0,
        SMG = 1,
        RIFLE = 2,
        SNIPER = 3,
        UNARMED_MELEE = 4,
        SHOTGUN = 5,
        HEAVY = 6,
        THROWABLE_SPECIAL = 7,
    }

    public enum eWeaponEffectGroup : uint
    {
        PUNCH_KICK = 0,
        MELEE_WOOD = 1,
        MELEE_METAL = 1,
        MELEE_SHARP = 3,
        // = 4,
        PISTOL_SMALL = 5,
        PISTOL_LARGE = 6,
        // = 7,
        // = 8,
        SMG = 9,
        SHOTGUN = 10,
        RIFLE_ASSAULT = 11,
        RIFLE_SNIPER = 12,
        ROCKET = 13,
        GRENADE = 14,
        MOLOTOV = 15,
        // = 16,
        EXPLOSION = 17,
        LASER = 18,
        STUNGUN = 19,
        HEAVY_MG = 20,
        VEHICLE_MG = 21,
    }

    [StructLayout(LayoutKind.Explicit, Size = 2384)]
    public unsafe struct CWeaponInfo
    {
        [FieldOffset(0x0010)] public uint Name;
        [FieldOffset(0x0014)] public uint Model;
        [FieldOffset(0x0018)] public uint Audio;
        [FieldOffset(0x001C)] public uint Slot;
        [FieldOffset(0x0020)] public eWeaponDamageType DamageType;
        [FieldOffset(0x0024)] public CItemExplosionInfo Explosion;

        [FieldOffset(0x0054)] public eWeaponFireType FireType;
        [FieldOffset(0x0058)] public eWeaponWheelSlot WheelSlot;
        [FieldOffset(0x005C)] public uint Group;
        [FieldOffset(0x0060)] public CAmmoInfo* AmmmoInfo;
        [FieldOffset(0x0068)] public CAimingInfo* AimingInfo;
        [FieldOffset(0x0070)] public int ClipSize;
        [FieldOffset(0x0074)] public float AccuracySpread;
        [FieldOffset(0x0078)] public float AccuracyModeAccuracyModifier;
        [FieldOffset(0x007C)] public float RunAndGunAccuracyModifier;
        [FieldOffset(0x0080)] public float RunAndGunAccuracyMinOverride;
        [FieldOffset(0x0084)] public float RecoilAccuracyMax;
        [FieldOffset(0x0088)] public float RecoilErrorTime;
        [FieldOffset(0x008C)] public float RecoilRecoveryRate;
        [FieldOffset(0x0090)] public float RecoilAccuracyToAllowHeadShotAI;
        [FieldOffset(0x0094)] public float MinHeadShotDistanceAI;
        [FieldOffset(0x0098)] public float MaxHeadShotDistanceAI;
        [FieldOffset(0x009C)] public float HeadShotDamageModifierAI;
        [FieldOffset(0x00A0)] public float RecoilAccuracyToAllowHeadShotPlayer;
        [FieldOffset(0x00A4)] public float MinHeadShotDistancePlayer;
        [FieldOffset(0x00A8)] public float MaxHeadShotDistancePlayer;
        [FieldOffset(0x00AC)] public float HeadShotDamageModifierPlayer;
        [FieldOffset(0x00B0)] public float Damage;
        [FieldOffset(0x00B4)] public float DamageTime;
        [FieldOffset(0x00B8)] public float DamageTimeInVehicle;
        [FieldOffset(0x00BC)] public float DamageTimeInVehicleHeadShot;
        [FieldOffset(0x00C0)] public float HitLimbsDamageModifier;
        [FieldOffset(0x00C4)] public float NetworkHitLimbsDamageModifier;
        [FieldOffset(0x00C8)] public float LightlyArmouredDamageModifier;

        [FieldOffset(0x00D0)] public float Force;
        [FieldOffset(0x00D4)] public float ForceHitPed;
        [FieldOffset(0x00D8)] public float ForceHitVehicle;
        [FieldOffset(0x00DC)] public float ForceHitFlyingHeli;
        [FieldOffset(0x00E0)] public CSimpleArray_OverrideForce OverrideForces;

        [FieldOffset(0x00F0)] public float ForceMaxStrengthMult;
        [FieldOffset(0x00F4)] public float ForceFalloffRangeStart;
        [FieldOffset(0x00F8)] public float ForceFalloffRangeEnd;
        [FieldOffset(0x00FC)] public float ForceFalloffMin;
        [FieldOffset(0x0100)] public float ProjectileForce;
        [FieldOffset(0x0104)] public float FragImpulse;
        [FieldOffset(0x0108)] public float Penetration;
        [FieldOffset(0x010C)] public float VerticalLaunchAdjustment;
        [FieldOffset(0x0110)] public float DropForwardVelocity;
        [FieldOffset(0x011C)] public float Speed;
        [FieldOffset(0x0118)] public int BulletsInBatch;
        [FieldOffset(0x011C)] public float BatchSpread;
        [FieldOffset(0x0120)] public float ReloadTimeMP;
        [FieldOffset(0x0124)] public float ReloadTimeSP;
        [FieldOffset(0x0128)] public float VehicleReloadTime;
        [FieldOffset(0x012C)] public float AnimReloadRate;
        [FieldOffset(0x0138)] public int BulletsPerAnimLoop;
        [FieldOffset(0x013C)] public float TimeBetweenShots;
        [FieldOffset(0x0138)] public float TimeLeftBetweenShotsWhereShouldFireIsCached;
        [FieldOffset(0x013C)] public float SpinUpTime;
        [FieldOffset(0x0140)] public float SpinTime;
        [FieldOffset(0x0144)] public float SpinDownTime;
        [FieldOffset(0x0148)] public float AlternateWaitTime;
        [FieldOffset(0x014C)] public float BulletBendingNearRadius;
        [FieldOffset(0x0150)] public float BulletBendingFarRadius;
        [FieldOffset(0x0154)] public float BulletBendingZoomedRadius;
        [FieldOffset(0x0158)] public float FirstPersonBulletBendingNearRadius;
        [FieldOffset(0x015C)] public float FirstPersonBulletBendingFarRadius;
        [FieldOffset(0x0160)] public float FirstPersonBulletBendingZoomedRadius;

        [FieldOffset(0x0170)] public FxInfo Fx;

        [FieldOffset(0x0240)] public int InitialRumbleDuration;
        [FieldOffset(0x0244)] public float InitialRumbleIntensity;
        [FieldOffset(0x0248)] public float InitialRumbleIntensityTrigger;
        [FieldOffset(0x024C)] public int RumbleDuration;
        [FieldOffset(0x0250)] public float RumbleIntensity;
        [FieldOffset(0x0254)] public float RumbleIntensityTrigger;
        [FieldOffset(0x0258)] public float RumbleDamageIntensity;
        [FieldOffset(0x025C)] public int InitialRumbleDurationFps;
        [FieldOffset(0x0260)] public float InitialRumbleIntensityFps;
        [FieldOffset(0x0264)] public int RumbleDurationFps;
        [FieldOffset(0x0268)] public float RumbleIntensityFps;
        [FieldOffset(0x026C)] public float NetworkPlayerDamageModifier;
        [FieldOffset(0x0270)] public float NetworkPedDamageModifier;
        [FieldOffset(0x0274)] public float NetworkHeadShotPlayerDamageModifier;
        [FieldOffset(0x0278)] public float LockOnRange;
        [FieldOffset(0x027C)] public float WeaponRange;
        [FieldOffset(0x0290)] public float AiSoundRange;
        [FieldOffset(0x0284)] public float AiPotentialBlastEventRange;
        [FieldOffset(0x0288)] public float DamageFallOffRangeMin;
        [FieldOffset(0x028C)] public float DamageFallOffRangeMax;

        [FieldOffset(0x0294)] public float DamageFallOffModifier;
        [FieldOffset(0x0298)] public uint VehicleWeaponHash;
        [FieldOffset(0x029C)] public uint DefaultCameraHash;

        [FieldOffset(0x02A8)] public uint CoverCameraHash;
        [FieldOffset(0x02AC)] public uint CoverReadyToFireCameraHash;
        [FieldOffset(0x02B0)] public uint RunAndGunCameraHash;
        [FieldOffset(0x02B4)] public uint CinematicShootingCameraHash;
        [FieldOffset(0x02B8)] public uint AlternativeOrScopedCameraHash;
        [FieldOffset(0x02BC)] public uint RunAndGunAlternativeOrScopedCameraHash;
        [FieldOffset(0x02C0)] public uint CinematicShootingAlternativeOrScopedCameraHash;

        [FieldOffset(0x02C8)] public uint RecoilShakeHash;
        [FieldOffset(0x02CC)] public uint RecoilShakeHashFirstPerson;
        [FieldOffset(0x02D0)] public uint AccuracyOffsetShakeHash;
        [FieldOffset(0x02D4)] public int MinTimeBetweenRecoilShakes;
        [FieldOffset(0x02D8)] public float RecoilShakeAmplitude;
        [FieldOffset(0x02DC)] public float ExplosionShakeAmplitude;
        [FieldOffset(0x02E0)] public float CameraFov;

        [FieldOffset(0x02EC)] public float FirstPersonScopeFov;

        [FieldOffset(0x0310)] public NativeVector3Float FirstPersonRNGOffset;
        [FieldOffset(0x0320)] public NativeVector3Float FirstPersonRNGRotationOffset;
        [FieldOffset(0x0330)] public NativeVector3Float FirstPersonLTOffset;
        [FieldOffset(0x0340)] public NativeVector3Float FirstPersonLTRotationOffset;
        [FieldOffset(0x0350)] public NativeVector3Float FirstPersonScopeOffset;
        [FieldOffset(0x0360)] public NativeVector3Float FirstPersonScopeAttachmentOffset;
        [FieldOffset(0x0370)] public NativeVector3Float FirstPersonScopeRotationOffset;
        [FieldOffset(0x0380)] public NativeVector3Float FirstPersonScopeAttachmentRotationOffset;
        [FieldOffset(0x0390)] public NativeVector3Float FirstPersonAsThirdPersonIdleOffset;
        [FieldOffset(0x03A0)] public NativeVector3Float FirstPersonAsThirdPersonRNGOffset;
        [FieldOffset(0x03B0)] public NativeVector3Float FirstPersonAsThirdPersonLTOffset;
        [FieldOffset(0x03C0)] public NativeVector3Float FirstPersonAsThirdPersonScopeOffset;
        [FieldOffset(0x03D0)] public NativeVector3Float FirstPersonAsThirdPersonWeaponBlockedOffset;
        [FieldOffset(0x03E0)] public float FirstPersonDofSubjectMagnificationPowerFactorNear;
        [FieldOffset(0x03E4)] public float FirstPersonDofMaxNearInFocusDistance;
        [FieldOffset(0x03E8)] public float FirstPersonDofMaxNearInFocusDistanceBlendLevel;

        [FieldOffset(0x0400)] public float ZoomFactorForAccurateMode;

        [FieldOffset(0x0410)] public NativeVector3Float AimOffsetMin;
        [FieldOffset(0x0420)] public NativeVector3Float AimOffsetMax;
        [FieldOffset(0x0430)] public NativeVector2Float TorsoAimOffset;
        [FieldOffset(0x0438)] public NativeVector2Float TorsoCrouchedAimOffset;
        [FieldOffset(0x0440)] public float AimProbeLengthMin;
        [FieldOffset(0x0444)] public float AimProbeLengthMax;

        [FieldOffset(0x0450)] public NativeVector3Float AimOffsetMinFPSIdle;
        [FieldOffset(0x0460)] public NativeVector3Float AimOffsetMedFPSIdle;
        [FieldOffset(0x0470)] public NativeVector3Float AimOffsetMaxFPSIdle;
        [FieldOffset(0x0480)] public NativeVector3Float AimOffsetMinFPSLT;
        [FieldOffset(0x0490)] public NativeVector3Float AimOffsetMaxFPSLT;
        [FieldOffset(0x04A0)] public NativeVector3Float AimOffsetMinFPSRNG;
        [FieldOffset(0x04B0)] public NativeVector3Float AimOffsetMaxFPSRNG;
        [FieldOffset(0x04C0)] public NativeVector3Float AimOffsetMinFPSScope;
        [FieldOffset(0x04D0)] public NativeVector3Float AimOffsetMaxFPSScope;
        [FieldOffset(0x04E0)] public NativeVector3Float AimOffsetEndPosMinFPSIdle;
        [FieldOffset(0x04F0)] public NativeVector3Float AimOffsetEndPosMedFPSIdle;
        [FieldOffset(0x0500)] public NativeVector3Float AimOffsetEndPosMaxFPSIdle;

        [FieldOffset(0x0560)] public NativeVector3Float LeftHandIkOffset;

        [FieldOffset(0x0570)] public float IkRecoilDisplacement;
        [FieldOffset(0x0574)] public float IkRecoilDisplacementScope;
        [FieldOffset(0x0578)] public float IkRecoilDisplacementScaleBackward;
        [FieldOffset(0x057C)] public float IkRecoilDisplacementScaleVertical;
        [FieldOffset(0x0580)] public NativeVector2Float ReticuleHudPosition;
        [FieldOffset(0x0588)] public NativeVector2Float ReticuleHudPositionOffsetForPOVTurret;
        [FieldOffset(0x0590)] public float ReticuleMinSizeStanding;
        [FieldOffset(0x0594)] public float ReticuleMinSizeCrouched;
        [FieldOffset(0x0598)] public float ReticuleScale;
        [FieldOffset(0x059C)] public uint ReticuleStyleHash;
        [FieldOffset(0x05A0)] public uint FirstPersonReticuleStyleHash;
        [FieldOffset(0x05A4)] public uint PickupHash;
        [FieldOffset(0x05A8)] public uint MPPickupHash;
        [FieldOffset(0x05AC)] public uint HumanNameHash;

        [FieldOffset(0x05B4)] public uint MovementModeConditionalIdle;

        [FieldOffset(0x05E0)] private IntPtr statNameStrPtr;
        [FieldOffset(0x05E8)] public int KnockdownCount;
        [FieldOffset(0x05EC)] public float KillshotImpulseScale;
        [FieldOffset(0x05F0)] public uint NmShotTuningSet;
        [FieldOffset(0x05F4)] private AttachPointInfo attachPointsArrayStart;
        [FieldOffset(0x08B0)] public uint AttachPointsCount;
        [FieldOffset(0x08B4)] public uint GunFeedBoneId;
        [FieldOffset(0x08C8)] public eWeaponFlags1 WeaponFlags1;
        [FieldOffset(0x08C0)] public eWeaponFlags2 WeaponFlags2;
        [FieldOffset(0x08C8)] public eWeaponFlags3 WeaponFlags3;
        [FieldOffset(0x08D0)] public CWeaponTintSpecValues* TintSpecValues;
        [FieldOffset(0x08D8)] public CWeaponFiringPatternAliases* FiringPatternAliases;
        [FieldOffset(0x08E0)] public CWeaponUpperBodyFixupExpressionData* ReloadUpperBodyFixupExpressionData;
        [FieldOffset(0x08E8)] public uint TargetSequenceGroup;
        [FieldOffset(0x08EC)] public float BulletDirectionOffsetInDegrees;
        [FieldOffset(0x08F0)] public float BulletDirectionPitchOffset;
        [FieldOffset(0x08F4)] public float BulletDirectionPitchHomingOffset;

        [FieldOffset(0x0910)] public float VehicleAttackAngle;


        public AttachPointInfo* GetAttachPoints()
        {
            fixed (AttachPointInfo* array = &attachPointsArrayStart)
            {
                return array;
            }
        }

        public string GetStatName()
        {
            return Marshal.PtrToStringAnsi(statNameStrPtr);
        }

        [StructLayout(LayoutKind.Sequential, Size = 12)]
        public struct OverrideForce
        {
            public uint BoneTag;
            public float ForceFront;
            public float ForceBack;
        }

        [StructLayout(LayoutKind.Sequential, Size = 196)]
        public struct FxInfo
        {
            public eWeaponEffectGroup EffectGroup;
            public uint FlashFx;
            public uint FlashFxAlt;
            public uint FlashFxFP;
            public uint FlashFxAltFP;
            public uint MuzzleSmokeFx;
            public uint MuzzleSmokeFxFP;
            public float MuzzleSmokeFxMinLevel;
            public float MuzzleSmokeFxIncPerShot;
            public float MuzzleSmokeFxDecPerSec;
            private long pad0;
            private long pad1;
            private long pad2;
            public uint ShellFx;
            public uint ShellFxFP;
            public uint TracerFx;
            public uint PedDamageHash;
            public float TracerFxChanceSP;
            public float TracerFxChanceMP;
            public float FlashFxChanceSP;
            public float FlashFxChanceMP;
            public float FlashFxAltChance;
            public float FlashFxScale;
            public bool FlashFxLightEnabled;
            public bool FlashFxLightCastsShadows;
            private ushort pad3;
            public float FlashFxLightOffsetDist;
            public NativeColorRGBFloat FlashFxLightRGBAMin;
            private uint pad4;
            public NativeColorRGBFloat FlashFxLightRGBAMax;
            private uint pad5;
            public NativeVector2Float FlashFxLightIntensityMinMax;
            public NativeVector2Float FlashFxLightRangeMinMax;
            public NativeVector2Float FlashFxLightFalloffMinMax;
            public bool GroundDisturbFxEnabled;
            private ushort pad6;
            private byte pad7;
            public float GroundDisturbFxDist;
            public uint GroundDisturbFxNameDefault;
            public uint GroundDisturbFxNameSand;
            public uint GroundDisturbFxNameDirt;
            public uint GroundDisturbFxNameWater;
            public uint GroundDisturbFxNameFoliage;
        }

        [StructLayout(LayoutKind.Explicit, Size = 100)]
        public struct AttachPointInfo
        {
            [FieldOffset(0x0000)] public uint AttachBone;

            [FieldOffset(0x0008)] private Component componentsArrayStart;

            [FieldOffset(0x0060)] public uint ComponentsCount;

            public Component* GetComponents()
            {
                fixed (Component* array = &componentsArrayStart)
                {
                    return array;
                }
            }

            [StructLayout(LayoutKind.Sequential, Size = 8)]
            public struct Component
            {
                public uint Name;
                public bool Default;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CSimpleArray_OverrideForce
        {
            public OverrideForce* Offset;
            public ushort Count;
            public ushort Size;


            public OverrideForce* Get(ushort index)
            {
                if (index >= Size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"The size of this {nameof(CSimpleArray_OverrideForce)} is {Size}, the index {index} is out of range.");
                }

                return &Offset[index];
            }
        }
    }

}
