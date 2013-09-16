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

// All ShapeBase images are mounted into one of 8 slots on a shape.  This weapon
// system assumes all primary weapons are mounted into this specified slot:
$WeaponSlot = 0;

// ----------------------------------------------------------------------------
// Weapon Order
// ----------------------------------------------------------------------------

// This is a simple means of handling easy adding & removal of weapons to the
// cycleWeapon function and still maintain a constant cycle order.
function WeaponOrder(%weapon, %slot)
{
   if ($lastWeaponOrderSlot $= "")
      $lastWeaponOrderSlot = -1;

   // the order# slot to name index
   $weaponOrderIndex[%slot] = %weapon;

   // the weaponName to order# slot index
   $weaponNameIndex[%weapon] = %slot;

   // the last slot in the array
   $lastWeaponOrderSlot++;
}

// Now create the Index/array by passing a name and order# for each weapon.
// NOTE:  the first weapon needs to be 0.
WeaponOrder(RocketLauncher, 0);

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
   // Images assume a false ammo state on load.  We need to
   // set the state according to the current inventory.
   if ( %this.item.usesAmmo )
      %ammoType = %this.ammo;
   else
      %ammoType = %this.item;

   if(%ammoType !$= "")
   {
      if (%obj.getInventory(%ammoType))
      {
         %obj.setImageAmmo(%slot, true);
         %currentAmmo = %obj.getInventory(%ammoType);
      }
      else
         %currentAmmo = 0;
      //AISK Changes: Start
      if (%obj.client !$= "")
         %obj.client.RefreshWeaponHud(%currentAmmo, %this.item.invIcon, %this.item.reticle);
      //AISK Changes: End
   }
   
   if ( %this.customLookAnim !$= "" )
   {
      %obj.setArmThread(%this.customLookAnim);
      %obj.setSwingingArms(false);
      %obj.setLookAnimationOverride(false);
   }
}

function WeaponImage::onUnmount(%this, %obj, %slot)
{
   //AISK Changes: Start
   if (%obj.client !$= "")
      %obj.client.RefreshWeaponHud(0, "", "");
   //AISK Changes: End

   if ( %this.customLookAnim !$= "" )
   {
      %obj.clearArmThread();
      %obj.setSwingingArms(true);
      %obj.setLookAnimationOverride(true);
   }
}

// ----------------------------------------------------------------------------
// A "generic" weaponimage onFire handler for most weapons.  Can be overridden
// with an appropriate namespace method for any weapon that requires a custom
// firing solution.

// projectileSpread is a dynamic property declared in the weaponImage datablock
// for those weapons in which bullet skew is desired.  Must be greater than 0,
// otherwise the projectile goes straight ahead as normal.  lower values give
// greater accuracy, higher values increase the spread pattern.
// ----------------------------------------------------------------------------

