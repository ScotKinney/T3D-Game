// SpellSpecific datablocks ----------------------------------------------------
singleton SpellData(AstralPassport : DefaultSelfSpell)
{
   Cost = 20;

   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "Astral_Passport";
};

function AstralPassport::onCast(%this, %spell)
{
	%src = %spell.getSource();
   if ( !isObject(%src))
      return;

   // Remove the item from the casters inventory
   //%src.decInventory(%this.item, 1);

   %src.ForceAnimation(true, "ap", true);

   %start = %src.position;
   %effectObj = new ParticleEffect(){
      dataBlock = APLeaveEffect;
      position = %start;
   };
   %effectObj.schedule(3000, delete);

   %src.startFade(1000, 250, true);
   %newPos = %this.findAppearPos(%src, %start);
   %this.schedule(3000, "Reappear", %src, %newPos);
}

function AstralPassport::Reappear(%this, %src, %newPos)
{
   if ( !isObject(%src))
      return;
 
   %effectObj = new ParticleEffect(){
      dataBlock = APArriveEffect;
      position = %newPos;
   };
   %effectObj.schedule(3000, delete);

   %spawnPos = VectorAdd(%newPos, "0 0 1");
   %src.position = %spawnPos;

   %src.startFade(1000, 1000, false);
	%src.schedule(2000, "ForceAnimation", false, "root");
}

function AstralPassport::findAppearPos(%this, %src, %start)
{
   %rotation = %src.getForwardVector();
   %targetLoc = VectorAdd(%start, VectorScale(%rotation, 10));
   %above = VectorAdd(%targetLoc, "0 0 50");
   %below = VectorSub(%targetLoc, "0 0 20");

   %result = containerRayCast(%above, %below, $TypeMasks::ShapeBaseObjectType |
                                             $TypeMasks::StaticShapeObjectType |
                                             $TypeMasks::TerrainObjectType);

   if ( isObject(getWord(%result, 0)) )
      %targetLoc = getWord(%result, 1) SPC getWord(%result, 2) SPC getWord(%result, 3);

   return %targetLoc;
}
