//-----------------------------------------------------------------------------
// Alterverse Fishing
//-----------------------------------------------------------------------------

// Distance a player can move before their line is automatically reeled in.
$Fishing::MoveDistance = 10;

// Min and max times in seconds. A fish will never be caught in less than the
// min time or longer than the max time.
$Fishing::MinTime = 10; // 10 seconds
$Fishing::MaxTime = 600; // 10 minutes

// The low and high times is the base range that will be used to constrain the 
// random fishing time. These values will be adjusted based on the luck of the
// fishing spot and lure used.
$Fishing::LowTime = 60; // 60 seconds
$Fishing::HighTime = 300; // 5 minutes

$Fishing::StealChance = 0.06; // 6% chance the fish will be stolen by an AI

$Fishing::WaitTime = 30;   // Display a wait message about every 30 seconds.

// Default Water Plane fish stock
//$Fishing::WaterPlaneFS = "Barracuda 30|Green_Gill 30|Orange_Sea_Bass 15|Red_Head 30|Swordfish 2";

// Default Water Block fish stock
//$Fishing::WaterBlockFS = "Mudfish 20|Blue_Striped_Perch 30|Brook_Trout 25|Pike 25|Rainbow_Trout 20|Red_Devil 10";

//-------------------

datablock ProjectileData(BobberProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/flintloc/shot.dae";
   scale="1 1 1";
   muzzleVelocity = 80;
   directDamage = 1;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   radiusDamage = 0;
   damageRadius = 5;
   lightDesc = 0;
   gravityMod = 0.0;

   explosion = 0;
   waterExplosion = 0;

   decal = 0;
   splash = ProjectileSplash;

   particleEmitter = 0;
   particleWaterEmitter = 0;

   retrievable = "";
};

function Pole::onUse(%this, %user)
{
   if(!isObject(%user.client))
      return false;

   if ( %user.isFishing )
   {  // If they are already fishing, remove the pole and cancel any timers
      %user.unmountEquipment("mount0");
      %user.updateMountedEquipment();
      if ( isEventPending(%user.fishSchedule) )
         cancel(%user.fishSchedule);
      %user.isFishing = false;
      %user.BreakTeather();
      commandToClient(%user.client, 'SendWaterClicks', false);
      messageClient(%user.client, 'LocalizedMsg', "", "fishEnd", "a", false, true, 0);
      %user.AVMountImage("", $WeaponSlot);
   }
   else
   {  // Equip the fishing pole
      %user.unmountImage(0); // remove any mounted weapon
      %user.lastWeapon = "";

      // Attach the pole to mount0
      %user.mountEquipment(%this.shapeFile, "mount0");
      %user.updateMountedEquipment();
      %user.isFishing = true;
      commandToClient(%user.client, 'SendWaterClicks', true);
      messageClient(%user.client, 'LocalizedMsg', "", "fishStart", "a", false, true, 0);
   }

   %user.onHook = "NoBait";
   %user.lineCast = false;
   return true;
}

function Bait::onUse(%this, %user)
{
   if(!isObject(%user.client))
      return false;

   if ( !%user.isFishing )
   {  // Must have pole out before we can bait the hook
      messageClient(%user.client, 'LocalizedMsg', "", "fishPoleFirst", "a", false, true, 0);
   }
   else if ( %user.onHook !$= "NoBait" )
   {  // There is already bait on the hook
      messageClient(%user.client, 'InventoryMsg', "", "fishHasBait", %user.onHook.ItemID, "a", false, true, 0);
   }
   else
   {  // Put this bait on and remove one from inventory
      %key = $AlterVerse::ItemNames[%this.ItemID];
      %curInventory = %user.getInventory(%key);
      if ( %curInventory > 0 )
      {
         %user.onHook = %this;
         %user.setInventory(%key, %curInventory - 1);
         if ( %user.lineCast )
         {
            if ( isEventPending(%user.fishSchedule) )
               cancel(%user.fishSchedule);
            messageClient(%user.client, 'InventoryMsg', "", "fishReelBait", %user.onHook.ItemID, "a", false, true, 0);
         }
         else
         {
            messageClient(%user.client, 'InventoryMsg', "", "fishBaited", %user.onHook.ItemID, "a", false, true, 0);
         }
         %user.lineCast = false;
      }
   }
   return true;
}

