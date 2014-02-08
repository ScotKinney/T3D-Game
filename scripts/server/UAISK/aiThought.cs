//****************************************************************
//The Universal AI Starter Kit (AISK)
//Copyright (c) 2009-2011 Twisted Jenius - All rights reserved.
//This file is engine NEUTRAL.
//****************************************************************


//The bot uses a state machine to control it's actions. The bot's default actions are as follows:
//Guarding:         When guarding the bot paces, scans for new targets, and when one is found it switches to 'Attacking'
//Attacking:        The bot tries to close with the target while firing and checking for target updates.
//Holding:          When the bot loses a target it will go into a holding pattern. While holding the bot's FOV
//                          is enhanced. The bot holds for a set number of cycles before changing it's action state to 'Returning'
//Returning:        The bot tries to return to it's original position. While returning the bot looks for new targets
//                          and checks it motion relative to it's last movement to determine if it is stuck.
//Defending:        When a bot takes damage it's status is set to defending. The bot sidesteps and then
//                          goes into a holding pattern. This does two things. It enhances the bots FOV and detect range and it
//                          scans for targets. The bot returns to it's original position if there is no perceivable threat in range.


//The 'Think' function is the brains of the bot. The bot performs certain
//actions based on what its current 'action' state is. The bot thinks
//on a scheduled basis. How fast the bot 'thinks' is determined by the
//bots attention level and its default scan time.
function AIPlayer::Think(%this, %obj)
{
   //This cancels the current schedule - just to make sure that things are kept neat and tidy.
   cancel(%this.ailoop);

   //If the bot is dead, then there's no need to think or do anything. So let's bail out.
   if (%obj.getstate() $= "Dead" || !isObject(%obj))
      return;

   //The bot is doing something special right now, so don't interrupt it
   if (%obj.specialMove)
      return;

   //The switch$ takes the value of the bots action variable and then chooses what code to run
   //according to what value it is.
   switch$(%obj.action)
   {
      //This is the bots default position. While guarding the bot will do 3 things by default.
      //The first is that the bot will run a random check to see if it can enhance it's fov.
      //The second thing the bot does is to check for nearby targets. If found the bot goes into attack mode.
      //The third is to pace back and fourth around the spot they're guarding.
      //If the bot is in the "teammate" behavior mode, it will try to go back to a player.
      case "Guarding":
         %obj.fireLater = 0;
         %obj.lostest = 0;
         %obj.isLost = 0;

         //Check if there's a target in sight and range, then attack if so.
         if (%this.attackTransition(%obj))
            return;

         //If the bot is a teammate, have it follow the player
         if (%obj.behavior.isFollowPlayer)
            %this.yesFollowPlayer(%obj);
         else
            %this.pacing(%obj);

         //There are no targets so continue guarding and call the scheduler to have the bot think
         //at it's regular interval
         %this.ailoop = %this.schedule($AISK_SCAN_TIME * %obj.attentionlevel, "Think", %obj);

      //The bot has been told that there is a target in sight and range and is set to attack it.
      //While attacking the bot's attention level is kept at its lowest value (quickest thinking).
      //The bot looks for the nearest target in sight. If the target is found the bot will aim at the
      //target, set it's move destination to the position of the target, and then openfire on the target.
      case "Attacking":
         //Set the bot's move speed back to normal
         %obj.setMoveSpeed(1.0);
         %obj.isLost = 0;
         %obj.nextNode = 0;
         %obj.pathPaused = 0;

         //Get the id of the nearest valid target
         %tgt = %this.GetClosestHumanInSightandRange(%obj);
         //Maintain a low attention value to keep the bot thinking quickly while attacking.
         %obj.attentionlevel = 1;

         //Check if there is a valid target
         if (%tgt > 0)
         {
            %this.target = %tgt;//epls bloodclans

            %dest = %tgt.getposition();
            %basedist = vectorDist(%obj.getposition(), %dest);
            %this.basedist = %basedist;//epls bloodclans

            //Set the bot to aim at the target.
            //%aimOffset = $AISK_CHAR_HEIGHT;
            %aimOffset = VectorSub(%tgt.getEyePoint(), %dest);
            //echo("Attacking Aim Offset = " @ %aimOffset);
            %obj.setAimObject(%tgt, %aimOffset);

            //Check if the bot is already close enough to the target or needs to be closer
            if (%basedist > %obj.weapRange)
            {
               %this.moveDestinationA = %dest;
               %this.movementPositionFilter(%obj);
            }
            //If the bots not too far, check if its too close
            else if (%basedist < %obj.rangeMin)
            {
               %this.sidestep(%obj);
               %obj.setAimObject(%tgt, %aimOffset);
            }
            //The bot isn't too close or too far from its target
            else
            {
               //Since the bot is within the proper range, just have it stop where it is if it's not sidestepping
               if (%obj.activeDodge <= 0)
                  %this.stop();
               else if (%obj.dodgeTimer > 0)
                  %obj.dodgeTimer--;
               else
               {
                  //If dodge is set to random, get a number for it now
                  if (%obj.activeDodge $= "x")
                  {
                     %rand = getRandom(1, $AISK_RAND_DODGE_MAX);
                     //How much longer until the bot dodges
                     %obj.dodgeTimer = %rand;
                  }
                  else
                     %obj.dodgeTimer = %obj.activeDodge;

                  %this.sidestep(%obj, true);
                  %obj.setAimObject(%tgt, %aimOffset);
               }

               %obj.stop();
               if ( !%obj.firing )
               {
                  cancel(%this.firetimer);
                  %this.firetimer = %this.schedule(1, "openfire",
                        %obj, %tgt, %basedist);
               }
            }

            if (%obj.behavior.isLeashed)
            {
               %this.moveDestinationA = %obj.getPosition();
               %this.movementPositionFilter(%obj);
            }

            //Tells the scheduler to have us think again. attentionLevel is always 1 here
            %this.ailoop = %this.schedule($AISK_SCAN_TIME, "Think", %obj);
            return;
         }

         //Stop looking at the old target
         if (%obj.getAimObject() > 0)
         {
            %aimPosition = %obj.getAimObject().getPosition();
            %basedist = VectorDistSquared(%obj.getposition(), %aimPosition);

            if (%basedist > %obj.detDisSqr)
               %obj.setAimLocation(vectorAdd(%aimPosition, $AISK_CHAR_HEIGHT));
         }
         else
            %obj.clearaim();

         if (!%obj.behavior.returnToMarker && %obj.path !$= "")
            %obj.path = "";

         //Clear the firing variable
         %obj.firing = false;
         //Clear holdcnt
         %obj.holdcnt = 0;
         //Set our action to 'Holding'
         %obj.action = "Holding";
         //Again this sets the scheduler to have us think quickly to have the bot
         //react to the loss of it's attack target
         %this.ailoop = %this.schedule($AISK_QUICK_THINK, "Think", %obj);

      //When a bot loses it's target, or when the bot reaches it's destination as the result of
      //a sidestep the bot will go into a 'hold'. During a hold the bot will have enhanced
      //FOV (to emulate scanning around for targets.) The bot will look for targets in range and
      //attack if found. If no target is found the bot will increase it's holdcnt by 1. When the
      //bot reaches its maximum holdcnt value it will attempt to return to its return position.
      case "Holding":
         //Set the bot's move speed back to normal
         %obj.setMoveSpeed(1.0);

         //Check if there's a target in sight and range, then attack if so.
         if (%this.attackTransition(%obj))
            return;

         //There was no target found, so we need to have the bot continue to 'hold'
         //for a little bit before doing anything else.

         //Increase the holdcnt variable by one
         %obj.holdcnt++;
         %obj.fireLater = 0;

         if (%obj.behavior.isFollowPlayer)
            %this.yesFollowPlayer(%obj);

         //Check to see if we've passed our threshold of waiting
         if (%obj.holdcnt > $AISK_HOLDCNT_MAX)
         {
            //Set holdcnt back to 0 for the next time we need it.
            %obj.holdcnt = 0;
            %obj.isLost++;

            //Set the bot to return to where it last saw the player if it's not pathed
            if (%obj.path $= "")
            {
               //Reset returning positions for guard bots
               if (%obj.behavior.returnToMarker)
               {
                  if (%obj.oldPath $= "")
                     %obj.returningPos = %obj.marker.getposition();
                  else
                     %obj.returningPos = %obj.oldPath;
               }

               %this.moveDestinationA = %obj.returningPos;
               %this.movementPositionFilter(%obj);
            }
            //Set the bot to return to its path since it is pathed
            else
            {
               if (%obj.returningPath != 0)
               {
                  if (%obj.behavior.returnToMarker)
                     AIPlayer::followPath(%obj, %obj.path);
               }
               else
                  %obj.returningPath = 1;
            }

            if (%obj.behavior.isFollowPlayer)
               %obj.action = "Guarding";
            else
               %obj.action = "Returning";

            //Sets the bot's oldpos to the position it's returning to. This is done
            //due to the fact that we've been holding and our position hasn't been
            //changing. So we want to be sure that the bot doesn't think that it's
            //stuck as soon as it tries to return.
            %obj.oldpos = %obj.returningPos;
            //We've waited long enough, so let's think quickly and go into 'Return' mode
            %this.ailoop = %this.schedule($AISK_QUICK_THINK, "Think", %obj);
         }
         else
         {
            %this.moveDestinationA = %obj.returningPos;
            %basedist = VectorDistSquared(%obj.getposition(), %this.moveDestinationA);

            //Check if the bot is already close enough to its return position
            if (%basedist > 1.0)
               %this.movementPositionFilter(%obj);

            %this.ailoop = %this.schedule($AISK_SCAN_TIME * %obj.attentionlevel, "Think", %obj);
         }

      //In Return mode the bot will do the following: It looks for the nearest target in sight and will attack it.
      //If no target is found, the bot is still in the process of returning so we check to see if the bot is stuck.
      //Stuck in the case means that the bot has moved a distance of less than 1 unit since the last time it thought.
      //If the bot is stuck, sidestep is called to have the bot try to move in a different direction.
      case "Returning":
         //Check if there's a target in sight and range, then attack if so.
         if (%this.attackTransition(%obj))
            return;

         if (%this.noCanMove(%obj))
            return;

         // BloodClans Script Modification (MAR) - AI Paths >>>
         // If we've already side stepped, get back on the path
         if ( (%obj.returningPath == 2) && isObject(%obj.path) )
            %obj.moveToNextNode();
         // BloodClans Script Modification (MAR) - AI Paths <<<

         //There was no target so we're still returning. So now check for a pathed or stuck bot
         //This gets a value depicting the distance from the bots last known move point
         %movedist = VectorDistSquared(%obj.getposition(), %obj.oldpos);

         //If the bot hasn't moved more than 1 unit we're probably stuck.
         //Remember - this is only checked for while returning - not guarding
         if (%movedist < 1.0 && !%obj.nextNode)
         {
            //Set our holdcnt to 1 less than the maximum so we only hold for 1 cycle
            %obj.holdcnt = $AISK_HOLDCNT_MAX;
            //Call sidestep to pick a new move destination near the bot
            %this.sidestep(%obj);
         }
         else
            %obj.clearaim();

         //See if the bot seems to be stuck, and if so then have it stop moving
         if (%obj.isLost >= $AISK_LOOP_COUNTER)
         {
            if ($AISK_SHOW_NAME $= "Debug")
            warn("Bot ID " @ %obj @ " was unable to get to its intended destination.");

            if (!%obj.behavior.returnToMarker)
            {
               %obj.returningPos = %obj.getposition();
               %obj.action = "Guarding";
            }
         }

         //Set our oldpos to match our current position so that next time we cycle through
         //we'll know if we're going anywhere or not
         %obj.oldpos = %obj.getposition();
         //Scedhule ourselves to think at our regular interval
         %this.ailoop = %this.schedule($AISK_SCAN_TIME * %obj.attentionlevel, "Think", %obj);

      //When a bot takes damage his state is set to defending. A bot that is
      //defending will have its attention set to its lowest level. It will sidestep
      //to try to avoid the danger, and to throw some randomness into its movement.
      //The bot will then go into a quick hold of 1 count.
      case "Defending":
         //Set the bot's move speed back to normal
         %obj.setMoveSpeed(1.0);
         %obj.isLost = 0;
         %obj.nextNode = 0;
         %obj.pathPaused = 0;

         //Set the bot to it's highest awareness
         %obj.attentionlevel = 1;
         //Set the hldcnt to 1 less than the max
         %obj.holdcnt = $AISK_HOLDCNT_MAX - 1;

         //Sidestep to a random position
         %this.sidestep(%obj, true);

         //Set our action to 'Holding'
         %obj.action = "Holding";
         //Set a quick think schedule to start us looking for targets quickly.
         %this.ailoop = %this.schedule($AISK_QUICK_THINK, "Think", %obj);

      case "Grazing":
         //Check if there's a player in range, run away from it.
         if (%this.fleeTransition(%obj))
            return;
         %obj.action = "Roaming";

         %this.ailoop = %this.schedule($AISK_SCAN_TIME * %obj.attentionlevel, "Think", %obj);

      case "Roaming":
         //Check if there's a player in range, run away from it.
         if (%this.fleeTransition(%obj))
            return;
         %this.Roaming(%obj);

         %this.ailoop = %this.schedule($AISK_SCAN_TIME * %obj.attentionlevel, "Think", %obj);

      case "Fleeing":
         //Check if there's a player in range, run away from it.
         if (%this.fleeTransition(%obj))
            return;

         %obj.action = "Grazing";
         %this.ailoop = %this.schedule($AISK_SCAN_TIME * %obj.attentionlevel, "Think", %obj);

      default:
         %obj.action = "Holding";
         %this.ailoop = %this.schedule($AISK_QUICK_THINK, "Think", %obj);
   }
}