function WeaponImage::onFire(%this, %obj, %slot)
{
   if ( %obj.inNeutralZone )
   {
      sfxPlay(BaseFireEmptySound, %obj.getTransform());
      return;
   }
   //echo("\c4WeaponImage::onFire( "@%this.getName()@", "@%obj.client.nameBase@", "@%slot@" )");

   if ( (%this.item.effect $= "THROWN") && (%this.throwAnim !$= "") )
   {  // This is a weapon thrown by a player
      %obj.firingWeapon = %this;
      %obj.schedule(1, "setArmThreadPlayOnce",%this.throwAnim);
      return;
   }

   if ( (%this.fireAnim !$= "") && %obj.setArmThreadPlayOnce(%this.fireAnim) )
   {  // This weapon has it's own firing animation
      %obj.firingWeapon = %this;
      return;
   }

   %obj.decInventory(%this.ammo, 1, true);
   if ( %obj.isBot || %obj.client.isFirstPerson() )
      %muzzleVector = %obj.getMuzzleVector(%slot);
   else
      %muzzleVector = %obj.getEyeVector();

   %mp = %obj.getMuzzlePoint(%slot);
   
   if ( %obj.getClassName() $= "AIPlayer" )
   {
      %aimLoc = %obj.getAimLocation();
      if ( isObject(%this.projectile) )
      {  // Adjust the bots aim to account for gravity and weapon ballistics
         %gravMod = %this.projectile.gravityMod;
         if ((%gravMod > 0) && %this.projectile.isBallistic)
         {
            %muzzleVector = VectorSub(%aimLoc, %mp);
            %aimDist = VectorLen(%muzzleVector);
            //%heightAdjust = (%aimDist / %this.projectile.muzzleVelocity) * (%gravMod * 9.81);
            // y = 1/2(gtt)
            %time = %aimDist / %this.projectile.muzzleVelocity;
            %heightAdjust = %time * %time * (%gravMod * 4.905); // 4.905 = 1/2(9.81)
            %aimZ = getWord(%aimLoc, 2) + %heightAdjust;
            %aimLoc = setWord(%aimLoc, 2, %aimZ);
            %muzzleVector = VectorSub(%aimLoc, %mp);
         }
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
         %matrix = %matrix @ (getRandom() - 0.5) * 2 * 3.1415926 * %this.projectileSpread @ " ";
      %mat = MatrixCreateFromEuler(%matrix);

      // Which we'll use to alter the projectile's initial vector with
      %muzzleVector = MatrixMulVector(%mat, %vec);
   }

   // Get the player's velocity, we'll then add it to that of the projectile
   %objectVelocity = %obj.getVelocity();
   %muzzleVelocity = VectorAdd(
      VectorScale(%muzzleVector, %this.projectile.muzzleVelocity),
      VectorScale(%objectVelocity, %this.projectile.velInheritFactor));
      
   // Create the projectile object
   %p = new (%this.projectileType)()
   {
      dataBlock = %this.projectile;
      initialVelocity = %muzzleVelocity;
      initialPosition  = %mp;  

      sourceObject = %obj;
      sourceSlot = %slot;
      ignoreSourceTimeout = true;
      client = %obj.client;
         ammoID           = %this.ammo.itemID;
   };
   MissionCleanup.add(%p);
   
   if ( %this.item.usesAmmo && %obj.getInventory(%this.ammo) < 1 )
   {
      //%obj.setInventory(%this.item, 0);
      %obj.unmountImage(%slot);
      %obj.lastWeapon = "";
      %this.NoAmmoMessage(%obj);
      %obj.clearArmThread();
      %obj.updateInventoryString();
   }

   return %p;
}

// ----------------------------------------------------------------------------
// A "generic" weaponimage onAltFire handler for most weapons.  Can be
// overridden with an appropriate namespace method for any weapon that requires
// a custom firing solution.
// ----------------------------------------------------------------------------

function WeaponImage::onAltFire(%this, %obj, %slot)
{
   return %this.onFire(%obj, %slot);
}

// ----------------------------------------------------------------------------
// A "generic" weaponimage onWetFire handler for most weapons.  Can be
// overridden with an appropriate namespace method for any weapon that requires
// a custom firing solution.
// ----------------------------------------------------------------------------

function WeaponImage::onWetFire(%this, %obj, %slot)
{
   return %this.onFire(%obj, %slot);
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
      // GUY >> hack
      // if this is a thrown weapon like a spear, then give the player
      // the actual weapon if he doesn't already have it
      //%itemName = $AlterVerse::ItemNames[%this.itemID];
      //%spos = strstr(%itemName, "Ammo");
      //if ( %spos > -1 )
      //{
         //%weaponName = getSubStr(%itemName, 0, %spos) @ "Weapon";
         //if(!%shape.hasInventory(%weaponName))
            //%shape.incInventory(%weaponName, 1);
      //}
      // GUY <<
   }
}

