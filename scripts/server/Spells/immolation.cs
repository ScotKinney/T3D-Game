// Spell specific datablocks ---------------------------------------------------
singleton SpellData(SelfImmolation : DefaultAOESpell)
{
   ChannelTimesMS[1] = 1600;
   SpellDecalManager = DefaultSpellIndicator;
   CastType = "Self";
   TargetType = "Object";
	Cost = 20;

   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "Self_Immolation_Kit";
};

// Spell callbacks ---------------------------------------------------------- 
function SelfImmolationSpell::onChannelBegin(%this, %spell)
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

function SelfImmolationSpell::onChannelEnd(%this, %spell)
{
	// Optional: This line releases the player from any forced animation
	%spell.getSource().ForceAnimation(false, "root");
	%spell.baseEmitter.delete();
}

function SelfImmolationSpell::onCast(%this, %spell) 
{    
	%src = %spell.getSource();
	%target = %spell.getTarget();
   if (!isObject(%src) || !isObject(%target) || (%target.getState() $= "Dead"))
      return;

   // Remove the item from the casters inventory
   %src.decInventory(%this.item, 1);

   %aoe = new AOEImpact(){       
      SourceObject = %src;       
      Center = %spell.getTargetPosition();       
      Radius = 5;       
      TypeMask =  $TypeMasks::StaticShapeObjectType |                    
                  $TypeMasks::StaticTSObjectType;       
      CallBack = "AOEFireballCallback";    
   }; 
} 

// Projectile callbacks------------------------------------------------------ 
function AoEFireballProjectile::onCollision(%this, %obj, %col, %fade, %pos, %norm) 
{    
   %blast = new GraphEmitterNode()
   {
      dataBlock = g_defaultNode;
      emitter = FireballChannelEmitterBASE;
      ParticleBehaviour[0] = ChannelAttraction;
      standAloneEmitter = true;
      position = %spell.getSource().position;
      Grounded = true;
   }; 
   %blast.schedule(1500, "delete"); 
} 