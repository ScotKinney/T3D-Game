// Spell specific datablocks ---------------------------------------------------
singleton SpellData(BlindingSpell : DefaultTargetSpell)
{
	ChannelTimesMS[1] = 2000;
	Cost = 60;
   range = 50;
   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "Book_of_Blinding";
};

// Spell specific callbacks ----------------------------------------------------
function BlindingSpell::onChannelBegin(%this, %spell)
{
   // Optional: This line forces the player into an animation and 
   // roots it.
   %spell.getSource().ForceAnimation(true, "CastSpell1");
}

function BlindingSpell::onChannelEnd(%this, %spell)
{
	// Optional: This line releases the player from any forced animation
	%spell.getSource().ForceAnimation(false, "root");
}

function BlindingSpell::onCast(%this, %spell) 
{
	%src = %spell.getSource();
   %obj = %spell.getTarget();
   if (!isObject(%src) || !isObject(%target) || (%target.getState() $= "Dead"))
      return;

   // Remove the item from the casters inventory
   %src.decInventory(%this.item, 1);
	%obj.setWhiteOut(0.7);
	%obj.setWhiteOut.schedule(1500, 0);
}
