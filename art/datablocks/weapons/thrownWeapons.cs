// Thrown weapons that the player can carry in inventory

datablock ProjectileData(daggerProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/dagger/dagger.dts";
   scale = "1 1 1";
   muzzleVelocity = 25;
   directDamage = 65;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   explosion = DefaultHitExplosion;
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
   muzzleVelocity = 10;
   gravityMod = 0.6;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(DaggerImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/Dagger/Dagger.dts";
   scale = "1 1 1";
   item = DaggerWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = DaggerProjectile;
   wetProjectile = DaggerWetProjectile;
   fireAnim = "Throw_HamAxe";
   fireSound = BaseThrowSound;
   canH2H = false; // Allow H2H combat while this weapon is mounted
   canUseMounted = true;
};


// SpearThrown
datablock ProjectileData(JavelinProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/Javelin/Javelin.dts";
   scale = "1 1 1";
   muzzleVelocity = 25;
   directDamage = 65;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   explosion = DefaultHitExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   gravityMod = 0.3;
   lifetime = 30000;
   decal = ScorchRXDecalSmall;
   velInheritFactor = 1.0;
   retrievable = "JavelinWeapon";
};

datablock ProjectileData(JavelinWetProjectile : JavelinProjectile)
{
   muzzleVelocity = 10;
   gravityMod = 0.6;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(JavelinImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/Javelin/Javelin.dts";
   scale = "1 1 1";
   item = JavelinWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = JavelinProjectile;
   wetProjectile = JavelinWetProjectile;
   fireAnim = "Throw_Javelin";
   fireSound = BaseThrowSound;
   canH2H = false; // Allow H2H combat while this weapon is mounted
   canUseMounted = true;
};

// Hammer
datablock ProjectileData(HammerProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/Hammer/Hammer.dts";
   scale = "1 1 1";
   muzzleVelocity = 25;
   directDamage = 65;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   explosion = DefaultHitExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   gravityMod = 0.3;
   lifetime = 30000;
   velInheritFactor = 1.0;
   decal = ScorchRXDecalSmall;
   retrievable = "HammerWeapon";
};

datablock ProjectileData(HammerWetProjectile : HammerProjectile)
{
   muzzleVelocity = 10;
   gravityMod = 0.6;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(HammerImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/Hammer/Hammer.dts";
   scale = "1 1 1";
   item = HammerWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = HammerProjectile;
   wetProjectile = HammerWetProjectile;
   fireAnim = "Throw_HamAxe";
   fireSound = BaseThrowSound;
   canH2H = false; // Allow H2H combat while this weapon is mounted
   canUseMounted = true;
};

// AxeThrown
datablock ProjectileData(TomahawkProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/Tomahawk/thawk.dts";
   muzzleVelocity = 25;
   directDamage = 65;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   explosion = AxeHitExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   gravityMod = 0.3;
   lifetime = 30000;
   decal = ScorchRXDecalSmall;
   velInheritFactor = 1.0;
   retrievable = "TomahawkWeapon";
};

datablock ProjectileData(TomahawkWetProjectile : TomahawkProjectile)
{
   muzzleVelocity = 10;
   gravityMod = 0.6;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(TomahawkImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/tomahawk/thawk.dts";
   scale = "1 1 1";
   item = TomahawkWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = TomahawkProjectile; //The name of a projectile in the BCWeapons/projectiles.cs file.
   wetProjectile = TomahawkWetProjectile;
   fireAnim = "Throw_HamAxe";
   fireSound = BaseThrowSound;
   canH2H = false; // Allow H2H combat while this weapon is mounted
   canUseMounted = true;
};

// Grenade
datablock ProjectileData(GrenadeProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/grenade/grenade.dts";
   scale="0.3 0.3 0.3";
   directDamage = 50;
   radiusDamage = 200;
   damageRadius = 25;
   areaImpulse = 1000;

   muzzleVelocity = 25;
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
   gravityMod = 0.5;

   retrievable = "";
};

datablock ProjectileData(GrenadeWetProjectile : GrenadeProjectile)
{
   muzzleVelocity = 10;
   gravityMod = 0.1;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};
datablock ShapeBaseImageData(GrenadeImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/grenade/grenade.dts";
   scale = "1 1 1";
   item = grenadeWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = GrenadeProjectile; //The name of a projectile in the BCWeapons/projectiles.cs file.
   wetProjectile = GrenadeWetProjectile;
   fullSkelAnim = true;    // The grenade throw is not a blended anim
   fireAnim = "Throw_Grenade";
   fireSound = BaseThrowSound;
   canH2H = false; // Allow H2H combat while this weapon is mounted
   canUseMounted = true;
};
