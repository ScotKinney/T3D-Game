// SpellSpecific datablocks ----------------------------------------------------
singleton SpellData(FrostBarrageSpell : DefaultTargetSpell)
{
   Cost = 20;
   range = 50;
   
   Radius = 3;

   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "Shards_of_Ice_Crystal";
};

function FrostBarrageSpell::onChannel(%this, %spell)
{
}

function FrostBarrageSpell::onCast(%this, %spell)
{
	%src = %spell.getSource();
   %target = %spell.getTarget();
   if (!isObject(%src) || !isObject(%target) || (%target.getState() $= "Dead"))
      return;

   // Remove the item from the casters inventory
   %src.decInventory(%this.item, 1);

   %spell.dotObj = new DOTImpact(){
      TickMS = 100;
      TickCount = 15;
      
      CallBack = "FrostBarrageCB";
      sourceObject = %src;
      
      // Dynamic variables
      Target = %target;
   };
}

function DOTImpact::FrostBarrageCB(%this, %src)
{
   %weights = GetRandomVector(-3, 3, -3, 3, 1, 6);
   ThrowHomingBezierProjectile(%src, %this.Target, FrostShardProjectile, true, %weights);
}
