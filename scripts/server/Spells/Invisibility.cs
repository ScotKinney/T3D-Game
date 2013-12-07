// SpellSpecific datablocks ----------------------------------------------------
singleton SpellData(InvisibilitySpell : DefaultSelfSpell)
{
   Cost = 20;
   InvisibleTime = 60; // Length of time the player remains invisible (in seconds)

   // Every spell needs a link to it's inventory item.
   item = "Invisibility_Rune";
};

function InvisibilitySpell::onCast(%this, %spell)
{
	%src = %spell.getSource();
   if ( !isObject(%src))
      return;

   // Remove the item from the casters inventory
   %src.decInventory(%this.item, 1);

   // Fade out the caster
   %src.startFade(1000, 0, true);

   // Schedule the reappearance
   %this.schedule((%this.InvisibleTime * 1000), "InvisibilityEnd", %src);
}

function InvisibilitySpell::InvisibilityEnd(%this, %src)
{
   if ( !isObject(%src) )
      return;
   %src.startFade(1000, 0, false);
}
