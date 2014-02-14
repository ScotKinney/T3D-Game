
datablock ShapeBaseImageData(BaseAutoImage)
{
   className = "WeaponImage";

   // Need a shape file so datablock is valid. Replace in derived blocks...
   shapefile = "core/art/effects/debris_player.dts";
   scale = "0.25 0.25 0.25";
   emap = true;

   // Specify mount point & offset for 3rd person, and eye offset
   // for first person rendering.
   mountPoint = 0;
   correctMuzzleVector = false;

   projectileType = Projectile;

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
   maxRange = "40";
   minRange = "15";
   moveTolerance = "1.0";
   ignoreDistance = 100;

   // Images have a state system which controls how the animations
   // are run, which sounds are played, script callbacks, etc. This
   // state system is downloaded to the client so that clients can
   // predict state changes and animate accordingly. The following
   // system supports basic ready->fire->reload transitions as
   // well as a no-ammo->dryfire idle state.

   // Initial start up state
   stateName[0] = "Preactivate";
   stateTransitionOnLoaded[0] = "Activate";
   stateTransitionOnNoAmmo[0] = "NoAmmo";

   // Activating the gun.
   // Called when the weapon is first mounted and there is ammo.
   stateName[1] = "Activate";
   stateTransitionOnTimeout[1] = "Ready";
   stateTimeoutValue[1] = 0.6;
   stateSequence[1] = "Activate";

   // Ready to fire, just waiting for the trigger
   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "CheckWet";
   stateSequence[2] = "Ready";

   // Fire the weapon. Calls the fire script which does the actual work.
   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "PostFire";
   stateTimeoutValue[3] = 0.9;
   stateFire[3] = true;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFire";

   // Check ammo
   stateName[4] = "PostFire";
   stateTransitionOnAmmo[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";

   // Play the reload animation, and transition into
   stateName[5] = "Reload";
   stateTransitionOnTimeout[5] = "Ready";
   stateTimeoutValue[5] = 0.9;
   stateAllowImageChange[5] = false;
   stateSequence[5] = "Reload";
   stateEjectShell[5] = false; // set to true to enable shell casing eject

   // No ammo in the weapon, just idle until something shows up.
   // Play the dry fire sound if the trigger iS pulled.
   stateName[6] = "NoAmmo";
   stateTransitionOnAmmo[6] = "Reload";
   stateSequence[6] = "NoAmmo";
   stateTransitionOnTriggerDown[6] = "DryFire";

   // No ammo dry fire
   stateName[7] = "DryFire";
   stateTimeoutValue[7] = 1.0;
   stateTransitionOnTimeout[7] = "NoAmmo";

   // Check if wet
   stateName[8] = "CheckWet";
   stateTransitionOnWet[8] = "WetFire";
   stateTransitionOnNotWet[8] = "Fire";

   // Check if alt wet
   stateName[9] = "CheckWetAlt";
   stateTransitionOnWet[9] = "WetFire";
   stateTransitionOnNotWet[9] = "ChargeUp1";

   // Wet fire
   stateName[10] = "WetFire";
   stateTransitionOnTimeout[10] = "PostFire";
   stateTimeoutValue[10] = 0.9;
   stateFire[10] = true;
   stateAllowImageChange[10] = false;
   stateSequence[10] = "Fire";
   stateScript[10] = "onWetFire";

   // Begin "charge up", 1 in the pipe
   stateName[11] = "ChargeUp1";
   stateScript[11] = "readyLoad";
   stateTransitionOnAltTriggerUp[11] = "AltFire";
   stateTransitionOnTimeout[11] = "ChargeUp2";
   stateTimeoutValue[11] = 0.8;
   stateWaitForTimeout[11] = false;

   // Charge up, 2 in the pipe
   stateName[12] = "ChargeUp2";
   stateScript[12] = "incLoad";
   stateTransitionOnAltTriggerUp[12] = "AltFire";
   stateTransitionOnTimeout[12] = "ChargeUp3";
   stateTimeoutValue[12] = 0.8;
   stateWaitForTimeout[12] = false;

   // Charge up, 3 in the pipe
   stateName[13] = "ChargeUp3";
   stateScript[13] = "incLoad";
   stateTransitionOnAltTriggerUp[13] = "AltFire";
   stateTransitionOnTimeout[13] = "Altfire";  // lets force them to fire
   stateTimeOutValue[13] = 1.2;
   stateWaitForTimeout[13] = false;

   // Alt-fire
   stateName[14] = "AltFire";
   stateTransitionOnTimeout[14] = "PostFire";
   stateTimeoutValue[14] = 1.2;
   stateFire[14] = true;
   stateAllowImageChange[14] = false;
   stateSequence[14] = "Fire";
   stateScript[14] = "onAltFire";
};

datablock ShapeBaseImageData(XR75Image : BaseAutoImage)
{
   shapefile = "art/inv/weapons/Guns/XR75.dts";//
   scale = "1 1 1";
   //eyeOffset = "0.2 0.5 -0.4";// right/left - forward/back -0.6=up/down
   correctMuzzleVector = false;
   correctMuzzleVectorTP = false;
   item = XR75Weapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   ammo = XRBoltsAmmo; //This is the name of the AMMO that comes from the weapons table in aureus.
   projectile = XRBoltsProjectile;
   wetProjectile = XRBoltsProjectile;
   usesAmmo = true;
   usesBothHands = true;
   stateSound[3] = XR75FireSound;
   //stateSequence[3] = "Sequence_Fire";
   stateTimeoutValue[3] = 0.2;
   stateTimeoutValue[5] = 0.2;
   customLookAnim = "XR75";
};

//2913.playThread(3, "Look2_XR75");2913.pauseThread(3);
//2913.setThreadPosition(3, 0.5);//2913.destroyThread(3);
