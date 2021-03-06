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
   lifetime = 2000;
};
// Spell callbacks ---------------------------------------------------------- 
function SelfImmolation::onChannelBegin(%this, %spell)
{
   // Optional: This line forces the player into an animation and 
   // roots it.
   %spell.getSource().ForceAnimation(true, "Kneel_R");
   %crush = new ParticleEmitterNode(){       
      dataBlock = DefaultEmitterNodeData;       
      emitter = CrushEmitter;       
      position = %pos;    
   };
   %crush.setBehaviorObject(0, %spell.getSource());
   %src = %spell.getSource();
   %src.mountobject(%crush, 2, "0.0 0.0 0.0");
   %crush.schedule(1500, "delete");
   %spell.baseEmitter = new ParticleEmitterNode(){       
      dataBlock = DefaultEmitterNodeData;       
      emitter = EmberEmitter;       
      position = %pos;    
   };
   %spell.baseEmitter.setBehaviorObject(0, %spell.getSource()); 
}

function SelfImmolation::onChannelEnd(%this, %spell)
{
	// Optional: This line releases the player from any forced animation
	%spell.getSource().ForceAnimation(false, "root");
	%spell.baseEmitter.schedule(5200, "delete");
}

function SelfImmolation::onCast(%this, %spell) 
{    
	%src = %spell.getSource();
	//%target = %spell.getTarget(); // Self targetting spell...
   //if (!isObject(%src) || !isObject(%target) || (%target.getState() $= "Dead"))
   if ( !isObject(%src))
      return;
   
   // Remove the item from the casters inventory
   %lampOil = %src.getInventory(Lamp_Oil);
   if ( %lampOil < 1 )
   {  // Not enough oil to burn again, so turn off the light and don't reschedule
      messageClient(%src.client, 'LocalizedMsg', "", "noOilImm", "a", false, true, 0);
      return;
   }
   %src.decInventory(Lamp_Oil, 1);
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
   %blast = new ParticleEmitterNode(){       
      dataBlock = DefaultEmitterNodeData;       
      emitter = ImmolationEmitter;       
      position = %pos;    
   };
   %blast.setBehaviorObject(0, %col);
   %blast.schedule(5100, "delete"); 
   %col.mountobject(%blast, 31, "0.0 0.0 1.0"); 
   %count = 0;
   %damage = getRandom(30, 50);
   %col.schedule(100, "damage", %obj.sourceObject, %pos, %damage, "Immoliation");
   while(%count <= 5)
   {
      %damage = getRandom(150, 250);
      %damage = %damage / 5;
      if (%obj.sourceObject == %col)
      {
         %damage = (%damage * 0.75) / 5;
      }
      %col.schedule(%count * 1000, "damage", %obj.sourceObject, %pos, %damage, "Immoliation");
      %count++;
   }
} 
