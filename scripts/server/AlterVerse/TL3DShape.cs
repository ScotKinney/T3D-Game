// ----------------------------------------------------------------------------
// 3D TAP-Link
// ----------------------------------------------------------------------------

function serverCmdUse3DTL(%client)
{
   if ( isObject(%client.player) )
      %client.player.use3DTL();
}

function Player::use3DTL(%this)
{
   // Toggle the TAP-Link state.
   if( isObject(%this.TAPLink) )
   {  // It's already out, Put it away and schedule deletion
      %this.setThreadDir(0, false);
      %this.playThread(0, "");
      %this.setThreadPosition(0, 1.0);
      %this.schedule(300, "destroyTL");
   }
   else
   {  // Create the shape
      %tlShape = new TSStatic()
      {
         shapeName = "art/inv/TapLink/TapLink.dts";
         scale = "1 1 1";
         playAmbient = "0";
      };

      // Mount it to the player
      %this.mountObject(%tlShape, 1, "0 0 0 0 0 1 0"); // mountobject(%obj, mountNode, mountTransform)
      %this.TAPLink = %tlShape;

      // Put the player in the "holding-TL" pose
      %this.playThread(0, "Taplink");
      %this.setThreadTimeScale(0, 0.5);
   }
}

function Player::destroyTL(%this)
{  // Remove the Taplink animation from the player and delete the shape
   %this.destroyThread(0);
   if( isObject(%this.TAPLink) )
      %this.TAPLink.delete();
   %this.TAPLink = "";
}
