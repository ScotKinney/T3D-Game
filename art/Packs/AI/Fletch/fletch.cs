// Custom movement and actions for Old Fletch
Fletch.pathSpeed = 0.5; // Fletch walks his path at 1/2 his attack speed

// Movements: Pause times (in seconds) and actions at path nodes.
// Node 0 is at the work bench. Pause for 10 seconds and play hammer anim
Fletch.nodePause[0] = 10;
Fletch.nodeAnim[0] = "hammer";

// Node 3 is at the edge of the hill. Pause for 3 seconds
Fletch.nodePause[3] = 3;

// Node 7 is at the well. Pause for 5 seconds
Fletch.nodePause[7] = 5;

// Node 8 is up the path. Pause for 5 seconds
Fletch.nodePause[8] = 5;

// Descisions:
// State 0 A players initial approach
Fletch.message[0] = "Hello there! Would you like to buy some arrows?";
Fletch.stateSound[0] = "FletchVoice0";
Fletch.stateAnim[0] = "talk3";  // Animation to play in this state
Fletch.animTime[0] = "";  // How long to let animation play before returning to root
Fletch.stateChoices[0] = 2;     // Number of choices
Fletch.choice1GoTo[0] = 1;      // GoTo state on first choice
Fletch.choice1Text[0] = "No";   // Label for first choice
Fletch.choice2GoTo[0] = 2;      // GoTo state on second choice
Fletch.choice2Text[0] = "Yes";   // Label for second choice

// State 1 Player does NOT want to buy weapons
Fletch.message[1] = "So it's adventure you're after eh?";
Fletch.stateSound[1] = "FletchVoice1";
Fletch.stateAnim[1] = "talk3";  // Animation to play in this state
Fletch.animTime[1] = "";  // How long to let animation play before returning to root
Fletch.stateChoices[1] = 2;     // Number of choices
Fletch.choice1GoTo[1] = 3;      // GoTo state on first choice
Fletch.choice1Text[1] = "No";   // Label for first choice
Fletch.choice2GoTo[1] = 4;      // GoTo state on second choice
Fletch.choice2Text[1] = "Yes";   // Label for second choice

// State 2 Player does want to buy weapons
Fletch.message[2] = "Help yourself then, they're over on the bench.";
Fletch.stateSound[2] = "FletchVoice2";
Fletch.stateAnim[2] = "talk1";  // Animation to play in this state
Fletch.animTime[2] = "";  // How long to let animation play before returning to root
Fletch.stateChoices[2] = 1;     // Number of choices
Fletch.choice1GoTo[2] = 86;      // GoTo state on first choice
Fletch.choice1Text[2] = "OK";   // Label for first choice

// State 3 Player does NOT want adventure
Fletch.message[3] = "Want some Rye? Course you do!";
Fletch.stateSound[3] = "FletchVoice3";
Fletch.stateAnim[3] = "talk3";  // Animation to play in this state
Fletch.animTime[3] = "";  // How long to let animation play before returning to root
Fletch.stateChoices[3] = 1;     // Number of choices
Fletch.choice1GoTo[3] = 86;      // GoTo state on first choice
Fletch.choice1Text[3] = "OK";   // Label for first choice

// State 4 Player does want an adventure
Fletch.message[4] = "Many years ago the Shields of the Ten were scattered to the far ends of Mythriel. Bring me all ten shields and I'll give you a weapon that can easily destroy 10 enemies in one blow. Are you up for the challenge?";
Fletch.stateSound[4] = "FletchVoice4";
Fletch.stateAnim[4] = "talk4";  // Animation to play in this state
Fletch.animTime[4] = "14";  // How long to let animation play before returning to root
Fletch.stateChoicesv = 2;     // Number of choices
Fletch.choice1GoTo[4] = 5;      // GoTo state on first choice
Fletch.choice1Text[4] = "No";   // Label for first choice
Fletch.choice2GoTo[4] = 6;      // GoTo state on second choice
Fletch.choice2Text[4] = "Yes";   // Label for second choice

