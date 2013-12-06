// SpellSpecific datablocks ----------------------------------------------------
singleton SpellData(FlashHealSpell : DefaultTargetSpell)
{
   Cost = 20;
   
   HealAmount = 50; // 50% of full health get's added

   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "Leaf_Me_Alone_Potion";
};

function FlashHealSpell::onCast(%this, %spell)
{
	%src = %spell.getSource();
   %target = %spell.getTarget();
   if (!isObject(%src) || !isObject(%target) || (%target.getState() $= "Dead"))
      return;

   // Remove the item from the casters inventory
   %src.decInventory(%this.item, 1);

   // adjust heal amount based on percentage of max damage
   %addedHealth = %this.HealAmount;
   %maxDamage = %target.getDataBlock().maxDamage;
   %health = mCeil((1 - %target.getDamagePercent()) * 100);
   %damagePercent = 100 - %health;
   if(%addedHealth > %damagePercent)
      %addedHealth = %damagePercent;

   %adjustedHealth = (%addedHealth / 100) * %maxDamage;
   %target.applyRepair(%adjustedHealth);
}
