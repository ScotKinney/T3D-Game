//****************************************************************
//The Universal AI Starter Kit (AISK)
//Copyright (c) 2009-2011 Twisted Jenius - All rights reserved.
//This file is engine SPECIFIC. - T3D
//****************************************************************


//This code is used for player and weapon randomization and
//it creates a datablock for each player. Only called by the AI marker editor.
function createDataRandom()
{
   %count = DatablockGroup.getCount();

   if (!isObject(playerRandomizer))
      new SimSet(playerRandomizer);
   if (!isObject(weaponRandomizer))
      new SimSet(weaponRandomizer);

    //Cycle through all datablocks and get the names of the player types and weapons
    for (%i = 0; %i < %count; %i++)
    {
        %data = DatablockGroup.getObject(%i);
        %dataClass = %data.getClassName();

        //Put the players and weapons into simsets
        if (%dataClass $= "PlayerData")
        {
            %dataName = %data.getName();
            playerRandomizer.add(%dataName);

            //Comment this out if you don't want an extra datablock made for each player
            //datablock, but make sure all of your markers are set to "AIPlayerMarker"
            //UAISK+AFX Interop Changes: Start
            eval("datablock StaticShapeData(" @ %dataName @ "Marker){shapeFile = \"" @ %dataName.shapeFile @ "\";isAiMarker = true;};");
            //UAISK+AFX Interop Changes: End
        }
        else if (%dataClass $= "ItemData")
        {
            %j = %data.getName();

            //Make sure we're just adding weapons to the list and not ammo
            if (%j.className $= "Weapon")
                weaponRandomizer.add(%j);
        }
        //UAISK+AFX Interop Changes: Start
        else if (%dataClass $= $AISK_AFX_DATA_TYPE)
        {
            //Make sure this is a real spell
            if (!%data.isPlaceholder)
            {
                //The bots can't properly use corpse targeting spells most of the time
                if (%data.target !$= "corpse")
                {
                    %k = %data.getName();
                    weaponRandomizer.add(%k);
                }
            }
        }
        //UAISK+AFX Interop Changes: End
    }

    if (isObject(UaiskData))
    {
        UaiskData.add(playerRandomizer);
        UaiskData.add(weaponRandomizer);
    }
}

//Execute the function above as soon as the file is loaded.
//createDataRandom(); //UAISK+AFX Interop Change

//This function calls the functions below as needed
function loadMarkers(%noCycle)
{
    if (!%noCycle)
        echo("Preparing Markers...");
    else
        echo("Preparing Prefabs...");

    if (!isObject(UaiskData))
    {
        //Make a simgroup that will contain all AI data
        new SimGroup(UaiskData);

        //Load the behaviors
        loadAiBehaviors();

        //Organization for all markers and bots
        new SimSet(allMarkersSet);
        new SimGroup(allBotsGroup);
        UaiskData.add(allMarkersSet);
        UaiskData.add(allBotsGroup);

        //On load, make the first two teams because we'll need at least that many later
        $TotalTeams = 2;
        new SimSet(TeamSet1);
        new SimSet(TeamSet2);
        UaiskData.add(TeamSet1);
        UaiskData.add(TeamSet2);
    }

    if (isObject(MissionCleanup))
        MissionCleanup.add(UaiskData);

    //Reset varaibles from last time
    $simgroupCount = 0;
    $simgroupCount2 = 1;
    $simgroupNameVar = "";

    if (!%noCycle)
    {
        getAllObjectsWanted();

        //Keep going until we've gone through every simgroup in the missiongroup
        while ($simgroupCount2 <= $simgroupCount)
        {
            $simgroupNameVar = $simgroupNameArray[$simgroupCount2];
            getAllObjectsWanted();
            $simgroupCount2++;
        }
    }

    hideMarkers();
}

//This function cycles through all objects in a mission
function getAllObjectsWanted()
{
    //If this is our first cycle, start with the missiongroup
    if ($simgroupNameVar $= "")
        $simgroupNameVar = "MissionGroup";

    //Get the number of things in this simgroup
    %n = $simgroupNameVar.getCount();

    for (%i = 0; %i < %n; %i++)
    {
        //Get the name of what we're dealing with now
        %obj = $simgroupNameVar.getObject(%i);

        //If this object is a simgroup, get its name so we can go through it later
        if (%obj.getClassName() $= "SimGroup")
        {
           $simgroupCount++;
           $simgroupNameArray[$simgroupCount] = %obj.getName();
        }
        else
        {
            //Check if the object is an AI marker
            if (%obj.getFieldValue(Datablock).isAiMarker)
            {
                //Call a specific function to do things with the object
                groupMarkers(%obj);
            }
            //Other functions can be added here for other types of objects
            //Put them inside an "else if" that checks the datablock or getClassName
        }
    }
}

//This function places all markers in a simset
function groupMarkers(%obj)
{
    //Add the marker to this SimSet
    allMarkersSet.add(%obj);

   //Get the datablock that this marker will spawn
   if (%obj.block $= "" || %obj.block $= "-random")
      %block = $AISK_CHAR_TYPE;
   else
      %block = %obj.block;

    //Get the spawn group that this marker belongs to
    if (%obj.spawnGroup !$= "")
        %spawnGroup = %obj.spawnGroup;
    else if (%block.spawnGroup !$= "")
        %spawnGroup = %block.spawnGroup;
    else
        %spawnGroup = $AISK_SPAWN_GROUP;

    changeSpawnGroups(%obj, %spawnGroup);

    //Get the team that this marker belongs to
    if (%obj.team !$= "")
        %team = %obj.team;
    else if (%block.team !$= "")
        %team = %block.team;
    else
        %team = $AISK_TEAM;

    changeMarkerTeams(%obj, %team);
}

//This function hides all markers
function hideMarkers()
{
    //Should the markers be hidden on unhidden
    if ($AISK_MARKER_HIDE == true)
        echo("Hiding AI Markers...");
    else
        echo("Unhiding AI Markers...");

    //Get the number of markers
    %n = allMarkersSet.getCount();

    for (%i = 0; %i < %n; %i++)
    {
        //Get the name of what we're dealing with now
        %obj = allMarkersSet.getObject(%i);

        //Work around for T3D bug
        if ($AISK_MARKER_HIDE)
        {
            //Unhide then hide the marker again
            %obj.sethidden(0);
            %obj.sethidden(1);
            //Then set it's position again to update it
            %obj.setTransform(%obj.getPosition());
        }
        else
            //This one line is what the code should really be,
            //like the TGE and TGEA versions
            %obj.sethidden($AISK_MARKER_HIDE);
    }
}

function Prefab::onLoad(%this, %obj)
{
    //Create the standard simsets if it hasn't been done already
    if (!isObject(UaiskData))
        loadMarkers(1);

    //Get the number of things in this simgroup
    %n = %obj.getCount();

    for (%i = 0; %i < %n; %i++)
    {
        //Get the name of what we're dealing with now
        %item = %obj.getObject(%i);

        //Check if the object is an AI marker
        if (%item.getFieldValue(Datablock).isAiMarker)
        {
            //Call a specific function to do things with the object
            groupMarkers(%item);
        }
        //Other functions can be added here for other types of objects
        //Put them inside an "else if" that checks the datablock or getClassName
    }
}
