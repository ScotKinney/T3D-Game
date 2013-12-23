//****************************************************************
//The Universal AI Starter Kit (AISK)
//Copyright (c) 2009-2011 Twisted Jenius - All rights reserved.
//This file is engine NEUTRAL.
//****************************************************************


//-----------------------------------------------------------------------------
//Target Selection Functions
//-----------------------------------------------------------------------------

//This function gets the best valid target for the bot and sets its attention level
function AIPlayer::GetClosestHumanInSightandRange(%this, %obj)
{
   //Set the initial values to -1.
   %dist = -1;
   %dist2 = -1;
   %health = -1;
   %index = -1;
   %index2 = -1;
   //The bots current position
   %botpos = %this.getposition();

   // If we're currently engaged with a target, keep fighting them
   if ( isObject(%obj.targetEngaged) && (%obj.targetEngaged.getstate() !$= "Dead") )
   {
      %tgt = %obj.targetEngaged;
      //Determine the distance from the bot to the target
      %tempdist = VectorDistSquared(%tgt.getposition(), %botpos);
      if ( (%tempdist <= %obj.detDisSqr) &&
         %this.IsTargetInView(%obj, %tgt, %obj.fov) && %this.CheckLOS(%obj, %tgt))
         return %tgt;
   }
   %obj.targetEngaged = "";

   //This for loop cycles through all possible teams
   for (%j = 0; %j <= $TotalTeams; %j++)
   {
      //If the bot is on this team, don't check it for targets
      if (%obj.team != %j || $AISK_FREE_FOR_ALL == true)
      {
         //Get the name of the SimSet the bot is checking
         %teamSet = "TeamSet" @ %j;

         //The number of things to check
         if ( !isObject(%teamSet) )
            continue;
         %count = %teamSet.getCount();

         //This for loop cycles through all possible targets
         for (%i = 0; %i < %count; %i++)
         {
            //Get the target
            %tgt = %teamSet.getobject(%i);
            %namedClass = %tgt.getClassName();

            //If the target is invalid then the function bails out returning a -1 value
            if (%tgt != %obj && isObject(%tgt) && ((%tgt.behavior.isKillable && %namedClass $= "AIPlayer")
                     || %namedClass $= "Player") && %tgt.getstate() !$= "Dead")
            {
               //Determine the distance from the bot to the target
               %tempdist = VectorDistSquared(%tgt.getposition(), %botpos);

               //The first test we perform is to see if the target is within the bots range
               //Is target in range? If not bail out of checking to see if its in view.
               if (%tempdist <= %obj.detDisSqr)
               {
                  //The second check is to see if the target is within the FOV of the bot.
                  //Is the target within the fov field of vision of the bot?
                  if (%this.IsTargetInView(%obj, %tgt, %obj.fov))
                  {
                     //The third check we run is to see if there is anything blocking the target from the bot.
                     if (%this.CheckLOS(%obj, %tgt))
                     {
                        //Subtract the damage from the total health to get current health of the target
                        %tempHealth = %tgt.getDatablock().maxDamage - %tgt.getdamagelevel();

                        //If %health still equals -1, then this is our first valid target
                        //Set all values to be based off of our first valid target
                        if (%health == -1)
                        {
                           %health = %tempHealth;
                           %dist = %tempdist;
                           %index = %tgt;
                           %obj.returningPos = %tgt.getposition();
                        }
                        //Check this target has less health left than the last target did
                        //else if (%tempHealth + $AISK_HEALTH_IGNORE < %health)
                        else if (%tempHealth > %health)
                        {
                           %health = %tempHealth;
                           %index = %tgt;
                           %obj.returningPos = %tgt.getposition();
                        }
                        //Check the distance to the new target as compared to the current set target.
                        //If the new target is closer, then set the index and distance to the new target.
                        //Also make sure the reason the previous else if got pasted up was because the
                        //health was inside the ignore value
                        else if (%tempdist < %dist && %tempHealth - %health < $AISK_HEALTH_IGNORE)
                        {
                           %dist = %tempdist;
                           %index = %tgt;
                           %obj.returningPos = %tgt.getposition();
                        }
                     }
                  }
               }

               //Get the closest valid target
               if (%tempdist < %dist2 || %dist2 == -1)
               {
                  %dist2 = %tempdist;
                  %index2 = %tgt;
               }
            }
         }
      }
   }

   if (%index2 > 0)
      %this.adjustAttentionLevel(%obj, %index2, %botpos);
   else
      %this.attentionlevel = $AISK_MAX_ATTENTION;

   if (%obj.lostest == 1 && (!isObject(%obj.oldTarget) || %obj.oldTarget.getstate() $= "Dead"))
   {
      //If 2 or more bots just killed the player, we don't want them all standing exactly
      //where the player died. So we have them stay where they are.
      if (!%obj.behavior.returnToMarker)
      {
         %obj.returningPos = %obj.getposition();
         %obj.lostest = 0;

         if (%obj.behavior.isFollowPlayer)
            %this.yesFollowPlayer(%obj);
      }
   }

   //If the bot had sight of a target lasst think cycle, and now it can't find a target,
   //get its last target's current position
   if (%index == -1)
   {
      if (%obj.lostest == 1)
      {
         %obj.lostest = 0;

         //Make sure at least one target is somewhere near the bot before chasing
         if (%dist2 <= %obj.detDisSqr * $AISK_ATTENTION_RANGE)
            %this.lostrigger = %this.schedule($AISK_LOS_TIME, "getnewguardposition", %obj);
      }
   }
   else
      %obj.oldTarget = %index;

   return %index;
}

