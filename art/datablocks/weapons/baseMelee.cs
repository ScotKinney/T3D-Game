
// Base definition for all melee weapons
datablock ShapeBaseImageData(BaseMeleeImage)
{
   className = "MeleeImage";

   // Need a shape file so datablock is valid. Replace in derived blocks...
   shapefile = "core/art/effects/debris_player.dts";

   firstPerson = true;
   scale = "1 1 1";
   correctMuzzleVector = false;

   // You must provide an item for weapons that can also be carried in
   // inventory. This is the name of the WEAPON that comes from the weapons
   // table in the database.
   // item = ValMaleSwordWeapon;

   // If usesBothHands is true, no weapon will be allowed to mount in the
   // off-hand when this weapon is mounted. Set true for two-handed weapons.
   usesBothHands = false;

   // Can the feet be used for kicking when this weapon is mounted
   allowKicks = true;

   // Can this weapon be used when mounted to an AI or vehicle
   canUseMounted = false;

   // The image slot to mount into by default. 0 is the primary weapon slot.
   // Images mounted in slot 0 will take precedence over all other weapons.
   // Weapon slots: 0 = Right Hand, 1 = Left Hand, 2 = Right Foot, 3 = Left Foot
   weaponSlot = 0;

   // AI settings
   maxRange = "1.2";
   minRange = "0.5";
   moveTolerance = "0.5";
   ignoreDistance = 50;

   // Initial start up state
   stateName[0]                     = "Preactivate";
   stateTransitionOnLoaded[0]       = "Activate";

   // Activating the weapon.  Called when the weapon is first mounted
   stateName[1]                     = "Activate";
   stateTransitionOnTimeout[1]      = "Ready";
   stateTimeoutValue[1]             = 0.6;
   //stateSequence[1]                 = "Activate";

   // Ready to fire, just waiting for a trigger
   stateName[2]                     = "Ready";
   stateTransitionOnTriggerDown[2]  = "Fire";
   stateTransitionGeneric0In[2]     = "Attack0";
   stateTransitionGeneric1In[2]     = "Attack1";
   stateTransitionGeneric2In[2]     = "Attack2";
   stateTransitionGeneric3In[2]     = "Attack3";
   stateTransitionOnAltTriggerDown[2]  = "Attack4";

   // Fire the weapon. Calls the fire script which does the actual work.
   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 0.2;
   stateFire[3]                     = true;
   stateAllowImageChange[3]         = false;
   stateScript[3]                   = "onFire";

   // Play the relead animation, and transition into
   stateName[4]                     = "Reload";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 0.1;
   stateAllowImageChange[4]         = false;
   stateEjectShell[4]               = false;

   // Fire the weapon. Calls the fire script which does the actual work.
   stateName[5]                     = "Attack0";
   stateTransitionOnTimeout[5]      = "Reload";
   stateTimeoutValue[5]             = 0.2;
   stateFire[5]                     = true;
   stateAllowImageChange[5]         = false;
   stateScript[5]                   = "onAttack0";

   // Fire the weapon. Calls the fire script which does the actual work.
   stateName[6]                     = "Attack1";
   stateTransitionOnTimeout[6]      = "Reload";
   stateTimeoutValue[6]             = 0.2;
   stateFire[6]                     = true;
   stateAllowImageChange[6]         = false;
   stateScript[6]                   = "onAttack1";

   // Fire the weapon. Calls the fire script which does the actual work.
   stateName[7]                     = "Attack2";
   stateTransitionOnTimeout[7]      = "Reload";
   stateTimeoutValue[7]             = 0.2;
   stateFire[7]                     = true;
   stateAllowImageChange[7]         = false;
   stateScript[7]                   = "onAttack2";

   // Fire the weapon. Calls the fire script which does the actual work.
   stateName[8]                     = "Attack3";
   stateTransitionOnTimeout[8]      = "Reload";
   stateTimeoutValue[8]             = 0.2;
   stateFire[8]                     = true;
   stateAllowImageChange[8]         = false;
   stateScript[8]                   = "onAttack3";

   // Fire the weapon. Calls the fire script which does the actual work.
   stateName[9]                     = "Attack4";
   stateTransitionOnTimeout[9]      = "Reload";
   stateTimeoutValue[9]             = 0.2;
   stateFire[9]                     = true;
   stateAllowImageChange[9]         = false;
   stateScript[9]                   = "onAttack4";
};
