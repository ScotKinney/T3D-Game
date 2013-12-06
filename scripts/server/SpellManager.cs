
function serverCmdsetSpellTarget(%client, %objID)
{
   // prevent bogging down the server with multiple rapid clicks
   if(%client.canClick())
      %client.clickLock();
   else
      return;

   %client.ssTarget = 0;   
   // the client sends us their ghostID for the object, so we need to convert
   // this to the server-side index for that object
   %obj = %client.resolveObjectFromGhostIndex(%objID);

   // check it exists   
   if ( !isObject(%obj) )
      return;
   
   // and we must have a player
   if(!isObject(%client.player))
      return;
      
   // and the player must be alive
   if(%client.player.getState() $= "Dead")
      return;
      
   // Set the target
   %client.ssTarget = %obj;
}

function ShapeBase::castSpell(%this, %spellItem)
{
   if ( !isObject(%spellItem.spellDef) )
      return;

   if ((%spellItem.spellTarget $= "Enemy") || (%spellItem.spellTarget $= "Friend"))
   {
      if ( !isObject(%this.client.ssTarget) )
      {
         centerPrint(%this.Client, "NoTgt", 1, 1);
         return;
      }
      %this.client.ipsSpellManager.beginTargetCast(%spellItem.spellDef, %this.client,
         %this.client.ssTarget);
   }
   else
      %this.client.ipsSpellManager.beginCast(%spellItem.spellDef, %this.client);

   // Clear the target so we can't keep hitting them
   %this.client.ssTarget = -1;
}

function GetRandomVector(%xfrom, %xto, %yfrom, %yto, %zfrom, %zto)
{
   %randx = (getRandom() * (%xto - %xfrom)) + %xfrom;
   %randy = (getRandom() * (%yto - %yfrom)) + %yfrom;
   %randz = (getRandom() * (%zto - %zfrom)) + %zfrom;
   return %randx SPC %randy SPC %randz;
}

function GetPointWithinArea(%center, %radius, %offset)
{
   %rand = getRandom() * m2Pi();
   %relx = mCos(%rand) * %radius;
   %rely = mSin(%rand) * %radius;
   %pos = VectorAdd(%center, %relx SPC %rely SPC "0");
   %pos = VectorAdd(%pos, %offset);
   return %pos;
}
function SpellManager::onOOM(%this, %spell)
{
   centerPrint(%this.Client, "Out of mana", 1, 1);
}

function SpellManager::onOutOfRange(%this, %spell)
{
   centerPrint(%this.Client, "Out of range", 1, 1);
}

function SpellManager::onNoTarget(%this, %spell)
{
   centerPrint(%this.Client, "No target selected", 1, 1);
}

function SpellManager::onCooldown(%this, %spell)
{
   centerPrint(%this.Client, "That spell is on cooldown", 1, 1);
}

function SpellManager::onTargetNotFound(%this, %spell)
{
   centerPrint(%this.Client, "NoTgt", 1, 1);
}

function SpellManager::onAlreadyCastingSpell(%this, %spell)
{
   centerPrint(%this.Client, "Already casting a spell", 1, 1);
}

function SpellManager::onTechnicalError(%this, %spell)
{
   centerPrint(%this.Client, "Technical error occured", 1, 1);
}