//UAISK+AFX Interop Changes: Start
//This function gets the best valid friendly target for the bot
function AIPlayer::GetClosestFriendInSightandRange(%this, %obj)
{
   //Set the initial values to -1.
   %dist = -1;
   %health = -1;
   %index = -1;
   //The bots current position
   %botpos = %this.getposition();

   //Get the name of the SimSet the bot is checking
   %teamSet = "TeamSet" @ %obj.team;

   //The number of things to check
   %count = %teamSet.getCount();

   //This for loop cycles through all possible targets
   for (%i = 0; %i < %count; %i++)
   {
      //Get the target
      %tgt = %teamSet.getobject(%i);
      %namedClass = %tgt.getClassName();

      //If the target is invalid then the function bails out returning a -1 value
      if (%tgt != %obj && isObject(%tgt) && ((%tgt.behavior.isKillable && %namedClass $= "AIPlayer")
               || %namedClass $= "Player") && %tgt.getstate() !$= "Dead")
      {
         //Determine the distance from the bot to the target
         %tempdist = VectorDistSquared(%tgt.getposition(), %botpos);

         //The first test we perform is to see if the target is within the bots range
         //Is target in range? If not bail out of checking to see if its in view.
         if (%tempdist <= %obj.detDisSqr)
         {
            //The second check we run is to see if there is anything blocking the target from the bot.
            if (%this.CheckLOS(%obj, %tgt))
            {
               //Subtract the damage from the total health to get current health of the target
               %tempHealth = %tgt.getDatablock().maxDamage - %tgt.getdamagelevel();

               //If %health still equals -1, then this is our first valid target
               //Set all values to be based off of our first valid target
               if (%health == -1)
               {
                  %health = %tempHealth;
                  %dist = %tempdist;
                  %index = %tgt;
               }
               //Check this target has less health left than the last target did
               else if (%tempHealth + $AISK_HEALTH_IGNORE < %health)
               {
                  %health = %tempHealth;
                  %index = %tgt;
               }
               //Check the distance to the new target as compared to the current set target.
               //If the new target is closer, then set the index and distance to the new target.
               //Also make sure the reason the previous else if got pasted up was because the
               //health was inside the ignore value
               else if (%tempdist < %dist && %tempHealth - %health < $AISK_HEALTH_IGNORE)
               {
                  %dist = %tempdist;
                  %index = %tgt;
               }
            }
         }
      }
   }

   if (%index > 0)
      %obj.oldTarget = %index;

   return %index;
}
//UAISK+AFX Interop Changes: End