//epls bloodclans
// Detect when a animation trigger has been fired on this player.
function AIPlayer::onAnimationTrigger(%this, %obj, %slot)
{
   if ( (%slot == 3) && isObject(%obj.firingWeapon) )
   {
      %obj.firingWeapon.delayedFire(%obj, 0);
      if ( %obj.firingWeapon.weaponType !$= "Delayed" )
         %obj.firing = false;
      %obj.firingWeapon = "";
      return;
   }

   //we use slot 3 of the addTrigger to key an attack on the animation.
   if ( (%slot == 3) && (%this.target !$= "") )
      %this.openfire(%obj, %this.target, %this.basedist);
}
//epls end

function PlayerData::animationDone(%this, %obj)
{
   if ( %obj.getMountedImage(0).weaponType !$= "Delayed" )
   {
      if ( %obj.isBot && %obj.firing )
      {
         //If the weapon doesn't have a fireDelay set, then use the default
         if (isObject(%obj.firingWeapon) && %obj.firingWeapon.fireDelay !$= "")
            %k = %obj.firingWeapon.fireDelay;
         else
            %k = $AISK_FIRE_DELAY;
         %obj.ceasefiretrigger = %obj.schedule(%k, "delayFire", %obj);
      }
      else
         %obj.firing = false;
   }
   %obj.inAttackThread = false;
}

