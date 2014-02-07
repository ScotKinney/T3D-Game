// Flintlock
datablock ProjectileData(ShotProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/Guns/shot.dae";
   scale="1 1 1";
   muzzleVelocity = 50;
   gravityMod = 0.0;
   directDamage = 80;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   explosion = flintlockHitExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   decal = ScorchRXDecalSmall;

   retrievable = "";
};

datablock ProjectileData(ShotWetProjectile : ShotProjectile)
{
   muzzleVelocity = 20;
   gravityMod = 0.1;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(FlintlockImage : BaseTriggeredImage)
{
   weaponType = "Delayed"; 
   shapefile = "art/inv/weapons/Guns/flintlock.dts";
   scale = "1 1 1";
   item = FlintlockWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   usesAmmo = true;
   usesBothHands = true;
   ammo = ShotAmmo; //This is the name of the AMMO that comes from the weapons table in aureus.
   projectile = ShotProjectile; //The name of a projectile in the BCWeapons/projectiles.cs file.
   wetProjectile = ShotWetProjectile;
   stateTimeoutValue[3] = 0.9;
   fireAnim = "Fire_Flintlock";
   fireSound = "flintlockFireSound";
   canUseMounted = true;
};

// Crossbow
datablock ProjectileData(BoltProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/Crossbows/projectile.dts";
   scale = "0.75 0.75 0.75";
   muzzleVelocity = 40;
   gravityMod = 0.3;
   directDamage = 80;
   
   particleWaterEmitter = 0;
   explosion = DefaultHitExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   lifetime = 5000;
   decal = ScorchRXDecalSmall;
   retrievable = "BoltAmmo";
};

datablock ProjectileData(BoltWetProjectile : BoltProjectile)
{
   muzzleVelocity = 20;
   gravityMod = 0.4;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(CrossbowImage : BaseTriggeredImage)
{
   weaponType = "Delayed"; 
   shapefile = "art/inv/weapons/crossbows/weapon.dts";
   scale = ".5 .5 .5";
   item = crossbowWeapon; //This is the name of the WEAPON that comes from the weapons table in av plus "Weapon".
   usesAmmo = true;
   usesBothHands = true;
   canUseMounted = true;
   ammo = boltAmmo; //This is the name of the AMMO that comes from the weapons table in aureus plus "Ammo".
   projectile = BoltProjectile; 
   wetProjectile = BoltWetProjectile;
   fireAnim = "Fire_Flintlock";
   fireSound = "BaseFireSound";
   stateSequence[1] = "Activate";
   stateSequence[2] = "Ready";
   stateTimeoutValue[3] = 0.9;   // Don't reload before we've fired
   stateTransitionOnTimeout[3] = "PostFire";
   stateSequence[3] = "Fire";
   stateTimeoutValue[4] = 0.9;   // Don't reload before we've fired
   stateTransitionOnTimeout[4] = "PostFire";
   stateSequence[4] = "Fire";

   // Check ammo
   stateName[6] = "PostFire";
   stateTransitionOnAmmo[6] = "Reload";
   stateTransitionOnNoAmmo[6] = "NoAmmo";

   // Play the reload animation, and transition into
   stateName[7] = "Reload";
   stateTransitionOnTimeout[7] = "Ready";
   stateTimeoutValue[7] = 0.9;
   stateAllowImageChange[7] = false;
   stateSequence[7] = "Reload";
   stateEjectShell[7] = false; // set to true to enable shell casing eject
   stateSound[7] = BaseReloadSound;
   stateEmitter[7] = Basefiring2Emitter;
   stateEmitterTime[7] = 2.4;

   // No ammo in the weapon, just idle until something shows up.
   stateName[8] = "NoAmmo";
   stateTransitionOnAmmo[8] = "Reload";
   stateSequence[8] = "NoAmmo";
};


// ElvenBow
datablock ProjectileData(ElvenArrowProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/bows/ElvenArrow.dts";
   scale = "1 1 1";
   muzzleVelocity = 40;
   gravityMod = 0.3;
   directDamage = 80;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   explosion = ArrowHitStaticExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   lifetime = 5000;
   decal = ScorchRXDecalSmall;
   retrievable = "ElvenArrowAmmo";
};

datablock ProjectileData(ElvenArrowWetProjectile : ElvenArrowProjectile)
{
   muzzleVelocity = 20;
   gravityMod = 0.4;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(ElvenBowImage : BaseTriggeredImage)
{
   weaponType = "Delayed"; 
   shapefile = "art/inv/weapons/bows/ElvenBow.dts";
   scale = "1 1 1";
   item = ElvenBowWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus plus "Weapon".
   usesAmmo = true;
   canUseMounted = true;
   usesBothHands = true;
   ammo = ElvenArrowAmmo; //This is the name of the AMMO that comes from the weapons table in aureus plus "Ammo".
   projectile = ElvenArrowProjectile; //The name of a projectile in the BCWeapons/projectiles.cs file.
   wetProjectile = ElvenArrowWetProjectile;
   mountPoint = 2;
   weaponSlot = 0;   // Secondary weapon slot (Left Hand)
   fireAnim = "B_Fire";
   //fireSound = "BowFireSound";
   stateSound[3] = "BowFireSound";
   stateSequence[3] = "FireBow";
};