function Ammo::onInventory(%this,%obj,%amount)
{
   // The ammo inventory state has changed, we need to update any
   // mounted images using this ammo to reflect the new state.
   for (%i = 0; %i < 8; %i++)
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
   %slot = -1;
   if (%this.getMountedImage($WeaponSlot) != 0)
   {
      %curWeapon = %this.getMountedImage($WeaponSlot).item.getName();
      %slot = $weaponNameIndex[%curWeapon];
   }

   if (%direction $= "prev")
   {
      // Previous weapon...
      if (%slot == 0 || %slot == -1)
      {
         %requestedSlot = $lastWeaponOrderSlot;
         %slot = 0;
      }
      else
         %requestedSlot = %slot - 1;
   }
   else
   {
      // Next weapon...
      if (%slot == $lastWeaponOrderSlot || %slot == -1)
      {
         %requestedSlot = 0;
         %slot = $lastWeaponOrderSlot;
      }
      else
         %requestedSlot = %slot + 1;
   }

   %newSlot = -1;
   while (%requestedSlot != %slot)
   {
      if ($weaponOrderIndex[%requestedSlot] !$= "" && %this.hasInventory($weaponOrderIndex[%requestedSlot]) && %this.hasAmmo($weaponOrderIndex[%requestedSlot]))
      {
         // player has this weapon and it has ammo or doesn't need ammo
         %newSlot = %requestedSlot;
         break;
      }
      if (%direction $= "prev")
      {
         if (%requestedSlot == 0)
            %requestedSlot = $lastWeaponOrderSlot;
         else
            %requestedSlot--;
      }
      else
      {
         if (%requestedSlot == $lastWeaponOrderSlot)
            %requestedSlot = 0;
         else
            %requestedSlot++;
      }
   }
   if (%newSlot != -1)
      %this.use($weaponOrderIndex[%newSlot]);
}

function WeaponImage::delayedFire(%this, %obj, %slot)
{
   if ( %this.item.effect $= "THROWN" )
      %obj.setImageHidden(%slot, true);

   if ( %obj.getMountedImage(%slot) != %this )
      return; // %obj died, before animation trigger was hit, don't fire

   if (%obj.isMounted())
      %muzzleVector = %obj.getObjectMount().getEyeVector();
   else if ( (%obj.isBot || %obj.client.isFirstPerson()) && !isObject(%obj.driver) )
      %muzzleVector = %obj.getMuzzleVector(%slot);
   else
      %muzzleVector = %obj.getEyeVector();

   %mp = %obj.getAnimMuzzlePoint(%slot);
   //echo("MP  = " @ %mp);

   if ((%obj.getClassName() $= "AIPlayer") && !isObject(%obj.driver))
   {
      if ( isObject(%obj.getAimObject()) )
         %aimLoc = %obj.getAimObject().getEyePoint();
      else
         %aimLoc = %obj.getAimLocation();

      if ( isObject(%this.projectile) )
      {  // Adjust the bots aim to account for gravity and weapon ballistics
         %gravMod = %this.projectile.gravityMod;
         if ((%gravMod > 0) && %this.projectile.isBallistic)
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
         %matrix = %matrix @ (getRandom() - 0.5) * 2 * 3.1415926 * %this.projectileSpread @ " ";
      %mat = MatrixCreateFromEuler(%matrix);

      // Which we'll use to alter the projectile's initial vector with
      %muzzleVector = MatrixMulVector(%mat, %vec);
   }

   // Get the player's velocity, we'll then add it to that of the projectile
   %objectVelocity = %obj.getVelocity();
   %baseVelocity = %this.projectile.muzzleVelocity;
   if ( %obj.isBot && (%this == FlintlockImage.getID()) )
      %baseVelocity = 300;
   %muzzleVelocity = VectorAdd(
      VectorScale(%muzzleVector, %baseVelocity),
      VectorScale(%objectVelocity, %this.projectile.velInheritFactor));
      
   // Create the projectile object
   %p = new (%this.projectileType)()
   {
      dataBlock = %this.projectile;
      initialVelocity = %muzzleVelocity;
      initialPosition  = %mp;  

      sourceObject = %obj;
      sourceSlot = %slot;
      ignoreSourceTimeout = true;
      client = %obj.client;
         ammoID           = %this.ammo.itemID;
   };
   MissionCleanup.add(%p);
   
   if ( %this.fireSound !$= "" )
      serverPlay3D(%this.fireSound,%obj.getTransform());

   if ( %this.item.usesAmmo )
      %ammoType = %this.ammo;
   else
      %ammoType = %this.item;
   if ( %this.item.usesAmmo || !%obj.isBot )
      %obj.decInventory(%ammoType, 1, true);
   
   if ( (%obj.getInventory(%ammoType) < 1) && !%obj.isBot )
   {
      //%obj.setInventory(%this.item, 0); // Don't remove from inventory when they fire the last shot
      %obj.unmountImage(%slot);
      %obj.lastWeapon = "";
      %obj.updateInventoryString();
      %this.NoAmmoMessage(%obj);
   }
   else if ( %this.item.effect $= "THROWN" )
      %obj.schedule(%this.rearmDelay, "setImageHidden", %slot, false);

   return %p;
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
