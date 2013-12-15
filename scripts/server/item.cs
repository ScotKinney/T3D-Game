//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

// These scripts make use of dynamic attribute values on Item datablocks,
// these are as follows:
//
//    maxInventory      Max inventory per object (100 bullets per box, etc.)
//    pickupName        Name to display when client pickups item
//
// Item objects can have:
//
//    count             The # of inventory items in the object.  This
//                      defaults to maxInventory if not set.

// Respawntime is the amount of time it takes for a static "auto-respawn"
// object, such as an ammo box or weapon, to re-appear after it's been
// picked up.  Any item marked as "static" is automaticlly respawned.
$Item::RespawnTime = 30 * 1000;

// Poptime represents how long dynamic items (those that are thrown or
// dropped) will last in the world before being deleted.
// 6 Hours = 6 * 60 (minutes) * 60 (seconds) * 1000 (ms)
$Item::PopTime = 6 * 60 * 60 * 1000;

//-----------------------------------------------------------------------------
// ItemData base class methods used by all items
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

function Item::respawn(%this)
{
   // This method is used to respawn static ammo and weapon items
   // and is usually called when the item is picked up.
   // Instant fade...
   %this.startFade(0, 0, true);
   %this.setHidden(true);

   %newTransform = "";
   if ( (%this.spawnGroup !$= "") && isObject(%this.spawnGroup) )
   {
      %spawnSphere = %this.spawnGroup.getRandom();
      if ( isObject(%spawnSphere) )
         %newTransform = %spawnSphere.getTransform();
   }
   
   // For Random Respawn Time
   if ( %this.respawnTime $= "Random" )
   {
      // size selection to make respawns longer for larger objects.
      // This is the time in seconds.
      switch$(%this.nugSize)
      {
         case "S":
            %respawnRand = getRandom(600, 899);
         case "M":
            %respawnRand = getRandom(900, 1199);
         case "L":
            %respawnRand = getRandom(1200, 1499);
         case "H":
            %respawnRand = getRandom(1500, 1799);
         default:
            // Default random set if nugSize not used. 
            %respawnRand = getRandom(700, 1200);
      }

      // End Size Selection.
      %this.respawnTime = %respawnRand;
      // convert to milliseconds
      %respawnTime = %this.respawnTime * 1000;
      // Reset random time so script will execute a new random
      %this.respawnTime = "Random";
      %respawnRand = 0;
   }
   // For Default Respawn Time
   else if ( %this.respawnTime $= "" || %this.respawnTime == 0 )
   {
      %this.respawnTime = 30;
      %respawnTime = %this.respawnTime * 1000;
   }
   // For Static Respawn Time
   // Manually enter a number in the respawnTime in the properties to use this feature.
   else
   {
      %respawnTime = %this.respawnTime * 1000;
   }

   // Shedule a reapearance
   if ( %newTransform !$= "" )
      %this.schedule(%respawnTime, "setTransform", %newTransform);
   %this.schedule(%respawnTime, "setHidden", false);
   %this.schedule(%respawnTime + 100, "startFade", 1000, 0, false);
}

function Item::schedulePop(%this)
{
   // This method deletes the object after a default duration. Dynamic
   // items such as thrown or drop weapons are usually popped to avoid
   // world clutter.
   %this.schedule($Item::PopTime - 1000, "startFade", 1000, 0, true);
   %this.schedule($Item::PopTime, "delete");
}

function ItemData::onAdd(%this, %obj)
{
   if ( (%obj.spawnGroup !$= "") && isObject(%obj.spawnGroup) )
   {  // If we have a spawn group assigned, use it to select a transform
      %spawnSphere = %obj.spawnGroup.getRandom();
      if ( !isObject(%spawnSphere) )
         return;
         
      %newTransform = %spawnSphere.getTransform();
      %obj.setTransform(%newTransform);
   }
}

//-----------------------------------------------------------------------------
// Callbacks to hook items into the inventory system

function ItemData::onThrow(%this, %user, %amount)
{
   if ( %this.category $= "horses" )
   {  // Trying to drop a horse on a no horse level
      if( isObject(%user.client) )
         messageClient(%user.client, 'LocalizedMsg', "", "horseNoDrop", "a", true, true, 0);
      return 0;
   }

   // Remove the object from the inventory
   if (%amount $= "")
      %amount = 1;
   if (%this.maxInventory !$= "")
      if (%amount > %this.maxInventory)
         %amount = %this.maxInventory;
   if (!%amount)
      return 0;
   %user.decInventory(%this,%amount);

   return %this.createDropItem(%user, %amount);
}

function ItemData::createDropItem(%this, %user, %amount)
{
   %ammo = 0;
   if ( isObject(%this.image) && %this.image.usesAmmo )
   {
      %ammo = %user.getInventory(%this.image.ammo);
      %wpnCount = %user.getInventory(%this);

      // If they still have a weapon, only give away half the ammo
      if ( %wpnCount > 0 )
         %ammo = mFloor(%ammo/2);

      // Now remove the ammo from inventory so it doesn't get duplicated
      %user.decInventory(%this.image.ammo, %ammo);
   }

   // Construct the actual object in the world, and add it to
   // the mission group so it's cleaned up when the mission is
   // done.  The object is given a random z rotation.
   %obj = new Item()
   {
      datablock = %this;
      rotation = "0 0 1 "@ (getRandom() * 360);
      static = "0";
      count = %amount;
      ammo = %ammo;
   };
   MissionGroup.add(%obj);
   %obj.schedulePop();
   return %obj;
}

