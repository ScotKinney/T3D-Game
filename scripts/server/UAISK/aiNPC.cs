//****************************************************************
//The Universal AI Starter Kit (AISK)
//Copyright (c) 2009-2011 Twisted Jenius - All rights reserved.
//This file is engine SPECIFIC. - T3D
//****************************************************************


//Do whatever npc action the bot needs to do
function AIPlayer::doingNpcAction(%this, %obj)
{
   //Select a target based on the bots detect distance, but this target will be used to chat with, not attack.
   //This will also increase/decrease the bots attention level based on how close the target player is.
   %tgt = %this.GetClosestPlayerInSightandRange(%obj);

   //Check if there is a valid target gotten by the function above.
   if ( (%tgt > 0) || %obj.npcEngaged )
   {
      //Set the bot to aim at the target, so it will look at the player.
      if ( !%obj.npcEngaged )
         %obj.setAimObject(%tgt, $AISK_CHAR_HEIGHT);

      //Get a string version of the of this bot's npcDecision variable to set a value to it later.
      %npcString = %obj @ ".npcDecision = ";

      //Since the bot is close enough to a player, do something based on what its npcAction is set to.
      switch(%obj.npcAction)
      {
         //If its npcAction is 1, then do the following
         case 1:
            //Only display this pop up if it hasn't recently been displayed.
            if (%obj.npcDecision == 0)
            {
               //This will make a yes/no pop up display to the player, the order is as follows:
               //MessageBoxYesNo(%title, %message, %yesCallback, %noCallback)
               //You can check messageBox.cs for other types of pop ups.
               // BloodClans Script Modification (MAR) - Networked NPC Messages >>>
               //MessageBoxYesNo("Fight me!", "Fight?", %npcString @ "2;", %npcString @ "1;");
               //clientCmdNPCMessage(%npcID, %ttlTag, %msgTag, %format, %val1, %val2)
               // %format = 0 for ok, 1 for yes/no
               commandToClient(%tgt.client, 'NPCMessage', %obj, 'Fight me!', 'Fight?', 1, 2, 1);
               // BloodClans Script Modification (MAR) - Networked NPC Messages <<<
               //Set npcDecision to a neutral number while we wait for the player's input
               %obj.npcDecision = 3;
               %obj.npcEngaged = true; // Lock onto this player until they respond
            }

            //If an option in the below message box has already been selected, then
            //we'll set npcAction to do something else next think cycle.
            if (%obj.npcDecision == 1)
            {
               //If "no" was selected, set npcAction to a high number so it will just use the default next cycle.
               %obj.npcAction = 99;
               %obj.npcEngaged = false;
            }
            //This is an "else if" instead of just an "else" because we only want this code to execute if
            //an option has been selected, not just as a default.
            else if (%obj.npcDecision == 2)
            {
               //If "yes" was selected, change the bot from being non aggressive, to being aggressive.
               //Double check to make sure the npc think loop is canceled.
               cancel(%this.ailoop);
               //Set the bots behavior mode from npc to chase.
               %this.behavior = "ChaseBehavior";
               //Execute a normal think cycle to start the bot thinking normally.
               %this.Think(%obj);
               %obj.npcEngaged = false;
            }

         //The rest of these cases will have fewer comments since most of it has already
         //been explained, see case 1 for more details.
         case 2:
            if (%obj.npcDecision == 0)
            {
               //MessageBoxOK(%title, %message, %callback)
               //MessageBoxOK("Ammo!", "Have some ammo.", %npcString @ "1;");
               commandToClient(%tgt.client, 'NPCMessage', %obj, 'Ammo!', 'Have some ammo.', 0, 1, 1);
               %obj.npcDecision = 3;
               %obj.lastTgt = %tgt;
               %obj.npcEngaged = true;
            }
            //Make sure the player hit "ok".
            else if (%obj.npcDecision == 1)
            {
               //Give our target player 3 rounds of ammo.
               //%tgt.incInventory($AISK_WEAPON.image.ammo, 3);
               %obj.lastTgt.incInventory($AISK_WEAPON @ "Ammo", 3); // << BloodClans Script Modification
               //Set npcAction to go to the default.
               %obj.npcAction = 99;
               %obj.npcEngaged = false;
            }

         //See case 1 for more details.
         case 3:
            if (%obj.npcDecision == 0)
            {
               //MessageBoxYesNo("Talk 1", "Would you like to talk some more?", %npcString @ "2;", %npcString @ "1;");
               commandToClient(%tgt.client, 'NPCMessage', %obj, 'Talk 1', 'Would you like to talk some more?', 1, 2, 1);
               %obj.npcDecision = 3;
            }
            else if (%obj.npcDecision == 2)
            {
               //MessageBoxYesNo("Talk 2", "Do you still want to talk?", %npcString @ "0;", %npcString @ "1;");
               commandToClient(%tgt.client, 'NPCMessage', %obj, 'Talk 2', 'Do you still want to talk?', 1, 0, 1);
               %obj.npcDecision = 3;
            }

            //If the player selected "no", use the default npcAction.
            if (%obj.npcDecision == 1)
               %obj.npcAction = 99;

         //banker
         case 6:
            if (%obj.npcDecision == 0 && %this.lastClientBanked != %tgt.client)
            {
               messageClient(%tgt.client, 'MsgItemPickup', '\c1Hail!  I am %1 the Bankster. How may I help you?', %this.realname);
               commandToClient(%tgt.client, 'ActivateBanking', %this.realName);
               %this.lastClientBanked = %tgt.client;
               %obj.npcDecision = 1;
            }
            else if (%obj.npcDecision == 1)
            {
               %tgt = 0;
               %obj.clearaim();
            }

         //shopkeeper
         case 7:
            if (%obj.npcDecision == 0 && %this.lastClientShopped != %tgt.client)
            {
               messageClient(%tgt.client, 'MsgItemPickup', '\c1Hail!  I am %1 the Merchant.  What can I do for you?', %this.realname);
               commandToClient(%tgt.client, 'ActivateSelling', %this.realName, %this.willBuy);
               %this.lastClientShopped = %tgt.client;
               %obj.npcDecision = 1;
            }
            else if (%obj.npcDecision == 1)
            {
               %tgt = 0;
               %obj.clearaim();
            }

         case 8: // Generic message NPC
            if (%obj.npcDecision == 0)
            {
               %taggedTitle = addTaggedString(%obj.marker.msgTitle);
               %taggedMsg = addTaggedString(%obj.marker.msgText);
               commandToClient(%tgt.client, 'NPCMessage', %obj, %taggedTitle, %taggedMsg, 0, 1);
               %obj.npcDecision = 1;
            }

         default:
            //Now that the player has selected an option, have the bot go back to its marker if needed
            if ( %obj.behavior.returnToMarker )
            {
               if (%obj.path $= "")
               {
                  if (%obj.oldPath $= "")
                     %goingTo = %obj.marker.getposition();
                  else
                     %goingTo = %obj.oldPath;

                  %basedist = VectorDistSquared(%obj.getposition(), %goingTo);

                  //Make sure the bot isn't just pacing
                  if (%basedist > (%obj.maxPace * %obj.maxPace))
                  {
                     %obj.clearaim();
                     %obj.returningPos = %goingTo;
                     %obj.moveDestinationA = %goingTo;

                     %this.movementPositionFilter(%obj);
                  }
               }
               else
                  %obj.moveToNextNode();
            }
      }
   }
   //The player is too far away, so reset the bots actions to make sure it always does
   //the same thing next time the player gets near it.
   else
   {
      %this.lastClientBanked = 0;
      %this.lastClientShopped = 0;
      //Get the bot's marker's npcAction
      %marker = %obj.marker.getFieldValue(npcAction);

      //Check if the bot's marker has a npcAction value on it.
      if (%marker !$= "")
         //Set the bot's npcAction back to whatever it originally was on its marker.
         %obj.npcAction = %marker;
      //If the marker doesn't have a value, use the datablock's
      else
         %obj.npcAction = %obj.dataBlock.npcAction;

      //Check if the player was within the bots range last cycle.
      //If the player wasn't, we don't want to close the dialog boxes because
      //that may close things such as the exit game dialog.
      if (%obj.npcDecision > 0)
      {
         //Close all of our dialogs because we're now out of range of the bot.
         //Canvas.popDialog(MessageBoxYesNoDlg); // << BloodClans Script Modification
         //Canvas.popDialog(MessageBoxOKDlg);   // << BloodClans Script Modification
      }

      //Reset the bot's npcDecision value so that it can start fresh if
      //the player gets within the bot's range again.
      %obj.npcDecision = 0;
      %obj.npcEngaged = false;
   }
}

function serverCmdNPCDecision(%client, %npcID, %newVal)
{
   %npcID.npcDecision = %newVal;
}
