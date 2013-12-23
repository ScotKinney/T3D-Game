// Spell specific datablocks ---------------------------------------------------
singleton SpellData(Duplication : DefaultTargetSpell)
{
	ChannelTimesMS[1] = 500;
	Cost = 60;
   range = 50;
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
	//Declare what the AI is here
	
	//---------------------------
	%obj = %spell.getTarget();
   if (!isObject(%src) || !isObject(%obj) || %obj.getState() $= "Dead")
   {
      return;
   }
   %start = %src.position;
   %effectObj = new ParticleEffect(){
      dataBlock = APLeaveEffect;
      position = %start;
   };
   %effectObj.schedule(3000, delete);
   // Remove the item from the casters inventory
   // %src.decInventory(%this.item, 1);	
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