// State 5 Player does NOT accept the challenge
Fletch.message[5] = "Be on your way then scallywag!";
Fletch.stateSound[5] = "FletchVoice5";
Fletch.stateAnim[5] = "talk1";  // Animation to play in this state
Fletch.animTime[5] = "";  // How long to let animation play before returning to root
Fletch.stateChoices[5] = 1;     // Number of choices
Fletch.choice1GoTo[5] = 86;      // GoTo state on first choice
Fletch.choice1Text[5] = "OK";   // Label for first choice

// State 6 Player does accept the challenge
Fletch.message[6] = "Hurry along then and bring me back the Shields of the Ten.";
Fletch.stateSound[6] = "FletchVoice6";
Fletch.stateAnim[6] = "talk3";  // Animation to play in this state
Fletch.animTime[6] = "";  // How long to let animation play before returning to root
Fletch.stateChoices[6] = 1;     // Number of choices
Fletch.choice1GoTo[6] = 100;      // GoTo state on first choice
Fletch.choice1Text[6] = "OK";   // Label for first choice

// State 7 Player returns after being given quest
Fletch.message[7] = "Welcome back, did you find the shields?";
Fletch.stateSound[7] = "FletchVoice7";
Fletch.stateAnim[7] = "talk3";  // Animation to play in this state
Fletch.animTime[7] = "";  // How long to let animation play before returning to root
Fletch.stateChoices[7] = 2;     // Number of choices
Fletch.choice1GoTo[7] = 8;      // GoTo state on first choice
Fletch.choice1Text[7] = "No";   // Label for first choice
Fletch.choice2GoTo[7] = 101;      // GoTo state on second choice
Fletch.choice2Text[7] = "Yes";   // Label for second choice

// State 8 Player does NOT have all shields
Fletch.message[8] = "Well come back when you have them all!";
Fletch.stateSound[8] = "FletchVoice8";
Fletch.stateAnim[8] = "talk3";  // Animation to play in this state
Fletch.animTime[8] = "";  // How long to let animation play before returning to root
Fletch.stateChoices[8] = 1;     // Number of choices
Fletch.choice1GoTo[8] = 86;      // GoTo state on first choice
Fletch.choice1Text[8] = "OK";   // Label for first choice

// State 9 Player does have all shields and ready to trade
Fletch.message[9] = "Thanks, now get on out of here before I beat you silly!";
Fletch.stateSound[9] = "FletchVoice9";
Fletch.stateAnim[9] = "talk2";  // Animation to play in this state
Fletch.animTime[9] = "";  // How long to let animation play before returning to root
Fletch.stateChoices[9] = 1;     // Number of choices
Fletch.choice1GoTo[9] = 102;      // GoTo state on first choice
Fletch.choice1Text[9] = "OK";   // Label for first choice

function Fletch::destinationOverride(%this, %obj)
{
   if ( %obj.npcEngaged )
      return;  // Stop following path while engaged

   if (%this.nodePause[%obj.currentNode] > 0 )
   {
      if ( %this.nodeAnim[%obj.currentNode] !$= "" )
      {
         %obj.setActionThread(%this.nodeAnim[%obj.currentNode]);
      }
      %obj.delayedMove = %this.schedule(%this.nodePause[%obj.currentNode] * 1000, "moveToNextNode", %obj);
   }
   else
      %this.moveToNextNode(%obj);
}

