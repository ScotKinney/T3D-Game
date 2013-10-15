//****************************************************************
//The Universal AI Starter Kit (AISK)
//Copyright (c) 2009-2011 Twisted Jenius - All rights reserved.
//This file is engine SPECIFIC. - All
//****************************************************************


//-----------------------------------------------------------------------------
//Action and Command Functions
//-----------------------------------------------------------------------------

//This function does an action by spawn group when called
function AIPlayer::actionByGroup(%spawnGroup, %action)
{
   echo("Now " @ %action @ "ing group: " @ %spawnGroup);

   if (%spawnGroup !$= "all")
      %name = "MarkerSpawnGroup" @ %spawnGroup;
   else
      %name = allMarkersSet;

   if (!isObject(%name))
   {
      if ($AISK_SHOW_NAME $= "Debug")
      warn("Group " @ %spawnGroup @ " is not valid.");

      return;
   }

   AIPlayer::actionBeingDone(%name, %action);
}

//This function does an action by team number when called
function AIPlayer::actionByTeam(%team, %action)
{
   echo("Now " @ %action @ "ing team: " @ %team);

   if (%team !$= "all")
      %name = "MarkerTeamsSet" @ %team;
   else
      %name = allMarkersSet;

   if (!isObject(%name))
   {
      warn("Team " @ %team @ " is not valid.");
      return;
   }

   AIPlayer::actionBeingDone(%name, %action);
}

//Do the action now that we found the correct simset
function AIPlayer::actionBeingDone(%name, %action)
{
   //Get the number of markers
   %n = %name.getCount();

   for (%i = 0; %i < %n; %i++)
   {
      //Get the name of what we're dealing with now
      %obj = %name.getObject(%i);
      %bot = %obj.botBelongsToMe;

      //Now check what action to take
      switch$(%action)
      {
         case "spawn":
            //Let's spawn some bad guys!
            %player = AIPlayer::spawnAtMarker(%obj);

         case "delete":
            //Check if there's a bot from this marker then get rid of it
            if (%obj.botBelongsToMe !$= "")
            {
               %bot.delete();
               %obj.botBelongsToMe = "";
               cancel(%obj.delayRespawn);
               %obj.delayRespawn = "";
               %obj.respawnCount = "";
               %obj.respawnCounter = "";
            }

         case "kill":
            //Get the bot's id from the marker then kill it
            if (%obj.botBelongsToMe !$= "")
               %bot.kill();

         case "stop":
            //Set the bot to not respawn
            %bot.respawn = false;
            cancel(%obj.delayRespawn);
            %obj.delayRespawn = "";
            %obj.respawnCount = "";
            %obj.respawnCounter = "";

         case "unspawned":
            //Spawn all bots that have not been spawned yet
            if ((!isObject(%bot) || %bot.getState() $= "Dead") && %obj.delayRespawn < 1)
               %player = AIPlayer::spawnAtMarker(%obj);

         case "inactive":
            //Check if there's a bot from this marker
            if (%obj.botBelongsToMe !$= "")
            {
               //Make sure the bot is inactive then get rid of it
               if (%bot.action $= "Guarding" || %bot.action $= "Returning")
               {
                  %bot.delete();
                  %obj.botBelongsToMe = "";
                  cancel(%obj.delayRespawn);
                  %obj.delayRespawn = "";
                  %obj.respawnCount = "";
                  %obj.respawnCounter = "";
               }
            }

         default:
            %player = AIPlayer::spawnAtMarker(%obj);
      }

      //Hide or unhide the marker
      %obj.sethidden($AISK_MARKER_HIDE);

      //Work around for T3D bug
      if ($AISK_MARKER_HIDE)
         %obj.setTransform(%obj.getPosition());
   }
}

//Calls the spawn function to create the bots and place them at their starting positions.
function AIPlayer::spawnAtMarker(%obj)
{
   if (!isObject(%obj))
   {
      warn("Marker " @ %obj @ " is not valid.");
      return;
   }

   %player = AIPlayer::spawn(%obj);
   return %player;
}

