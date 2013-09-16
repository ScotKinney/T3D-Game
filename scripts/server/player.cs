//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

// Timeouts for corpse deletion.
$CorpseTimeoutValue = 7 * 1000;

// // Damage Rate for entering Liquid
 $DamageWater = 1;
 $DamageBogWater = 2;
 //$DamageLava = 0.5;
 $DamageLava = 2;
 $DamageHotLava = 10;
 $DamageCrustyLava = 0.4;

// Death Animations
$PlayerDeathAnim::TorsoFrontFallForward = 1;
$PlayerDeathAnim::TorsoFrontFallBack = 2;
$PlayerDeathAnim::TorsoBackFallForward = 3;
$PlayerDeathAnim::TorsoLeftSpinDeath = 4;
$PlayerDeathAnim::TorsoRightSpinDeath = 5;
$PlayerDeathAnim::LegsLeftGimp = 6;
$PlayerDeathAnim::LegsRightGimp = 7;
$PlayerDeathAnim::TorsoBackFallForward = 8;
$PlayerDeathAnim::HeadFrontDirect = 9;
$PlayerDeathAnim::HeadBackFallForward = 10;
$PlayerDeathAnim::ExplosionBlowBack = 11;

$PlayerImpulseScale = 0.3;

function PLAYERDATA::onAdd(%this,%obj)
{
   //Scale the player
   %obj.setscale(".714 .714 .714");  

   // Vehicle timeout
   %obj.mountVehicle = true;

   // Default dynamic armor stats
   %obj.setRechargeRate(%this.rechargeRate);
   %obj.setRepairRate(0);

    %obj.newlyAdded = true;
}

function PLAYERDATA::onRemove(%this, %obj)
{
   // GUY >>
   // don't leave inventory array hanging about on the server
   if(isObject(%obj.inv))
      %obj.inv.delete();
   //%obj.FlashlightDisable();
   if(isObject(%obj.light))
      %obj.light.delete();
   // GUY <<
   
   if (%obj.client.player == %obj)
      %obj.client.player = 0;
}

function PLAYERDATA::onNewDataBlock(%this,%obj)
{
}

//----------------------------------------------------------------------------

function PLAYERDATA::onMount(%this, %obj, %vehicle, %node)
{
   %vDB = %vehicle.getDatablock();
   %obj.setActionThread(%vDB.mountPose[%node], true, true);
   %obj.lastWeapon = %obj.getMountedImage($WeaponSlot);

   // Make sure players scale remains constant 0.714 when mounted
   //%obj.setscale("1 1 1");
   %scaleZ = getWord(%vehicle.getScale(), 2);
   %newScale = 0.714 / %scaleZ;
   %obj.setscale(%newScale SPC %newScale SPC %newScale);
   %obj.setTransform("0 0 0 0 0 1 0");
   //%obj.unmountImage($WeaponSlot);
   if (%node == %vDB.driverNode)
   {
      if ( isEventPending(%vehicle.FreeSchedule) )
         cancel(%vehicle.FreeSchedule);
      if ( isEventPending(%vehicle.aiLoop) )
         cancel(%vehicle.aiLoop);

      %obj.setControlObject(%vehicle);
   }
   else if ( %node == %vDB.riderNode )
   {
      %client = %obj.client;
      if ( isObject(%client.camera) )
      {
         %client.camera.setOrbitObject(%obj, "0 0 0", 2, 15, 3, true);
         %client.setControlObject(%client.camera);
      }
   }
}

function PLAYERDATA::onUnmount(%this, %obj, %vehicle, %node)
{
   if ( %obj.lastWeapon !$= "" )
      %obj.mountImage(%obj.lastWeapon.image, $WeaponSlot);
   %obj.setscale(".714 .714 .714"); // Restore the players scale

   %vDB = %vehicle.getDatablock();
   if (%node == %vDB.driverNode)
   {      
      %obj.setControlObject("");
      %vehicle.driver = -1;
      %vehicle.client = -1;
      if ( (%vehicle.owner == %obj.client) && (%vehicle.owner !$= "") )
      {  // Set a timer to free the mount if it is unattended too long
         %vehicle.FreeSchedule = %vehicle.schedule($Horse::StableDelay, "SetHorseFree");
      }
      else if ( %vehicle.behavior.isAggressive )
         %vehicle.ailoop = %vehicle.schedule($AISK_QUICK_THINK, "Think", %vehicle);
      else if ( isObject(%vehicle.path) )
         %vehicle.moveToNode(%vehicle.currentNode);
   }
   else
   {
      if ( isObject(%obj.client) )
         %obj.client.setControlObject(%obj);
   }
   
   if ( %obj.isBot && %obj.behavior.isAggressive )
      %obj.ailoop = %obj.schedule($AISK_QUICK_THINK, "Think", %obj);
}

