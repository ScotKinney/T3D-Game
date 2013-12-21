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

function Blinding::onCast(%this, %spell) 
{
	%src = %spell.getSource();
   %obj = %src.camera; //%spell.getTarget();
   /*
   if (!isObject(%src) || !isObject(%obj) || %obj.getState() $= "Dead")
   {
      return;
   }
   */
   if ( !isObject(%src))
      return;
   //
   // Remove the item from the casters inventory
   %src.decInventory(%this.item, 1);
	%obj.schedule(100, "setWhiteOut", 0.1);
   %obj.schedule(200, "setWhiteOut", 0.2);
   %obj.schedule(300, "setWhiteOut", 0.3);
   %obj.schedule(400, "setWhiteOut", 0.4);
   %obj.schedule(500, "setWhiteOut", 0.5);
   %obj.schedule(600, "setWhiteOut", 0.6);
   %obj.schedule(700, "setWhiteOut", 0.7);
   %obj.schedule(800, "setWhiteOut", 0.8);
   %obj.schedule(2800, "setWhiteOut", 0.7);
   %obj.schedule(2900, "setWhiteOut", 0.6);
   %obj.schedule(3000, "setWhiteOut", 0.5);
   %obj.schedule(3100, "setWhiteOut", 0.4);
   %obj.schedule(3200, "setWhiteOut", 0.3);
   %obj.schedule(3300, "setWhiteOut", 0.2);
   %obj.schedule(3400, "setWhiteOut", 0.1);
   %obj.schedule(3500, "setWhiteOut", 0);
}