//This function is for finding the nearest player by non aggressive bots.
//It does not take teams or FOV into account.
function AIPlayer::GetClosestPlayerInSightandRange(%this, %obj)
{
   %dist = -1;
   %dist2 = -1;
   //Set the initial index value to -1. The index is the nearest target found.
   %index = -1;
   %index2 = -1;
   //The bots current position
   %botpos = %this.getposition();
   //The number clients to check
   %count = ClientGroup.getCount();

   //This for loop cycles through all clients
   for (%i = 0; %i < %count; %i++)
   {
      //Get the target
      %tgt = ClientGroup.getobject(%i);
      %tgt = %tgt.player;

      //If the target is invalid then the function bails out returning a -1 value
      if (isObject(%tgt) && (%tgt.getstate() !$= "Dead" || %obj.behavior.isResBot)) //UAISK+AFX Interop Change
      {
         //Determine the distance from the bot to the target
         %tempdist = VectorDistSquared(%tgt.getposition(), %botpos);

         //The first test we perform is to see if the target is within the bots range
         //Is target in range? If not bail out of checking to see if its in view.
         if (%tempdist <= %obj.detDisSqr)
         {
            //We don't do a FOV check for non aggressive bots
            //The second check we run is to see if there is anything blocking the target from the bot.
            if (%this.CheckLOS(%obj, %tgt))
            {
               //If there is a current target, then check the distance to the new target as
               //compared to the current set target. If the new target is closest, then set
               //the index and tempdistance to the new target.
               if (%tempdist < %dist || %dist == -1)
               {
                  %dist = %tempdist;
                  %index = %tgt;

                  if (%obj.behavior.isFollowPlayer)
                     %obj.returningPos = %tgt.getposition();
               }
            }
         }

         //Get the closest valid target
         if (%tempdist < %dist2 || %dist2 == -1)
         {
            %dist2 = %tempdist;
            %index2 = %tgt;
         }
      }
   }

   if (%index2 > 0)
      %this.adjustAttentionLevel(%obj, %index2, %botpos);
   else
      %this.attentionlevel = $AISK_MAX_ATTENTION/2;

   //If 2 or more bots just killed the player, we don't want them all standing exactly
   //where the player died. So we have them stay where they are.
   if (%obj.lostest == 1 && %obj.behavior.isFollowPlayer && (!isObject(%obj.oldTarget) || %obj.oldTarget.getstate() $= "Dead"))
   {
      %obj.returningPos = %obj.getposition();
      %obj.lostest = 0;
   }

   //If the bot had sight of a target lasst think cycle, and now it can't find a target,
   //get its last target's current position
   if (%index == -1)
   {
      if (%obj.lostest == 1)
      {
         %obj.lostest = 0;
         %this.lostrigger = %this.schedule($AISK_LOS_TIME, "getnewguardposition", %obj);
      }
   }
   else
      %obj.oldTarget = %index;

   return %index;
}

//Get the position of the closest player on the bot's team
function AIPlayer::teammateCheck(%this, %obj)
{
   %dist = -1;
   //Set the initial index value to -1. The index is the nearest target found.
   %index = -1;
   //The bots current position
   %botpos = %this.getposition();
   %count = ClientGroup.getCount();

   //This for loop cycles through all clients
   for (%i = 0; %i < %count; %i++)
   {
      //Get the target
      %tgt = ClientGroup.getobject(%i);
      %tgt = %tgt.player;

      //If the target is invalid then the function bails out returning a -1 value
      if (%tgt.team == %obj.team && %tgt.getstate() !$= "Dead" && isObject(%tgt) && %tgt.getClassName() $= "Player")
      {
         //Determine the distance from the bot to the target
         %tempdist = VectorDistSquared(%tgt.getposition(), %botpos);

         //Get the closest valid target
         if (%tempdist < %dist || %dist == -1)
         {
            %dist = %tempdist;
            %index = %tgt;
         }
      }
   }

   %obj.loopCounter = 0;
   return %index;
}

