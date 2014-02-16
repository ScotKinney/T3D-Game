// The delay time before a pathed horse will return to it's path after the
// player dismounts
$Horse::ReturnDelay = 2 * 60 * 1000;   // 2 Minutes

// Delay time before a horse will respawn after death or pickup
$Horse::RespawnDelay = .5 * 60 * 1000;   // 30 seconds

// The delay time before a horse becomes free when left unattended
$Horse::StableDelay = 10 * 60 * 1000;   // 10 Minutes

//----------------------------------------------------------------------------
function AIPlayer::SetHorseFree(%this)
{
   if ( isObject(%this.owner) )
   {
      messageClient(%this.owner, 'LocalizedMsg', "", "horseLeave", "a", true, true, 0);
      if ( %this.owner.horse == %this )
         %this.owner.horse = "";
      %this.prevOwner = %this.owner;
      if ( isObject(%this.owner.player) )
         %this.owner.player.decInventory(%this.itemDB,1);
      %this.owner = "";
   }
   %this.setClanName("Drop");
}

function HorseItemOnUse(%user, %horseDB, %itemDB)
{
   %client = %user.client;
   if(!isObject(%client))
      return false;

   // prevent bogging down the server (or other clients) with multiple rapid clicks
   if(%client.canUseHorse())
      %client.horseLock();
   else
      return true;

   if ( isObject(%client.horse) )
   {  // Dismount the horse and put it back in the stabble
      if ( isEventPending(%client.horse.FreeSchedule) )
         cancel(%client.horse.FreeSchedule);

      %obj = %client.player.getObjectMount();
      %client.horse.owner = "";
      if (isObject(%obj) && (%obj == %client.horse))
         %client.player.getDataBlock().doDismount(%client.player, true);

      // If we have a passenger, dismount them now
      %rider = %client.horse.getMountNodeObject(5);
      if ( isObject(%rider) )
         %rider.getDataBlock().doDismount(%rider, true);

      messageClient(%client, 'LocalizedMsg', "", "stowHorse", "a", true, true, 0);
      %client.horse.playLeaveEffect();
      %client.horse.schedule(2000, "delete");
      %client.horse.client = "";
      %client.horse = "";
   }
   else
   {  // Spawn a horse for the player
      %horse = new AIPlayer() {
        dataBlock = %horseDB;
        aiPlayer = true;
        isBot = true;
        behavior = MountBehavior;
      };
      MissionCleanup.add(%horse);
      %horse.setScale("1 1 1");
      %client.horse = %horse;
      %horse.owner = %client;
      %horse.itemDB = %itemDB;
      %horse.setSkinName(%horseDB.skinName);
      %transform = FindHorseSpawn(%user, %horse);
      %horse.setTransform(%transform);
      %horse.setEnergyLevel(1);
      %horse.setMoveSpeed(0.1);
      %horse.setClanName(%client.nameBase);
      //%horse.startFade(0, 0, true);
      %horse.respawn = false;
      %horse.mountable = true;
      // Set a timer to free the horse if it is unattended too long
      %horse.FreeSchedule = %horse.schedule($Horse::StableDelay, "SetHorseFree");

      %client.horse.playArriveEffect();
   }

   return true;
}

function ThrowHorse(%user, %horseDB)
{
   %client = %user.client;
   if(!isObject(%client))
      return false;

   if ( isObject(%client.horse) && (%client.horse.getDatablock() == %horseDB.getID()) )
   {  // Mark the existing horse as dropped
      // If the player is mounted to it, dismount first.
      %obj = %client.player.getObjectMount();
      %client.horse.owner = "";
      if (isObject(%obj) && (%obj == %client.horse))
         %client.player.getDataBlock().doDismount(%client.player, true);

      %horse = %client.horse;
      %client.horse.client = "";
      %client.horse = "";
   }
   else
   {  // Spawn a horse
      %horse = new AIPlayer() {
        dataBlock = %horseDB;
        aiPlayer = true;
      };
      MissionCleanup.add(%horse);
      %horse.setScale("1 1 1");
      %horse.setSkinName(%horseDB.skinName);
      %transform = FindHorseSpawn(%user, %horse);
      %horse.setTransform(%transform);
      %horse.setEnergyLevel(1);
      %horse.startFade(0, 0, true);      
      %horse.respawn = false;
      %client.horse.playArriveEffect();
   }
   %horse.setClanName("Drop");

   return %horse;
}

