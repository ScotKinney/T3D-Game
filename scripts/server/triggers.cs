//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// DefaultTrigger is used by the mission editor.  This is also an example
// of trigger methods and callbacks.

function DefaultTrigger::onEnterTrigger(%this,%trigger,%obj)
{
   // This method is called whenever an object enters the %trigger
   // area, the object is passed as %obj.
}

function DefaultTrigger::onLeaveTrigger(%this,%trigger,%obj)
{
   // This method is called whenever an object leaves the %trigger
   // area, the object is passed as %obj.
}

function DefaultTrigger::onTickTrigger(%this,%trigger)
{
   // This method is called every tickPerioMS, as long as any
   // objects intersect the trigger.

   // You can iterate through the objects in the list by using these
   // methods:
   //    %trigger.getNumObjects();
   //    %trigger.getObject(n);
}

//Neutral zone
function NeutralZoneTrigger::onEnterTrigger( %this, %trigger, %obj )
{
   if(!isObject(%obj) || !isObject(%obj.client))
      return;

   if ( %obj.inNeutralZone && (%obj.nzTrigger == %trigger) )
      return;

   %obj.inNeutralZone = true;
   %obj.nzTrigger = %trigger;

   // If %obj is a mountable AI, check for riders because we won't get the
   // onEnterTrigger call for them
   if ((%obj.getClassName() $= "AIPlayer") && %obj.mountable )
   {
      %aiDB = %obj.getDatablock();
      %rider = %obj.getMountNodeObject(%aiDB.driverNode);
      if ( isObject(%rider) && isObject(%rider.client) )
      {
         %rider.inNeutralZone = true;
         %rider.nzTrigger = %trigger;
         %rider.setImageAmmo($WeaponSlot, false);
         if(%trigger.onEnterMessage !$= "")
            centerPrint(%rider.client, %trigger.onEnterMessage, 10);
      }
      if ( %aiDB.riderNode !$= "" )
      {
         %rider = %obj.getMountNodeObject(%aiDB.riderNode);
         if ( isObject(%rider) && isObject(%rider.client) )
         {
            %rider.inNeutralZone = true;
            %rider.nzTrigger = %trigger;
            %rider.setImageAmmo($WeaponSlot, false);
            if(%trigger.onEnterMessage !$= "")
               centerPrint(%rider.client, %trigger.onEnterMessage, 10);
         }
      }
   }
   else
   {
      %obj.setImageAmmo($WeaponSlot, false);
      if(%trigger.onEnterMessage !$= "")
         centerPrint(%obj.client, %trigger.onEnterMessage, 10);
   }
}

function NeutralZoneTrigger::onLeaveTrigger( %this, %trigger, %obj )
{
   if(!isObject(%obj) || !isObject(%obj.client) || (%obj.nzTrigger != %trigger))
      return;
      
   %obj.inNeutralZone = false;

   // If %obj is a mountable AI, check for riders because we won't get the
   // onLeaveTrigger call for them
   if ((%obj.getClassName() $= "AIPlayer") && %obj.mountable )
   {
      %aiDB = %obj.getDatablock();
      %rider = %obj.getMountNodeObject(%aiDB.driverNode);
      if ( isObject(%rider) && isObject(%rider.client) )
      {
         if( %rider.inNeutralZone && (%trigger.onExitMessage !$= "") )
            centerPrint(%rider.client, %trigger.onExitMessage, 10);
         %rider.inNeutralZone = false;
         %rider.setImageAmmo($WeaponSlot, true);
      }
      if ( %aiDB.riderNode !$= "" )
      {
         %rider = %obj.getMountNodeObject(%aiDB.riderNode);
         if ( isObject(%rider) && isObject(%rider.client) )
         {
            if( %rider.inNeutralZone && (%trigger.onExitMessage !$= "") )
               centerPrint(%rider.client, %trigger.onExitMessage, 10);
            %rider.inNeutralZone = false;
            %rider.setImageAmmo($WeaponSlot, true);
         }
      }
   }
   else
   {
      %obj.setImageAmmo($WeaponSlot, true);
      if(%trigger.onExitMessage !$= "")
         centerPrint(%obj.client, %trigger.onExitMessage, 10);
   }
}

// triggers for transferring players between servers.
// All of these triggers use the same datablock - serverTransferTrigger.
// The destination server, and the destination spawnpoint are specified
// on the trigger object in the world editor. This saves us from having to 
// create different trigger datablocks for different destinations
// if a manifest file and remote path are specified on the trigger, then the
// level assets will be streamed to the client before the transfer is performed

function serverTransferTrigger::onEnterTrigger(%this, %trigger, %obj)
{
   // the server transfer triggers only function when running in dedicated mode
   if(!$TAP::isDedicated)
      return;
      
   // check that the object entering the trigger is a player
   if(!isObject(%obj.client))
      return;

   // If it's a subscriber only trigger, make sure the user can pass
   if ( (%trigger.subscriberOnly $= "1") && !%obj.client.subscribe )
   {
      messageClient(%obj.client, 'LocalizedMsg', %trigger.migrantMessage, "a", true, true, 0);
      return;
   }

   // award any skull level increase, and check to
   // see if the player is allowed to use this trigger
   if(%this.checkSkullLevel(%trigger, %obj) == false)
   {
      messageClient(%obj.client, 'LocalizedMsg', "tgrLvl", "a", true, true, 1, %trigger.minSkullLevel);
      return;
   }
   
   // get the destination from the trigger
   %destination = %trigger.destinationServer;
   if(%destination $= "")
   {
      error("serverTransferTrigger: no destination");
      return;
   }

   if ( %this.clearInv $= "1" )
   {
      %obj.clearInventory();
      %obj.updateInventoryString();
   }

   TransferToServer(%obj.client, 0, %trigger.destinationSpawnSphere, %destination);
}

function serverTransferTrigger::checkSkullLevel(%this, %trigger, %obj)
{
   // give the player a skull level upgrade if appropriate
   %sl = %obj.client.skullLevel;
   if ( %trigger.skulllevel == (%sl+1) )
   {
      %sl = %trigger.skulllevel;
      %delayAward = "";
      if ( %trigger.destinationServer !$= "" )
         %delayAward = true;
      %obj.client.awardSkullLevel(%sl, %delayAward);
   }
   
   // prevent players with insufficient skull level from using this trigger
   if(%trigger.minSkullLevel !$= "")
   {
      if(%sl < %trigger.minSkullLevel)
         return false;
   }
   
   return true;
}