function AIPlayer::attackTransition(%this, %obj)
{
   //if holding, enhance the bot's FOV
   if (%obj.action $= "Holding")
      %this.enhancefov(%obj);
   else if ($AISK_ENHANCED_FOV_CHANCE >= 1)
   {
      //The bot will enhance it's FOV if it picks a 1 from a range of 1 to $AISK_ENHANCED_FOV_CHANCE
      %chance = getRandom(1, $AISK_ENHANCED_FOV_CHANCE);

      if (%chance == 1)
         %this.enhancefov(%obj);
   }

   //The bot checks for the nearest valid target if any.
   %tgt = %this.GetClosestHumanInSightandRange(%obj);

   //Check if a target was found
   if (%tgt > 0)
   {
      //Set the bots action to 'Attacking'.
      %obj.action = "Attacking";

      // If the bot has an attack sound, play it here
      %db = %obj.getDataBlock();
      if ( %db.numAttackSounds > 0 )
      {
         %idx = getRandom(0, (%db.numAttackSounds-1));
         %obj.playAudio(0, %db.AttackSound[%idx]);
      }

      //The bots thinking is sped up to enable the bot to react more quickly as seems appropriate.
      %this.ailoop = %this.schedule($AISK_QUICK_THINK, "Think", %obj);

      return true;
   }
   //If there was no target, stay in the same state
   else
      return false;
}

