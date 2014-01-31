//****************************************************************
//The Universal AI Starter Kit (AISK)
//Copyright (c) 2009-2011 Twisted Jenius - All rights reserved.
//This file is engine SPECIFIC. - TGEA
//****************************************************************


//-----------------------------------------------------------------------------
//Datablock Specific Function
//-----------------------------------------------------------------------------

//The onReachDestination function is responsible for setting the bots 'action' state to the
//appropriate setting depending on what action the bot was following to reach the destination.
//function PlayerDataAFX::onReachDestination(%this, %obj) //UAISK+AFX Interop Change
function AIPlayer::onReachDestination(%this, %obj) //UAISK+AFX Interop Change
{
   if ( %obj.isbot == false )
      return;

   if ( %obj.getDatablock().isMethod("destinationOverride") )
   {
      %obj.getDatablock().destinationOverride(%obj);
      return;
   }

   //Picks an appropriate set of actions based on the bots 'action' variable
   switch$(%obj.action)
   {
      case "Guarding":
         %obj.clearaim();

      case "Returning":
         %obj.clearaim();

         //If the bot is pathed have it move to the next node on its path
         if (%obj.path !$= "")
         {
            //Check if the bot's guarding
            if (!%obj.behavior.returnToMarker)
            {
               if (%obj.returningPos == %obj.marker.getposition())
                  %obj.moveToNextNode();
               else
                  %obj.path = "";
            }
            else
               %obj.moveToNextNode();
         }
         //The bot is not pathed
         else
         {
            if (%obj.behavior.returnToMarker)
            {
               if (%obj.oldPath $= "")
                  %basedist = VectorDistSquared(%obj.getposition(), %obj.marker.getposition());
               else
                  %basedist = VectorDistSquared(%obj.getposition(), %obj.oldPath);
            }
            else
               %basedist = VectorDistSquared(%obj.getposition(), %obj.returningPos);

            //If the bot is close to his original position then set it's action to Guarding
            if (%basedist < 4.0)
            {
               %obj.action = "Guarding";
            }
            //If the bot is away from his post, then he must have gotten here
            //as a result of sidestepping so set him to do a quick hold to scan
            //for targets then return to post.
            else
            {
               //Sets holdcnt to 1 less than the max. Ensures that the bot only holds for 1 cycle
               //before trying to return.
               %obj.holdcnt = $AISK_HOLDCNT_MAX - 1;
               %obj.action = "Holding";
            }
         }

      //The bot was defending and sidestepped. So set it to 'hold' to check for targets
      //and to prepare to return to post if no targets are found.
      case "Defending":
         %obj.action = "Holding";
        
      case "Roaming":
         %obj.action = "Grazing";

      case "Thief":
         %obj.stoleFish = true;
         %obj.stealTartget.HideFish();
         // Set a new destination
         %pos1 = %obj.stealTartget.getPosition();
         %thiefPos = %obj.getPosition();
         %vec = VectorSub(%thiefPos, %pos1);
         %newPos = VectorAdd(%pos1, VectorScale(%vec, 50));
         %newPos = setWord(%newPos, 2, (getWord(%newPos,2) - 35));
         %obj.setAimLocation(%newPos);
         %obj.setMoveDestination(%newPos, false);
         %obj.setMoveSpeed(1.0);
   }
}


//-----------------------------------------------------------------------------
//Pace and Sidestep Functions
//-----------------------------------------------------------------------------

