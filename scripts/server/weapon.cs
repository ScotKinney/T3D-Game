//-----------------------------------------------------------------------------
// Torque Game Engine 
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------
// ----------------------------------------------------------------------------
// This file contains Weapon and Ammo Class/"namespace" helper methods as well
// as hooks into the inventory system. These functions are not attached to a
// specific C++ class or datablock, but define a set of methods which are part
// of dynamic namespaces "class". The Items include these namespaces into their
// scope using the  ItemData and ItemImageData "className" variable.
// ----------------------------------------------------------------------------

// All ShapeBase images are mounted into one of 4 slots on a shape.  This weapon
// system assumes all primary weapons are mounted into this specified slot:
$WeaponSlot = 0;

// ----------------------------------------------------------------------------
// Weapon Order
// ----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Weapon Class 
//-----------------------------------------------------------------------------

function Weapon::onUse(%data,%obj)
{
   // Default behavoir for all weapons is to mount it into the
   // this object's weapon slot, which is currently assumed
   // to be slot 0
   if (%obj.getMountedImage($WeaponSlot) != %data.image.getId())
   {
      serverPlay3D(WeaponUseSound,%obj.getTransform());
      %obj.mountImage(%data.image, $WeaponSlot);
      if (%obj.client)
      {
         if (%data.description !$= "")
            messageClient(%obj.client, 'MsgWeaponUsed', '\c0%1 selected.', %data.description);
         else
            messageClient(%obj.client, 'MsgWeaponUsed', '\c0Weapon selected');
      }
   }
}

function Weapon::onPickup(%this, %obj, %shape, %amount)
{
   // The parent Item method performs the actual pickup.
   // For player's we automatically use the weapon if the
   // player does not already have one in hand.
   if (Parent::onPickup(%this, %obj, %shape, %amount))
   {
      serverPlay3D(WeaponPickupSound, %shape.getTransform());
      //if (%shape.getClassName() $= "Player" && 
            //%shape.getMountedImage($WeaponSlot) == 0)  {
         //%shape.use(%this);
      //}
      //UAISK+AFX Interop Changes: Start
      if ($UAISK_Is_Available && %shape.getClassName() $= "AIPlayer") {
         %countWeapons = getWordCount(%shape.botWeapon);
         %shape.botWeapon = setWord(%shape.botWeapon, %countWeapons, %this.getname());

         if (%shape.weaponMode $= "best")
            sortBestWeapons(%shape);
      }
      //UAISK+AFX Interop Changes: End
   }
}

function Weapon::onInventory(%this,%obj,%amount)
{
   // Weapon inventory has changed, make sure there are no weapons
   // of this type mounted if there are none left in inventory.
   if ((%slot = %obj.getMountSlot(%this.image)) != -1)
   {  // The weapon is currently mounted
      if ( !%amount )
      {
         %obj.unmountImage(%slot); // Unmount if it's been dropped
         %obj.lastWeapon = "";
      }
      else if ((%obj.client !$= "") && !%this.usesAmmo)
      {  // If it's a thrown weapon, we need to decrease the HUD ammo count
         %currentAmmo = %obj.getInventory(%this);
         %obj.client.setAmmoAmountHud(%currentAmmo);
      }
   }
}   


//-----------------------------------------------------------------------------
// Weapon Image Class
//-----------------------------------------------------------------------------

function WeaponImage::onMount(%this,%obj,%slot)
{
   if ( isObject(%obj.client) && isObject(%this.item) )
   {
      // Images assume a false ammo state on load.  We need to
      // set the state according to the current player inventory.
      if ( %this.usesAmmo )
         %ammoType = %this.ammo;
      else
         %ammoType = %this.item;

      if(%ammoType !$= "")
      {
         %currentAmmo = %obj.getInventory(%ammoType);
         if (%currentAmmo > 0)
            %obj.setImageAmmo(%slot, true);
         else
            %currentAmmo = 0;
         %obj.client.RefreshWeaponHud(%currentAmmo, %this.item.invIcon, %this.item.reticle);
      }
   }
   else
      %obj.setImageAmmo(%slot, true);
   
   if ( %this.customLookAnim !$= "" )
   {
      %obj.setArmThread(%this.customLookAnim);
      %obj.setSwingingArms(false);
      %obj.setLookAnimationOverride(false);
   }
}

function WeaponImage::onUnmount(%this, %obj, %slot)
{
   if ( isObject(%obj.client) && isObject(%this.item) )
      %obj.client.RefreshWeaponHud(0, "", "");

   if ( %this.customLookAnim !$= "" )
   {
      %obj.clearArmThread();
      %obj.setSwingingArms(true);
      %obj.setLookAnimationOverride(true);
   }
}

