// Spell specific datablocks ---------------------------------------------------
datablock SpellData(AoEFireballData : DefaultAOESpell)
{
   ChannelTimesMS[1] = 1600;
   SpellDecalManager = DefaultSpellIndicator;
};
datablock BezierProjectileData(AoEFireballProjectile : FireballProjectile)
{
   lifetime = 1500;
};

// Spell callbacks ---------------------------------------------------------- 
function AoEFireballData::onChannelBegin(%this, %spell) 
{    
   // Change ambient out with your own spell animation    
   %spell.getSource().ForceAnimation(1,"ambient"); 
}  

function AoEFireballData::onChannelEnd(%this, %spell) 
{    
   %spell.getSource().ForceAnimation(0); 
}  

function AoEFireballData::onCast(%this, %spell) 
{    
   %aoe = new AOEImpact(){       
      SourceObject = %spell.getSource();       
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