// client has clicked on water so cast line
function ServerCmdWaterClick(%client, %objID, %clickPos)
{
   // prevent bogging down the server with multiple rapid clicks
   if(%client.canClick())
      %client.clickLock();
   else
      return;
   
   // the client sends us their ghostID for the object, so we need to convert
   // this to the server-side index for that object
   %obj = %client.resolveObjectFromGhostIndex(%objID);

   // check it exists   
   if(!isObject(%obj))
      return;
   
   // and we must have a player that's alive and fishing
   if(!isObject(%client.player) || (%client.player.getState() $= "Dead") || !%client.player.isFishing)
      return;

   if ( isEventPending(%client.player.fishSchedule) )
      cancel(%client.player.fishSchedule);

   // Check that there are actually fish in the water selected
   if ( %obj.liquidType !$= "Water" )
      return;
   if ( %obj.fishStock $= "" )
   {
      if (%obj.NoFishingMsg !$= "" )
         messageClient(%client, 'LocalizedMsg', "", %obj.NoFishingMsg, "a", false, true, 0);
      else
         messageClient(%client, 'LocalizedMsg', "", "fishingNA", "a", false, true, 0);
      return;
   }

   // Play the casting sound effect, animation and schedule the bobber splash
   %client.player.playAudio(0, PoleCastSound);
   if ( %client.player.isMounted() )
      %client.player.setArmThreadPlayOnce("CastLine");
   else
      %client.player.setactionthread("CastLine");
   //schedule(1664, 0, "ShowBobberSplash", %client, %clickPos);
   schedule(1500, 0, "ShowBobberSplash", %client, %clickPos);

   messageClient(%user.client, 'LocalizedMsg', "", "fishCast", "a", false, true, 0);

   // Record the position the player casts from
   %client.player.fishingSpot = %client.player.getPosition();
   %client.player.SetTeatherPos(%client.player.fishingSpot, $Fishing::MoveDistance);
   %client.player.lineCast = true;

   %numSpots = 0;
   if ( isObject(FishingSpots) )
      %numSpots = FishingSpots.count();
   for ( %i = 0; %i < %numSpots; %i++ )
   {
      %spotStr = FishingSpots.getValue(%i);
      %spotPos = GetCommaWord(%spotStr, 0);
      %spotRadius = GetCommaWord(%spotStr, 1);
      %distSqr = VectorDistSquared(%clickPos, %spotPos);
      if ( %distSqr < (%spotRadius * %spotRadius) )
      {
         %inFishingSpot = true;
         %fishLuck = GetCommaWord(%spotStr, 2);
         %fishStock = GetCommaWord(%spotStr, 3);
         break;
      }
   }

   if ( !%inFishingSpot )
   {  // Not in a fishing location, so use defaults from water object
      %fishLuck = %obj.fishLuck;
      %fishStock = %obj.fishStock;
   }
   
   if ((%fishLuck $= "") || (%fishLuck <= 0))
      %fishLuck = 1.0;
   
   // Adjust luck for lure and time-of-day
   %lureLuck = %client.player.onHook.fishLuck;
   if ( (%lureLuck !$= "") && (%lureLuck > 0) )
      %fishLuck *= %lureLuck;

   // Select time to catch fish
   %lowTime = $Fishing::LowTime / %fishLuck;
   %highTime = $Fishing::HighTime / %fishLuck;
   if ( %lowTime < $Fishing::MinTime )
      %lowTime = $Fishing::MinTime;
   if ( %highTime > $Fishing::MaxTime )
      %highTime = $Fishing::MaxTime;
   if ( %highTime < (%lowTime + 10) )
      %highTime = (%lowTime + 10);  // Make sure there's at least some variation
   %catchTime = (getRandom() * (%highTime - %lowTime)) + %lowTime;

   // Randomly select the fish to be caught
   %count = getBarWordCount(%fishStock);
   %chance = 0;
   for ( %i = 0; %i < %count; %i++ )
   {
      %fishStr = getBarWord(%fishStock, %i);
      %fishType = getWord(%fishStr, 0);
      %fishCount = getWord(%fishStr, 1);
      if ( %fishType $= "Junk" )
         %fishMod = %client.player.onHook.affinity[0];
      else
         %fishMod = %client.player.onHook.affinity[%fishType.ItemID];
      if ( %fishMod !$= "" )
         %fishCount *= %fishMod;
      %chance += %fishCount;
   }
   %diceRoll = getRandom() * %chance;
   %chance = 0;
   for ( %i = 0; %i < %count; %i++ )
   {
      %fishStr = getBarWord(%fishStock, %i);
      %fishType = getWord(%fishStr, 0);
      %fishCount = getWord(%fishStr, 1);
      if ( %fishType $= "Junk" )
         %fishMod = %client.player.onHook.affinity[0];
      else
         %fishMod = %client.player.onHook.affinity[%fishType.ItemID];
      if ( %fishMod !$= "" )
         %fishCount *= %fishMod;
      %chance += %fishCount;
      if ( %diceRoll <= %chance )
         break;
   }

   // Set the timer to catch the fish
   %client.player.fishSchedule = schedule(%catchTime * 1000, 0, "CatchFish", %client, %fishType);

   // If it's going to be a while, schedule a wait message
   if ( $Fishing::WaitTime < %catchTime )
   {
      %msgCount = mFloor(%catchTime / $Fishing::WaitTime);
      %msgTime = %catchTime / (%msgCount + 1);
      schedule(%msgTime * 1000, 0, "ShowFishingMsg", %client, %msgTime, %msgCount, %client.player.fishSchedule);
   }
}

