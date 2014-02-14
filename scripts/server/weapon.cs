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
         %obj.client.lastWeapon[%slot] = 0;
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
         {
            %currentAmmo = 0;
            %obj.setImageAmmo(%slot, false);
            %this.NoAmmoMessage(%obj);
         }
         %obj.client.RefreshWeaponHud(%currentAmmo, %this.item.invIcon, %this.item.reticle);
      }
   }
   else
      %obj.setImageAmmo(%slot, true);
   
   if ( %this.customLookAnim !$= "" )
   {
      %obj.playThread(3, %this.customLookAnim);
      %obj.setThreadTimeScale(3, 0.5);
   }
}

function WeaponImage::onUnmount(%this, %obj, %slot)
{
   if ( isObject(%obj.client) && isObject(%this.item) )
      %obj.client.RefreshWeaponHud(0, "", "");

   if ( %this.customLookAnim !$= "" )
   {
      %obj.destroyThread(3);
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

   if ( %this.fireAnim !$= "" )
   {  // Just start the animation and record that we're the image firing
      %obj.firingWeapon = %this;
      if ( %obj.isBot )
      {
         if ( %this.fullSkelAnim )
            %obj.setActionThread(%this.fireAnim);
         else
            %obj.setArmThreadPlayOnce(%this.fireAnim);
      }
      else
      {
         if ( %obj.isMounted() || %obj.isMoving() || %obj.isSwimming() )
            //%obj.setArmThreadPlayOnce(%this.fireAnim @ "Blend");
            %obj.playThread(1, %this.fireAnim @ "Blend");
         else
            %obj.setActionThread(%this.fireAnim);
      }
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
   %muzzleVector = %obj.getAimVector();

   %mp = %obj.getAnimMuzzlePoint(%slot);
   //if ( %this == XR75Image.getId() ) %mp = %obj.getEyePoint(); // Use this for perfect aim with an XR75

   if ( %this.customLookAnim !$= "" )
   {
      %muzzleVector = %obj.getMuzzleVector(%slot);
      %mp = %obj.getMuzzlePoint(%slot);
   }

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

   %canRearm = true;
   if ( isObject(%this.item) && !%obj.isBot )
   {  // This is an inventory item so update counts
      if ( %this.usesAmmo )
         %ammoType = %this.ammo;
      else
         %ammoType = %this.item;

      %obj.decInventory(%ammoType, 1, false);
      %numLeft = %obj.getInventory(%ammoType);
      
      if ( %numLeft < 1 )
      {
         %obj.setImageTrigger(%slot, false);
         %obj.setImageHidden(%slot, false);
         %obj.setImageAmmo(%slot, false);
         //%obj.unmountImage(%slot);
         %obj.schedule(0, "unmountImage", %slot);
         %obj.client.lastWeapon[%slot] = 0;
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
            if (%obj.client !$= "")
            {
               %obj.client.setAmmoAmountHud(%currentAmmo);
            }

         }
   }
}

function Wpn::onInventory(%this,%obj,%amount)
{
   // A weapon has been added to inventory.
   for (%i = 0; %i < 4; %i++)
   {
      if ((%image = %obj.getMountedImage(%i)) > 0)
         if ( isObject(%image.item) && !isObject(%image.ammo) &&
               (%image.item.getId() == %this.getId()) )
         {
            %obj.setImageAmmo(%i, %amount != 0);
            %currentAmmo = %obj.getInventory(%this);
            if (%obj.client !$= "")
            {
               %obj.client.setAmmoAmountHud(%currentAmmo);
            }
            break;
         }
   }
}

// ----------------------------------------------------------------------------
// Weapon mounting
// ----------------------------------------------------------------------------
// usesBothHands weaponSlot allowKicks canUseMounted
// Weapon slots - 0=RH, 1=LH, 2=RF, 3=LF
function ShapeBase::AVMountImage(%this, %wpnKey, %slot)
{
   %slotUsed = false;
   if ( isObject(%wpnKey) && isObject(%wpnKey.image) )
   {
      %weapon = %wpnKey.image;
      %slot = %weapon.weaponSlot;
      if ( !%this.isMounted() || %weapon.canUseMounted )
      {
         // Weapon slot 0 takes precedence over all others. If the image there
         // disallows us, we don't mount
         if ( %slot > 0 )
         {
            %mainWeapon = %this.getMountedImage(0);
            if ( isObject(%mainWeapon) )
            {
               if ( (%slot > 1) && !%mainWeapon.allowKicks )
                  return;  // Can't mount weapons to the feet.
               if ( (%slot == 1) && %mainWeapon.usesBothHands )
               {  // The primary weapon needs the left hand free
                  messageClient(%this.client, 'DualInvMsg',"", "noDual",
                     %wpnKey.ItemID, %mainWeapon.item.ItemID, "a", true, true, 0);
                  return;
               }
            }
         }

         // If it's an inventory item, make sure we have it
         if ( isObject(%this.client) )
         {
            if ( %this.getInventory(%wpnKey) > 0 )
            {
               if ( %weapon.usesAmmo )
               {
                  if ( %this.getInventory(%weapon.ammo) > 0 )
                     %slotUsed = true;
                  else
                     messageClient(%this.client, 'InventoryMsg',"", "noAmmo", %wpnKey.ItemID, "a", true, true, 0);
               }
               else
                  %slotUsed = true;
            }
         }
         else
            %slotUsed = true;
      }
   }

   if ( %slotUsed )
   {
      // mountImage( image, slot, loaded, skinTag )
      %this.mountImage(%weapon, %weapon.weaponSlot, true, addTaggedString(%wpnKey.skinMat));
      %this.client.lastWeapon[%slot] = %wpnKey;
   }
   else
   {
      if ( (%slot != 0) && (%slot != 1) )
         %slot = 0;
      %this.client.lastWeapon[%slot] = 0;
      %this.unmountImage(%slot);
   }
}

function ShapeBase::AVResetWpnState(%this)
{  // Restores the clients last weapon state. This is usually called after
   // unmounting from an AI/Vehicle or when spawning a new character.
   for ( %i = 0; %i < 2; %i++ )
   {
      %wpnKey = %this.client.lastWeapon[%i];
      %this.AVMountImage(%wpnKey, %i);
   }
   %this.AVCheckWeapons();
}

function ShapeBase::AVCheckWeapons(%this)
{  // Check all mounted weapons and add H2H to empty slots if allowed.
   %isMounted = %this.isMounted();
   %feetAllowed = !%this.isMounted();
   %lhAllowed = true;
   %primaryWeapon = %this.getMountedImage(0);
   if ( isObject(%primaryWeapon) )
   {
      if ( %isMounted && !%primaryWeapon.canUseMounted )
         %this.unmountImage(0);
      else
      {
         if ( %primaryWeapon.usesBothHands )
            %lhAllowed = false;
         if ( !%primaryWeapon.allowKicks )
            %feetAllowed = false;
      }
   }
   else if ( !%isMounted )
      %this.mountImage(RightHandImage, 0, true);

   %lhWeapon = %this.getMountedImage(1);
   if ( isObject(%lhWeapon) )
   {
      if ( (%isMounted && !%lhWeapon.canUseMounted) || !%lhAllowed)
      {
         %this.unmountImage(1);
         if ( !%lhAllowed )
            %this.client.lastWeapon[1] = 0;
      }
      else
      {
         if ( !%lhWeapon.allowKicks )
            %feetAllowed = false;
      }
   }
   else if ( %lhAllowed && !%isMounted )
      %this.mountImage(LeftHandImage, 1, true);
      
   if ( %feetAllowed )
   {
      %this.mountImage(RightFootImage, 2, true);
      %this.mountImage(LeftFootImage, 3, true);
   }
   else
   {
      %this.unmountImage(2);
      %this.unmountImage(3);
   }
}

function ShapeBase::FreeLHForWeapon(%this)
{  // Called when a left or two handed weapon is being mounted. Make sure there
   // are no non-weapons mounted to the left hand.
   if( isObject(%this.TAPLink) )
      %this.use3DTL();

   if( isObject(%this.light) )
      Lantern.Toggle(%this);
}

function ShapeBase::FreeLHForNonWeapon(%this)
{  // Called when a non-weapon (TapLink, Lantern, etc.) is being mounted to the
   // left hand. Left hand weapon is slot 1.
   %this.client.lastWeapon[1] = 0;
   %this.unmountImage(1);

   // If there's a two handed weapon in the primary weapon slot, we need to
   // unmount that too, but replace with right hand weapon, if they're not mounted.
   %primaryWeapon = %this.getMountedImage(0);
   if ( isObject(%primaryWeapon) )
   {
      if ( %primaryWeapon.usesBothHands )
      {
         %this.client.lastWeapon[0] = 0;
         if ( %this.isMounted() )
            %this.unmountImage(0);
         else
            %this.mountImage(RightHandImage, 0, true);
      }
   }
}

function WeaponImage::NoAmmoMessage(%this, %obj)
{
   if ( %obj.client $= "" )
      return;

   if ( %this.usesAmmo )
   {
      messageClient(%obj.client, 'InventoryMsg',"", "noAmmo", %this.item.ItemID, "a", true, true, 0);
   }
   else
   {
      messageClient(%obj.client, 'InventoryMsg',"", "noThrown", %this.item.ItemID, "a", true, true, 0);
   }
}

function serverCmdDoAttack(%client, %slot, %attackNum, %make)
{
   if (!isObject(%client.player))
      return;

   if ( %make && %client.player.inArmThreadPlayOnce() )
      %client.player.stopPlayOnce();

   if ( !isObject(%client.player.getMountedImage(%slot)) )
   {
      if ( %slot > 1 )
      {
         %slot -= 2;
         if ( !isObject(%client.player.getMountedImage(%slot)) )
            %slot = 0;
      }
      else
         %slot = 0;
   }
   
   if ( %make )
      %client.player.curAttack = %attackNum;

   %client.player.setImageTrigger(%slot, %make);
}
