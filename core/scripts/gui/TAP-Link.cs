//-----------------------------------------------------------------------------
// Functions for handling communication from the TAP-Link and the in game 
// TAP-Link Gui

function TPToServer(%serverID)
{  // User has requested to teleport to another server
   echo("TPToServer(" @ %serverID @ ") Called!\n");
   if ( !$TAP::onServer )
      return;  // Must be on a server to teleport

   CommandToServer('TeleportToServer', %serverID);
}

function PutTLOnTop()
{  // Pop/Push the TL dialog so it is on top of the canvas. This function needs
   // called anytime the canvas content is reset with a setContent call
   if ( isObject(TAPLinkHUD) )
   {
      if ( TAPLinkHUD.isAwake() )
         Canvas.popDialog(TAPLinkHUD);

      if ( $pref::TL::isShown && TAPLink.isConnected() )
         TAPLinkHUD.showTL();
   }
}

function ToggleTAPLink(%val)
{  // Pop/Push the TL dialog so it is on top of the canvas. This function needs
   // called anytime the canvas content is reset with a setContent call
   if ( !%val || !isObject(TAPLinkHUD) || !TAPLink.isConnected() )
      return;

   if ( $pref::TL::isShown )
      TAPLinkHUD.HideTL();
   else
      TAPLinkHUD.showTL();
}

function Hide3DTAPLink()
{
   commandToServer('Use3DTL');
   //RestoreGlobalBinds();
}

function RestoreGlobalBinds()
{
   //globalActionMap.bind( mouse, button1, toggleCursor );
   if ( Canvas.getContent() == PlayGui.getId() )
      showCursor();
}

function focusWebShape(%obj, %mouseDown, %rayStart, %rayEnd)
{
   // get the class name of the object
   %objClass = %obj.getClassName();
   echo("Hit Web Shape: " @ %objClass @ ", Mouse is " @ (%mouseDown?"Down":"Up") @ ", Ray start: " @ %rayStart @ ", Ray end: " @ %rayEnd);
   %goodShape = $TAP::WebResponder.setInputTarget(%obj, %rayStart, %rayEnd, %mouseDown);
   if ( %goodShape )
   {
      if ( ($mvTriggerCount0 % 2) == 1 )
         $mvTriggerCount0++;
      //globalActionMap.unbind( mouse, button1);
      hideCursor();
   }
}

function TAPLinkHUD::onResize(%this, %newWidth, %newHeight)
{
   %this.checkPositions(%newWidth, %newHeight);
}

function TAPLinkHUD::checkPositions(%this, %newWidth, %newHeight)
{  // Make sure the docked and full versions of the TL will be fully visible
   // at the passed resolution
   if ( $pref::TL::framePos $= "" )
      $pref::TL::framePos = "0 0";
   %posX = getWord($pref::TL::framePos, 0);
   %posY = getWord($pref::TL::framePos, 1);
   %frameExt = TLFrame.getExtent();
   %frameX = getWord(%frameExt, 0);
   %frameY = getWord(%frameExt, 1);
   if ( %posX < 0 )
      %posX = 0;
   else if ( %posX > (%newWidth - %frameX) )
      %posX = %newWidth - %frameX;
   if ( %posY < 0 )
      %posY = 0;
   else if ( %posY > (%newHeight - %frameY) )
      %posY = %newHeight - %frameY;
   TLFrame.setPosition(%posX, %posY);
   $pref::TL::framePos = %posX SPC %posY;

   if ( $pref::TL::dockedPos $= "" )
      $pref::TL::dockedPos = "0 0";
   %posX = getWord($pref::TL::dockedPos, 0);
   %posY = getWord($pref::TL::dockedPos, 1);
   %frameExt = DockedTL.getExtent();
   %frameX = getWord(%frameExt, 0);
   %frameY = getWord(%frameExt, 1);
   if ( %posX < 0 )
      %posX = 0;
   else if ( %posX > (%newWidth - %frameX) )
      %posX = %newWidth - %frameX;
   if ( %posY < 0 )
      %posY = 0;
   else if ( %posY > (%newHeight - %frameY) )
      %posY = %newHeight - %frameY;
   DockedTL.setPosition(%posX, %posY);
   $pref::TL::dockedPos = %posX SPC %posY;
}

