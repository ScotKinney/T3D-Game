//****************************************************************
//The Universal AI Starter Kit (AISK)
//Copyright (c) 2009-2010 Twisted Jenius - All rights reserved.
//This file is engine SPECIFIC. - All
//****************************************************************


//The AIPlayer marker is placed in the map while editing. When the map is loaded the
//marker is replaced by an AI player. The marker is hidden or not depending on
//the value set in $AISK_MARKER_HIDE.

datablock StaticShapeData(AIPlayerMarker)
{
   //Mission editor category, this datablock will show up in the
   //specified category under the "shapes" root category.
   category = "AIMarker";
   //Basic Item properties
   shapeFile = "core/art/shapes/simplecone.dts";
   isAiMarker = true;
};


//*******************************************************************************
//This is the default datablock for the bot. This was done to allow the creation of different
//classes of bots with their own thinking and reaction routines for each class.

//You can specify as many datablocks as you have characters. Each datablock needs its own
//onReachDestination and OnDamage functions. Copy and paste those function (which are below
//here) and then change "DefaultPlayer" in the name to the name of your new datablock.

//The first variable after PlayerData must be a unique name. The second variable (after the
//semicolon) must be a valid body type.
//*******************************************************************************

datablock PlayerData(DefaultAIPlayerData : DefaultPlayerData)
{
   //All values can be commented out if you wish
   //If you get rid of them, the bot will just use the same values as the player

   maxDamage = 100;
   maxForwardSpeed = 4;
   maxBackwardSpeed = 3;
   maxSideSpeed = 3;

   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "XR75";
   respawn = 1;
   behavior = "GuardBehavior";
   maxRange = 25;
   minRange = 0;
   distDetect = 50;
   sidestepDist = 10;
   paceDist = 6;
   npcAction = 0;
   spawnGroup = 1;
   fov = 200;
   leash = 35;
   cycleCounter = "5";
   weaponMode = "pattern";
   activeDodge = 1;
   realName = "Bot";
   maxStepHeight = "1";
};

//***************************************************************************
//Trigger Controller
//This code handles the placing and behavior of the guardTrigger datablock
//***************************************************************************

datablock TriggerData(guardTrigger)
{
    tickPeriodMS = 125;
    spawnGroup = 1;
    moreThanOnce = false;
};

//This function does an action after the trigger is entered by a player
function guardTrigger::onEnterTrigger(%this, %trigger, %obj)
{
    //Check to see if a player triggered this
    if (%obj.getClassName() $= "Player")
    {
        //Don't spawn more bots if they aren't needed
        if (%this.moreThanOnce || !%trigger.doneOnce)
        {
            //Use the value on the trigger if it has one, or else use the trigger's datablock's value
            if (%trigger.spawnGroup > 0)
                %spawn = %trigger.spawnGroup;
            else
                %spawn = %this.spawnGroup;

            //We've now triggered this trigger once
            if (!%this.moreThanOnce)
                %trigger.doneOnce = true;

            //Spawn the group, this can be changed to another action if you want
            AIPlayer::actionByGroup(%spawn, "unspawned");
        }
    }
}
