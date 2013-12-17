// Spell specific datablocks ---------------------------------------------------
singleton SpellData(SelfImmolation : DefaultSelfSpell)
{
   ChannelTimesMS[1] = 1600;
   //SpellDecalManager = DefaultSpellIndicator;
   CastType = "Self";
   TargetType = "Object";
	Cost = 20;

   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "Self_Immolation_Kit";
};
datablock BezierProjectileData(SelfImmolationProjectile : ImmolationProjectile)
{
   lifetime = 1500;
};
// Spell callbacks ---------------------------------------------------------- 
function SelfImmolation::onChannelBegin(%this, %spell)
{
   // Optional: This line forces the player into an animation and 
   // roots it.
   %spell.getSource().ForceAnimation(true, "CastSpell1");
   %spell.baseEmitter = new SphereEmitterNode(){       
      dataBlock = DefaultEmitterNodeData;       
      emitter = Immolation;       
      position = %pos;    
   };
   %spell.baseEmitter.setBehaviorObject(0, %spell.getSource()); 
}

function SelfImmolation::onChannelEnd(%this, %spell)
{
	// Optional: This line releases the player from any forced animation
	%spell.getSource().ForceAnimation(false, "root");
	%spell.baseEmitter.schedule(3200, "delete");
}

function SelfImmolation::onCast(%this, %spell) 
{    
	%src = %spell.getSource();
	//%target = %spell.getTarget(); // Self targetting spell...
   //if (!isObject(%src) || !isObject(%target) || (%target.getState() $= "Dead"))
   if ( !isObject(%src))
      return;

   // Remove the item from the casters inventory
   %src.decInventory(%this.item, 1);

   %aoe = new AOEImpact()
   {       
      SourceObject = %src;       
      Center = %src.getPosition();       
      Radius = 15;       
      TypeMask =  $TypeMasks::PlayerObjectType;       
      CallBack = "SelfImmolationCallback";    
   };  
} 
// Impact callbacks---------------------------------------------------------- 
function AOEImpact::SelfImmolationCallback(%this, %src, %tgt) 
{    
   %projectile = SelfImmolationProjectile;    
   ThrowHomingBezierProjectile(%src,%tgt,%projectile,true,"0 0 12"); 
} 

// Projectile callbacks------------------------------------------------------ 
function SelfImmolationProjectile::onCollision(%this, %obj, %col, %fade, %pos, %norm) 
{    
   %blast = new SphereEmitterNode(){       
      dataBlock = DefaultEmitterNodeData;       
      emitter = Immolation;       
      position = %pos;    
   };
   %blast.setBehaviorObject(0, %col);
   %blast.schedule(3100, "delete"); 
   %col.mountobject(%blast, 31, "0.0 0.0 1.0"); 
   
   %damage = 300 / 6;
   if (%obj.sourceObject == %col)
      %damage = 100 / 6;
   
   %col.schedule(500, "damage", %obj.sourceObject, %pos, %damage, "Immoliation");
   %col.schedule(1000, "damage", %obj.sourceObject, %pos, %damage, "Immoliation");
   %col.schedule(1500, "damage", %obj.sourceObject, %pos, %damage, "Immoliation");
   %col.schedule(2000, "damage", %obj.sourceObject, %pos, %damage, "Immoliation");
   %col.schedule(2500, "damage", %obj.sourceObject, %pos, %damage, "Immoliation");
   %col.schedule(3000, "damage", %obj.sourceObject, %pos, %damage, "Immoliation");
} 
