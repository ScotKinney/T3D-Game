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