function Fletch::customNPCAction(%this, %obj)
{
   if ( !%obj.npcEngaged )
   {
      //%tgt = %obj.GetClosestPlayerInSightandRange(%obj);
      %tgt = %obj.GetClosestHumanInSightandRange(%obj);
      if ( %tgt > 0 )
      {  // Make sure it's a valid target
         if ( !isObject(%tgt.client) )
            %tgt = -1;
         else
            %tgt = %tgt.client;
      }
   }
   else
      %tgt = %obj.lastNPCTgt;

   if ( (%tgt > 0) || %obj.npcEngaged )
   {
      if ( !%obj.npcEngaged )
      {  // New target so stop following the path
         %obj.stop();
         if ( isEventPending(%obj.delayedMove) )
            cancel(%obj.delayedMove);

         // Set the bot to look at the player.
         %obj.setAimObject(%tgt.player, $AISK_CHAR_HEIGHT);

         // Record the target
         %obj.npcEngaged = true;
         %obj.lastNPCTgt = %tgt;

         // And reset state
         if ( %tgt.onQuest == 10 )
            %obj.npcState = 7;   // Player returning from quest
         else
            %obj.npcState = 0;
         %obj.npcDecision = 0;
      }
      else
      {  // make sure our target is still valid
         if ( !isObject(%tgt) || !isObject(%tgt.player) )
         {
            %obj.npcDecision = 0;
            %obj.npcState = 86;
         }
      }
      
      // 99 is used to indicate we're paused waiting for a response from player
      if ( %obj.npcDecision == 99 )
         return;

      if ( %obj.npcState == 86 )
      {  // Return Fletch to his path, the interaction is done.
         %obj.npcEngaged = false;
         %obj.attentionlevel = 10;
         %this.moveToNode(%obj, %obj.currentNode);
         return;
      }
      
      if ( %obj.npcDecision == 0 )
      {  // Entering state, so do state actions
         // Send message to client to display input box
         commandToClient(%tgt, 'QNPCMessage', %obj,
            Fletch.message[%obj.npcState], Fletch.stateChoices[%obj.npcState],
            Fletch.choice1Text[%obj.npcState], Fletch.choice2Text[%obj.npcState],
            Fletch.choice3Text[%obj.npcState]);
         %obj.npcDecision = 99;  // Put into hold state

         // Play the animation if there is one
         if ( %this.stateAnim[%obj.npcState] !$= "" )
         {
            %obj.setActionThread(%this.stateAnim[%obj.npcState]);
            if ( %this.animTime[%obj.npcState] !$= "" )
               %obj.stateAnimTimer = %obj.schedule(%this.animTime[%obj.npcState] * 1000, "setActionThread", "idle");
         }

         // Play the sound file if there is one
         if ( %this.stateSound[%obj.npcState] !$= "" )
            serverPlay3D(%this.stateSound[%obj.npcState],%obj.getTransform());
         
         %obj.attentionlevel = 2;
      }
      else if ( %obj.npcDecision == 1 )
      {
         %obj.npcState = %this.choice1GoTo[%obj.npcState];
         %obj.npcDecision = 0;
         %obj.attentionlevel = 1;
      }
      else if ( %obj.npcDecision == 2 )
      {
         %obj.npcState = %this.choice2GoTo[%obj.npcState];
         %obj.npcDecision = 0;
         %obj.attentionlevel = 1;
      }
      else if ( %obj.npcDecision == 3 )
      {
         %obj.npcState = %this.choice3GoTo[%obj.npcState];
         %obj.npcDecision = 0;
         %obj.attentionlevel = 1;
      }
      
      // Now that the input has been processed, see if we've been put into a conditional state
      if ( %obj.npcState >= 100 )
      {
         if ( %obj.npcState == 100 )
         {  // Player has accepted the quest
            %tgt.onQuest = 10;   // Mark the client as on the quest
            %obj.npcState = 86;  // Go into our exit state
         }
         else if ( %obj.npcState == 101 )
         {  // The player has come back and says they have all 10 shields
            if ( %this.takeShields(%obj, %tgt) )
               %obj.npcState = 9;  // Get ready to do battle
            else
               %obj.npcState = 8;  // They lied, they don't have them all
         }
         else if ( %obj.npcState == 102 )
         {  // Fletch has taken the shield and the battle has begun
            %this.attackTarget(%obj, %tgt);
            %tgt.onQuest = -1;
            %obj.npcDecision = -1;
         }
      }
   }
   else
   {
      %obj.attentionlevel = 10;
   }
}

