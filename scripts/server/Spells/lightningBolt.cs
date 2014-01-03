// Spell specific datablocks ---------------------------------------------------
singleton SpellData(LightningBolt : DefaultTargetSpell)
{
	ChannelTimesMS[1] = 2000;
	Cost = 20;
   range = 50;

   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "WizardsStaff";
};

// Spell specific callbacks ----------------------------------------------------
function LightningBolt::onChannelBegin(%this, %spell, %src)
{
   // Optional: This line forces the player into an animation and 
   // roots it.
   %spell.getSource().ForceAnimation(true, "CastSpell1");
   %src = %spell.getsource();
   %pos = %src.position;
   %spell.baseEmitter = new SphereEmitterNode(){       
      dataBlock = DefaultEmitterNodeData;       
      emitter = LightningBall;       
      position = %pos;    
   };
   %spell.baseEmitter.setBehaviorObject(0, %spell.getSource());
   %src.mountobject(%spell.baseEmitter, 0, "0.0 0.0 0.0");
}

function LightningBolt::onChannelEnd(%this, %spell)
{
	// Optional: This line releases the player from any forced animation
	%spell.getSource().ForceAnimation(false, "root");
	%spell.baseEmitter.delete();
}

function LightningBolt::onCast(%this, %spell, %src, %pos) 
{
	%target = %spell.getTarget();
   if (!isObject(%src) || !isObject(%target) || (%target.getState() $= "Dead"))
      return;

   // Remove the item from the casters inventory
   // %src.decInventory(%this.item, 1);

	%projectile = LightningProjectile;
	//ThrowHomingProjectile(%src, %tgt, %projectile);

   // Randomize the bezier curve weights...just for kicks
   %weights = GetRandomVector(0, 0, 0, 0, 0, 0);
	ThrowHomingBezierProjectile(%src, %target, %projectile, true, %weights);
}

// Projectile callbacks------------------------------------------------------ 
function LightningProjectile::onCollision(%this, %obj, %col) 
{  
   %pos = %col.position;  
   %blast = new SphereEmitterNode(){       
      dataBlock = DefaultEmitterNodeData;       
      emitter = LightningBuzz;       
      position = %pos;    
   };
   %blast.setBehaviorObject(0, %col);
   %blast.schedule(3000, "delete"); 
   %col.mountobject(%blast, 31, "0.0 0.0 1.0"); 
   %count = 0;
   %col.schedule(100, "damage", %obj.sourceObject, %pos, getRandom(30, 50), "Immoliation");
   while(%count <= 3)
   {
      %damage = getRandom(30, 100) / 3;
      if (%obj.sourceObject == %col)
         %damage = (%damage * 0.75) / 3;
         
      %col.schedule(%count * 1000, "damage", %obj.sourceObject, %pos, %damage, "Immoliation");
      %count++;
   }
} 