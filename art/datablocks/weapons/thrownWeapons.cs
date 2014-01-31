// Thrown weapons that the player can carry in inventory

datablock ProjectileData(daggerProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/knives/dagger.dts";
   scale = "1 1 1";
   muzzleVelocity = 15;
   directDamage = 65;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   explosion = AxeHitStaticExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   gravityMod = 0.3;
   lifetime = 30000;
   decal = ScorchRXDecalSmall;
   velInheritFactor = 1.0;
   retrievable = "daggerWeapon";
};

datablock ProjectileData(daggerWetProjectile : daggerProjectile)
{
   muzzleVelocity = 8;
   gravityMod = 0.6;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(DaggerImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/knives/Dagger.dts";
   scale = "1 1 1";
   item = DaggerWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = DaggerProjectile;
   wetProjectile = DaggerWetProjectile;
   fireAnim = "Throw_HamAxe";
   fireSound = BaseThrowSound;
   canUseMounted = true;
   usesBothHands = true;
};


// Stone Spear
datablock ProjectileData(StoneSpearProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/spears/spearstone_thrown.dts";
   scale = "1 1 1";
   muzzleVelocity = 10;
   gravityMod = 0.3;
   directDamage = 40;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   explosion = ProjectileHitExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   lifetime = 30000;
   decal = ScorchRXDecalSmall;
   velInheritFactor = 1.0;
   retrievable = "StoneSpearWeapon";
};

datablock ProjectileData(StoneSpearWetProjectile : StoneSpearProjectile)
{
   muzzleVelocity = 8;
   gravityMod = 0.8;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(StoneSpearImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/spears/spearstone_thrown.dts";
   scale = "1 1 1";
   item = StoneSpearWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = StoneSpearProjectile;
   wetProjectile = StoneSpearWetProjectile;
   fireAnim = "Throw_Javelin";
   fireSound = BaseThrowSound;
   canUseMounted = true;
   usesBothHands = true;
};

// Iron Spear
datablock ProjectileData(IronSpearProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/spears/spearIron_thrown.dts";
   scale = "1 1 1";
   muzzleVelocity = 12;
   gravityMod = 0.3;
   directDamage = 60;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   explosion = JavelinHitStaticExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   lifetime = 30000;
   decal = ScorchRXDecalSmall;
   velInheritFactor = 1.0;
   retrievable = "IronSpearWeapon";
};

datablock ProjectileData(IronSpearWetProjectile : IronSpearProjectile)
{
   muzzleVelocity = 8;
   gravityMod = 0.8;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(IronSpearImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/spears/spearIron_thrown.dts";
   scale = "1 1 1";
   item = IronSpearWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = IronSpearProjectile;
   wetProjectile = IronSpearWetProjectile;
   fireAnim = "Throw_Javelin";
   fireSound = BaseThrowSound;
   canUseMounted = true;
   usesBothHands = true;
};

// Steel Spear
datablock ProjectileData(SteelSpearProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/spears/spearSP_thrown.dts";
   scale = "1 1 1";
   muzzleVelocity = 15;
   gravityMod = 0.3;
   directDamage = 100;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   explosion = JavelinHitStaticExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   lifetime = 30000;
   decal = ScorchRXDecalSmall;
   velInheritFactor = 1.0;
   retrievable = "SteelSpearWeapon";
};

datablock ProjectileData(SteelSpearWetProjectile : SteelSpearProjectile)
{
   muzzleVelocity = 8;
   gravityMod = 0.6;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(SteelSpearImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/spears/spearSP_thrown.dts";
   scale = "1 1 1";
   item = SteelSpearWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = SteelSpearProjectile;
   wetProjectile = SteelSpearWetProjectile;
   fireAnim = "Throw_Javelin";
   fireSound = BaseThrowSound;
   canUseMounted = true;
   usesBothHands = true;
};

// Jack Hammer
datablock ProjectileData(JackHammerProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/Hammers/JackHammer.dts";
   scale = "1 1 1";
   muzzleVelocity = 10;
   gravityMod = 0.3;
   directDamage = 40;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   explosion = ProjectileHitExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   lifetime = 30000;
   velInheritFactor = 1.0;
   decal = ScorchRXDecalSmall;
   retrievable = "JackHammerWeapon";
};

datablock ProjectileData(JackHammerWetProjectile : JackHammerProjectile)
{
   muzzleVelocity = 8;
   gravityMod = 0.6;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(JackHammerImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/Hammers/JackHammer.dts";
   scale = "1 1 1";
   item = JackHammerWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = JackHammerProjectile;
   wetProjectile = JackHammerWetProjectile;
   fireAnim = "Throw_HamAxe";
   fireSound = BaseThrowSound;
   canUseMounted = true;
   usesBothHands = true;
};

// Reaver Axe Thrown
datablock ProjectileData(ReaverProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/Axes/Reaver.dts";
   muzzleVelocity = 10;
   gravityMod = 0.3;
   directDamage = 65;
   directImpulse = 1000;
   explosion = AxeHitLiveExplosion;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   waterExplosion = 0;
   lightDesc = 0;
   lifetime = 30000;
   decal = ScorchRXDecalSmall;
   velInheritFactor = 1.0;
   retrievable = "ReaverWeapon";
};

datablock ProjectileData(ReaverWetProjectile : ReaverProjectile)
{
   muzzleVelocity = 8;
   gravityMod = 0.6;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(ReaverImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/axes/Reaver.dts";
   scale = "1 1 1";
   item = ReaverWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = ReaverProjectile; //The name of a projectile in the BCWeapons/projectiles.cs file.
   wetProjectile = ReaverWetProjectile;
   fireAnim = "Throw_HamAxe";
   fireSound = BaseThrowSound;
   canUseMounted = true;
   usesBothHands = true;
};

// Grenade
datablock ProjectileData(GrenadeProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/grenades/grenade.dts";
   scale="0.3 0.3 0.3";
   directDamage = 50;
   radiusDamage = 200;
   damageRadius = 25;
   areaImpulse = 1000;

   muzzleVelocity = 12;
   gravityMod = 0.3;
   velInheritFactor = 1.0;

   explosion = ProjectileExplosion;
   waterExplosion = ProjectileExplosion;

   armingDelay = 3000;
   lifetime = 10000;
   fadeDelay = 5000;
   decal = ScorchBigDecal;

   bounceElasticity = 0.4;
   bounceFriction = 0.01;
   isBallistic = true;

   retrievable = "";
};

datablock ProjectileData(GrenadeWetProjectile : GrenadeProjectile)
{
   muzzleVelocity = 8;
   gravityMod = 0.6;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};
datablock ShapeBaseImageData(GrenadeImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/grenades/grenade.dts";
   scale = "1 1 1";
   item = grenadeWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = GrenadeProjectile; //The name of a projectile in the BCWeapons/projectiles.cs file.
   wetProjectile = GrenadeWetProjectile;
   fullSkelAnim = true;    // The grenade throw is not a blended anim
   fireAnim = "Throw_Grenade";
   fireSound = BaseThrowSound;
   canUseMounted = true;
   usesBothHands = true;
};

// Thumper
datablock ProjectileData(ThumperProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/maces/thumper.dts";
   muzzleVelocity = 10;
   gravityMod = 0.3;
   directDamage = 55;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   explosion = ProjectileHitExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   lifetime = 30000;
   decal = ScorchRXDecalSmall;
   velInheritFactor = 1.0;
   retrievable = "ThumperWeapon";
};

datablock ProjectileData(ThumperWetProjectile : ThumperProjectile)
{
   muzzleVelocity = 8;
   gravityMod = 0.6;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(ThumperImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/maces/Thumper.dts";
   scale = "1 1 1";
   item = ThumperWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = ThumperProjectile; //The name of a projectile in the BCWeapons/projectiles.cs file.
   wetProjectile = ThumperWetProjectile;
   fireAnim = "Throw_HamAxe";
   fireSound = BaseThrowSound;
   canUseMounted = true;
   usesBothHands = true;
};