function PLAYERDATA::doDismount(%this, %obj, %forced)
{
    // This function is called by player.cc when the jump trigger
    // is true while mounted
    if (!%obj.isMounted())
        return;

    // Position above dismount point
    %pos = getWords(%obj.getTransform(), 0, 2);
    %oldPos = %pos;
    %vec[0] = " .75 0 1";
    %vec[1] = " -.75 0 1";
    %vec[2] = " 0 1 1";
    %vec[3] = " 1 0 0";
    %vec[4] = "-1 0 0";
    %impulseVec  = "0 0 0";
    //%vec[0] = MatrixMulVector( %obj.getTransform(), %vec[0]);

    // Make sure the point is valid
    %pos = "0 0 0";
    %numAttempts = 5;
    %success = -1;
    for (%i = 0; %i < %numAttempts; %i++)
    {
        %vec[%i] = MatrixMulVector( %obj.getTransform(), %vec[%i]);
        %pos = VectorAdd(%oldPos, VectorScale(%vec[%i], 3));
        if (%obj.checkDismountPoint(%oldPos, %pos))
        {
            %success = %i;
            %impulseVec = %vec[%i];
            break;
        }
    }
    if (%forced && %success == -1)
       %pos = %oldPos;


    %obj.mountVehicle = false;
    %obj.schedule(4000, "mountVehicles", true);

    // Position above dismount point
    %obj.unmount();
    %obj.setTransform(%pos);
    %obj.applyImpulse(%pos, VectorScale(%impulseVec, %obj.getDataBlock().mass));
    %obj.vehicleTurret = "";
    %obj.aiMount = "";
}


//----------------------------------------------------------------------------