function TAPLinkHUD::showTL(%this)
{
   $pref::TL::isShown = true;
   %vidMode = Canvas.getVideoMode();
   %newWidth = getWord(%vidMode, 0);
   %newHeight = getWord(%vidMode, 1);
   TAPLinkHUD.checkPositions(%newWidth, %newHeight);

   if ( $pref::TL::isDocked )
   {
      TLFrame.setVisible(false);
      DockedTL.setVisible(true);
   }
   else
   {
      TLFrame.setVisible(true);
      DockedTL.setVisible(false);
   }

   Canvas.pushDialog(TAPLinkHUD);
}

function TAPLinkHUD::MinimizeTL(%this)
{  // Minimize the TL to the docked state.
   $pref::TL::isDocked = true;
   TLFrame.setVisible(false);
   DockedTL.setVisible(true);
}

function TAPLinkHUD::RestoreTL(%this)
{  // Restore the Tap link from the docked state.
   $pref::TL::isDocked = false;
   TLFrame.setVisible(true);
   DockedTL.setVisible(false);
}

function TAPLinkHUD::HideTL(%this)
{  // Hide the TL Gui
   $pref::TL::isShown = false;
   if ( %this.isAwake() )
      Canvas.popDialog(%this);
}

function TLFrameHeader::onMouseDown(%this, %modifier, %point, %clickCount)
{
   // Find the max drag positions
   %frameExt = TAPLinkHUD.getExtent();
   %frameX = getWord(%frameExt, 0);
   %frameY = getWord(%frameExt, 1);
   %movingSize = TLFrame.getExtent();
   %this.maxX = %frameX - getWord(%movingSize, 0);
   %this.maxY = %frameY - getWord(%movingSize, 1);
   
   // Record the starting position for the Gui and mouse
   %this.startX = getWord(%point, 0);
   %this.startY = getWord(%point, 1);
   %movingPos = TLFrame.getPosition();
   %this.oldX = getWord(%movingPos, 0);
   %this.oldY = getWord(%movingPos, 1);
}

function TLFrameHeader::onMouseDragged(%this, %modifier, %point, %clickCount)
{
   %mouseX = getWord(%point, 0);
   %mouseY = getWord(%point, 1);
   %newX = %this.oldX + (%mouseX - %this.startX);
   %newY = %this.oldY + (%mouseY - %this.startY);
   if (%newX < 0)
      %newX = 0;
   if (%newY < 0)
      %newY = 0;
   if (%newX > %this.maxX)
      %newX = %this.maxX;
   if (%newY > %this.maxY)
      %newY = %this.maxY;
   TLFrame.setPosition(%newX, %newY);
   $pref::TL::framePos = %newX SPC %newY;
}

function DockedTLHeader::onMouseDown(%this, %modifier, %point, %clickCount)
{
   // Find the max drag positions
   %frameExt = TAPLinkHUD.getExtent();
   %frameX = getWord(%frameExt, 0);
   %frameY = getWord(%frameExt, 1);
   %movingSize = DockedTL.getExtent();
   %this.maxX = %frameX - getWord(%movingSize, 0);
   %this.maxY = %frameY - getWord(%movingSize, 1);
   
   // Record the starting position for the Gui and mouse
   %this.startX = getWord(%point, 0);
   %this.startY = getWord(%point, 1);
   %movingPos = DockedTL.getPosition();
   %this.oldX = getWord(%movingPos, 0);
   %this.oldY = getWord(%movingPos, 1);
}

function DockedTLHeader::onMouseDragged(%this, %modifier, %point, %clickCount)
{
   %mouseX = getWord(%point, 0);
   %mouseY = getWord(%point, 1);
   %newX = %this.oldX + (%mouseX - %this.startX);
   %newY = %this.oldY + (%mouseY - %this.startY);
   if (%newX < 0)
      %newX = 0;
   if (%newY < 0)
      %newY = 0;
   if (%newX > %this.maxX)
      %newX = %this.maxX;
   if (%newY > %this.maxY)
      %newY = %this.maxY;
   DockedTL.setPosition(%newX, %newY);
   $pref::TL::dockedPos = %newX SPC %newY;
}

GlobalActionMap.bind(keyboard, "ctrl t", ToggleTAPLink);
//Canvas.pushDialog(TAPLinkHUD);