//Adjust the bot's attention level based on its distance from the closest valid target
//This will make the bot think more or less often
function AIPlayer::adjustAttentionLevel(%this, %obj, %index2, %botpos)
{
   //Determine the distance from the bot to the target
   %tempdist = VectorDistSquared(%index2.getposition(), %botpos);

   if (%tempdist <= %obj.detDisSqr)
   {
      //Since the target is close, make sure the current attention is no greater than half the max
      if (%this.attentionlevel > $AISK_MAX_ATTENTION/2)
         %this.attentionlevel = $AISK_MAX_ATTENTION/2;
      //Lower attentionlevel to increase response time if it's currently 2 or more
      else if (%this.attentionlevel >= 2)
         %this.attentionlevel--;
      else
         %this.attentionlevel = 1;
   }
   //Check if the target is more than X times the bots detect distance
   else if (%tempdist >= %obj.detDisSqr * $AISK_ATTENTION_RANGE)
   {
      //This will slow down how often the bot thinks and checks for threats
      if (%this.attentionlevel <= $AISK_MAX_ATTENTION - 0.5)
         %this.attentionlevel = %this.attentionlevel + 0.5;
   }
   else
   {
      //If the target isn't extremely far or close, raise the attention level upto half of the max
      if (%this.attentionlevel <= $AISK_MAX_ATTENTION/2 - 0.5)
         %this.attentionlevel = %this.attentionlevel + 0.5;
      else
         %this.attentionlevel = $AISK_MAX_ATTENTION/2;
   }
}

//Get the player's position a short time after sight is lost
function AIPlayer::GetNewGuardPosition(%this, %obj)
{
   if ( isObject(%obj.oldTarget) )
      %obj.returningPos = %obj.oldTarget.getposition();
   else if ( isObject(%obj.marker) )
      %obj.returningPos = %obj.marker.getposition();
}


//-----------------------------------------------------------------------------
//Vision Functions
//-----------------------------------------------------------------------------

//It checks to see if there are any static objects blocking the view from the AIPlayer to the target.
function AIPlayer::CheckLOS(%this, %obj, %tgt)
{
   //%foundObject = %this.checkMovementLos(%obj, %obj.getEyeTransform(), %tgt.getPosition());
   %foundObject = %this.checkMovementLos(%obj, %obj.getEyeTransform(), %tgt.getEyePoint());

   if (%foundObject == 0)
   {
      if (%obj.behavior.isAggressive || (!%obj.behavior.isAggressive && %obj.behavior.isFollowPlayer))
         %obj.lostest = 1;

      return true;
   }

   return false;
}

//This function checks to see if the target supplied is within the bots FOV
function AIPlayer::IsTargetInView(%this, %obj, %tgt, %fov)
{
   //No need to check the rest if the bot can see everything
   if (%fov >= 360)
      return true;

   %ang = %this.check2dangletotarget(%obj, %tgt);
   %visleft = 360 - (%fov/2);
   %visright = %fov/2;

   if (%ang > %visleft || %ang < %visright)
      return true;

   return false;
}

//This function gets the angle to a target
function AIPlayer::check2DAngletoTarget(%this, %obj, %tgt)
{
   %eyeVec = VectorNormalize(%this.getEyeVector());
   %eyeangle = %this.getAngleofVector(%eyeVec);
   %posVec = VectorSub(%tgt.getPosition(), %obj.getPosition());
   %posangle = %this.getAngleofVector(%posVec);
   %angle = %posangle - %eyeAngle;
   %angle = %angle ? %angle : %angle * -1;

   if (%angle < 0)
      %angle = %angle + 360;

   return %angle;
}

