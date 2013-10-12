// Base definition for weapons that fire a projectile on an animation trigger

datablock ShapeBaseImageData(BaseTriggeredImage)
{
   className = "WeaponImage";

   // Type can be Thrown, Delayed or Fired. Thrown and Delayed weapons do not
   // spawn a projectile until trigger 3 is hit in their fireAnim animation
   weaponType = "Thrown"; 

   // Thrown weapons disappear from hand for rearmDelay ms after being thrown
   // before the image reactivates
   rearmDelay = 1500;

   // Don't allow use of melee weapons while triggered weapons are mounted
   canMelee = false;

   // You must provide an item for weapons that can also be carried in
   // inventory. This is the name of the WEAPON that comes from the weapons
   // table in the database.
   // item = FlintlockWeapon;

   usesAmmo = false;
   
   // If the weapon is an inventory item that uses ammunition (the weapon is
   // not the projectile), there must be an inventory item for the ammo too.
   // ammo = ShotAmmo;

   // Basic Item properties
   shapefile = "core/art/effects/debris_player.dts";
   scale = "1 1 1";
   emap = true;

   firstPerson = true;
   correctMuzzleVector = true;
   projectile = "";
   wetProjectile = "";
   projectileType = Projectile;
   
   // Initial start up state
   stateName[0]                     = "Preactivate";
   stateTransitionOnLoaded[0]       = "Activate";

   // Activating the weapon.  Called when the weapon is first mounted
   stateName[1]                     = "Activate";
   stateTransitionOnTimeout[1]      = "Ready";
   stateTimeoutValue[1]             = 0.6;

   // Ready to fire, just waiting for the trigger
   stateName[2]                     = "Ready";
   stateTransitionOnTriggerDown[2]  = "CheckWet";
   stateTransitionGeneric0In[2]     = "CheckWet";
   stateTransitionGeneric1In[2]     = "CheckWet";
   stateTransitionGeneric2In[2]     = "CheckWet";
   stateTransitionGeneric3In[2]     = "CheckWet";
   stateTransitionOnAltTriggerDown[2]  = "CheckWet";

   // Fire the weapon. Calls the fire script which does the actual work.
   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Ready";
   stateTimeoutValue[3]             = 0.2;
   stateFire[3]                     = true;
   stateAllowImageChange[3]         = false;
   stateScript[3]                   = "onFire";

   // Fire the weapon. Calls the wet fire script which does the actual work.
   stateName[4]                     = "WetFire";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 0.2;
   stateFire[4]                     = true;
   stateAllowImageChange[4]         = false;
   stateScript[4]                   = "onWetFire";

   // Check if wet
   stateName[5] = "CheckWet";
   stateTransitionOnWet[5] = "WetFire";
   stateTransitionOnNotWet[5] = "Fire";
};
