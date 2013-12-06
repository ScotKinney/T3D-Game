// SpellSpecific datablocks ----------------------------------------------------
singleton SpellData(DazeSpell : DefaultTargetSpell)
{
   Cost = 20;
   Duration = 3000;

   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "Evil_Eye_Potion";
};

function DazeSpell::onCast(%this, %spell)
{
	%src = %spell.getSource();
   %target = %spell.getTarget();
   if (!isObject(%src) || !isObject(%target) || (%target.getState() $= "Dead"))
      return;

   // Remove the item from the casters inventory
   %src.decInventory(%this.item, 1);

   // We don't have the "applySlow" function, but could create one fairly easily
   // that would work for both players and AI...
   //%spell.getTarget().applySlow(60);
   new DOTImpact() {
      TickCount = 1;
      TickMS = %this.Duration;
      
      Callback = "DazeCallback";
      sourceObject = %src;
      
      // Dynamic variables
      Target = %target;
   };
}

function DOTImpact::DazeCallback(%this, %src)
{
   // We don't have the "removeSlow" function, but could create one fairly easily
   // that would work for both players and AI...
   //%this.Target.removeSlow(60);
}