//Return the angle of a vector in relation to world origin
function AIPlayer::getAngleofVector(%this, %vec)
{
   %vector = VectorNormalize(%vec);
   %vecx = getWord(%vector, 0);
   %vecy = getWord(%vector, 1);

   if (%vecx >= 0 && %vecy >= 0)
      %quad = 1;
   else
      if (%vecx >= 0 && %vecy < 0)
         %quad = 2;
      else
         if (%vecx < 0 && %vecy < 0)
            %quad = 3;
         else 
            %quad = 4;

   %angle = mATan(%vecy/%vecx, -1);
   %degangle = mRadToDeg(%angle);

   switch(%quad)
   {
      case 1:
         %angle = %degangle - 90;
      case 2:
         %angle = %degangle + 270;
      case 3:
         %angle = %degangle + 90;
      case 4:
         %angle = %degangle + 450;
   }

   if (%angle < 0)
      %angle = %angle + 360;

   return %angle;
}

//The EnhanceFOV function temporarily gives the bot a 360 degree field of vision
//This is used to emulate the bot looking around at different times. Namely when 'Holding'.
function AIPlayer::EnhanceFOV(%this, %obj)
{
   //Is the botFOV already 360 degrees? If not then we'll set it, and set the schedule to
   //turn it back off.
   if (%obj.fov < 360)
   {
      //Sets the field of vision to 360 deg.
      %obj.fov = 360;
      //Starts the timer to disable the enhanced FOV
      %this.fovtrigger = %this.schedule($AISK_ENHANCED_FOV_TIME, "restorefov", %obj);
   }
}

//Restore FOV sets the bot's FOV back to it's regular default setting.
function AIPlayer::restoreFOV(%this, %obj)
{
   %obj.fov = %obj.OldFOV;
}

//Enhances the defending bot's FOV and detect distance after being hit.
function AIPlayer::EnhanceDefending(%this, %obj)
{
   //Make sure enhanced defending is better than normal
   if (%obj.detDis < $AISK_ENHANCED_DEFENDING_DISTANCE * %obj.OldDetDis)
   {
      //Set the bots detect distance to be enhanced
      %obj.detDis = $AISK_ENHANCED_DEFENDING_DISTANCE * %obj.OldDetDis;
      %obj.detDisSqr = %obj.detDis * %obj.detDis;
      %this.distancetrigger = %this.schedule($AISK_ENHANCED_DEFENDING_TIME, "restoreDefending", %obj);
   }

   if (%obj.fov < 360)
   {
      //Set field of veiw
      %obj.fov = 360;
      %this.fovtrigger = %this.schedule($AISK_ENHANCED_DEFENDING_TIME, "restorefov", %obj);
   }
}

//Restores the defending bot's detect distance.
function AIPlayer::restoreDefending(%this, %obj)
{
   %obj.detDis = %obj.OldDetDis;
   %obj.detDisSqr = %obj.detDis * %obj.detDis;
}

