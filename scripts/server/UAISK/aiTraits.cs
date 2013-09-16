//****************************************************************
//The Universal AI Starter Kit (AISK)
//Copyright (c) 2009-2011 Twisted Jenius - All rights reserved.
//This file is engine NEUTRAL.
//****************************************************************


//-----------------------------------------------------------------------------
//Leashed Functions
//-----------------------------------------------------------------------------

//Checks where a leashed bot can move to
function AIPlayer::yesLeashed(%this, %obj)
{
   //Get the object the bot is leashed to
   eval("%leashPos = " @ %obj.behavior.leashedTo @ ";");

   //Make sure it's a valid object and get a new player if needed
   if (!isObject(%leashPos))
   {
      if (%obj.behavior.isFollowPlayer)
         %this.yesFollowPlayer(%obj);

      return false;
   }

   %leashPos = %leashPos.getposition();

   %dist = VectorDistSquared(%this.moveDestinationA, %leashPos);

   //See if it's at the end of its leash
   if (%dist > (%obj.leash * %obj.leash))
   {
      %dist2 = VectorDistSquared(%obj.getAimLocation(), %obj.getPosition());

      //See if its target is within its detect distance
      if (%dist2 < %obj.detDisSqr)
      {
         %dist3 = vectorDist(%leashPos, %obj.getPosition());

         //See if it could get any closer to its target while still being
         //inside of its leash area
         if (%dist3 + 1.0 < %obj.leash && %obj.action $= "Attacking")
         {
            %this.getCloserToTarget(%obj, %leashPos);
            return true;
         }
         //It's too far and needs to go back
         else if (%dist3 > %obj.leash)
         {
            if (!%obj.behavior.isFollowPlayer && (%obj.action !$= "Attacking") && (%obj.action !$= "Holding"))
               %obj.clearaim();

            %this.moveDestinationA = %leashPos;
            return true;
         }
         //Just right, so stop
         else
            return false;
      }
      else
      {
         if (!%obj.behavior.isFollowPlayer)
            %obj.clearaim();

         //If the target is too far, return to where it should
         %this.moveDestinationA = %leashPos;
         return true;
      }
   }
   else
   {
      %dist4 = VectorDistSquared(%this.moveDestinationA, %obj.getPosition());

      if (%dist4 < 1.0)
         return false;

      return true;
   }
}

//A basic check to see if a leashed bot can move to a position
function AIPlayer::testLeashed(%this, %obj, %newLoc)
{
   eval("%leashPos = " @ %obj.behavior.leashedTo @ ";");

   if (!isObject(%leashPos))
   {
     if (%obj.behavior.isFollowPlayer)
         %this.yesFollowPlayer(%obj);

     return false;
   }

   %leashPos = %leashPos.getposition();

   %dist = VectorDistSquared(%newLoc, %leashPos);

   //See if it's at the end of its leash
   if (%dist > (%obj.leash * %obj.leash))
      return false;
   else
      return true;
}

//Get the closest position to the player that's still within the bot's leash range
function AIPlayer::getCloserToTarget(%this, %obj, %leashPos)
{
   //Get some numbers to work with
   %aimPos = %obj.getAimLocation();
   %k = %obj.leash / vectorDist(%leashPos, %aimPos);

   //Do some math
   %x1 = getWord(%aimPos, 0);
   %x2 = getWord(%leashPos, 0);

   %x3 = %x1 - %x2;
   %x3 = %k * %x3;
   %x3 = %x1 - %x3;

   %y1 = getWord(%aimPos, 1);
   %y2 = getWord(%leashPos, 1);

   %y3 = %y1 - %y2;
   %y3 = %k * %y3;
   %y3 = %y1 - %y3;

   %z1 = getWord(%aimPos, 2);
   %z2 = getWord(%leashPos, 2);

   if (%z1 > %z2)
      %z3 = %z1;
   else
      %z3 = %z2;

   //Set the new position
   %obj.moveDestinationA = %x3 SPC %y3 SPC %z3;
}

//-----------------------------------------------------------------------------
//Other Functions
//-----------------------------------------------------------------------------

