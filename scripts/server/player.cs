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

$PlayerImpulseScale = 1;

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
   // don't leave inventory array hanging about on the server
   if(isObject(%obj.inv))
      %obj.inv.delete();

   if(isObject(%obj.light))
      %obj.light.delete();
   
   if(isObject(%obj.TAPLink))
      %obj.TAPLink.delete();

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
   %obj.AVCheckWeapons();

   // Make sure players scale remains constant 0.714 when mounted
   %scaleZ = getWord(%vehicle.getScale(), 2);
   %newScale = 0.714 / %scaleZ;
   %obj.setscale(%newScale SPC %newScale SPC %newScale);
   %obj.setTransform("0 0 0 0 0 1 0");//0 0 0 0 0 1 0

   if (%node == %vDB.driverNode)
   {
      if ( isEventPending(%vehicle.FreeSchedule) )
         cancel(%vehicle.FreeSchedule);
      if ( isEventPending(%vehicle.aiLoop) )
         cancel(%vehicle.aiLoop);

      %vehicle.setMountBaseSpeed(%vDB.mountBaseSpeed);
      //%obj.setControlObject(%vehicle);
      %obj.setMountHeadAngles();
      if ( %vDB.mountHeadHThread !$= "" )
         %obj.setHeadHThread(%vDB.mountHeadHThread, %vDB.maxMountYawAngle);
      if ( %vDB.mountHeadVThread !$= "" )
         %obj.setHeadVThread(%vDB.mountHeadVThread, %vDB.maxMountPitchAngle);
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

   if ( %obj.isBot && isEventPending(%obj.aiLoop) )
   {
      cancel(%obj.aiLoop);
      %obj.clearAim();
   }
}