// This function detects if any players are within the AIs detect distance and
// if so, attempts to find a position to flee to.
function AIPlayer::FindFleePosition(%this, %obj)
{
   //Set the initial values to -1.
   %hunterDist = -1;
   %hunter2Dist = -1;
   %closestHunter = -1;
   %hunter2 = -1;
   %index = -1;
   %index2 = -1;
   //The bots current position
   %botpos = %this.getposition();

   %numHunters = 0; // Number of players within detect distance.

   //This for loop cycles through all possible teams
   for (%j = 1; %j <= $TotalTeams; %j++)
   {
      if ( %obj.team != %j )
      {
         //Get the name of the SimSet the bot is checking
         %teamSet = "TeamSet" @ %j;

         //The number of things to check
         if ( !isObject(%teamSet) )
            continue;
         %count = %teamSet.getCount();

         //This for loop cycles through all possible targets
         for (%i = 0; %i < %count; %i++)
         {
            //Get the target
            %tgt = %teamSet.getobject(%i);
            %namedClass = %tgt.getClassName();

            // See if it's a live player within range
            if (%tgt != %obj && isObject(%tgt) &&
               (%namedClass $= "Player") && %tgt.getstate() !$= "Dead")
            {
               //Determine the distance from the bot to the player
               %targetPosition = %tgt.getposition();
               %tempdist = vectorDist(%targetPosition, %botpos);

               // If the player is in range, add it to our hunter list
               if (%tempdist <= %obj.detDis)
               {
                  %hunterPos[%numHunters] = %targetPosition;

                  // Save the closest player
                  if (%tempdist < %hunterDist || %hunterDist == -1)
                  {
                     if ( %hunterDist != -1 )
                     {
                        %hunter2Dist = %hunterDist;
                        %hunter2 = %closestHunter;
                        %index2 = %index;
                     }
                     %hunterDist = %tempdist;
                     %closestHunter = %tgt;
                     %index = %numHunters;
                  }
                  else if ( %hunter2Dist == -1 )
                  {
                     %hunter2Dist = %tempdist;
                     %hunter2 = %tgt;
                     %index2 = %numHunters;
                  }
                  %numHunters++;
               }
            }
         }
      }
   }
    
   if ( %hunterDist == -1 )
   {
      %obj.oldTarget = -1;
      %obj.oldDist = -1;
      return false;  // No players to worry about
   }

   // Set speed to move at based on the distance from the nearest hunter
   %worryDist = %obj.detDis * 0.9;
   %panicDist = %obj.detDis * 0.5;
   %maxSpeed = %obj.getDatablock().maxForwardSpeed;
   if ( %hunterDist < %worryDist )
   {
      %fleeSpeed = ((%worryDist - %hunterDist)/(%worryDist - %panicDist)) * %maxSpeed;
      if ( %fleeSpeed > %maxSpeed )
         %fleeSpeed = %maxSpeed;
      else if ( %fleeSpeed < 2.0 )
         %fleeSpeed = 2.0;
   }
   else
      %fleeSpeed = 2.0;
   %fleeSpeed = %fleeSpeed / %maxSpeed;

   if ((%obj.oldTarget == -1) || (%obj.oldTarget != %closestHunter) || (%obj.fleeCount > 19))
   {   
      // Find a safe direction to move away.
      %obj.fleeCount = 0;
      if ( %numHunters == 1 )
      {  // Only 1 so move roughly opposite
         %moveDir = VectorSub(%botpos, %hunterPos[0]);
      }
      else
      {  // Move away from the center point of the closest 2 hunters
         %adjVec = VectorSub(%hunterPos[%index], %hunterPos[%index2]);
         %adjVec = VectorScale(%adjVec, 0.5);
         %centerPt = VectorAdd(%hunterPos[%index2], %adjVec);
         %moveDir = VectorSub(%botpos, %centerPt);
      }
      %moveDir = setWord(%moveDir, 2, "0");
      %moveDir = VectorNormalize(%moveDir);
      %obj.moveDir = %moveDir;
      //%obj.lastMoveDir = "";
   }
   %obj.fleeCount++;
   
   //Set the bot to move towards the new position.
   %this.FilterFleePosition(%obj, %fleeSpeed, %maxSpeed);

   // Remember who we're running from
   %obj.oldTarget = %closestHunter;
   %obj.oldDist = %hunterDist;

   return true;
}

