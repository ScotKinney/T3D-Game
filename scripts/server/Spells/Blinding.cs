// Spell specific datablocks ---------------------------------------------------
singleton SpellData(Blinding : DefaultTargetSpell)
{
	ChannelTimesMS[1] = 2000;
	Cost = 60;
   range = 50;
   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "Book_of_Blinding";
};

// Spell specific callbacks ----------------------------------------------------
function Blinding::onChannelBegin(%this, %spell)
{
   // Optional: This line forces the player into an animation and 
   // roots it.
   %spell.getSource().ForceAnimation(true, "CastSpell1");
}

function Blinding::onChannelEnd(%this, %spell)
{
	// Optional: This line releases the player from any forced animation
	%spell.getSource().ForceAnimation(false, "root");
}

function Blinding::Reappear(%this, %obj, %newPos)
{
   if ( !isObject(%obj))
      return;
 
   %effectObj = new ParticleEffect(){
      dataBlock = APArriveEffect;
      position = %newPos;
   };
   %effectObj.schedule(3000, delete);

   %spawnPos = VectorAdd(%newPos, "0 0 300");
   %obj.position = %spawnPos;

   %obj.startFade(1000, 1000, false);
	%obj.schedule(2000, "ForceAnimation", false, "root");
}

function Blinding::onCast(%this, %spell) 
{
	%src = %spell.getSource();
	%obj = %src;// %spell.getTarget();
   //%obj = %target; // .camera();
   if (!isObject(%src) || !isObject(%obj) || %obj.getState() $= "Dead")
   {
      return;
   }
   %start = %obj.position;
   %effectObj = new ParticleEffect(){
      dataBlock = APLeaveEffect;
      position = %start;
   };
   %effectObj.schedule(3000, delete);

   %obj.startFade(1000, 250, true);
   %newPos = %this.findAppearPos(%obj, %start);
   %this.schedule(3500, "Reappear", %obj, %newPos);
   // Remove the item from the casters inventory
   %src.decInventory(%this.item, 1);
   $SB::WODec = 0.0;
	%obj.schedule(100, "setWhiteOut", 0.1);
   %obj.schedule(200, "setWhiteOut", 0.2);
   %obj.schedule(300, "setWhiteOut", 0.3);
   %obj.schedule(400, "setWhiteOut", 0.4);
   %obj.schedule(500, "setWhiteOut", 0.5);
   %obj.schedule(600, "setWhiteOut", 0.6);
   %obj.schedule(700, "setWhiteOut", 0.7);
   %obj.schedule(800, "setWhiteOut", 0.8);
   %obj.schedule(900, "setWhiteOut", 0.9);
   %obj.schedule(1000, "setWhiteOut", 1);
   %obj.schedule(4000, "setWhiteOut", 0.9);
   %obj.schedule(4100, "setWhiteOut", 0.8);
   %obj.schedule(4200, "setWhiteOut", 0.7);
   %obj.schedule(4300, "setWhiteOut", 0.6);
   %obj.schedule(4400, "setWhiteOut", 0.5);
   %obj.schedule(4500, "setWhiteOut", 0.4);
   %obj.schedule(4600, "setWhiteOut", 0.3);
   %obj.schedule(4700, "setWhiteOut", 0.2);
   %obj.schedule(4800, "setWhiteOut", 0.1);
   %obj.schedule(4900, "setWhiteOut", 0);
}

function Blinding::findAppearPos(%this, %obj, %start)
{
   %rotation = %obj.getForwardVector();
   %targetLoc = VectorAdd(%start, VectorScale(%rotation, 90));
   %above = VectorAdd(%targetLoc, "0 0 50");
   %below = VectorSub(%targetLoc, "0 0 20");

   %result = containerRayCast(%above, %below, $TypeMasks::ShapeBaseObjectType |
                                             $TypeMasks::StaticShapeObjectType |
                                             $TypeMasks::TerrainObjectType);

   if ( isObject(getWord(%result, 0)) )
      %targetLoc = getWord(%result, 1) SPC getWord(%result, 2) SPC getWord(%result, 3);

   return %targetLoc;
}