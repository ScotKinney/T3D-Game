// Spell specific datablocks ---------------------------------------------------
singleton SpellData(FireballSpell : DefaultTargetSpell)
{
	ChannelTimesMS[1] = 2000;
	Cost = 20;
   range = 50;

   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "BBQ_Ribs_Potion";
};

// Spell specific callbacks ----------------------------------------------------
function FireballSpell::onChannelBegin(%this, %spell)
{
   // Optional: This line forces the player into an animation and 
   // roots it.
   %spell.getSource().ForceAnimation(true, "CastSpell1");
   %spell.baseEmitter = new GraphEmitterNode()
   {
      dataBlock = g_defaultNode;
      emitter = FireballChannelEmitterBASE;
      ParticleBehaviour[0] = ChannelAttraction;
      standAloneEmitter = true;
      position = %spell.getSource().position;
      Grounded = true;
   };
   %spell.baseEmitter.setBehaviorObject(0, %spell.getSource());
}

function FireballSpell::onChannelEnd(%this, %spell)
{
	// Optional: This line releases the player from any forced animation
	%spell.getSource().ForceAnimation(false, "root");
	%spell.baseEmitter.delete();
}

function FireballSpell::onCast(%this, %spell) 
{
	%src = %spell.getSource();
   %target = %spell.getTarget();
   if (!isObject(%src) || !isObject(%target) || (%target.getState() $= "Dead"))
      return;

   // Remove the item from the casters inventory
   %src.decInventory(%this.item, 1);

	%projectile = FireballProjectile;
	//ThrowHomingProjectile(%src, %tgt, %projectile);

   // Randomize the bezier curve weights...just for kicks
   %weights = GetRandomVector(-10, 10, 0, 0, 3, 12);
	ThrowHomingBezierProjectile(%src, %target, %projectile, true, %weights);
}