//Calls the spawn function to create a bot and place it at where the object is.
function AIPlayer::spawnAtObject(%obj, %block)
{
   if (!isObject(%obj))
   {
      warn("Object " @ %obj @ " is not valid.");
      return;
   }

   //Get the object's transform while it's still here
   %pos = %obj.getTransform();

   //Delete the old object we're spawning from, this is so it doesn't occupy
   //the same location as the new bot
   %obj.delete();

   //Call spawnAtPosition which does the real work
   %player = AIPlayer::spawnAtPosition(%pos, %block);
   return %player;
}

//Calls the spawn function to create a bot and place it at the location supplied.
function AIPlayer::spawnAtPosition(%pos, %block)
{
   //Name the new marker, try in order first
   %num = allMarkersSet.getCount() + 1;

   if (%num < 10)
      %name = "Marker0" @ %num;
   else
      %name = "Marker" @ %num;

   //If in order doesn't work, do it at random
   if (isObject(%name))
      %name = "Marker" @ getRandom(1, 999);

   if (%block $= "")
      %block = $AISK_CHAR_TYPE;

   %markerData = %block @ "Marker";

   if (!isObject(%markerData))
      %markerData = "AIPlayerMarker";

   //Add a new marker
   %marker = new StaticShape(%name) {
      canSaveDynamicFields = "1";
      position = "0 0 0";
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = %markerData;
      block = %block;
   };

   //Instead of setting the position above, we'll set the transform here
   //in case we want a specific rotation
   %marker.setTransform(%pos);

   //Get the marker's team and group
   if (%block.team !$= "")
      %team = %block.team;
   else    
      %team = $AISK_TEAM;

   if (%block.spawnGroup !$= "")
      %group = %block.spawnGroup;
   else    
      %group = $AISK_SPAWN_GROUP;

   //Add the new marker to this SimSet
   allMarkersSet.add(%marker);
   changeMarkerTeams(%marker, %team);
   changeSpawnGroups(%marker, %group);

   MissionGroup.add(%marker);

   //Hide the new marker if needed
   if ($AISK_MARKER_HIDE == true)
   {
      %marker.sethidden(true);
      //Work around for T3D bug
      %marker.setTransform(%marker.getPosition());
   }

   %player = AIPlayer::spawn(%marker);
   return %player;
}


//-----------------------------------------------------------------------------
//Spawning Functions
//-----------------------------------------------------------------------------

