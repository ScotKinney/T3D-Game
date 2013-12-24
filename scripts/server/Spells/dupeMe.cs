// Spell specific datablocks ---------------------------------------------------
singleton SpellData(Duplication : DefaultTargetSpell)
{
	ChannelTimesMS[1] = 500;
	Cost = 60;
   range = 50;
   
   // Length of time the clone will stay around, if not killed, in MS.
   cloneLifetimeMS = 120000;

   // The weapon(s) to equip the clone with if the caster has no weapons equiped
   cloneDefaultWeapon = "RightHand LeftHand RightFoot LeftFoot";

   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "Split_Personality_Potion";
};

// Spell specific callbacks ----------------------------------------------------
function Duplication::onChannelBegin(%this, %spell)
{
   // Optional: This line forces the player into an animation and 
   // roots it.
   %spell.getSource().ForceAnimation(false, "CastSpell1");
}

function Duplication::onChannelEnd(%this, %spell)
{
	// Optional: This line releases the player from any forced animation
	%spell.getSource().ForceAnimation(false, "root");
}

function Duplication::Reappear(%this, %obj, %posTgt, %newPos)
{
   if (!isObject(%posTgt))
      return;
   %rndX = getRandom(-30, 30);
   %rndY = getRandom(-30, 30);
   %vector = %rndX SPC %rndY SPC "0";
   %rndRot = getRandom(4, 15);
   %trgPos = %obj.position;
   %newPos = %this.findAppearPos(%obj, %vector, %rndRot, %trgPos);
   %effectObj = new ParticleEffect(){
      dataBlock = APArriveEffect;
      position = %newPos;
   };
   %effectObj.schedule(3000, delete);
   %posTgt.position = %newPos;
   %posTgt.startFade(1000, 1000, false);
	%posTgt.schedule(2000, "ForceAnimation", false, "root");
}

function Duplication::onCast(%this, %spell) 
{
	%src = %spell.getSource();
	%obj = %spell.getTarget();
   if (!isObject(%src) || !isObject(%obj) || %obj.getState() $= "Dead")
   {
      return;
   }

	//Declare what the AI is here
	%copy = %this.spawnClone(%src);
	
	// Make sure it attacks the right target
	%copy.targetEngaged = %obj;
	//---------------------------

   %start = %src.position;
   %effectObj = new ParticleEffect(){
      dataBlock = APLeaveEffect;
      position = %start;
   };
   %effectObj.schedule(3000, delete);
   %src.startFade(1000, 250, true);
   %src.ForceAnimation(true, "tp", true);
   // Remove the item from the casters inventory
   // %src.decInventory(%this.item, 1);
   %posPlayer = %start;
   %posAI = %start;
   %this.schedule(3200, "Reappear", %obj, %src, %posPlayer);
   %this.schedule(3250, "Reappear", %obj, %copy, %posAI);
}

function Duplication::findAppearPos(%this, %target, %vector, %rndRot, %start)
{
   %rotation = %target.getForwardVector();
   %targetLoc = VectorAdd(%start, VectorScale(%rotation, %rndRot));
   %above = VectorAdd(%targetLoc, VectorAdd(%vector, "0 0 50"));
   %below = VectorSub(%targetLoc, VectorAdd(%vector, "0 0 20"));

   %result = containerRayCast(%above, %below, $TypeMasks::ShapeBaseObjectType |
                                             $TypeMasks::StaticShapeObjectType |
                                             $TypeMasks::TerrainObjectType);

   if ( isObject(getWord(%result, 0)) )
      %targetLoc = getWord(%result, 1) SPC getWord(%result, 2) SPC getWord(%result, 3);

   return %targetLoc;
}

function Duplication::spawnClone(%this, %spellSource)
{  // Create a marker for the clone so the AI scripts can process it

   // Create the weapon string we'll use to equip the bot
   %weaponStr = "";
   %primaryWeapon = "";
   for ( %i = 0; %i < 4; %i++ )
   {
      %curWeapon = %spellSource.getMountedImage(%i);
      if ( isObject(%curWeapon) )
      {
         %weaponName = %curWeapon.getName();
         %cleanName = getSubStr(%weaponName, 0, strstr(%weaponName, "Image"));
         %weaponStr = %weaponStr @ ((%i > 0) ? (" " @ %cleanName) : %cleanName);
         if ( %i == 0 )
            %primaryWeapon = %curWeapon;
      }
      else
         break;
   }

   // If the caster has no weapon equiped, give the clone the default weapon
   if ( %weaponStr $= "" )
      %weaponStr = %this.cloneDefaultWeapon;

   if ( !isObject(%primaryWeapon) )
      %primaryWeapon = getWord(%weaponStr, 0) @ "Image";

   %weapMax = %primaryWeapon.maxRange;
   %weapMin = %primaryWeapon.minRange;
   %weapMove = %primaryWeapon.moveTolerance;

   %botMarker = new StaticShape() {
      dataBlock = "AIPlayerMarker";
      position = "0 0 0";
      rotation = "0 0 1 0";
      scale = %spellSource.getScale();
      hidden = "1";
      canSave = "0";
      canSaveDynamicFields = "0";
         block = %spellSource.getDatablock();
         distDetect = "200";
         behavior = "TeammateBehavior";
         fov = "270";
         maxRange = %weapMax;
         minRange = %weapMin;
         moveTolerance = %weapMove;
         respawn = "0";
         respawnCount = "0";
         respawnCounter = "0";
         Weapon = %weaponStr;
         avOptions = %spellSource.client.avOptions;
         team = %spellSource.team;
   };
   MissionCleanup.add(%botMarker);
   %botMarker.sethidden(0);
   %botMarker.sethidden(1);

   // Create the clone and hide it
   %clone = AIPlayer::spawn(%botMarker);
   %clone.startFade(0, 0, true);
   %clone.ForceAnimation(true, "tp", true);
   
   // Set name and clan to match the casters
   %clone.setshapename(%spellSource.getShapeName());
   %clone.setClanName(%spellSource.getClanName());

   // Schedule an event to kill the clone and cleanup
   %this.schedule(%this.cloneLifetimeMS, "killClone", %spellSource, %botMarker, %clone);

   return %clone;
}

function Duplication::killClone(%this, %caster, %botMarker, %clone)
{  // Remove the clone and its marker
   if ( isObject(%clone) )
   {  // It's still alive
      if ( isEventPending(%clone.ailoop) )
         cancel(%clone.ailoop);

      %clone.isInvincible = true;  // don't take damage during fade
      %clone.behavior.isKillable = false;
      %clone.startFade(1000, 0, true);
      %clone.schedule(1000, "delete");
   }

   %botMarker.schedule(1000, "delete");
}
