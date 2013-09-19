// raidHours.cs functions for activating the raiding hour bonuses
function startRaidHour()
{
   $Treasury::HitMin = 6;
   $Treasury::HitMax = 12;
   $Treasury::InRaidHour = true;
   schedule(600000, 0, "updateRaidTime");
}

function stopRaidHour()
{
   $Treasury::HitMin = 3;
   $Treasury::HitMax = 6;
   $Treasury::InRaidHour = false;
}

function updateRaidTime()
{
   %ltStr = getLocalTime();
   %minutes = getWord(%ltStr, 4);
   %seconds = getWord(%ltStr, 5);
   
   if ( (%minutes > 8) && (%minutes < 52) && $Treasury::InRaidHour)
   {
      %delay = (60 - %minutes) % 10;
      if ( %delay == 0 )
         %delay = 10;
      %nextCheck = (((%delay-1) * 60) + (60 - %seconds)) * 1000;
      if ( %nextCheck <= 0 )
         %nextCheck = 600000;
      schedule(%nextCheck, 0, "updateRaidTime");

      %message = (60 - %minutes) @ " minutes left in the Raid Hour.";
      messageAll('MsgItemPickup', ("\c5" @ %message));
   }
}

function checkRaidShedule()
{
   %ltStr = getLocalTime();
   %hours = getWord(%ltStr, 3);
   %minutes = getWord(%ltStr, 4);
   %seconds = getWord(%ltStr, 5);
   
   %nextCheck = (( (60 - (%minutes + 1)) * 60) + (60 - %seconds)) * 1000;
   
   if ( %nextCheck < 60000 )
   {  // Within a minute close enough
      %nextCheck += 3600000;
      %hours++;
   }

   $Treasury::RaidSched = schedule(%nextCheck, 0, "checkRaidShedule");

   %message = "";
   if ( %hours < 5 )
      %hours += 8;
   %hoursSince = ((%hours - 5) % 8);
   if ( (%hoursSince == 0) && !$Treasury::InRaidHour )
   {
      startRaidHour();
      %message = "Raid Hour is starting! For the next hour the take from all treasury hits is doubled!";
   }
   else
   {
      if ( $Treasury::InRaidHour )
      {
         stopRaidHour();
         %message = "Raid Hour is ending! ";
      }
      %message = %message @ "Next Raid Hour in " @ (8 - %hoursSince) @ " hour";
      if ( (8 - %hoursSince) > 1 )
         %message = %message @ "s.";
      else
         %message = %message @ ".";
   }
   messageAll('MsgItemPickup', ("\c5" @ %message));
}

checkRaidShedule();
