//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

function PhysicsShapeData::damage(%this, %obj, %_dummy1, %position, %amount, %_dummy2)
{
   if(%this.invulnerable || %amount < 0 || %this.minDamageAmount != 0 && %amount < %this.minDamageAmount) {
      return;
   }
   if(%obj.isDestroyed()) {
      return;
   }
   %obj.destroy();
   if(%obj.getClientObject()) {
      %obj.getClientObject().destroy();
   }
   if(%this.damageRadius > 0) {
      if(%this.areaImpulse > 0) {
         RadialImpulseEvent::send(%position, %this.damageRadius, %this.areaImpulse);
      }
      if(%this.radiusDamage > 0) {
         radiusDamage(%obj, %position, %this.damageRadius, %this.radiusDamage, %this.damageType);
      }
   }
}

// Pass damage calls on to the objects datablock handler
function PhysicsShape::damage(%this, %sourceObject, %position, %damage, %damageType)
{
   if ( isObject(%this) )
      %this.getDataBlock().damage(%this, %sourceObject, %position, %damage, %damageType);
}