//Follow the player if the behavior isFollowPlayer and the bot is idle
function AIPlayer::yesFollowPlayer(%this, %obj)
{
   if (%obj.path !$= "")
      return;

   //See if a new player is needed or if we can just follow the current one
   if (!isObject(%obj.master) || %obj.master.getstate() $= "Dead")
   {
      //Get the nearest valid player on the bot's team
      //No LOS checks are done with this
      %obj.master = %this.teammateCheck(%obj);
   }

   //Make sure the bot has a valid player to follow
   if (%obj.master > 0)
   {
      %masterPos = %obj.master.getPosition();
      %basedist = vectorDist(%obj.getposition(), %masterPos);

      //The bot is too far from the player
      if (%basedist > %obj.weapRange)
      {
         %obj.returningPos = %masterPos;
         %this.moveDestinationA = %masterPos;

         %this.movementPositionFilter(%obj);
         %obj.setAimObject(%obj.master);
         %obj.movingTowardsPlayer = 1;
      }
      else
      {
         //If the bot is still moving towards the player, have it stop
         if (%obj.movingTowardsPlayer)
         {
            %this.stop();
            %obj.movingTowardsPlayer = 0;
         }
         //If it already stopped, then pace
         else
         {
            %obj.returningPos = %obj.getposition();
            %this.pacing(%obj);
         }
      }
   }

   //Keep the bot's attention level down
   if (%this.attentionlevel > $AISK_MAX_ATTENTION/2)
      %this.attentionlevel = $AISK_MAX_ATTENTION/2;
}

//Check if this bot can move
function AIPlayer::noCanMove(%this, %obj)
{
   if (!%obj.behavior.canMove || %obj.isCasting)
   {
      %obj.action = "Guarding";
      %obj.clearaim();

      if( isEventPending(%this.ailoop) )
         cancel(%this.ailoop);

      if (%obj.behavior.isAggressive)
         %this.ailoop = %this.schedule($AISK_SCAN_TIME * %obj.attentionlevel, "Think", %obj);
      else
         %this.ailoop = %this.schedule($AISK_SCAN_TIME * %obj.attentionlevel, "npcThink", %obj);

      return true;
   }

   return false;
}

//UAISK+AFX Interop Changes: Start
//Put the bot into a confused state that reduces their view distance,
//makes them run around, and not fire/cast as often
function confuseBot(%obj, %time, %range)
{
   %obj.isConfused++;
   //Reduce the bot's view distance
   %obj.detDis = %range/3;
   %obj.detDisSqr = %obj.detDis * %obj.detDis;

   cancel(%obj.keepConfused);
   %wait = 320;

   //Keep doing this same function until the effect is done
   if ($Sim::Time + (%wait / 1000) <= %time)
   {
      //Have the bot move around
      %obj.sidestep(%obj);
      %obj.keepConfused = schedule(%wait, %obj, "confuseBot", %obj, %time, %range);
   }
   else
   {
      //Reset the bot's view distance to normal
      %obj.detDis = %range;
      %obj.detDisSqr = %obj.detDis * %obj.detDis;
      %obj.keepConfused = 0;
      %obj.isConfused = 0;
   }
}

//Random direction facing for "Green Legs and Scram"
function randAimOffset(%obj, %time)
{
   %wait = 320;
   %min = 2;
   %max = 8;

   //Get a random offset
   %aimX = AIPlayer::constrainedRandom(%obj, %obj, %max, %min);
   %aimY = AIPlayer::constrainedRandom(%obj, %obj, %max, %min);
   %randVector = %aimX SPC %aimY SPC 0;

   //Set the bot to aim at the offset location
   %aimPos = vectorAdd(%obj.getAimLocation(), %randVector);
   %obj.setAimLocation(vectorAdd(%aimPos, $AISK_CHAR_HEIGHT));

   cancel(%obj.runAround);

   //Keep doing this same function until the spell is done
   if ($Sim::Time + (%wait / 1000) <= %time)
      %obj.runAround = schedule(%wait, %obj, "randAimOffset", %obj, %time);
   else
      %obj.runAround = 0;
}

//Random movement for "Bron-Y-Orc Stomp"
function randMoveOffsetPos(%obj, %time)
{
   %obj.sidestep(%obj);

   cancel(%obj.moveAround);
   %wait = 320;

   //Keep doing this same function until the spell is done
   if ($Sim::Time + (%wait / 1000) <= %time)
      %obj.moveAround = schedule(%wait, %obj, "randMoveOffsetPos", %obj, %time);
   else
      %obj.moveAround = 0;
}
//UAISK+AFX Interop Changes: End
