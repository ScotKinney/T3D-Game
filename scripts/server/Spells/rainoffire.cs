// SpellSpecific datablocks ----------------------------------------------------
singleton SpellData(RainOfFireSpell : DefaultAOESpell)
{
   Cost = 20;
   range = 50;
   
   Radius = 3;

   // Every spell needs a link to it's inventory item.
   // For now this just links to the item it replaces from the old game.
   item = "Human_Torch_Potion";
};

function RainOfFireSpell::onCast(%this, %spell)
{
	%src = %spell.getSource();
   if ( !isObject(%src) )
      return;

   // Remove the item from the casters inventory
   %src.decInventory(%this.item, 1);

   %dotimpact = new DOTImpact(){
      SourceObject = %src;       
      TickMS = 500;
      TickCount = 10;
      
      CallBack = "RainOfFireCB";
      
      // Dynamic variables
      TargetPos = %spell.getTargetPosition();
      Radius = %this.Radius;
   };
   %dotimpact.schedule(6000, "delete");
}

function DOTImpact::RainOfFireCB(%this, %src)
{
   %point1 = GetPointWithinArea(%this.TargetPos, %this.Radius, "0 0 7");
   %point2 = GetPointWithinArea(%this.TargetPos, %this.Radius, "0 0 7");
   
   %end = VectorSub(%point2, "0 0 20");
   %searchResult = containerRayCast(%point2, %end, $TypeMasks::TerrainObjectType
         | $TypeMasks::StaticObjectType);
   
   if(!%searchResult)
      return;
   
   %end = getWords( %searchResult, 1, 3 );
   
   %vel = VectorSub(%end, %point1);
   %nvel = VectorNormalize(%vel);
   %vel = VectorScale(%nvel, 3);
   
   %bullet = new BezierProjectile(){
      initialPosition = %point1;
      initialVelocity = %vel;
      Homing = true;
      dataBlock = RainOfFireComet;
      TargetPosition = %end;
      BezierWeights = "0 0 0";
      sourceObject = %src;
      sourceSlot = 0;
      client = %src.client;
   };
   MissionCleanup.add(%bullet);
}