function WeaponImage::onFire(%this, %obj, %slot)
{
   %this.startFiring(%obj, %slot, false);
}

function WeaponImage::onWetFire(%this, %obj, %slot)
{
   %this.startFiring(%obj, %slot, true);
}

function WeaponImage::startFiring(%this, %obj, %slot, %isWet)
{
   if ( %obj.inNeutralZone )
      return;  // Can't do anything in an NZ

   %obj.firingWet = %isWet;

   if ( (%this.fireAnim !$= "") && %obj.setArmThreadPlayOnce(%this.fireAnim) )
   {  // Just start the animation and record that we're the image firing
      %obj.firingWeapon = %this;
      return;
   }

   // No animation playing, so fire now
   %this.delayedFire(%obj, %slot);
}

// DelayedFire is called from the players onAnimationTrigger callback when 
// trigger 3 in an animation hits.
function WeaponImage::delayedFire(%this, %obj, %slot)
{
   // If it's a thrown weapon, hide the one in the hand
   if ( %this.weaponType $= "Thrown" )
      %obj.setImageHidden(%slot, true);

   if ( %obj.getMountedImage(%slot) != %this )
      return; // %obj died, before animation trigger was hit, don't fire

   // Get the aim vector and release point
   if (%obj.isMounted())
      %muzzleVector = %obj.getObjectMount().getEyeVector();
   else if ( (%obj.isBot || %obj.client.isFirstPerson()) && !isObject(%obj.driver) )
      %muzzleVector = %obj.getMuzzleVector(%slot);
   else
      %muzzleVector = %obj.getEyeVector();

   %mp = %obj.getAnimMuzzlePoint(%slot);

   // Select the wet or dry projectile. Bail if we don't have one
   %useProjectile = (%obj.firingWet && isObject(%this.wetProjectile)) ?
         %this.wetProjectile : %this.projectile;
   if ( !isObject(%useProjectile) )
      return;

   if ((%obj.getClassName() $= "AIPlayer") && !isObject(%obj.driver))
   {  // It's a bot firing on its own
      if ( isObject(%obj.getAimObject()) )
         %aimLoc = %obj.getAimObject().getEyePoint();
      else
         %aimLoc = %obj.getAimLocation();

      // Adjust the bots aim to account for gravity and weapon ballistics
      %gravMod = %useProjectile.gravityMod;
      if ((%gravMod > 0) && %useProjectile.isBallistic)
      {
         %muzzleVector = VectorSub(%aimLoc, %mp);
         %aimDist = VectorLen(%muzzleVector);
         //%heightAdjust = (%aimDist / %this.projectile.muzzleVelocity) * (%gravMod * 9.81);
         // y = 1/2(gtt)
         %time = %aimDist / %this.projectile.muzzleVelocity;
         %heightAdjust = %time * %time * (%gravMod * 4.905); // 4.905 = 1/2(9.81)
         %aimZ = getWord(%aimLoc, 2) + %heightAdjust;
         %aimLoc = setWord(%aimLoc, 2, %aimZ);
      }
      %muzzleVector = VectorSub(%aimLoc, %mp);
      %muzzleVector = VectorNormalize(%muzzleVector);
   }
   
   if (%this.projectileSpread)
   {
      // We'll need to "skew" this projectile a little bit.  We start by
      // getting the straight ahead aiming point of the gun
      %vec = %muzzleVector;

      // Then we'll create a spread matrix by randomly generating x, y, and z
      // points in a circle
      for(%i = 0; %i < 3; %i++)
         %matrix = %matrix @ (getRandom() - 0.5) * 2 * 3.141593 * %this.projectileSpread @ " ";
      %mat = MatrixCreateFromEuler(%matrix);

      // Which we'll use to alter the projectile's initial vector with
      %muzzleVector = MatrixMulVector(%mat, %vec);
   }

   // Get the player's velocity, we'll then add it to that of the projectile
   %objectVelocity = %obj.getVelocity();
   %baseVelocity = %useProjectile.muzzleVelocity;
   if ( %obj.isBot && (%this == FlintlockImage.getID()) )
      %baseVelocity = 300;
   %muzzleVelocity = VectorAdd(VectorScale(%muzzleVector, %baseVelocity),
      VectorScale(%objectVelocity, %useProjectile.velInheritFactor));
      
   // Create the projectile object
   %p = new (%this.projectileType)()
   {
      dataBlock = %useProjectile;
      initialVelocity = %muzzleVelocity;
      initialPosition  = %mp;  

      sourceObject = %obj;
      sourceSlot = %slot;
      ignoreSourceTimeout = true;
      client = %obj.client;
   };
   MissionCleanup.add(%p);
   
   if ( %this.fireSound !$= "" )
      serverPlay3D(%this.fireSound,%obj.getTransform());

   %canRearm =true;
   if ( isObject(%this.item) && !%obj.isBot )
   {  // This is an inventory item so update counts
      if ( %this.usesAmmo )
         %ammoType = %this.ammo;
      else
         %ammoType = %this.item;
      
      %numLeft = %obj.decInventory(%ammoType, 1, true);
      
      if ( %numLeft < 1 )
      {
         %obj.setImageHidden(%slot, false);
         %obj.unmountImage(%slot);
         %obj.lastWeapon = "";
         %obj.updateInventoryString();
         %this.NoAmmoMessage(%obj);
         %canRearm = false;
      }
   }
   if ( (%this.weaponType $= "Thrown") && %canRearm )
      %obj.schedule(%this.rearmDelay, "setImageHidden", %slot, false);

   return %p;
}