//This is the spawn function for the bot.
function AIPlayer::spawn(%obj, %isRespawn)
{
   //Select what datablock this bot should use
   if (%obj.block $= "")
      %block = $AISK_CHAR_TYPE;
   else
      %block = %obj.block;

   //If the field is not blank, set the weapon variable to the spawn marker weapon,
   //if the marker is blank, then try datablock
   if (%obj.Weapon !$= "")
      %tempWeapon = %obj.Weapon;
   else if (%block.Weapon !$= "")
      %tempWeapon = %block.Weapon;
   else
      %tempWeapon =$AISK_WEAPON;
   
   // BloodClans Script Modification (MAR) - AI Weapons >>>
   if ( (%tempWeapon !$= "-noweapon") && (strlen(%tempWeapon) > 6) && (getSubStr(%tempWeapon, strlen(%tempWeapon) - 6, 6) $= "Weapon") )
      %tempWeapon = getSubStr(%tempWeapon, 0, strlen(%tempWeapon) - 6);
   // BloodClans Script Modification (MAR) - AI Weapons <<<

   //First try to use the value on the marker, then the datablock and then the default, this is for max range
   if (%obj.maxRange !$= "" && %obj.maxRange >= 1)
      %tempMaxRange = %obj.maxRange;
   else if (%block.maxRange !$= "" && %block.maxRange >= 1)
      %tempMaxRange = %block.maxRange;
   else
      %tempMaxRange = $AISK_MAX_DISTANCE;

   if (%obj.sidestepDist !$= "")
      %tempSidestep = %obj.sidestepDist;
   else if (%block.sidestepDist !$= "")
      %tempSidestep = %block.sidestepDist;
   else
      %tempSidestep = $AISK_SIDESTEP;

   // Delay between death and respawn
   if (%obj.respawnTime !$= "")
      %tempRespawnTime = %obj.respawnTime;
   else if (%block.respawnTime !$= "")
      %tempRespawnTime = %block.respawnTime;
   else
      %tempRespawnTime = $AISK_RESPAWN_DELAY;

   // Min range
   if (%obj.minRange !$= "" && (%tempMaxRange > %obj.minRange && %tempSidestep > %obj.minRange))
      %tempMinRange = %obj.minRange;
   else if (%block.minRange !$= "" && (%tempMaxRange > %block.minRange && %tempSidestep > %block.minRange))
      %tempMinRange = %block.minRange;
   else
      %tempMinRange = $AISK_MIN_DISTANCE;

   // Detect distance
   if (%obj.distDetect !$= "" && %obj.distDetect >= 1)
      %tempDistDetect = %obj.distDetect;
   else if (%block.distDetect !$= "" && %block.distDetect >= 1)
      %tempDistDetect = %block.distDetect;
   else
      %tempDistDetect = $AISK_DETECT_DISTANCE;

   // Max pace distance
   if (%obj.paceDist !$= "")
      %tempPaceDist = %obj.paceDist;
   else if (%block.paceDist !$= "")
      %tempPaceDist = %block.paceDist;
   else
      %tempPaceDist = $AISK_MAX_PACE;

   // Behavior
   if (isObject(%obj.behavior))
      %tempBehavior = %obj.behavior;
   else if (isObject(%block.behavior))
      %tempBehavior = %block.behavior;
   else
      %tempBehavior = $AISK_BEHAVIOR;

   // Respawn allowed
   if (%obj.respawn !$= "")
      %tempRespawn = %obj.respawn;
   else if (%block.respawn !$= "")
      %tempRespawn = %block.respawn;
   else
      %tempRespawn = $AISK_DEFAULT_RESPAWN;

   // Active dodging
   if (%obj.activeDodge !$= "")
      %tempDodge = %obj.activeDodge;
   else if (%block.activeDodge !$= "")
      %tempDodge = %block.activeDodge;
   else
      %tempDodge = $AISK_ACTIVE_DODGE;

   // Advanced dodging
   if (%obj.advancedDodge !$= "")
      %tempAdvanced = %obj.advancedDodge;
   else if (%block.advancedDodge !$= "")
      %tempAdvanced = %block.advancedDodge;
   else
      %tempAdvanced = $AISK_ADVANCED_DODGE;

   // NPC's actions
   if (%obj.npcAction !$= "")
      %tempNpcAction = %obj.npcAction;
   else
      %tempNpcAction = %block.npcAction;

   // fov (field of view)
   if (%obj.fov !$= "")
      %tempFOV = %obj.fov;
   else if (%block.fov !$= "")
      %tempFOV = %block.fov;
   else
      %tempFOV = $AISK_FOV;

   // Leash distance
   if (%obj.leash !$= "")
      %tempLeash = %obj.leash;
   else if (%block.leash !$= "")
      %tempLeash = %block.leash;
   else
      %tempLeash = $AISK_LEASH_DISTANCE;

   // Assign bot to a team
   if (%obj.team !$= "")
      %tempTeam = %obj.team;
   else if (%block.team !$= "")
      %tempTeam = %block.team;
   else
      %tempTeam = $AISK_TEAM;

   //This is for the bot's name
   if (%obj.realName !$= "")
      %tempRealName = %obj.realName;
   else if (%block.realName !$= "")
      %tempRealName = %block.realName;
   else
      %tempRealName = $AISK_REAL_NAME;

   //Can the bot be mounted
   if (%obj.mountable !$= "")
      %tempMountable = %obj.mountable;
   else if (%block.mountable !$= "")
      %tempMountable = %block.mountable;
   else
      %tempMountable = false;

   //Move Tolerance for pathed bots
   if (%obj.moveTolerance !$= "")
      %tempTolerance = %obj.moveTolerance;
   else if (%block.mountable !$= "")
      %tempTolerance = %block.moveTolerance;
   else
      %tempTolerance = 1.0;

   //The bot's respawn count is set on to the marker on the original spawn only
   if (!%isRespawn)
   {
      if (%obj.countRespawn !$= "")
         %obj.respawnCount = %obj.countRespawn;
      else if (%block.countRespawn !$= "")
         %obj.respawnCount = %block.countRespawn;
      else
         %obj.respawnCount = $AISK_RESPAWN_COUNT;

      %obj.respawnCounter = %obj.respawnCount;
   }

   //epls bloodclans
   if ( %obj.dropitem !$= "" )
      %tempdropitem = %obj.dropitem;
   if ( %obj.dropitem2 !$= "" )
      %tempdropitem2 = %obj.dropitem2;
   if ( %obj.dropcount !$= "" )
      %tempdropcount = %obj.dropcount;
   
   if ( %obj.willBuy !$= "" )
      %tempwillbuy = %obj.willbuy;
   //epls end

   //Create the demo player object
   %player = new AIPlayer() {
      //Sets the bot's dataBlock
      dataBlock = %block;
      //The marker is the static object that the bot is associated with.
      //The marker object is save on the bot because it's location, and
      //dynamic variable values are used in several functions.
      marker = %obj;
      //Sets the bot's field of vision
      fov = %tempFOV;
      OldFOV = %tempFOV;
      //Sets the bot's leash distance
      leash = %tempLeash;
      //Sets what team the bot is on
      team = %tempTeam;
      //Sets the bot's detect distance
      detDis = %tempDistDetect;
      OldDetDis = %tempDistDetect;
      detDisSqr = %tempDistDetect * %tempDistDetect;
      //Sets the bot's sidestep
      stepDis = %tempSidestep;
      //Sets the bot's max pacing distance
      maxPace = %tempPaceDist;
      //Sets the bot's returning position
      returningPos = %obj.getposition();
      //Sets the bot not to return to a path as soon as it is loaded
      //The pathed bots will go to there paths at another point
      returningPath = 0;
      //Fix for premature firing
      fireLater = 0;
      //Sets the bot's pacing
      pace = getRandom(1, $AISK_PACE_TIME);
      //The pathname variable is a dynamic variable set during map editing.
      //This allows the designer to attach each bot to a seperate path
      path = %obj.pathname;
      //Is the bots max range
      weapRange = %tempMaxRange;
      //Is the bots min range
      rangeMin = %tempMinRange;
      //Sets the bots behavior
      behavior = %tempBehavior;
      //Sets whether the bot is AI or not
      isbot = true;
      //Thinking variables
      //Firing tells whether or not we're in the midst of a firing sequence.
      firing = false;
      //The 'action' variable holds the state of the bot - which controls how it thinks.
      action = "Guarding";
      holdcnt = $AISK_HOLDCNT_MAX-1;
      //The bots starting attention level is set to half of it's maximum.
      attentionlevel = $AISK_MAX_ATTENTION/2;
      //Oldpos holds the position of the bot at the end of it's last 'think' cycle
      //This is used to help determine if a bot is stuck or not.
      oldpos = %obj.getposition();
      //Added for bots use different weapons
      botWeapon = %tempWeapon;
      //Set the number of the weapon the bot is currently using
      currentWeaponIs = 0;
      //Set the number of the weapon cycle the bot is currently using
      currentCycleNumber = 0;
      //Should the bot respawn or not
      respawn = %tempRespawn;
      //Should the bot actively dodge attacks
      activeDodge = %tempDodge;
      //In what manner should the be dodge
      advancedDodge = %tempAdvanced;
      //What action should this take if it's an npc
      npcAction = %tempNpcAction;
      //This is the bot's name, but it isn't set as the object's name in case it's non-unique
      realName = %tempRealName;
      //Max range must be this number or higher
      maxIgnore = 1;
      //epls bloodclans
      dropitem = %tempdropitem;
      dropitem2 = %tempdropitem2;
      dropcount = %tempdropcount;
      willbuy = %tempwillbuy;
      //epld end
      respawnTime = %tempRespawnTime;
      mountable = %tempMountable;
      mMoveTolerance = %tempTolerance;
   };

   allBotsGroup.add(%player);

   //Set this marker as having this bot
   %obj.botBelongsToMe = %player;
   %player.newlyAdded = false;

   // Set the bots skin
   if (%obj.skinName !$= "")
      %tempSkin = %obj.skinName;
   else if (%block.skinName !$= "")
      %tempSkin = %block.skinName;
   if ( %tempSkin !$= "" )
      %player.setSkinName(%tempSkin);

   //Sets the bot's initial position to that of it's marker.
   %botTransform = %obj.getTransform();
   if ( (%obj.spawnGroup !$= "") && isObject(%obj.spawnGroup) )
   {  // We have a spawn group so select a random transform
      %botSphere = %obj.spawnGroup.getRandom();
      if ( isObject(%botSphere) )
      {
         %botTransform = %botSphere.getTransform();
         %obj.setTransform(%botTransform);
      }
   }
   %player.setTransform(%botTransform);

   //Sets the bot's scale
   %player.setScale(%obj.getScale());
   %player.mountVehicle = false;
   if (($ServerName $= "MarsTest") && (%block $= "FemalePlayerData"))
      %player.mountVehicle = true;

   %player.setshapename("\c3" @ %tempRealName);
   if ( (%tempRealName !$= "") && (%tempRealName !$= " ") && (%tempTeam > 1) && isObject($Server::ClanData) )
   {
      %player.setClanName($Server::ClanData.clan[%tempTeam]);
   }
   else if (%block.getClassNameSpace() $= "Steed")
   {
      %player.setshapename("");
      %player.setClanName("Buy");
      %player.buyable = true;
   }
   //echo("Player = " @ %player @ ", clan = " @ %player.getClanName());

   // AlterVerse Script Modification (MAR) - Avatar customization options >>>
   if ( %obj.avOptions !$= "" )
   {
      %player.setAvOptions(%obj.avOptions @ "|" @ %obj.avOverlays);
   }
   // AlterVerse Script Modification (MAR) - Avatar customization options <<<

   //Set the serpentine movment to the side first
   if (%player.advancedDodge $= "Serpentine")
      %player.dodgeCounter = true;

   //Min range must be this number or lower
   %ignoreMinimum = 10000;

   %weap = getWord(%player.botWeapon, 0);
   %weapData = %weap @ "Weapon";
   if ( !isObject(%weapData) )
      %weapData = %weap @ "Image";

   if ( isObject(%weapData) )
   {
      //Get the weapon ignore distance
      %maxIgn = %weapData.ignoreDistance;

      if (%maxIgn $= "" || %maxIgn <= 1)
         %maxIgn = $AISK_IGNORE_DISTANCE;

      if (%player.maxIgnore < %maxIgn)
         %player.maxIgnore = %maxIgn;

      //Get the bot's shortest weapon ignore distance
      %minIgn = %weapData.minIgnoreDistance;

      if (%minIgn $= "")
         %minIgn = $AISK_MIN_IGNORE_DISTANCE;

      if (%ignoreMinimum > %minIgn)
         %ignoreMinimum = %minIgn;
   }

   //Make sure all min and max values are properly set
   safeguardMinMax(%player, %ignoreMinimum);

   // Mounts the bots weapon.
   if (%player.botWeapon !$= "-noweapon")
      equipBotWeapon(%player);

   // Mount any additional equipment
   if ( %block.equipmentSlots !$= "" )
   {
      for ( %i = 0; %i < %block.equipmentSlots; %i++ )
      {
         if ((%block.eqShape[%i] !$= "") && (%block.eqNode[%i] !$= ""))
            %player.mountEquipment(%block.eqShape[%i], %block.eqNode[%i]);
      }
      %player.updateMountedEquipment();
   }

   //Put the bot in a SimSet with its teammates
   TeamSimSets(%player, %player.team);

   // BloodClans Script Modification (MAR) - Stagger think loops >>>
   if ( $AV_AIDelayOffset $= "" )
      $AV_AIDelayOffset = 0;
   else
      $AV_AIDelayOffset = %isRespawn ? 0 : $AV_AIDelayOffset + 10;
   // BloodClans Script Modification (MAR) - Stagger think loops <<<
    
   //Sets the bot to begin thinking after waiting the length of $AISK_CREATION_DELAY
   if (%player.behavior.isAggressive)
      %player.ailoop = %player.schedule($AISK_CREATION_DELAY + $AV_AIDelayOffset, "Think", %player);
   else
      %player.ailoop = %player.schedule($AISK_CREATION_DELAY + $AV_AIDelayOffset, "npcThink", %player);

   //If the bot is pathed, have it go on its path soon
   if (%player.path !$= "" && %player.behavior.canMove && !%player.behavior.isFollowPlayer)
   {
      %player.action = "Returning";
      %player.oldpos = "0 0 0";
      %player.schedule($AISK_CREATION_DELAY, "followPath", %player.path);
   }
   else
      %player.path = "";

   if (%player.behavior.isHunted)
      %player.action = "Grazing";

   return %player;
}

