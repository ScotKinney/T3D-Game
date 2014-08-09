// Uncle Salty AI Script

// Talk sound profiles
datablock SFXProfile(SaltyGotAnyGems)   
{   
   filename = "art/Packs/AI/A3D_Pirate/sound/GotAnyGems";   
   description = NPCVoice3D;   
   preload = false;   
}; 

datablock SFXProfile(SaltyTakeYourTime)   
{   
   filename = "art/Packs/AI/A3D_Pirate/sound/TakeYourTime";   
   description = NPCVoice3D;   
   preload = false;   
}; 

datablock SFXProfile(SaltyBetterNotBe)   
{   
   filename = "art/Packs/AI/A3D_Pirate/sound/BetterNotBe";   
   description = NPCVoice3D;   
   preload = false;   
}; 

// Talk sequence variables
Salty.talkAnim[0] = "GotAnyGems";
Salty.talkAnim[1] = "TakeYourTime";
Salty.talkAnim[2] = "BetterNotBe";

Salty.talkSound[0] = SaltyGotAnyGems;
Salty.talkSound[1] = SaltyTakeYourTime;
Salty.talkSound[2] = SaltyBetterNotBe;

Salty.talkDuration[0] = 3000;
Salty.talkDuration[1] = 6000;
Salty.talkDuration[2] = 2000;

Salty.talkDelay[0] = 500;
Salty.talkDelay[1] = 500;
Salty.talkDelay[2] = 500;

// Control functions
function Salty::clickedByPlayer(%this, %obj, %player)
{
   if ( %obj.isTalking && (%obj.talkingTo == %player) )
      return;

   if ((%player.saltySeq $= "") || (%player.saltySeq > 1))
      %player.saltySeq = 0;
   else
      %player.saltySeq++;

   // If he's already talking, don't interupt
   if ( !%obj.isTalking )
   {
      // Look at the player we're talking to
      %obj.setAimObject(%player, $AISK_CHAR_HEIGHT);

      %obj.setActionThread(%this.talkAnim[%player.saltySeq]);
      %obj.talkAnimTimer = %obj.schedule(%this.talkDuration[%player.saltySeq], "setActionThread", "Root");
      schedule(%this.talkDelay[%player.saltySeq], 0, ServerPlay3D, %this.talkSound[%player.saltySeq], %obj.getTransform());

      %obj.isTalking = true;
      %obj.talkingTo = %player;
      %this.talkSeqTimer = %this.schedule(%this.talkDuration[%player.saltySeq] + 1000, "endTalkSequence", %obj);
   }

   if ( %player.saltySeq == 0 )
   {  // Ask if they want to sell some gems
      commandToClient(%player.client, 'QNPCMessage', %obj,
         "Do you have any Gems to sell?", 2, "Yes", "No", "");
   }
}

function Salty::handleNPCDecision(%this, %client, %npcID, %newVal)
{
   if ( %newVal == 1 )
   {  // Player wants to sell some gems
      commandToClient(%client, 'ActivateSelling', %npcID.realName, %npcID.willBuy);
   }
}

function Salty::endTalkSequence(%this, %obj)
{
   %obj.isTalking = false;
   // Turn back towart the table
   %obj.setAimObject(Cliff);
}

function Salty::customNPCAction(%this, %obj)
{
   // Salty doesn't really need to think.
   %obj.attentionlevel = 60;
}