//This is the thinking cycle for non aggressive bots.
function AIPlayer::npcThink(%this, %obj)
{
   //This cancels the current schedule - just to make sure that things are kept neat and tidy.
   cancel(%this.ailoop);

   //If the bot is dead, then there's no need to think or do anything. So let's bail out.
   if (%obj.getstate() $= "Dead" || !isObject(%obj))
      return;

   if (%obj.behavior.isFollowPlayer)
      %this.yesFollowPlayer(%obj);
   else
      %this.pacing(%obj);

   //Do an npc action if needed, this code is in the main think cycle as well but commented out
   if (%obj.npcAction == 5)
   {
      %obj.getDatablock().customNPCAction(%obj);
   }
   else if (%obj.npcAction > 0)
      %this.doingNpcAction(%obj);

   //Schedule this function to loop through again after a certain period of time.
   %this.ailoop = %this.schedule($AISK_SCAN_TIME * %obj.attentionlevel, "npcThink", %obj);
}

//-----------------------------------------------------------------------------
//Special Move Functions
//-----------------------------------------------------------------------------

//Have the bot completely stop all other actions and just do what you want
function AIPlayer::doSpecialMove(%obj, %time)
{
   if (!isObject(%obj) || %obj.getstate() $= "Dead")
      return;

   //Make sure we have a time
   if (%time < 1)
      %time = 1000;

   //Make sure the bot doesn't think due to damage or touch
   %obj.specialMove = true;

   //Cancel any old specials and start a new one
   cancel(%obj.specialTimer);
   %obj.specialTimer = schedule(%time, %obj, "clearSpecial", %obj);

   //Cancel the bot's think cycle
   cancel(%obj.ailoop);
   %obj.stop();
   %obj.clearaim();
}

function AIPlayer::fleeTransition(%this, %obj)
{
   //The bot checks for the nearest valid target if any.
   %isHunted = %this.FindFleePosition(%obj);

   //Check if a target was found
   if ( %isHunted )
   {
      //Set the bots action to 'Fleeing'.
      %obj.action = "Fleeing";
      %obj.attentionlevel = 1;
      %this.ailoop = %this.schedule($AISK_SCAN_TIME, "Think", %obj);
      return true;
   }

   //If there was no target, stay in the same state
   %obj.attentionlevel = $AISK_MAX_ATTENTION;
   return false;
}

function AIPlayer::setMountable(%this, %mountable)
{
   %this.mountable = %mountable;
}

//Allow the bot to start thinking again now that it's done with its special move
function clearSpecial(%obj)
{
   %obj.specialMove = false;

   //Make sure the bot doesn't act odd if it was attacking when the special started
   %obj.fireLater = 0; 
   %obj.lostest = 0;

   //Start thinking again
   %obj.ailoop = %obj.schedule($AISK_QUICK_THINK, "Think", %obj);
}
