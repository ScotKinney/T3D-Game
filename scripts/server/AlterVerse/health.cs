/*
   health.cs
   functions dealing with the players health
   
   Guy Allard 2010
*/

// start a schedule that will decrease the health
function GameConnection::scheduleHealthDecrease(%client)
{
   %client.healthDecreaseSchedule = %client.schedule($AlterVerse::PlayerHealthDecreaseTime, 
                                                     onHealthDecreaseSchedule, 
                                                     $AlterVerse::PlayerHealthDecreaseAmount);
}

// cancel the schedule that decreases the health
function GameConnection::stopHealthDecrease(%client)
{
   if(isEventPending(%client.healthDecreaseSchedule))
      cancel(%client.healthDecreaseSchedule);
}

// the part that actually does the decrease
function GameConnection::onHealthDecreaseSchedule(%client, %amount)
{
   %client.player.damage(0, "0 0 0", %amount, "Hunger");
   %client.scheduleHealthDecrease();
}

// let the client know if their health is getting low
function GameConnection::healthWarning(%client, %obj)
{
   %damageLevel = %obj.getDamagePercent();

   // don't message if our health is actually increasing!   
   if(%damageLevel <= %obj.lastDamage)
      return;
      
   if(%damageLevel >= $AlterVerse::DangerousLowHealthThreshold && 
      %damageLevel < 100 &&
      %obj.lastDamage < $AlterVerse::DangerousLowHealthThreshold )
   {
      messageClient(%client, 'msgDangerousLowHealth', $AlterVerse::DangerousLowHealthMessage);
   }
   else if (%damageLevel >= $AlterVerse::LowHealthThreshold && %obj.lastDamage < $AlterVerse::LowHealthThreshold)
      messageClient(%client, 'msgLowHealth', $AlterVerse::LowHealthMessage);
}

// readHealthLevel reads the players current health level and puts it
// in their pData, returning the healthLevel
function GameConnection::readHealthLevel(%client)
{
   %healthLevel = %client.retrievePersistantStat("health");
   return %healthLevel;
}

// writeHealthLevel stores the healthLevel in the database and also
// updates the clients pData
function GameConnection::writeHealthLevel(%client, %healthLevel)
{
   %client.storePersistantStat("health", %healthLevel);
}

// setHealthLevel stores the health value in the clients pData
// and updates the client health GUI. The value is NOT entered
// into the database at this time
function GameConnection::setHealthLevel(%client, %healthLevel)
{
   %client.setPersistantStat("health", %healthLevel);
}