function ItemData::onPickup(%this, %obj, %user, %amount)
{
   // check for any skull level requirements before picking the item up
   if(!(%this.checkSkullLevel(%obj, %user)))
      return false;

   %key = $AlterVerse::ItemNames[%this.ItemID];

   %count = %obj.count;
   if ( %count $= "0" )
      %count = 1;
   if (%count $= "")
   {
      if (%this.maxInventory !$= "")
      {
         if (!(%count = %this.maxInventory))
            return false;
      }
      else
         %count = 1;
   }

   %curInventory = %user.getInventory(%key);
   if ( %curInventory >=  %this.maxInventory )
   {
      messageClient(%user.client, 'InventoryMsg',"", "tooMany", %this.ItemID);
      return false;
   }
   else if ( (%curInventory + %count) > %this.maxInventory )
      %count = %this.maxInventory - %curInventory;

   if (%obj.buyable == 1)
   {
      // These two cases are now handled above
      //if ( %user.hasInventory(%key) &&  %this.maxInventory == 1 )
      //{
         //messageClient(%user.client, 'MsgItemPickup', '\c0You cannot buy another %1.', %name);
         //return false;
      //}
      //else if ( %user.getInventory(%key) >=  %this.maxInventory )
      //{
         //messageClient(%user.client, 'MsgItemPickup', '\c0You cannot buy any more %1.', %pname);
         //return false;
      //}

      %arns = %user.client.arns;
      %totalCost = %count * %this.cost;
      if ( %arns >= %totalCost )
      {
         if ( %count > 1 )
            messageClient(%user.client, 'InventoryMsg',"", "buyMany", %this.ItemID, "a", true, true, 2, %count, %totalCost);
         else
            messageClient(%user.client, 'InventoryMsg',"", "buyOne", %this.ItemID, "a", true, true, 1, %totalCost);
         %user.client.giveArns(-%totalCost);
      }
      else
      {
         if ( %count > 1 )
            messageClient(%user.client, 'InventoryMsg',"", "affordMany", %this.ItemID, "a", true, true, 1, %totalCost);
         else
            messageClient(%user.client, 'InventoryMsg',"", "affordOne", %this.ItemID, "a", true, true, 1, %totalCost);
         return false;
      }
   }

   %user.setInventory(%key, %curInventory + %count, %obj.buyable);

   if ( %key.image.usesAmmo )
   {
      %curAmmo = %user.getInventory(%key.image.ammo);
      if ( %obj.ammo > 0 )
         %user.setInventory(%key.image.ammo, %curAmmo + %obj.ammo);
   }

   // Inform the client what they got.
   if (%user.client && %obj.buyable != 1 )
   {
      if ( %count > 1 )
         messageClient(%user.client, 'InventoryMsg',"", "pickMany", %this.ItemID, "a", true, true, 1, %count);
      else
         messageClient(%user.client, 'InventoryMsg',"", "pickOne", %this.ItemID, "a", true, true, 0);
   }

   // If the item is a static respawn item, then go ahead and
   // respawn it, otherwise remove it from the world.
   // Anything not taken up by inventory is lost.
   %className = %obj.getClassName();
   if ( ((%obj.getClassName() $= "AIPlayer") && (%obj.getClanName() $= "Buy")) ||
        ((%obj.getClassName() !$= "AIPlayer") && %obj.isStatic()) )
      %obj.respawn();
   else
      %obj.delete();
   return true;
}

// allow items to give players a skull level increase and only allow players
// with a certain skull level to pick up certain items
function ItemData::checkSkullLevel(%this, %item, %user)
{
   // if the skullLevel is not defined on the datablock or item, user can pick us up
   if((%item.skullLevel $= "" || %item.skullLevel == 0) &&
      (%this.skullLevel $= "" || %this.skullLevel == 0) &&
      (%item.team < 2))
      return true;
      
   // AI cannot pick up objects that award skull level
   if(!isObject(%user.client))
      return false;
      
   %playerSL = %user.client.skullLevel;
   
   if ( %item.skullLevel > 0 )
      %itemSL = %item.skullLevel;
   if ( %this.skullLevel > 0 )
      %itemSL = %this.skullLevel; // Datablock sl takes precedence if defined
   %minSL = %itemSL - 1;
   
   // if the item has a team assigned, make sure the player is on the right team
   if((%item.team > 0) && (%item.team != %user.team))
   {
      messageClient(%this.client, 'LocalizedMsg', "", "noClan", "a", true, true, 0);
      return false;
   }
   
   // if player has SL equal to or greater than this objects SL already, then
   // let him pick it up
   if(%playerSL >= %itemSL)
      return true;
      
   // if player has SL < item SL-1, prevent him from picking it up
   if(%playerSL < %minSL)
   {
      if ( !%item.static && !%item.aiDrop )
         %minSL = %itemSL;
      messageClient(%this.client, 'LocalizedMsg', "", "lowSkull", "a", true, true, 1, %minSL);
      return false;
   }
   else if ((%playerSL < %itemSL) && !%item.static && !%item.aiDrop)
   {  // Can't pick up a dropped object unless they already have the level
      // needed or it was dropped by an ai
      messageClient(%this.client, 'LocalizedMsg', "", "lowSkull", "a", true, true, 1, %itemSL);
      return false;
   }
   
   // if player has SL = item SL-1, let them pick it up, and give them a skull
   // level increase
   if(%playerSL == %minSL)
   {
      %user.client.awardLockLevel(%itemSL);
      return true;  
   }
   
   // shouldn't get this far
   return false;
}