function PLAYERDATA::onCollision(%this, %obj, %col)
{
   if (!isObject(%col) || (%obj.getState() $= "Dead"))
      return;

   //echo("PlayerVelocity = " @ %obj.getVelocity() @ ", speed = " @ VectorLen(%obj.getVelocity()));

   //AISK Changes: Start
   //If this is a bot that collided with an enemy, face that enemy
   if (%obj.isbot == true)
   {
      if ( %obj.action $= "Thief" )
      {  // Try to jump it
         return;
      }

      if ( (%col.getClassName()$="Player" || %col.getClassName()$="aiPlayer") && %col.getState() $= "Dead" )
      {
         if (%obj.getAimObject() == %col)
            %obj.clearAim();
         return;
      }

      if (%col.team != %obj.team && %col.team !$= "")
      {
        //If the bot is skittish, have it run away
        if (%obj.behavior.isSkittish)
            %obj.sidestep(%obj);

         if (%obj.getAimObject() <= 0)
         {
            if (!%obj.behavior.isSkittish && !isObject(%obj.path))
                %obj.setAimObject(%col, $AISK_CHAR_HEIGHT);

            if (%obj.behavior.isAggressive)
            {
               if( isEventPending(%obj.ailoop) )
                  cancel(%obj.ailoop);
               %obj.ailoop = %obj.schedule($AISK_QUICK_THINK, "Think", %obj);
            }
         }
      }
   }
   //AISK Changes: End
   
   // If we ran into a mountable AI, attempt to mount it
   %hitClass = %col.getClassName();
   if ((%hitClass $= "AIPlayer") && %col.mountable && %obj.mountVehicle && !%obj.isMounted())
   {
      // can't mount a dead AI
      if (%col.getState() $= "Dead")
         return;

      // must not mount an already mounted AI
      %vDB = %col.getDatablock();
      %player = %col.getMountNodeObject(%vDB.driverNode);
      if ( isObject(%player) )
      {
         if ((%col.getMountedObjectCount() < 2) && (%vDB.riderNode !$= ""))
         {  // If there's room, ask the driver if we can ride along
            if ( (%obj.sentRequest $= %col) || ((VectorLen(%obj.getVelocity()) < 0.5) && ($ServerName !$= "MarsTest")) )
               return;
            %obj.sentRequest = %col;
            if (%obj.isBot && $ServerName $= "MarsTest")
               forceAcceptMountRequest(%col, %obj);
            else
               commandToClient(%player.client, 'ShowMountRequest', %obj.getShapeName(), %obj.client);
            messageClient(%obj.client, 'LocalizedMsg', "", "mountMsg", "a", true, true, 1, %player.getShapeName());
         }
         return;
      }

      if ( (isObject(%col.owner) && (%obj.client != %col.owner)) || %col.buyable )
      {  // Cant mount a horse we don't own
         %oldSpeed = %col.getMoveSpeed();
         %col.setMoveSpeed(0);
         %col.mountable = false;
         %col.setActionThread("rejectmount", false, false);
         %col.playPain();
         %col.schedule(2500, "setMoveSpeed", %oldSpeed);
         %col.schedule(5000, "setMountable", true);
         return;
      }

      // Only mount drivers for now.
      %node = %vDB.driverNode;

      %obj.aiMount = %col;
      %col.driver = %obj;

      %client = %obj.client;
      %client.aiMount = %col;
      %col.client = %client;
      //BloodClans - adjust the 0 0 0 below for xyz positioning////////////////////////////////////////////
      %col.mountObject(%obj,%node,"0 0 0");//0 .35 -.1
      return;
   }

   // If we ran into a rigid shape apply an impulse
   if ((%hitClass $= "RigidShape") || (%hitClass $= "Player") || (%hitClass $= "AIPlayer"))
   {
      //%playerVelocity = setWord(%obj.getVelocity(), 2, "0"); // Get x and y component of velocity
      %playerVelocity = %obj.getVelocity();
      %playerVelocity = VectorScale(%playerVelocity, %this.mass * $PlayerImpulseScale); // Scale up for impulse
      %playerPosition = %obj.getPosition();
      // Player position is at feet so move up to hands
      %zPos = getWord(%playerPosition, 2) + 1.5;
      %playerPosition = setWord(%playerPosition, 2, %zPos);
      %col.applyImpulse(%playerPosition, %playerVelocity);
      return;
   }

   if (%obj.isbot == true)
   {
      if ($ServerName !$= "MarsTest")
         return;  // Don't let bots mount vehicles
   }

   // Mount vehicles
   if (%col.getType() & $TypeMasks::GameBaseObjectType)
   {
      %db = %col.getDataBlock();
      if ((%db.getClassName() $= "WheeledVehicleData") && %obj.mountVehicle && %obj.getState() $= "Move" && %col.mountable)
      {
         // Only mount drivers for now.
         %node = 0;
         %col.mountObject(%obj, %node);
      }
   }
}

function PLAYERDATA::onImpact(%this, %obj, %collidedObject, %vec, %vecLen)
{
   %obj.damage(0, VectorAdd(%obj.getPosition(),%vec),
      %vecLen * %this.speedDamageScale, "Impact");
}


//----------------------------------------------------------------------------