function AIPlayer::FilterFleePosition(%this, %obj, %fleeSpeed, %maxSpeed)
{
   //Set the bot to move towards the new position.
   //%oldDir = VectorScale(%obj.moveDir, (%fleeSpeed * 3));
   %botPos = %this.getPosition();
   %oldDir = VectorScale(%obj.moveDir, %maxSpeed);
   %newLoc = VectorAdd(%botPos, %oldDir);
   %pathFound = !%this.runPosLosCheck(%obj, %newLoc);
   
   if ( !%pathFound )
   {  // Blocked by something, try to avoid it.
      %rightMat = MatrixCreateFromEuler("0 0 0.2618");   // 15 degrees each way
      %leftMat = MatrixCreateFromEuler("0 0 -0.2618");
      if ( %obj.lastDodgeRight )
      {
         %mat2 = %rightMat;
         %mat1 = %leftMat;
      }
      else
      {
         %mat1 = %rightMat;
         %mat2 = %leftMat;
      }
      if ( %obj.lastMoveDir $= "" )
         %obj.lastMoveDir = %obj.moveDir;
      %pathFound = false;
      
      %tempVec = %obj.lastMoveDir;
      %newDir = VectorScale(%tempVec, %maxSpeed);
      %newLoc = VectorAdd(%botPos, %newDir);   
      %pathFound = !%this.runPosLosCheck(%obj, %newLoc);

      for ( %i = 0; (%i < 6) && !%pathFound; %i++)
      {
         %tempVec = MatrixMulVector(%mat1, %tempVec);
         %newDir = VectorScale(%tempVec, %maxSpeed);
         %newLoc = VectorAdd(%botPos, %newDir);   
         %pathFound = !%this.runPosLosCheck(%obj, %newLoc);
         if ( %pathFound )
            %obj.lastDodgeRight = !%obj.lastDodgeRight;
      }
      if ( !%pathFound )
         %tempVec = %obj.lastMoveDir;
         
      for ( %i = 0; (%i < 6) && !%pathFound; %i++)
      {
         %tempVec = MatrixMulVector(%mat2, %tempVec);
         %newDir = VectorScale(%tempVec, %maxSpeed);
         %newLoc = VectorAdd(%botPos, %newDir);   
         %pathFound = !%this.runPosLosCheck(%obj, %newLoc);
      }
      if ( %pathFound )
         %obj.lastMoveDir = %tempVec;
   }
   else
      %obj.lastMoveDir = "";

   %obj.setMoveSpeed(%fleeSpeed);
   //%obj.setSprintTrigger(%fleeSpeed > 0.4);
   %obj.setaimlocation(%newloc);
   %obj.setMoveDestination(%newLoc, true);

}

//Do a LOS test between the bot and a location
function AIPlayer::runPosLosCheck(%this, %obj, %newLoc)
{
   //Line of sight test for the position the bot wants to pace to
   %eyeTrans = %obj.getEyeTransform();
   %eyeEnd = vectorAdd(%newLoc, $AISK_OBSTACLE);
   %searchResult = containerRayCast(%eyeTrans, %eyeEnd, $TypeMasks::PlayerObjectType |
         $TypeMasks::ItemObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticObjectType, %obj);
   %foundObject = getword(%searchResult, 0);
   
   if ( %foundObject && ("TerrainBlock" $= %foundObject.getClassName()) )
   {
      if ( (getword(%searchResult, 4) > 0.4) || (getword(%searchResult, 5) > 0.4) ||
           (getword(%searchResult, 4) < -0.4) || (getword(%searchResult, 5) < -0.4) ||
         (getword(%searchResult, 6) < 0.75) )
         return %foundObject;  // Hit terrain with a slope we can't walk on
      return false;
   }
   
   if ( !%foundObject )
   {  // Make sure we aren't steering the bot into a waterblock
      %rayStart = vectorAdd(%newLoc, "0 0 20");
      %rayEnd = vectorAdd(%newLoc, "0 0 -100");
      %searchResult = containerRayCast(%rayStart, %rayEnd, $TypeMasks::InteriorObjectType |
            $TypeMasks::StaticObjectType | $TypeMasks::WaterObjectType, %obj);
      %foundObject = getword(%searchResult, 0);
      if ( %foundObject )
      {
         %hitClass = %foundObject.getClassName();
         if (("WaterPlane" $= %hitClass) || ("WaterBlock" $= %hitClass))
            return %foundObject;
      }

      return false;
   }

   return %foundObject;
}