//Causes AIPlayer to slowly pace around their current location
function AIPlayer::Pacing(%this, %obj)
{
    //Don't pace if the bot is pathed
    if ( %obj.path !$= "" )
        return;

    %obj.pace--;

    //Check if the bot has paced recently and if it should be pacing at all.
    if (%obj.pace <= 0 && (%obj.maxPace > 0 && $AISK_PACE_TIME > 0 && $AISK_PACE_SPEED > 0))
    {
        //If the bot needs to pace, get a random time (which is an amount of think cycles)
        //that the bot has before it paces again
        %obj.pace = getRandom(1, $AISK_PACE_TIME);

        //Multiple the random pace time by the bot's attention level.
        //This is so the bot always paces at the same rate no matter what its attention is.
        //The if/else and the line after can be commented out if you wish.
        if (%obj.attentionlevel != $AISK_MAX_ATTENTION)
            %tempAttention = $AISK_MAX_ATTENTION - %obj.attentionlevel;
        else
            %tempAttention = 1;

        %obj.pace = %obj.pace * %tempAttention;
    }
    else
        return;

    //Set the bots returning position to its marker if it's guarding
    if (%obj.behavior.returnToMarker && %obj.behavior.isAggressive)
    {
        if (%obj.oldPath $= "")
            %obj.returningPos = %obj.marker.getposition();
        else
            %obj.returningPos = %obj.oldPath;
    }

    //Skittish bots don't return back to their markers
    if (%obj.behavior.isSkittish && !%obj.behavior.returnToMarker)
        %basedist = 0;
    else
        %basedist = VectorDistSquared(%obj.getposition(), %obj.returningPos);

    //If the bot is away from its returning position, go back to it so it doesn't wander too far away
    if (%basedist > $AISK_MIN_PACE_SQR)
        %newLoc = %obj.returningPos;
    else
    {
        //Get max and min pace distances
        %max = %obj.maxPace;
        %min = $AISK_MIN_PACE;
        %foundObject = 1;

        for (%i = 0; (%i < $AISK_LOOP_COUNTER && %foundObject > 0); %i++)
        {
            //Get proper random numbers
            %xrand = %this.constrainedRandom(%obj, %max, %min);
            %yrand = %this.constrainedRandom(%obj, %max, %min);
            //%zrand = %this.constrainedRandom(%obj, %max, %min);
            //Change them into a vector
            %randVector = %xrand SPC %yrand SPC 0;

            //Add or subtract the numbers from the bot's current position. Subtraction
            //is done by adding a negative. Adding versus subtracting is the difference
            //between left vs right, or forward vs backward
            %newLoc =  vectorAdd(%obj.getposition(), %randVector);

            //Test LOS of the new position
            %foundObject = %this.positionLosCheck(%obj, %newLoc);

            //If the bot is leashed, make sure it stays in the proper range
            if (%obj.behavior.isLeashed)
            {
               if (!%this.testLeashed(%obj, %newLoc))
                   %foundObject = 1;
            }
        }
    }

    if (%foundObject > 0)
    {
        if ($AISK_SHOW_NAME $= "Debug")
            warn("Bot ID " @ %obj @ " could not find a valid PACE location.");

        return;
    }

    //Set the bot to move at a different speed than normal while pacing
    %obj.setMoveSpeed($AISK_PACE_SPEED);
    //Set the bot to look in the direction that it is moving.
    //%obj.setaimlocation(vectorAdd(%newloc, $AISK_CHAR_HEIGHT));
    %obj.setaimlocation(%newloc);
    //Set the bot to move towards the new position.
    if (%obj.behavior.canMove && !%obj.isCasting)
        %obj.setMoveDestination(%newLoc, true);
}

//Sidestep is used to find a random spot near the bot and attempt to have them move towards it.
//This function is only called in combat, including after being hit by an attack.
function AIPlayer::SideStep(%this, %obj, %isDodge)
{
    //If this is a turret return now because turrets don't move
    if (!%obj.behavior.canMove || %obj.isCasting)
        return;

    //Get max and min sidestep distances
    %max = %obj.stepDis;
    %min = %obj.rangeMin;
    // BloodClans Script Modification (MAR) - AI Paths >>>
    // Set min >= 1 because the think loop will think we're stuck if we move < 1
    if ( %min < 1 )
      %min = 1;
    if ( %max < (%min+1) )
       %max = %min + 4;
    %foundObject = 1;

    for (%i = 0; (%i < $AISK_LOOP_COUNTER && %foundObject > 0); %i++)
    {
        //Get proper random numbers
        %xrand = %this.constrainedRandom(%obj, %max, %min);
        %yrand = %this.constrainedRandom(%obj, %max, %min);
        //%zrand = %this.constrainedRandom(%obj, %max, %min);
        //Change them into a vector
        %randVector = %xrand SPC %yrand SPC 0;

        if (%isDodge && %obj.advancedDodge !$= "Random")
            %newLoc =  %this.advancedActiveDodge(%obj, %xrand);
        //Add or subtract the numbers from the bot's current position. Subtraction
        //is done by adding a negative. Adding versus subtracting is the difference
        //between left vs right, or forward vs backward
        else
            %newLoc =  vectorAdd(%obj.getposition(), %randVector);

        %foundObject = %this.positionLosCheck(%obj, %newLoc);

        //If the bot is leashed, make sure it stays in the proper range
        if (%obj.behavior.isLeashed)
        {
           if (!%this.testLeashed(%obj, %newLoc))
               %foundObject = 1;
        }
    }

    //Switch the bot from side to back, or the other way
    if (%isDodge && %obj.advancedDodge $= "Serpentine")
    {
        if (%obj.dodgeCounter)
            %obj.dodgeCounter = false;
        else
            %obj.dodgeCounter = true;
    }

    if (%foundObject > 0)
    {
        if ($AISK_SHOW_NAME $= "Debug")
            warn("Bot ID " @ %obj @ " could not find a valid SIDESTEP location.");

        return;
    }

    //If there's a target, keep aiming at it while sidestepping
    if (%obj.action $= "Returning")
        %obj.setaimlocation(vectorAdd(%newloc, $AISK_CHAR_HEIGHT));

    //If the bot is pathed, get ready to move to the correct node
    %this.returningPath = 2;

    //Set the bot to move towards the new position.
    %obj.setMoveDestination(%newLoc, true);
}