//-----------------------------------------------------------------------------
// Ammmo Class
//-----------------------------------------------------------------------------

function Ammo::onPickup(%this, %obj, %shape, %amount)
{
   // Parent::onPickup can delete the object, so save the transform now
   if ( isObject(%obj) )
      %transform = %obj.getTransform();
      
   // The parent Item method performs the actual pickup.
   if (Parent::onPickup(%this, %obj, %shape, %amount))
   {
      //serverPlay3D(AmmoPickupSound,%obj.getTransform());
      serverPlay3D(AmmoPickupSound, %transform);
   }
}

function Ammo::onInventory(%this,%obj,%amount)
{
   // The ammo inventory state has changed, we need to update any
   // mounted images using this ammo to reflect the new state.
   for (%i = 0; %i < 4; %i++)
   {
      if ((%image = %obj.getMountedImage(%i)) > 0)
         if (isObject(%image.ammo) && %image.ammo.getId() == %this.getId())
         {
            %obj.setImageAmmo(%i, %amount != 0);
            %currentAmmo = %obj.getInventory(%this);
            //AISK Changes: Start
            if (%obj.client !$= "")
            {
               %obj.client.setAmmoAmountHud(%currentAmmo);
            }
            //AISK Changes: End

         }
   }
}

// ----------------------------------------------------------------------------
// Weapon cycling
// ----------------------------------------------------------------------------

// Could make this player namespace only or even a vehicle namespace method,
// but for the time being....

function ShapeBase::cycleWeapon(%this, %direction)
{
   if ( %this.weaponCyclePos $= "" )
      %this.weaponCyclePos = 0;
   
   %this.weaponCyclePos += %direction;
   %weaponList = (%this.client.Gender $= "Male") ?
               $MaleWeaponCycle : $FemaleWeaponCycle;

   %weaponCount = getFieldCount(%weaponList);
   if ( %this.weaponCyclePos >= %weaponCount )
      %this.weaponCyclePos = 0;
   if ( %this.weaponCyclePos < 0 )
      %this.weaponCyclePos = %weaponCount - 1;

   %newWeapon = getField(%weaponList, %this.weaponCyclePos);
   %this.mountImage(%newWeapon, 0);
   %this.setImageAmmo(0, true);
}

function WeaponImage::NoAmmoMessage(%this, %obj)
{
   if ( %obj.client $= "" )
      return;

   if ( %this.item.usesAmmo )
   {
      messageClient(%obj.client, 'MsgItemPickup', '\c0Your %1 is out of ammo.', %this.item.pickupName);
   }
   else
   {
      if ( %this.item.pluralName !$= "" )
         %pname = %this.item.pluralName;
      else
         %pname = %this.item.pickupName @ "s";
      messageClient(%obj.client, 'MsgItemPickup', '\c0You have no more %1 to throw.', %pname);
   }
}

function serverCmdDoAttack(%client, %slot, %attackNum, %stopping)
{
   if (!isObject(%client.player))
      return;

   %triggerState = (%stopping !$= "") ? false : true;
   if ( %triggerState && %client.player.inArmThreadPlayOnce() )
      %client.player.stopPlayOnce();
   if ( %attackNum < 4 )
      %client.player.setImageGenericTrigger(%slot, %attackNum, %triggerState);
   else if ( %attackNum < 5 )
      %client.player.setImageAltTrigger(%slot, %triggerState);
   else
      %client.player.setImageTrigger(%slot, %triggerState);

   // Turn off the attack signal in 100 ms
   if ( %triggerState )  
      schedule(100, 0, "serverCmdDoAttack", %client, %slot, %attackNum, "1");
}