function Fletch::takeShields(%this, %obj, %tgt)
{  // Take all 10 shields from the player. If they don't have all ten, return
   // false and take none
   
   // First check that they have all 10
   for ( %i = 1; %i < 11; %i++ )
   {
      %key = "Shieldof10_" @ %i;
      if ( %tgt.player.getInventory(%key) <= 0 )
         return false;
   }

   // They have all 10 so take them
   for ( %i = 1; %i < 11; %i++ )
   {
      %key = "Shieldof10_" @ %i;
      %tgt.player.setInventory(%key, 0);
   }

   messageClient(%tgt, 'MsgItemPickup', '\c1You have given Old Fletch all 10 shields.');
   %tgt.player.updateInventoryString();
   return true;
}

function Fletch::attackTarget(%this, %obj, %tgt)
{  // We've been put into attack mode
   %obj.target = %tgt.player;
   
   // Make sure we haven't been pulled too far away from our path
   %botPos = %obj.getposition();
   %node = %obj.path.getObject(%obj.currentNode);
   %basedist = vectorDist(%botPos, %node.getposition());
   if ( %basedist > %obj.leash )
   {
      %obj.npcState = 86; // Go into exit state
      return;
   }

   %dest = %obj.target.getposition();
   %basedist = vectorDist(%botPos, %dest);
   %obj.basedist = %basedist;

   //Set the bot to aim at the target.
   %aimOffset = $AISK_CHAR_HEIGHT;
   %obj.setAimObject(%obj.target, %aimOffset);

   //Check if the bot is already close enough to the target or needs to be closer
   if (%basedist > %obj.weapRange)
   {
      %obj.setMoveSpeed($AISK_PATH_SPEED);
      %obj.moveDestinationA = %dest;
      %obj.movementPositionFilter(%obj);
   }
   //If the bots not too far, check if its too close
   else if (%basedist < %obj.rangeMin)
   {
      %obj.sidestep(%obj);
      %obj.setAimObject(%obj.target, %aimOffset);
   }
   //The bot isn't too close or too far from its target
   else
   {
      //Since the bot is within the proper range, just have it stop where it is if it's not sidestepping
      if (%obj.activeDodge <= 0)
         %obj.stop();
      else if (%obj.dodgeTimer > 0)
         %obj.dodgeTimer--;
      else
      {
         %obj.dodgeTimer = %obj.activeDodge;
         %obj.sidestep(%obj, true);
         %obj.setAimObject(%obj.target, %aimOffset);
      }

      //Tells the bot to start shooting the target.
      %obj.stop();
      if ( !%obj.setActionThread("attack") )
      {
         if ( !%obj.setArmThread("attack") )
         {
            cancel(%obj.firetimer);
            %obj.firetimer = %obj.schedule(1, "openfire", %obj, %obj.target, %basedist);
         }
      }
   }
}

function Fletch::handleBotDeath(%this, %obj)
{
   if ( %obj.npcState != 102 )
      return;  // Not in battle with a questor, so don't drop the shard

   %item = new Item() {
      aiDrop = "1";
      static = "0";
      rotate = "0";
      dataBlock = Shard_of_Boltarc;
      position = %obj.getPosition();
      rotation = "1 0 0 0";
      scale = "1 1 1";
      canSave = "1";
      canSaveDynamicFields = "1";
         count = 10;
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

//This function moves the bot to the next path node
function Fletch::moveToNode(%this, %obj, %index)
{
   // Make sure there's a valid path
   if ( !isObject(%obj.path) )
      return;

   //Move to the given path node index
   %obj.currentNode = %index;
   %node = %obj.path.getObject(%index);

   //The 0 at the end sets if the bot should slow down or not, you can change it if needed
   %obj.setMoveDestination(%node.getPosition(), 0);

   //Make the bot face the node it's moving to
   %obj.setAimLocation(%obj.path.getObject(%obj.currentNode).getPosition());
}

//This function sets what path node the bot should move to next
function Fletch::moveToNextNode(%this, %obj)
{
   %path = %obj.path;

   %obj.nextNode = 0;

   //Set the bot's movement speed
   %obj.setMoveSpeed(%this.pathSpeed);

   //Move to the next node, unless the bot is at the last node then move to the first
   if (%obj.currentNode < %path.getCount() - 1)
      %this.moveToNode(%obj, %obj.currentNode + 1);
   else
      %this.moveToNode(%obj, 0);
}