//Get a random number that's constrained between min and max values
function AIPlayer::constrainedRandom(%this, %obj, %max, %min)
{
    //%numRand is set to be a random number that is between -max * 10 and +max * 10
    %numRand = getRandom(0, %max * 20) - %max * 10;

    //Make sure the random value is within the proper minimum range
    while (%numRand > (-%min * 10) && %numRand < (%min * 10))
    {
        %numRand = getRandom(0, %max * 20) - %max * 10;
    }

    //Divide the random number by 10 to get one decimal place
    %numRand = %numRand/10;
    return %numRand;
}

//Do a LOS test between the bot and a location
function AIPlayer::positionLosCheck(%this, %obj, %newLoc)
{
    //Line of sight test for the position the bot wants to pace to
    %eyeTrans = %obj.getEyeTransform();
    %eyeEnd = vectorAdd(%newLoc, $AISK_OBSTACLE);
    %searchResult = containerRayCast(%eyeTrans, %eyeEnd, $TypeMasks::PlayerObjectType | $TypeMasks::StaticTSObjectType |
        $TypeMasks::TerrainObjectType | $TypeMasks::ItemObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticObjectType, %obj);
    %foundObject = getword(%searchResult, 0);

    return %foundObject;
}

//Have the bot move side to side or back and forth
function AIPlayer::advancedActiveDodge(%this, %obj, %rand) {
    //Get the bot's position
    %x1 = getWord(%obj.getPosition(), 0);
    %y1 = getWord(%obj.getPosition(), 1);
    %z1 = getWord(%obj.getPosition(), 2);

    //Get the bot's rotation for the Z axis within a range of -120 to 240
    %rot = getWord(%obj.rotation, 2) * getWord(%obj.rotation, 3);

    //Side to side movement
    if (%obj.advancedDodge $= "Side" || (%obj.advancedDodge $= "Serpentine" && %obj.dodgeCounter))
    {
        %rot += 90;

        if (%rot > 360)
            %rot -= 360;
    }

    %rot = mDegToRad(%rot);

    //Do some math to get the destination point based on the angle and distance
    %x2 = mSin(%rot) * %rand;
    %y2 = mCos(%rot) * %rand;

    %x2 += %x1;
    %y2 += %y1;

    %pos = %x2 SPC %y2 SPC %z1;
    return %pos;
}


//-----------------------------------------------------------------------------
//Normal Movement Functions
//-----------------------------------------------------------------------------

//Check if the location the bot is moving to is in sight.
//And if it's not, move somwhere that is in sight (if there's a better place).
function AIPlayer::movementPositionFilter(%this, %obj)
{
    if (!%obj.behavior.canMove || %obj.isCasting)
        return;

    if (%obj.behavior.isLeashed)
    {
        if (!%this.yesLeashed(%obj))
            return;
    }

    //Save the original destination to another variable for later use
    %this.moveDestinationB = %this.moveDestinationA;
    %eyeTrans = %obj.getEyeTransform();

    //Do a simple test to see if the bot can go directly to its target destination,
    //or if it needs to do something fancy to go around an obstacle
    if (%this.checkMovementLos(%obj, %eyeTrans, %this.moveDestinationB) == 0)
        %obj.setmovedestination(%this.moveDestinationB, true);
    else
    {
        //The "45" below is the angle
        %this.moveDestinationB = %this.triangleBasedAviodance(%obj, 45, %this.moveDestinationA);
        %thirdPointA = %this.moveDestinationB;

        if (%this.checkMovementLos(%obj, %eyeTrans, %this.moveDestinationB) == 0)
        {
            %this.moveDestinationB = %this.triangleBasedAviodance(%obj, -45, %this.moveDestinationA);
            %thirdPointB = %this.moveDestinationB;

            //Both ways are clear so check which one is better
            if (%this.checkMovementLos(%obj, %eyeTrans, %this.moveDestinationB) == 0)
            {
                %start = vectorAdd(%thirdPointA, $AISK_CHAR_HEIGHT);
                %foundObject = %this.checkMovementLos(%obj, %start, %this.moveDestinationA);

                if (%foundObject == 0)
                    %obj.setmovedestination(%thirdPointA, true);
                else
                    %obj.setmovedestination(%thirdPointB, true);
            }
            else
                %obj.setmovedestination(%thirdPointA, true);
        }
        else
        {
            %this.moveDestinationB = %this.triangleBasedAviodance(%obj, -45, %this.moveDestinationA);

            if (%this.checkMovementLos(%obj, %eyeTrans, %this.moveDestinationB) == 0)
                %obj.setmovedestination(%this.moveDestinationB, true);
            //Nothing is unblocked, move in a random direction
            else
                %this.sidestep(%obj);
        }
    }

    %aimAt = %obj.getAimObject();

    if (%aimAt > 0 && %obj.runAround < 1) //UAISK+AFX Interop Change
    {
        %className = %aimAt.getClassName();

        if ((%className !$= "Player" && %className !$= "AIPlayer") || %aimAt.getstate() $= "Dead")
            %obj.setAimLocation(vectorAdd(%obj.getMoveDestination(), $AISK_CHAR_HEIGHT));
    }
}