function AIPlayer::respawn(%obj)
{
   if (%obj.respawn == true)
      %obj.marker.delayRespawn = schedule(%obj.respawnTime, %obj.marker, "AIPlayer::spawn", %obj.marker);
   %obj.delete();
}

//Make sure all min and max values are properly set
function safeguardMinMax(%obj, %ignoreMinimum)
{
   //Avoid dead zones where the bot could move to but couldn't attack from
   //Make sure the bot's max distance is the same or less than the max range on its longest weapon
   if (%obj.weapRange > %obj.maxIgnore)
   {
      %obj.weapRange = %obj.maxIgnore;
      warn("Bot ID " @ %obj @ " has max attack distance higher than max weapon distance.");
   }

   //Avoid dead zones where the bot could move to but couldn't attack from
   if (%obj.maxIgnore > %ignoreMinimum)
   {
      //Make sure the bot's min distance is the same or greater than the min range on its shortest weapon
      if (%obj.rangeMin < %ignoreMinimum)
      {
         %obj.rangeMin = %ignoreMinimum;
         warn("Bot ID " @ %obj @ " has min weapon distance higher than min attack distance.");
      }
   }

   //Make sure min pace is less than max, if set to pace
   if ($AISK_MIN_PACE >= %obj.maxPace && %obj.maxPace > 0)
   {
      %obj.maxPace = $AISK_MIN_PACE + 1;
      warn("Bot ID " @ %obj @ " has min PACE higher than max.");
   }

   //Max sidestep should be 1 or higher
   if (%obj.stepDis < 1)
   {
      %obj.stepDis = 1;
      warn("Bot ID " @ %obj @ " has max SIDESTEP too low.");
   }

   //Make sure min sidestep is less than max
   if (%obj.rangeMin >= %obj.stepDis)
   {
      %obj.stepDis = %obj.rangeMin + 1;
      warn("Bot ID " @ %obj @ " has min SIDESTEP higher than max.");
   }
}


