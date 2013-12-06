// Spell specific datablocks ---------------------------------------------------
singleton SpellData(AoEFireballSpell : DefaultAOESpell)
{
   ChannelTimesMS[1] = 1600;
   SpellDecalManager = DefaultSpellIndicator;
	Cost = 20;

   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "Ring_of_Fire_Rune";
};
datablock BezierProjectileData(AoEFireballProjectile : FireballProjectile)
{
   lifetime = 1500;
};

// Spell callbacks ---------------------------------------------------------- 
function AoEFireballSpell::onChannelBegin(%this, %spell) 
{    
   // Change ambient out with your own spell animation    
   %spell.getSource().ForceAnimation(1,"ambient"); 
}  

function AoEFireballSpell::onChannelEnd(%this, %spell) 
{    
   %spell.getSource().ForceAnimation(0); 
}  

function AoEFireballSpell::onCast(%this, %spell) 
{    
	%src = %spell.getSource();
   if ( !isObject(%src))
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

// Impact callbacks---------------------------------------------------------- 
function AOEImpact::AOEFireballCallback(%this, %src, %tgt) 
{    
   %projectile = AoEFireballProjectile;    
   ThrowHomingBezierProjectile(%src,%tgt,%projectile,true,"0 0 12"); 
} 

// Projectile callbacks------------------------------------------------------ 
function AoEFireballProjectile::onCollision( %this, %obj, %col,                                              
                                             %fade, %pos, %norm) 
{    
   %blast = new SphereEmitterNode(){       
      dataBlock = DefaultEmitterNodeData;       
      emitter = FireballBlastEmitter;       
      position = %pos;    
   };    
   %blast.schedule(500, "delete"); 
} 