//****************************************************************
//The Universal AI Starter Kit (AISK)
//Copyright (c) 2009-2011 Twisted Jenius - All rights reserved.
//This file is engine NEUTRAL.
//****************************************************************


//This function contains all of the AI behavior script objects
function loadAiBehaviors()
{
    //Create a new simgroup for behaviors, this is for the editor
    new SimGroup(allBehaviorsSet);
    UaiskData.add(allBehaviorsSet);

// -------------------------------------------------------

%behavior = new ScriptObject(LeashedBehavior) {
    //Sets if the bot attacks or not
    isAggressive = true;
    //Sets if the bot can move at all
    canMove = true;
    //Sets if the bot should return to its marker or path after killing or losing
    //track of its target
    returnToMarker = true;
    //Sets both if the bot can be killed and if other bots can target it
    isKillable = true;
    //Puts the bot on the player’s team and has it follow the player
    isFollowPlayer = false;
    //Sets if the bot can move away from a certain object, the object is set below
    isLeashed = true;
    //This is used in an eval if the behavior is leashed
    leashedTo = "%obj.marker";
    //Sets the bot to run away when touched and move farther from its spawn marker
    isSkittish = false;
};

//Add to the behavior simgroup for the editor
allBehaviorsSet.add(%behavior);

// -------------------------------------------------------

%behavior = new ScriptObject(ChaseBehavior) {
    isAggressive = true;
    canMove = true;
    returnToMarker = true;
    isKillable = true;
    isFollowPlayer = false;
    isLeashed = false;
    //leashedTo = "";
    isSkittish = false;
};

allBehaviorsSet.add(%behavior);

// -------------------------------------------------------

%behavior = new ScriptObject(GuardBehavior) {
    isAggressive = true;
    canMove = true;
    returnToMarker = true;
    isKillable = true;
    isFollowPlayer = false;
    isLeashed = false;
    //leashedTo = "";
    isSkittish = false;
};

allBehaviorsSet.add(%behavior);

// -------------------------------------------------------
// Used for Sazzon
%behavior = new ScriptObject(TeammateBehavior) {
    isAggressive = true;
    canMove = true;
    returnToMarker = false;
    isKillable = true;
    isFollowPlayer = true;
    isLeashed = false;
    //leashedTo = "";
    isSkittish = false;
};

allBehaviorsSet.add(%behavior);

// -------------------------------------------------------

/*%behavior = new ScriptObject(NPCBehavior) {
    isAggressive = false;
    canMove = true;
    returnToMarker = false;
    isKillable = false;
    isFollowPlayer = false;
    isLeashed = false;
    //leashedTo = "";
    isSkittish = false;
};

allBehaviorsSet.add(%behavior);*/

// -------------------------------------------------------

%behavior = new ScriptObject(KillableNPCBehavior) {
    isAggressive = false;
    canMove = true;
    returnToMarker = false;
    isKillable = true;
    isFollowPlayer = false;
    isLeashed = false;
    //leashedTo = "";
    isSkittish = false;
};

allBehaviorsSet.add(%behavior);

// -------------------------------------------------------

/*%behavior = new ScriptObject(EscortBehavior) {
    isAggressive = false;
    canMove = true;
    returnToMarker = false;
    isKillable = true;
    isFollowPlayer = true;
    isLeashed = false;
    //leashedTo = "";
    isSkittish = false;
};

allBehaviorsSet.add(%behavior);*/

// -------------------------------------------------------
// Clan pets
%behavior = new ScriptObject(PetBehavior) {
    isAggressive = true;
    canMove = true;
    returnToMarker = false;
    isKillable = true;
    isFollowPlayer = true;
    isLeashed = true;
    leashedTo = "%obj.master";
    isSkittish = false;
};

allBehaviorsSet.add(%behavior);

// -------------------------------------------------------

%behavior = new ScriptObject(MountBehavior) {
    isAggressive = false;
    canMove = true;
    returnToMarker = true;
    isKillable = true;
    isFollowPlayer = false;
    isLeashed = false;
    isSkittish = false;
};
allBehaviorsSet.add(%behavior);

/*%behavior = new ScriptObject(CritterBehavior) {
    isAggressive = false;
    canMove = true;
    returnToMarker = false;
    isKillable = true;
    isFollowPlayer = false;
    isLeashed = false;
    //leashedTo = "";
    isSkittish = true;
};

allBehaviorsSet.add(%behavior);*/

// -------------------------------------------------------
//epls bloodclans
%behavior = new ScriptObject(NPCVendorBehavior) {
    isAggressive = false;
    canMove = false;
    returnToMarker = true;
    isKillable = false;
    isFollowPlayer = false;
    isLeashed = false;
    isSkittish = false;
};

allBehaviorsSet.add(%behavior);
//epls end
// -------------------------------------------------------

%behavior = new ScriptObject(HuntedBehavior) {
    isAggressive = true;
    canMove = true;
    returnToMarker = false;
    isKillable = true;
    isFollowPlayer = false;
    isLeashed = false;
    isSkittish = true;
    isHunted = true;
};

allBehaviorsSet.add(%behavior);
// -------------------------------------------------------
}