//UAISK+AFX Interop Changes: Start
//-----------------------------------------------------------------------------
//Corpse Spell Functions
//-----------------------------------------------------------------------------

function AIPlayer::burnCorpse(%this, %corpse)
{
    if (!isObject(%corpse))
    {
        error("AIPlayer::burnCorpse() -- missing corpse object.");
        return;
    }

    if (%corpse.isEnabled())
    {
        error("AIPlayer::burnCorpse() -- corpse object is still alive!");
        return;
    }

    //Set the bot to not respawn
    %corpse.respawn = false;
    cancel(%corpse.marker.delayRespawn);
    %corpse.marker.delayRespawn = "";

    //Get rid of the body
    %corpse.schedule(0, "startFade", 1000, 0, true);
    %corpse.schedule(2000, "delete");
}

function AIPlayer::resurrectCorpse(%this, %corpse)
{
    if (!isObject(%corpse))
    {
        error("AIPlayer::resurrectCorpse() -- missing corpse object.");
        return;
    }

    if (%corpse.isEnabled())
    {
        error("AIPlayer::resurrectCorpse() -- corpse object is still alive!");
        return;
    }

    //Set the bot to not respawn
    %corpse.respawn = false;
    cancel(%corpse.marker.delayRespawn);
    %corpse.marker.delayRespawn = "";

    %corpse.setDamageLevel(%corpse.getDatablock().maxDamage * 0.5);
    //Default dynamic armor stats
    %corpse.setRechargeRate(%corpse.getDatablock().rechargeRate);
    %corpse.setRepairRate(%corpse.getDatablock().repairRate);

    //Sets the bot to begin thinking after waiting the length of $AISK_CREATION_DELAY
    if (%corpse.behavior.isAggressive)
        %corpse.schedule($AISK_CREATION_DELAY, "Think", %corpse);
    else
        %corpse.schedule($AISK_CREATION_DELAY, "npcThink", %corpse);

    //If the bot is pathed, have it go on its path soon
    if (%corpse.path !$= "" && %corpse.behavior.canMove && !%corpse.behavior.isFollowPlayer)
    {
        %corpse.action = "Returning";
        %corpse.oldpos = "0 0 0";
        %corpse.schedule($AISK_CREATION_DELAY, "followPath", %corpse.path);
    }
    else
        %corpse.path = "";

    schedule(1000, 0, afxBroadcastTargetStatusbarReset);
}
//UAISK+AFX Interop Changes: End