function PLAYERDATA::onUnmount(%this, %obj, %vehicle, %node)
{
   if ( !isObject(%vehicle) || !$missionRunning )
      return;

   %obj.setscale(".714 .714 .714"); // Restore the players scale

   %vDB = %vehicle.getDatablock();
   %objDB = %obj.getDatablock();
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

      if ( %vDB.mountHeadHThread !$= "" )
         %obj.setHeadHThread("headside", %objDB.maxHeadYawAngle);
      if ( %vDB.mountHeadVThread !$= "" )
         %obj.setHeadVThread("head", %objDB.maxLookAngle);
   }
   else
   {
      if ( isObject(%obj.client) )
         %obj.client.setControlObject(%obj);
   }
   
   if ( !%obj.isBot )
      %obj.AVResetWpnState();

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
   %hitClass = %col.getClassName();
   if (!isObject(%col) || (%obj.getState() $= "Dead") ||
         (%hitClass $= "TerrainBlock"))
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
            if (!%obj.behavior.isSkittish && !isObject(%obj.path) && isObject(%tgt))
                //%obj.setAimObject(%col, $AISK_CHAR_HEIGHT);
                %obj.setAimObject(%col, VectorSub(%tgt.getEyePoint(), %tgt.getPosition()));

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
            if ( (%obj.sentRequest $= %col) || ((VectorLen(%obj.getVelocity()) < 0.5) && ($ServerName !$= "EmptyRoom")) )
               return;
            %obj.sentRequest = %col;
            if (%obj.isBot && $ServerName $= "EmptyRoom")
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
      %obj.setControlObject(%col);
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
      %playerPosition = %col.getWorldBoxCenter();
      // Player position is at feet so move up to hands
      //%zPos = getWord(%playerPosition, 2) + 1.5;
      //%playerPosition = setWord(%playerPosition, 2, %zPos);
      %col.applyImpulse(%playerPosition, %playerVelocity);
      if ( %obj.isBot && !isObject(%obj.owner) )
         %obj.sideStep(%obj);
      return;
   }

   //if (%obj.isbot == true)
   //{
      //if ($ServerName !$= "MarsTest")
         //return;  // Don't let bots mount vehicles
   //}

   // Mount vehicles
   if (%col.getType() & $TypeMasks::GameBaseObjectType)
   {
      %vDB = %col.getDataBlock();
      if ((%vDB.getClassName() $= "WheeledVehicleData") && %obj.mountVehicle &&
            %obj.getState() $= "Move" && %col.mountable && !%obj.isMounted())
      {
         // Only mount drivers for now.
         //%node = 0;
         //%col.mountObject(%obj, %node);
         %driver = %col.getMountNodeObject(%vDB.driverNode);
         if ( isObject(%driver) )
         {
            if ((%col.getMountedObjectCount() < %vDB.numMountPoints) && (%vDB.riderNode !$= ""))
            {  // If there's room, ask the driver if we can ride along
               if ( (%obj.sentRequest $= %col) || ((VectorLen(%obj.getVelocity()) < 0.5) && ($ServerName !$= "EmptyRoom")) )
                  return;
               %obj.sentRequest = %col;
               if (%obj.isBot && $ServerName $= "EmptyRoom")
                  forceAcceptMountRequest(%col, %obj);
               else
                  commandToClient(%driver.client, 'ShowMountRequest', %obj.getShapeName(), %obj.client);
               messageClient(%obj.client, 'LocalizedMsg', "", "mountMsg", "a", true, true, 1, %driver.getShapeName());
            }
            return;
         }

         %node = %vDB.driverNode;

         %obj.aiMount = %col;
         %col.driver = %obj;

         %client = %obj.client;
         %client.aiMount = %col;
         //%col.client = %client;
         %col.mountObject(%obj,%node,"0 0 0");//0 .35 -.1
      }
   }
   else if ( %obj.isBot && !isObject(%obj.owner) )
      %obj.sideStep(%obj);
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
   
   //If friendly fire is turned off, and the source and target are on
   //the same team, then return
   if ($AISK_FRIENDLY_FIRE == false && $AISK_FREE_FOR_ALL == false)
   {
        if (%sourceObject.team == %obj.team)
            return;
   }

   //If this is a bot, set its attention level
   if ((%obj.isbot == true) && !isObject(%obj.owner) && (%obj.action !$= "Thief"))
   {
      if ( %obj.team != %sourceObject.team )
         %obj.targetEngaged = %sourceObject;  // Remember who hit us last

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
   //else if ( isObject(%obj.client) )
   //{
      //%playerSL = %obj.client.getPersistantStat("skulls");
      //%sourceClient = %sourceObject ? %sourceObject.client : 0;
      //if ( (%playerSL < 3) && isObject(%sourceClient) )
         //return;  // SL 1&2 do not take pvp damage
      //if ( isObject(%sourceClient) && (%sourceClient.getPersistantStat("skulls") < 3) )
         //return;  // SL 1&2 do not do PvP damage either
   //}

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

   if (%obj.getState() !$= "Dead")
   {
      // If the pain is excessive, let's hear about it unless it's first spawn.
      %painThreshold = (%this.painThreshold $= "") ? 10 : %this.painThreshold;
      if ((%damage > %painThreshold) && !%obj.newlyAdded)
      {
         %obj.playPain();
         %this.playDamage(%obj, %position);
      }
   }
   else
   {
      //Respawn the bot if needed
      if (%obj.isbot == true)
      {
         // If this bot was killed by a player, give them the kill stat
         if (isObject(%sourceClient) && isObject(%sourceClient.pData))
         {
            //if ( isObject(Deer) && %obj.getDatablock() == Deer.getID() )
               //DB::SprocNoRet("sp_StatsDeerKill", "'" @ %sourceClient.pData.dbID @ "'");
            //else if ( %obj.behavior.isAggressive || (%obj.action $= "Thief") )
               //DB::SprocNoRet("sp_StatsAIKill", "'" @ %sourceClient.pData.dbID @ "'");

            // If it was a boglin, give them the toes.
            if ( isObject(Boglin) && ((%obj.getDatablock() == Boglin.getID()) ||
                  (%obj.getDatablock() == BoglinBig.getID())) )
            {
               %amount = %sourceClient.player.incInventory(Boglin_Toes, 10);
               if ( %amount > 0 )
               {
                  %message = "\c0You killed a Boglin and collect " @ %amount @ " Boglin Toe";
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
      //if ( %this.deathEffectron !$= "" )
      //{
         //%eff = startEffectron(%this.deathEffectron, %obj, "impactedObject");
         //if ( %damageType $= "RadiusDamage" )
            //%position = %obj.getPosition();
         //%eff.addConstraint(%position, "impactPoint"); 
      //}
   }
}

function PLAYERDATA::onDamage(%this, %obj, %delta, %isSilent)
{
   // This method is invoked by the ShapeBase code whenever the
   // object's damage level changes.
   if (%delta > 0 && %obj.getState() !$= "Dead")
   {

      // Increment the flash based on the amount.
      %flash = %obj.getDamageFlash() + ((%delta / %this.maxDamage) * 2);
      if (%flash > 0.75)
         %flash = 0.75;
      %obj.setDamageFlash(%flash);

      // If the pain is excessive, let's hear about it unless it's first spawn.
      //%painThreshold = (%this.painThreshold $= "") ? 10 : %this.painThreshold;
      //if ((%delta > %painThreshold) && !%obj.newlyAdded && !%isSilent)
      //{
         //%obj.playPain();
         //%this.playDamage(%obj);
      //}
   }
   
   // BloodClans >>
   if ( !isObject(%obj.client)  || (%obj != %obj.client.player) )
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
   if ( %obj.isMounted() )
      %obj.getDatablock().doDismount(%obj, true);
   %obj.playDeathCry();
   %obj.playDeathAnimation();
   //%obj.setDamageFlash(0.75);

   // Schedule corpse removal.  Just keeping the place clean.
   %obj.schedule($CorpseTimeoutValue - 1000, "startFade", 1000, 0, true);
   %obj.schedule($CorpseTimeoutValue, "delete");
}

function PLAYERDATA::playDamage(%this, %obj, %pos)
{
   %animNum = 1;
   %animName = "";
   %rootAnim = "root";

   if ( %obj.isMounted() )
   {
      %animName = "H_Damage";
      %rootAnim = "H_Root";
   }
   else if ( %this.hasLocationalAnims )
   {
      %result = %obj.getDamageLocation(%pos);
      %area = getWord(%result, 0);
      %side = getWord(%result, 1);
      %left = strstr(%side, "left");
      %right = strstr(%side, "right");
      %front = strstr(%side, "front");
      %back = strstr(%side, "back");
      
      if ( %area $= "head" )
      {
         if ( %front == 0 )
         {
            %animNum = getRandom(1, 6);
            %animName = "Damage_Head_F";
         }
         else if ( %left == 0 )
         {
            %animNum = getRandom(1, 3);
            %animName = "Damage_Head_L";
         }
         else if ( %right == 0 )
         {
            %animNum = getRandom(1, 3);
            %animName = "Damage_Head_R";
         }
         else if ( %back == 0 )
         {
            %animNum = getRandom(1, 4);
            %animName = "Damage_Head_B";
         }
      }
      else if ( %area $= "torso" )
      {
         if ( %front == 0 )
         {
            %animNum = getRandom(1, 6);
            %animName = "Damage_Body_F";
         }
         else if ( %left == 0 )
         {
            %animNum = getRandom(1, 3);
            %animName = "Damage_Body_L";
         }
         else if ( %right == 0 )
         {
            %animNum = getRandom(1, 3);
            %animName = "Damage_Body_R";
         }
         else if ( %back == 0 )
         {
            %animNum = getRandom(1, 4);
            %animName = "Damage_Body_B";
         }
      }
      else
      {
         if ( %front == 0 )
            %animName = "Damage_Legs_F";
         else if ( %left == 0 )
            %animName = "Damage_Legs_L";
         else if ( %right == 0 )
            %animName = "Damage_Legs_R";
         else if ( %back == 0 )
         {
            %animNum = getRandom(1, 2);
            %animName = "Damage_Legs_B";
         }
      }
      //echo("getDamageLocation() returned: " @ %result @ ", Playing animation: " @ %animName @ %animNum);
   }
   else if ( %this.numDamageAnims > 0 )
   {
      if ( %this.numDamageAnims > 1 )
         %animNum = getRandom(1, %this.numDamageAnims);
      else
         %animNum = 1;
      %animName = "damage";
   }

   if ( %animName !$= "" )
   {
      %painStunTime = %this.getSequenceDuration(%animName @ %animNum);
      %painStunTime *= 1000; // Convert to MS
      if ( %obj.isBot )
      {
         if ( isEventPending(%obj.clearDamage) )
            cancel(%obj.clearDamage);
         else
            %obj.preDamageSpeed = %obj.getMoveSpeed();
         %obj.setMoveSpeed(0);
         %obj.clearDamage = %obj.schedule(%painStunTime, "setMoveSpeed", %obj.preDamageSpeed);
         %obj.setActionThread(%animName @ %animNum, false, true);
      }
      else
      {
         if ( isEventPending(%obj.clearDamage) )
            cancel(%obj.clearDamage);
         %obj.ForceAnimation(true, %animName @ %animNum, true);
         %obj.clearDamage = %obj.schedule(%painStunTime, "ForceAnimation", false, %rootAnim);
      }
   }
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

function Player::onRunPoseChange(%this, %newRunMode)
{
   %mountDB = %this.getDataBlock();
   if ( !%mountDB.mountable )
      return;

   %driver = %this.getMountNodeObject(%mountDB.driverNode);
   if ( isObject(%driver) )
   {
      switch( %newRunMode )
      {
         case 3:
            %driver.setActionThread(%mountDB.mountPoseFast[%mountDB.driverNode], true, true);
         case 2:
            %driver.setActionThread(%mountDB.mountPoseMedium[%mountDB.driverNode], true, true);
         case 1:
            %driver.setActionThread(%mountDB.mountPoseSlow[%mountDB.driverNode], true, true);
         default:
            %driver.setActionThread(%mountDB.mountPose[%mountDB.driverNode], true, true);
      }
   }

   if ( %mountDB.riderNode !$= "" )
   {
      %rider = %this.getMountNodeObject(%mountDB.riderNode);
      if ( isObject(%rider) )
      {
         switch( %newRunMode )
         {
            case 3:
               %rider.setActionThread(%mountDB.mountPoseFast[%mountDB.riderNode], true, true);
            case 2:
               %rider.setActionThread(%mountDB.mountPoseMedium[%mountDB.riderNode], true, true);
            case 1:
               %rider.setActionThread(%mountDB.mountPoseSlow[%mountDB.riderNode], true, true);
            default:
               %rider.setActionThread(%mountDB.mountPose[%mountDB.riderNode], true, true);
         }
      }
   }
}

//----------------------------------------------------------------------------

function Player::playDeathAnimation(%this)
{
   //%this.setHeadHThread("");
   //%this.setHeadVThread("");
   if ( %this.isMounted() && %this.setActionThread("H_Death1") )
      return;

   %numDeaths = %this.getDataBlock().numDeathAnims;
   if ( %numDeaths $= "" )
      %numDeaths = 11; // If not set, assume 11 death anims

   if ( %numDeaths > 1 )
      %rand = getRandom(1, %numDeaths);
   else
      %rand = 1;

   //if ( !%this.setActionThread("Death" @ %rand, true) )
      //%this.setActionThread("Death");
   %this.ForceAnimation(true, "Death" @ %rand, true);
}

function Player::playImpulseAnim(%this, %pos, %impulse)
{
   %pd_db = %this.getDataBlock();
   if ( %pd_db.hasKnockDownAnims && (%impulse > %pd_db.minAnimImpulse) 
      && (%this.getState() !$= "Dead"))
   {
      if ( %this.isMounted() )
         %pd_db.doDismount(%this, true);

      %animNum = 1;
      %animName = "Damage_WBody_";
      %result = %this.getDamageLocation(%pos);
      %side = getWord(%result, 1);
      if ( strstr(%side, "front") > -1 )
         %animName = %animName @ "F";
      else
         %animName = %animName @ "B";
      
      %painStunTime = %pd_db.getSequenceDuration(%animName @ %animNum);
      %painStunTime *= 1000; // Convert to MS
      if ( %this.isBot )
      {
         if ( isEventPending(%this.clearDamage) )
            cancel(%this.clearDamage);
         else
            %this.preDamageSpeed = %this.getMoveSpeed();
         %this.setMoveSpeed(0);
         %this.clearDamage = %this.schedule(%painStunTime, "setMoveSpeed", %this.preDamageSpeed);
         %this.setActionThread(%animName @ %animNum, false, true);
      }
      else
      {
         if ( isEventPending(%this.clearDamage) )
            cancel(%this.clearDamage);
         %this.ForceAnimation(true, %animName @ %animNum, true);
         %this.clearDamage = %this.schedule(%painStunTime, "ForceAnimation", false, "root");
      }
   }
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
function Player::playLeaveEffect( %this )
{
   %this.ForceAnimation(true, "tp", true);

   %start = %this.position;
   %effectObj = new ParticleEffect(){
      dataBlock = APLeaveEffect;
      position = %start;
   };
   %effectObj.schedule(3000, delete);

   %this.startFade(1000, 250, true);
}

function Player::playArriveEffect( %this )
{
   %effectPos = %this.position;
   %above = VectorAdd(%effectPos, "0 0 50");
   %below = VectorSub(%effectPos, "0 0 20");

   %result = containerRayCast(%above, %below, $TypeMasks::ShapeBaseObjectType |
                                             $TypeMasks::StaticShapeObjectType |
                                             $TypeMasks::TerrainObjectType, %this);

   if ( isObject(getWord(%result, 0)) )
      %effectPos = getWord(%result, 1) SPC getWord(%result, 2) SPC getWord(%result, 3);

   %effectObj = new ParticleEffect(){
      dataBlock = APArriveEffect;
      position = %effectPos;
   };
   %effectObj.schedule(3000, delete);

   %this.ForceAnimation(true, "tp", true);
   %this.startFade(1000, 1000, false);
	%this.schedule(2000, "ForceAnimation", false, "root");
}

//----------------------------------------------------------------------------

function Player::playDeathCry( %this )
{
   %db = %this.getDataBlock();
   if ( %db.DeathSound !$= "" )
      %this.playAudio(0, %db.DeathSound);   
   else if ( %db.numDeathSounds > 0 )
   {
      %idx = getRandom(0, (%db.numDeathSounds-1));
      %this.playAudio(0, %db.DeathSound[%idx]);
   }
}

function Player::playPain( %this )
{
   %db = %this.getDataBlock();
   if ( %db.PainSound !$= "" )
      %this.playAudio(0, %db.PainSound);
   else if ( %db.numPainSounds > 0 )
   {
      %idx = getRandom(0, (%db.numPainSounds-1));
      %this.playAudio(0, %db.PainSound[%idx]);
   }
}

// ----------------------------------------------------------------------------
// Numerical Health Counter
// ----------------------------------------------------------------------------

function Player::updateHealth(%player)
{
   if ( !isObject(%player.client) || (%player.client.player != %player) )
      return;
      
   // Calcualte player health
   %maxDamage = %player.getDatablock().maxDamage;
   %damageLevel = %player.getDamageLevel();
   %curHealth = %maxDamage - %damageLevel;
   %curHealth = mceil(%curHealth);
   %player.client.health = %curHealth;
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
   if ( (%slot == 3) && isObject(%obj.firingWeapon) )
   {
      %obj.firingWeapon.delayedFire(%obj, 0);
      %obj.firingWeapon = "";
   }
}

function PlayerData::onEndSequence(%this, %obj, %slot)
{
   if ( (%slot == 0) || (%slot == 3) )
      return;  // Slot 0 is the TapLink animation, 3 is a look anim
   if ( %slot == 2 )
      %obj.setAttackBlend(2, ""); // Slot 2 is for attack blends
   %obj.destroyThread(%slot);
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