function ShowFishingMsg(%client, %msgTime, %msgCount, %fishEvent)
{
   if ( isEventPending(%fishEvent) )
   {  // Still waiting for a catch
      messageClient(%client, 'FishingMsg', "", "wait", "a", false, true);

      %msgCount -= 1;
      if ( %msgCount >=0 )
         schedule(%msgTime * 1000, 0, "ShowFishingMsg", %client, %msgTime, %msgCount, %fishEvent);
   }
}

function CatchFish(%client, %fishType)
{
   if(!isObject(%client) || !isObject(%client.player) || !%client.player.isFishing)
      return;

   %client.player.BreakTeather();
   %client.player.lineCast = false;

   if ( %fishType $= "Junk" )
   {
      %msgNum = 0;
      if ( %client.player.onHook $= "NoBait" )
      {
         messageClient(%client, 'FishingMsg', "", "NBJunk", "a", false, true);
      }
      else
      {
         messageClient(%client, 'FishingMsg', "", "Junk", "a", false, true);
      }
      %client.player.onHook = "NoBait";
      return;
   }
   %client.player.onHook = "NoBait";

   if ( isObject(%fishType) )
   {
      // determine if the catch should be stolen by a boglin
      %fishSteal = (getRandom() < $Fishing::StealChance);

      // Play the fish catch sound
      %client.player.playAudio(0, FishCatchSound);

      %client.player.Schedule(1000, "ShowFish", %fishType);
      if ( %fishSteal )
         %client.player.Schedule(1000, "SpawnFishThief", %fishType);
      else
      {
         %key = $AlterVerse::ItemNames[%fishType.ItemID];
         %curInventory = %client.player.getInventory(%key);
         if ( %curInventory < %fishType.maxInventory )
            %client.player.setInventory(%key, %curInventory + 1);
         else
            messageClient(%client, 'InventoryMsg', "", "tooMany", %fishType.ItemID, "a", true, true, 0);

         //if ( isObject(%client.pData) )
            //DB::SprocNoRet("sp_StatsFishCatch", "'" @ %client.pData.dbID @ "'");
      }
   }
   
   messageClient(%client, 'InventoryMsg', "", "fishCaught", %fishType.ItemID, "a", true, true, 0);
}

function Player::ShowFish(%this, %fishType)
{  // Spawn the fish that hangs from the pole and schedule it's removal
   %this.mountEquipment(%fishType.shapeFile, "mount7");
   %this.updateMountedEquipment();
   %this.schedule(4000, "HideFish");
}

function Player::HideFish(%this)
{  // Hide the players fish
   %this.unmountEquipment("mount7");
   %this.updateMountedEquipment();
}

function PLAYERDATA::onBreakTeather(%this, %obj)
{
   // Inform the client that their line has been reeled in
   %obj.lineCast = false;
   if ( isEventPending(%obj.fishSchedule) )
      cancel(%obj.fishSchedule);
   messageClient(%obj.client, 'LocalizedMsg', "", "fishMove", "a", true, true);
}