function PLAYERDATA::damage(%this, %obj, %sourceObject, %position, %damage, %damageType)
{
   if (%obj.getState() $= "Dead")
      return;

   if ( %obj.inNeutralZone )
   {
      return;
   }
   
   //AISK Changes: Start
   //If friendly fire is turned off, and the source and target are on
   //the same team, then return
   if ($AISK_FRIENDLY_FIRE == false && $AISK_FREE_FOR_ALL == false)
   {
        if (%sourceObject.team == %obj.team)
            return;
   }

   //If this is a bot, set its attention level
   if ((%obj.isbot == true) && (%obj.action !$= "Thief"))
   {
        //Move a little when hit, aggressive bots move in the "Defending" state
        if (!%obj.behavior.isAggressive)
            %obj.sidestep(%obj);
        else if (!%obj.behavior.isHunted)
        {
        //Item gathering has been commented out because it does not work properly
        //if (%obj.action !$= "GetHealth")
        //{
            //If the bot got sniped, enhance its vision
            if (%obj.action !$= "Attacking" && %obj.action !$= "Defending" && %obj.getstate() !$= "Dead")
            {
                %obj.enhancedefending(%obj);
                %obj.attentionlevel = 1;
               if( isEventPending(%obj.ailoop) )
                  cancel(%obj.ailoop);
                %obj.ailoop = %obj.schedule($AISK_QUICK_THINK, "Think", %obj);
            }

            if ( (%this.getName() !$= "Boglin") && (%this.getName() !$= "BoglinBig") && (%this.getName() !$= "Tolgart") )
               %obj.action = "Defending";
        //}
        }

        //Don't hurt unkillable bots
        if (!%obj.behavior.isKillable)
            return;
   }
   else if ( isObject(%obj.client) )
   {
      %playerSL = %obj.client.getPersistantStat("skulls");
      %sourceClient = %sourceObject ? %sourceObject.client : 0;
      if ( (%playerSL < 3) && isObject(%sourceClient) )
         return;  // SL 1&2 do not take pvp damage
      if ( isObject(%sourceClient) && (%sourceClient.getPersistantStat("skulls") < 3) )
         return;  // SL 1&2 do not do PvP damage either
   }

   %obj.lastDamage = %obj.getDamagePercent();
   %obj.lastDmgType = %damageType;
   %obj.applyDamage(%damage);
   %location = "Body";

   // Update the numerical Health HUD
   %obj.updateHealth();

   // Deal with client callbacks here because we don't have this
   // information in the onDamage or onDisable methods
   %client = %obj.client;
   %sourceClient = %sourceObject ? %sourceObject.client : 0;

   if (%obj.getState() $= "Dead")
   {
      //Respawn the bot if needed
      if (%obj.isbot == true)
      {
         // If this bot was killed by a player, give them the kill stat
         if (isObject(%sourceClient) && isObject(%sourceClient.pData))
         {
            if ( isObject(Deer) && %obj.getDatablock() == Deer.getID() )
               DB::SprocNoRet("sp_StatsDeerKill", "'" @ %sourceClient.pData.dbID @ "'");
            else if ( %obj.behavior.isAggressive || (%obj.action $= "Thief") )
               DB::SprocNoRet("sp_StatsAIKill", "'" @ %sourceClient.pData.dbID @ "'");

            // If it was a boglin, give them the toes.
            if ( isObject(Boglin) && ((%obj.getDatablock() == Boglin.getID()) ||
                  (%obj.getDatablock() == BoglinBig.getID())) )
            {
               %amount = %sourceClient.player.incInventory(Boglin_Toes, 10);
               if ( %amount > 0 )
               {
                  %message = "\c0You killed a Boglin and collect " @ %amount SPC Boglin_Toes.pickupName;
                  if ( %amount > 1 )
                     %message = %message @ "s";
                  messageClient(%sourceClient, 'MsgItemPickup', %message);
               }
            }
         }

         if (%obj.respawn == true)
         {
            %obj.marker.delayRespawn = schedule(%obj.respawnTime, %obj.marker, "AIPlayer::spawn", %obj.marker);
            %this.player = 0;
         }
         else
            %obj.marker.botBelongsToMe = "";
      }
      else if (isObject(%client))
      {
         if ( isObject(%client.pData) )
         {  // Give them the death stat
            if (isObject(%sourceClient) && isObject(%sourceClient.pData))
               DB::SprocNoRet("sp_StatsPvPKill", "'" @ %sourceClient.pData.dbID @ "','" @ %client.pData.dbID @ "'");
            else if (%sourceObject.isBot)
               DB::SprocNoRet("sp_StatsAIDeath", "'" @ %client.pData.dbID @ "'");
            else
               DB::SprocNoRet("sp_StatsEnvDeath", "'" @ %client.pData.dbID @ "'");
         }
         %client.onDeath(%sourceObject, %sourceClient, %damageType, %location);
      }

      // If we have death effects spawn them now.
      if ( %this.deathEffectron !$= "" )
      {
         %eff = startEffectron(%this.deathEffectron, %obj, "impactedObject");
         if ( %damageType $= "RadiusDamage" )
            %position = %obj.getPosition();
         %eff.addConstraint(%position, "impactPoint"); 
      }
   }
   //AISK Changes: End
}

function PLAYERDATA::onDamage(%this, %obj, %delta, %isSilent)
{
   // This method is invoked by the ShapeBase code whenever the
   // object's damage level changes.
   if (%delta > 0 && %obj.getState() !$= "Dead") {

      // Increment the flash based on the amount.
      %flash = %obj.getDamageFlash() + ((%delta / %this.maxDamage) * 2);
      if (%flash > 0.75)
         %flash = 0.75;
      %obj.setDamageFlash(%flash);

      // If the pain is excessive, let's hear about it unless it's first spawn.
      if ((%delta > 10) && !%obj.newlyAdded && !%isSilent)
      {
         %obj.playPain();
         if ( %obj.isBot )
            %obj.setActionThread("damage1", false, false);
      }
   }
   
   // BloodClans >>
   if ( !isObject(%obj.client) )
      return;
      
   // Update the health stats
   %obj.updateHealth();
   // check if we need to warn the client about his health status
   if(%delta > 0)
      %obj.client.healthWarning(%obj);
   // BloodClans <<
}

