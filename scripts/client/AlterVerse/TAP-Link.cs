//-----------------------------------------------------------------------------
// Functions for handling communication from the TAP-Link and the in game 
// TAP-Link Gui

function TPToServer(%serverID)
{
   echo("TPToServer(" @ %serverID @ ") Called!\n");
}

function PutTLOnTop()
{  // Pop/Push the TL dialog so it is on top of the canvas. This function needs
   // called anytime the canvas content is reset with a setContent call
   if ( isObject(TAPLinkHUD) )
   {
      if ( TAPLinkHUD.isAwake() )
         Canvas.popDialog(TAPLinkHUD);
      Canvas.pushDialog(TAPLinkHUD);
   }
}