function Player::SpawnFishThief(%this, %fishType)
{  // Spawn a boglin to steal the fish

   %spawnTrans = %this.FindThiefSpawn();
   %thief = new AIPlayer() {
      dataBlock = "Boglin";
      isbot = true;
      team = $AISK_TEAM;
      action = "Thief";
      botWeapon = "-NoWeapon";
      dropitem = %fishType;
   };
   %thief.setTransform(%spawnTrans);
   %thief.setScale("0.4 0.4 0.4");
   %thief.respawn = false;
   %thief.stoleFish = false;
   %thief.stealTartget = %this;
   %thief.startFade(0, 0, true);
   %thief.startFade(500, 0, false);
   
   // Select a random steal sound
   %idx = getRandom(1, 5);
   %fishTrack = "BoglinFish" @ %idx;
   %thief.schedule(1000, "playAudio", 0, %fishTrack);
   
   // Make the thief run at the fish
   %pos = getWords(%this.getTransform(), 0, 2);
   %vec = MatrixMulVector( %this.getTransform(), "0 1.6 0");
   %pos = VectorAdd(%pos, %vec);
   %thief.setAimLocation(%pos);
   %thief.setMoveDestination(%pos, false);
   %thief.setMoveSpeed(1.0);
   
   // Schedule the thief to disappear in 5 seconds
   %this.schedule(5000, "KillThief", %thief);
   %this.schedule(2000, "ShowStealMsg", "Boglin");
}

function Player::KillThief(%this, %thief)
{
   if ( isObject(%thief) && (%thief.getState() !$= "Dead") )
      %thief.delete();
}

function Player::ShowStealMsg(%this, %thiefType)
{
   messageClient(%this.client, 'LocalizedMsg', "", "fishSteal", "a", true, true, 1, %thiefType);
}

function Player::FindThiefSpawn(%this)
{  // Find the location to spawn the bogin at
   // Get player position
   %pos = getWords(%this.getTransform(), 0, 2);
   %trans = getWords(%this.getTransform(), 3, 6);
   %oldPos = %pos;
   %vec[0] = "1 -1 1";
   %vec[1] = "-1 -1 1";
   %vec[2] = "1 0 1";
   %vec[3] = "-1 0 1";
   %vec[4] = "0 1 1";

   // Make sure the point is valid
   %pos = "0 0 0";
   %numAttempts = 5;
   %success = false;
   for (%i = 0; %i < %numAttempts; %i++)
   {
      %vec[%i] = MatrixMulVector( %this.getTransform(), %vec[%i]);
      %pos = VectorAdd(%oldPos, VectorScale(%vec[%i], 3));
      if (%this.checkThiefSpawn(%oldPos, %pos))
      {
         %success = true;
         break;
      }
   }
   if ( !%success )
      %pos = %oldPos;

   return %pos SPC %trans;
}

function ShowBobberSplash(%client, %splashPos)
{  // Spawn the splash effect. Since a splash can not be created directly on the
   // server, spawn a projectile that has only the splash effect attached.
   %spawnPos = VectorAdd(%splashPos, "0 0 10");

   // Create the projectile object
   %p = new Projectile()
   {
      dataBlock = BobberProjectile;
      initialVelocity = "0 0 -40";
      initialPosition  = %spawnPos;  

      sourceObject = %client.player;
      sourceSlot = 0;
      ignoreSourceTimeout = false;
      client = %client;
   };
   MissionCleanup.add(%p);
}

//schedule(3000, 0, "CatchFish", 12466, Swordfish)
//schedule(3000, 0, "CatchFish", 12466, Red_Devil)
//schedule(3000, 0, "CatchFish", 12466, Blue_Striped_Perch)
//schedule(3000, 0, "CatchFish", 12466, Brook_Trout)
//schedule(3000, 0, "CatchFish", 12466, Barracuda)
//schedule(3000, 0, "CatchFish", 12466, Green_Gill)
//schedule(3000, 0, "CatchFish", 12466, Mudfish)
//schedule(3000, 0, "CatchFish", 12466, Orange_Sea_Bass)
//schedule(3000, 0, "CatchFish", 12466, Pike)
//schedule(3000, 0, "CatchFish", 12466, Red_Head)
//schedule(3000, 0, "CatchFish", 12466, Rainbow_Trout)