function PLAYERDATA::onDisabled(%this,%obj,%state)
{
   // Release the main weapon trigger
   %obj.setImageTrigger(0, false);

   // If it's a custom bot, let it process the death
    if ( (%obj.getClassName() $= "AIPlayer") && 
         %obj.getDatablock().isMethod("handleBotDeath") )
    {
        %obj.getDatablock().handleBotDeath(%obj);
        //return;
    }

   // The player object sets the "disabled" state when damage exceeds
   // it's maxDamage value.  This is method is invoked by ShapeBase
   // state mangement code.

   // If we want to deal with the damage information that actually
   // caused this death, then we would have to move this code into
   // the script "damage" method.
   // Toss out a health patch
   //%obj.tossPatch();
   if ( %obj.getClassName() $= "AIPlayer" && %obj.dropitem !$= "" && %obj.lastDmgType !$= "Water")
   {
      %item = new Item() {
         aiDrop = "1";
         static = "0";
         rotate = "0";
         dataBlock = %obj.dropitem;
         position = %obj.getPosition();
         rotation = "1 0 0 0";
         scale = "1 1 1";
         canSave = "1";
         canSaveDynamicFields = "1";
            count = %obj.dropcount;
      };
      if ( isObject(%item) )
      {
         %item.setCollisionTimeout(%obj);
         %item.schedulePop();
         MissionCleanup.add(%item);
      }
      else  
         echo("Failed to create new Item...");
   }
   if ( %obj.getClassName() $= "AIPlayer" && %obj.dropitem2 !$= "" && %obj.lastDmgType !$= "Water" )
   {
      %item = new Item() {
         aiDrop = "1";
         static = "0";
         rotate = "0";
         dataBlock = %obj.dropitem2;
         position = %obj.getPosition();
         rotation = "1 0 0 0";
         scale = "1 1 1";
         canSave = "1";
         canSaveDynamicFields = "1";
            count = %obj.dropcount;
      };
      if ( isObject(%item) )
      {
         //%item.setCollisionTimeout(%obj);
         %item.schedulePop();
         MissionCleanup.add(%item);
         %obj.throwObject(%item);
      }
      else  
         echo("Failed to create new Item...");
   }
   //epls end
   %obj.playDeathCry();
   %obj.playDeathAnimation();
   //%obj.setDamageFlash(0.75);

   // Schedule corpse removal.  Just keeping the place clean.
   %obj.schedule($CorpseTimeoutValue - 1000, "startFade", 1000, 0, true);
   %obj.schedule($CorpseTimeoutValue, "delete");
}


//-----------------------------------------------------------------------------

function PLAYERDATA::onLeaveMissionArea(%this, %obj)
{
   // Inform the client
   %obj.client.onLeaveMissionArea();
}
function PLAYERDATA::onEnterMissionArea(%this, %obj)
{
   // Inform the client
   %obj.client.onEnterMissionArea();
}

//-----------------------------------------------------------------------------

function PLAYERDATA::onEnterLiquid(%this, %obj, %coverage, %type)
{
    switch$(%type)
    {
       case "Water": //Water
          //%obj.setDamageDt($DamageWater, "Water");
          return;
       case "OceanWater": //Ocean Water
       case "RiverWater": //River Water
       case "BogWater": //Bog Water
        %obj.setDamageDt($DamageWater, "BogWater");
       case "Lava": //Lava
          %obj.setDamageDt($DamageLava, "Lava");
       case "HotLava": //Hot Lava
          %obj.setDamageDt($DamageHotLava, "Lava");
       case "CrustyLava": //Crusty Lava
          %obj.setDamageDt($DamageCrustyLava, "Lava");
       case "QuickSand": //Quick Sand
    }
}

function PLAYERDATA::onLeaveLiquid(%this, %obj, %type)
{
   %obj.clearDamageDt();
}


//-----------------------------------------------------------------------------

function PLAYERDATA::onTrigger(%this, %obj, %triggerNum, %val)
{
   // This method is invoked when the player receives a trigger
   // move event.  The player automatically triggers slot 0 and
   // slot one off of triggers # 0 & 1.  Trigger # 2 is also used
   // as the jump key.
   return;
}


//-----------------------------------------------------------------------------
// Player methods
//-----------------------------------------------------------------------------

