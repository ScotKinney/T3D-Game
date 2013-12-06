// SpellSpecific datablocks ----------------------------------------------------
datablock SpellData(ManaInfusionSpell : DefaultTargetSpell)
{
   Cost = 20;
   RateBoost = 10;
   BoostTime = 5;

   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "InsectInside_Potion";
};

function ManaInfusionSpell::onCast(%this, %spell)
{
	%src = %spell.getSource();
   %target = %spell.getTarget();
   if (!isObject(%src) || !isObject(%target) || (%target.getState() $= "Dead"))
      return;

   // Remove the item from the casters inventory
   %src.decInventory(%this.item, 1);

   %target.setRechargeRate(%target.getRechargeRate() + %this.RateBoost);
   %this.schedule((%this.BoostTime * 1000), "ManaInfusionEnd", %target);
}

function ManaInfusionSpell::ManaInfusionEnd(%this, %target)
{
   if ( !isObject(%target) )
      return;
   %target.setRechargeRate(%target.getRechargeRate() - %this.RateBoost);
}