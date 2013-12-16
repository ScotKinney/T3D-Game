//Bloodclans Lantern

function Lantern::onUse(%this, %user)
{
   if(!isObject(%user.client))
   {
      return false;
   }

   // Toggle the lantern state.
   /*
   if( isObject(%user.light) )
   {  // It's already on, so turn it off
      messageClient(%user.client, 'MsgItemPickup', '\c0You turned off the Lantern.' );
      %user.light.delete();
      %user.unmountEquipment("mount2");
      %user.updateMountedEquipment();
      if ( isEventPending(%user.burnSchedule) )
         cancel(%user.burnSchedule);
   }
   else
      %this.FlashlightEnable(%user);
   */
   %this.Toggle(%user);
   return true;   // This preventd the "You cannot use..." message
}

function Lantern::Toggle(%this, %user)
{
   // Toggle the lantern state.
   if( isObject(%user.light) )
   {  // It's already on, so turn it off
      messageClient(%user.client, 'MsgItemPickup', '\c0You turned off the Lantern.' );
      %user.light.delete();
      %user.unmountEquipment("mount2");
      %user.updateMountedEquipment();
      if ( isEventPending(%user.burnSchedule) )
         cancel(%user.burnSchedule);
   }
   else
      %this.FlashlightEnable(%user);
      
   %this.deathLoop(%user);
}

function Lantern::onThrow(%this, %user, %amount)
{  // If the lantern is in use, turn off and remove from hand before dropping
   if( isObject(%user.light) )
   {
      %user.light.delete();
      %user.unmountEquipment("mount2");
      %user.updateMountedEquipment();
      if ( isEventPending(%user.burnSchedule) )
         cancel(%user.burnSchedule);
   }
   
   // Now go ahead with drop as normal
   return ItemData::onThrow(%this, %user, %amount);
}
//----------------------------------------------------------------------------  
// Enable/Disable Player light  
//----------------------------------------------------------------------------  
function Lantern::FlashlightEnable(%this, %player)  
{  
   %lamp = %player.getInventory(Lantern);
   if ( %lamp == 0 )
   { 
      messageClient(%player.client, 'MsgItemPickup', '\c0You don\'t have a Lantern.' );
      return true;
   }
   else
   {
      %lampOil = %player.getInventory(Lamp_Oil);
      
      if ( %lampOil == 0 )
      {
         messageClient(%player.client, 'MsgItemPickup', '\c0You need oil to burn in the Lantern.');
         return true;
      }
      else
      {         
         // lamp light  
         %light = new PointLight() // In here you can add the example datablock values for more control  
         {     
            radius = "20";
            color = "0.996 0.816 0.408 1";  
            brightness = "1.0";  
            castShadows = "1";  
            animate = "0";
            animationType = "FireLightAnim";
            // cookie = "art/gui/light.png"; // Basic Lighting will not render this.  
     
            // Lens Flare will need a good mount and will need the mountOffset of the Flashlight   
            // to be modified for your specific application.  
            // flareType = "LightFlareExample1";   
         };  
         %player.mountobject(%light, 2, "0.0 0.1 -0.1"); // mountobject(%obj, mountNode, mountOffset)  
         %player.light = %light;  
         %player.mountEquipment(%this.shapeFile, "mount2");
         %player.updateMountedEquipment();
   
         messageClient(%player.client, 'MsgItemPickup', '\c0You turned on the Lantern.' );
         messageClient(%player.client, 'MsgItemPickup', "\c0You have" SPC %lampOil SPC "bottles of Lamp Oil left.");
         %player.burnSchedule = %this.schedule( 50000, "UseOil", %player );
      }
   }
}  

function Lantern::UseOil(%this, %player)
{
   // Stop using oil if the player has turned off the lantern or died
   if ( !isObject(%player) || !isObject(%player.light) )
      return;
   %player.decInventory(Lamp_Oil, 1);
   
   // See how much oil is left
   %lampOil = %player.getInventory(Lamp_Oil);
   //Warn the Client that their oil is getting low. 
   if ( %lampOil == 5 )
   {
   messageClient(%player.client, 'MsgItemPickup', "\c0You have" SPC %lampOil SPC "bottles of Lamp Oil left.");
   }
   if ( %lampOil == 1 )
   {
       messageClient(%player.client, 'MsgItemPickup', '\c0You have 1 bottle of Lamp Oil left.');
   }
   if ( %lampOil < 1 )
   {  // Not enough oil to burn again, so turn off the light and don't reschedule
      %player.light.delete();
      %player.unmountEquipment("mount2");
      %player.updateMountedEquipment();
      messageClient(%player.client, 'MsgItemPickup', '\c0You ran out of Lamp Oil. Better get some more!');
      return;
   }
   
   // Schedule another use in 50 seconds
   %player.burnSchedule = %this.schedule( 50000, "UseOil", %player );
}

function Lamp_Oil::onUse(%this, %user)
{  // Using oil so if the player has a lantern, toggle it's on/off state
   if(!isObject(%user.client))
   {
      return false;
   }

   %lamp = %user.getInventory(Lantern);
   if ( %lamp > 0 )
   {
      Lantern.onUse(%user);
   }
   else
   {  // They have no lantern to burn the oil in.
      messageClient(%user.client, 'MsgItemPickup', '\c0You need a Lantern to burn the oil in.');
   }
   return true;   // This preventd the "You cannot use..." message
}