//Go around an obstacle based on a triangle with two of the points
//being the bot's current position and its target position.
function AIPlayer::triangleBasedAviodance(%this, %obj, %angle, %tgtPos)
{
    %botPos = %obj.getPosition();

    //Get the X and Y values for the start and end points
    %x1 = getWord(%botPos, 0);
    %x2 = getWord(%tgtPos, 0);

    %y1 = getWord(%botPos, 1);
    %y2 = getWord(%tgtPos, 1);

    %angle = mDegToRad(%angle);

    //Get the slope of each line
    %M1 = (%y2 - %y1) / (%x2 - %x1);
    %M2 = mTan(%angle + mAtan(%M1, 1));
    %M3 = -(1 / %M2);

    //Get the intercept
    %B2 = %y1 - (%x1 * %M2);
    %B3 = %y2 - (%x2 * %M3);

    //Get the position of the third point in our triangle
    %x3 = -((%B3 - %B2) / (%M3 - %M2));
    %y3 = %M2 * %x3 + %B2;

    if (getWord(%tgtPos, 2) >= getWord(%botPos, 2))
        %z3 = getWord(%tgtPos, 2);
    else
        %z3 = getWord(%botPos, 2);

    %correctPos = %x3 SPC %y3 SPC %z3;
    return %correctPos;
}

//Line of sight test for the position the bot wants to move to
function AIPlayer::checkMovementLos(%this, %obj, %start, %end)
{
    //%end = vectorAdd(%end, $AISK_CHAR_HEIGHT);

    %searchResult = containerRayCast(%start, %end, $TypeMasks::StaticTSObjectType | $TypeMasks::TerrainObjectType |
        $TypeMasks::ItemObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticObjectType, %obj);

    %foundObject = getWord(%searchResult, 0);

    return %foundObject;
}

//Causes AIPlayer to slowly pace around their current location
function AIPlayer::Roaming(%this, %obj)
{
   %obj.pace--;

   //Check if the bot has paced recently and if it should be pacing at all.
   if (%obj.pace <= 0 && (%obj.maxPace > 0 && $AISK_PACE_TIME > 0 && $AISK_PACE_SPEED > 0))
   {
      //If the bot needs to pace, get a random time (which is an amount of think cycles)
      //that the bot has before it paces again
      %obj.pace = getRandom(1, $AISK_PACE_TIME);
   }
   else
      return;

   //Get max and min pace distances
   %max = %obj.maxPace;
   %min = $AISK_MIN_PACE;
   %foundObject = 1;

   for (%i = 0; (%i < $AISK_LOOP_COUNTER && %foundObject > 0); %i++)
   {
      //Get a random vector for direction
      %xrand = %this.constrainedRandom(%obj, %max, %min);
      %yrand = %this.constrainedRandom(%obj, %max, %min);
      %randVector = %xrand SPC %yrand SPC 0;

      // Make a new position with the vector
      %newLoc =  vectorAdd(%obj.getposition(), %randVector);

      //Test LOS of the new position
      %foundObject = %this.runPosLosCheck(%obj, %newLoc);
   }

   // Select a random move speed between 2 and 1/2 the bots max speed
   %maxSpeed = %obj.getDatablock().maxForwardSpeed;
   %fleeSpeed = getRandom() * %maxSpeed / 2;
   if ( %fleeSpeed < 2.0 )
      %fleeSpeed = 2.0;
   %fleeSpeed = %fleeSpeed / %maxSpeed; // Normalize to 0.0-1.0 range

   %obj.setMoveSpeed(%fleeSpeed);
   //%obj.setSprintTrigger(%fleeSpeed > 0.4);
   //Set the bot to look in the direction that it is moving.
   %obj.setaimlocation(vectorAdd(%newloc, $AISK_CHAR_HEIGHT));
   //Set the bot to move towards the new position.
   %obj.setMoveDestination(%newLoc, true);
}

function AIPlayer::onMoveStuck(%this, %obj)
{
   if ( (%obj.action $= "Roaming") || (%obj.action $= "Fleeing") )
   {
      %obj.pace = 0;
      %this.Roaming(%obj);
   }
}