//----------------------------------------------------------------------------

function Player::kill(%this, %damageType)
{
   %this.damage(0, %this.getPosition(), 10000, %damageType);
}


//----------------------------------------------------------------------------

function Player::mountVehicles(%this,%bool)
{
   // If set to false, this variable disables vehicle mounting.
   %this.mountVehicle = %bool;
}

function Player::isPilot(%this)
{
   %vehicle = %this.getObjectMount();
   // There are two "if" statements to avoid a script warning.
   if (%vehicle)
      if (%vehicle.getMountNodeObject(0) == %this)
         return true;
   return false;
}


//----------------------------------------------------------------------------

function Player::playDeathAnimation(%this)
{
   //AISK Changes: Start
   if (isObject(%this.client))
   {
      if (%this.client.deathIdx++ > 11)
         %this.client.deathIdx = 1;

      %this.setActionThread("Death" @ %this.client.deathIdx);
   }
   else
   {
      %rand = getRandom(1, 11);
      if ( !%this.setActionThread("Death" @ %rand) )
         %this.setActionThread("Death");
   }
   //AISK Changes: End
}

function Player::playCelAnimation(%this,%anim)
{
   if ( (%this.getState() !$= "Dead") && !%this.isMounted() )
      %this.setActionThread("cel"@%anim);
}

function Player::playXtraAnimation(%this,%anim)
{
   if ( (%this.getState() !$= "Dead") && !%this.isMounted() )
      %this.setActionThread(%anim);
}

//----------------------------------------------------------------------------

function Player::playDeathCry( %this )
{
   %this.playAudio(0, %this.getDataBlock().DeathSound);   
   //%this.playAudio(0,DeathCrySound);
}

function Player::playPain( %this )
{
   %db = %this.getDataBlock();
   if ( %db.PainSound !$= "" )
      %this.playAudio(0, %db.PainSound);
   else if ( %db.numHitSounds > 0 )
   {
      %idx = getRandom(0, (%db.numHitSounds-1));
      %this.playAudio(0, %db.HitSound[%idx]);
   }
   //%this.playAudio(0,PainCrySound);
}

// ----------------------------------------------------------------------------
// Numerical Health Counter
// ----------------------------------------------------------------------------

function Player::updateHealth(%player)
{
   if ( !isObject(%player.client) )
      return;
      
   //echo("\c4Player::updateHealth() -> Player Health changed, updating HUD!");

   // Calcualte player health
   %maxDamage = %player.getDatablock().maxDamage;
   %damageLevel = %player.getDamageLevel();
   %curHealth = %maxDamage - %damageLevel;
   %curHealth = mceil(%curHealth);

   %player.client.setHealthLevel(%curHealth);
}

function Player::use(%player, %data)
{
   // No mounting/using weapons when you're driving!
   if (%player.isMounted() &&
      ((%data.category $= "weapons") || (%data.category $= "magic") || (%data.category $= "ammo")) )
     return(false);

  return Parent::use(%player, %data);
}

function Player::onAnimationTrigger(%this, %obj, %slot)
{
   //we use slot 3 of the addTrigger to key an attack on the animation.
   if ( (%slot == 3) && (%obj.firingWeapon !$= "") )
   {
      %obj.firingWeapon.delayedFire(%obj, 0);
      %obj.firingWeapon = "";
   }
}

function serverCmdAcceptMountRequest(%client, %requestor)
{
   %vehicle = %client.aiMount;
   %player = %requestor.player;
   if (isObject(%vehicle) && isObject(%player))
   {
      %vDB = %vehicle.getDatablock();
      %player.sentRequest = "";
      %vehicle.mountObject(%player, %vDB.riderNode, "0 0 0");//0 -.3 0
   }
}

function forceAcceptMountRequest(%vehicle, %player)
{
   if (isObject(%vehicle) && isObject(%player))
   {
      if ( isEventPending(%player.ailoop) )
         cancel(%player.ailoop);
      %vDB = %vehicle.getDatablock();
      %player.sentRequest = "";
      %vehicle.mountObject(%player, %vDB.riderNode, "0 0 0");//0 -.3 0
   }
}

function PlayerData::onPoseChange(%this, %obj, %oldPose, %newPose)
{
   if ( %obj.isBot )
      return;

   if (%newPose $= "Swim")
      %obj.setDamageDt($DamageWater, "Water");
   else if (%oldPose $= "Swim")
      %obj.clearDamageDt();
}