function FindHorseSpawn(%user, %horse)
{
   // Get player position
   %pos = getWords(%user.getTransform(), 0, 2);
   %trans = getWords(%user.getTransform(), 3, 6);
   %oldPos = %pos;
   %vec[0] = " .5 .5 1";
   %vec[1] = " -1 .5 1";
   %vec[2] = " 0 1 1";
   %vec[3] = " .75 0 0";
   %vec[4] = "-.75 0 0";

   // Make sure the point is valid
   %pos = "0 0 0";
   %numAttempts = 5;
   %success = false;
   for (%i = 0; %i < %numAttempts; %i++)
   {
      %useTrans = %trans;
      %vec[%i] = MatrixMulVector( %user.getTransform(), %vec[%i]);
      %pos = VectorAdd(%oldPos, VectorScale(%vec[%i], 3));
      if (%horse.checkSpawnTrans(%pos SPC %useTrans))
      {
         %success = true;
         break;
      }
   }
   if ( !%success )
      %pos = %oldPos;

   return %pos SPC %useTrans;
}

//----------------------------------------------------------------------------
function Steed::handleBotDeath(%this, %obj)
{
   // Remove any players mounted
   %driver = %obj.getMountNodeObject(%this.driverNode);
   if ( isObject(%driver) )
      %driver.getDataBlock().doDismount(%driver, true);

   %rider = %obj.getMountNodeObject(%this.riderNode);
   if ( isObject(%rider) )
      %rider.getDataBlock().doDismount(%rider, true);

   // If this was an owned horse, notify the owner and remove from inventory
   if ( isObject(%obj.owner) )
   {
      messageClient(%obj.owner, 'InventoryMsg', "", "petDie", %obj.itemDB.ItemID, "a", true, true, 0);      if ( %obj.owner.horse == %obj )
         %obj.owner.horse = "";
      if ( isObject(%obj.owner.player) )
         %obj.owner.player.decInventory(%obj.itemDB,1);
      %obj.owner = "";
   }

}

//----------------------------------------------------------------------------
function Arabian_Horse_Item::onUse(%this, %user)
{
   %horseDB = ArabianHorse;
   return HorseItemOnUse(%user, %horseDB, %this);
}

function Bay_Horse_Item::onUse(%this, %user)
{
   %horseDB = BayHorse;
   return HorseItemOnUse(%user, %horseDB, %this);
}

function Buckskin_Horse_Item::onUse(%this, %user)
{
   %horseDB = LightHorse;
   return HorseItemOnUse(%user, %horseDB, %this);
}

function Mustang_Horse_Item::onUse(%this, %user)
{
   %horseDB = MustangHorse;
   return HorseItemOnUse(%user, %horseDB, %this);
}

function Painted_Horse_Item::onUse(%this, %user)
{
   %horseDB = IndianHorse;
   return HorseItemOnUse(%user, %horseDB, %this);
}

function Palimino_Horse_Item::onUse(%this, %user)
{
   %horseDB = PaliminoHorse;
   return HorseItemOnUse(%user, %horseDB, %this);
}

//----------------------------------------------------------------------------
function Arabian_Horse_Item::onThrow(%this, %user, %amount)
{
   %horseDB = ArabianHorse;
   %user.decInventory(%this,%amount);
   return ThrowHorse(%user, %horseDB);
}

function Bay_Horse_Item::onThrow(%this, %user, %amount)
{
   %horseDB = BayHorse;
   %user.decInventory(%this,%amount);
   return ThrowHorse(%user, %horseDB);
}

function Buckskin_Horse_Item::onThrow(%this, %user, %amount)
{
   %horseDB = LightHorse;
   %user.decInventory(%this,%amount);
   return ThrowHorse(%user, %horseDB);
}

function Mustang_Horse_Item::onThrow(%this, %user, %amount)
{
   %horseDB = MustangHorse;
   %user.decInventory(%this,%amount);
   return ThrowHorse(%user, %horseDB);
}

function Painted_Horse_Item::onThrow(%this, %user, %amount)
{
   %horseDB = IndianHorse;
   %user.decInventory(%this,%amount);
   return ThrowHorse(%user, %horseDB);
}

function Palimino_Horse_Item::onThrow(%this, %user, %amount)
{
   %horseDB = PaliminoHorse;
   %user.decInventory(%this,%amount);
   return ThrowHorse(%user, %horseDB);
}

//----------------------------------------------------------------------------
function GameConnection::canUseHorse(%client)
{
   if(%client.horseLocked $= "")
      %client.horseLocked = false;
   return !%client.horseLocked;  
}

function GameConnection::horseLock(%client)
{
   %client.horseLocked = true;
   %client.schedule(15000, "horseUnlock");
}

function GameConnection::horseUnlock(%client)
{
   if ( isObject(%client) )
      %client.horseLocked = false;
}

