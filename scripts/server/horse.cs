// Timeouts for corpse deletion.
$Horse::CorpseTimeoutValue = 3 * 1000;

//
$HorseDeathAnim::TorsoFrontFallForward = 1;
$HorseDeathAnim::TorsoFrontFallBack = 2;
$HorseDeathAnim::TorsoBackFallForward = 3;
$HorseDeathAnim::TorsoLeftSpinDeath = 4;
$HorseDeathAnim::TorsoRightSpinDeath = 5;
$HorseDeathAnim::LegsLeftGimp = 6;
$HorseDeathAnim::LegsRightGimp = 7;
$HorseDeathAnim::TorsoBackFallForward = 8;
$HorseDeathAnim::HeadFrontDirect = 9;
$HorseDeathAnim::HeadBackFallForward = 10;
$HorseDeathAnim::ExplosionBlowBack = 11;

// The delay time before a pathed horse will return to it's path after the
// player dismounts
$Horse::ReturnDelay = 2 * 60 * 1000;   // 2 Minutes

// Delay time before a horse will respawn after death or pickup
$Horse::RespawnDelay = .5 * 60 * 1000;   // 30 seconds

// The delay time before a horse becomes free when left unattended
$Horse::StableDelay = 10 * 60 * 1000;   // 10 Minutes

//----------------------------------------------------------------------------
// Steed Datablock methods
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

function Steed::onAdd(%this,%obj)
{
   // Default dynamic Steed stats
   %obj.setRechargeRate(%this.rechargeRate);

   // Horses auto repair
   //%obj.setRepairRate(%this.repairRate);
   %obj.setRepairRate(0.002);

   %obj.setEnergyLevel(60);
}

function Steed::onRemove(%this, %obj)
{
   if (%obj.client.Horse == %obj)
      %obj.client.Horse = 0;

   if ( isEventPending(%obj.FreeSchedule) )
      cancel(%obj.FreeSchedule);
}

//----------------------------------------------------------------------------

function Steed::onRearing(%this,%obj)
{
   %obj.playPain();
}

//----------------------------------------------------------------------------

function Steed::onCollision(%this,%obj,%col,%vec,%speed)
{
   //%obj.damage(0, VectorAdd(%obj.getPosition(),%vec),
   //   %speed * %this.speedDamageScale, "Collision");
}

function Steed::onImpact(%this, %obj, %collidedObject, %vec, %vecLen)
{
   // RFB -> the horse has a large bounds box that occasionally
   // causes an impact on rough terrain. let's prevent this here.
   if (%collidedObject.getType() & $TypeMasks::TerrainObjectType)
      return;
   // <- RFB

   %obj.damage(0, VectorAdd(%obj.getPosition(),%vec),
      %vecLen * %this.speedDamageScale, "Impact");
}


//----------------------------------------------------------------------------

function Steed::damage(%this, %obj, %sourceObject, %position, %damage, %damageType)
{
   if ((%obj.getState() $= "Dead") || %obj.inNeutralZone)
      return;
   %obj.applyDamage(%damage);
   %location = "Body";
}

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
      castSpell(AstralPassportSpell, %client.horse, %client.horse);
      %client.horse.schedule(3500, "delete");
      %client.horse.client = "";
      %client.horse = "";
   }
   else
   {  // Spawn a horse for the player
      %horse = new AIPlayer() {
        dataBlock = %horseDB;
        aiPlayer = true;
      };
      MissionCleanup.add(%horse);
      %horse.setScale("0.714 0.714 0.714");
      %client.horse = %horse;
      %horse.owner = %client;
      %horse.itemDB = %itemDB;
      %horse.setSkinName(%horseDB.skinName);
      %transform = FindHorseSpawn(%user, %horse);
      %horse.setTransform(%transform);
      %horse.setEnergyLevel(1);
      %horse.setMoveSpeed(0.1);
      %horse.setClanName(%client.playerName);
      %horse.startFade(0, 0, true);
      %horse.respawn = false;
      %horse.mountable = true;
      // Set a timer to free the horse if it is unattended too long
      %horse.FreeSchedule = %horse.schedule($Horse::StableDelay, "SetHorseFree");

      
      castSpell(AstralPassportReappearSpell, %horse, %horse);
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
      %horse.setScale("0.714 0.714 0.714");
      %horse.setSkinName(%horseDB.skinName);
      %transform = FindHorseSpawn(%user, %horse);
      %horse.setTransform(%transform);
      %horse.setEnergyLevel(1);
      %horse.startFade(0, 0, true);      
      %horse.respawn = false;
      castSpell(AstralPassportReappearSpell, %horse, %horse);
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
      //if ( %i == 0 )
      //{
         //%zVal = getWord(%trans, 2);
         //%rotVal = getWord(%trans, 3);
         //if ( %zVal > 0 )
         //{
            //%rotVal -= 1.57;
            //%zVal = 1;
         //}
         //else
         //{
            //%rotVal += 1.57;
            //%zVal = -1;
         //}
         //%useTrans = "0 0" SPC %zVal SPC %rotVal;
      //}
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

//----------------------------------------------------------------------------
//12480.mountObject(12476, 0, "0 .35 -.1");
