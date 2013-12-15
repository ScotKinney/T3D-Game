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
// PlayGui is the main TSControl through which the game is viewed.
// The PlayGui also contains the hud controls.
//-----------------------------------------------------------------------------

function PlayGui::onWake(%this)
{
   // Turn off any shell sounds...
   // sfxStop( ... );

   $enableDirectInput = "1";
   activateDirectInput();

   // Message hud dialog
   if ( isObject( MainChatHud ) )
   {
      $ChatAnchor = 40;
      Canvas.pushDialog( MainChatHud );
      MainChatHud.schedule(1000, setChatHudLength, $Pref::ChatHudLength );
   }     

   // just update the action map here
   unbindChatCommands();
   moveMap.push();

   if(isObject(numericalHealthHUD))
      numericalHealthHUD.start();

   // Fill in static text
   %this-->HomeworldText.setText($AlterVerse::Homeworld);
   %this-->ClanText.setText($AlterVerse::ClanName);

   // Resize any dynamic gui elements
   %screenExtent = Canvas.getExtent();
   %this.onResize( getWord(%screenExtent, 0), getWord(%screenExtent, 1));

   PutTLOnTop();  // Bring the TL gui back onto the canvas
   $TAP::WebResponder = %this-->WebResponder;

   // If there's a Lock level upgrade waiting, activate the message
   if($AlterVerse::PendingSkullUpgrade !$= "")
   {
      if ( $AlterVerse::PendingSkullUpgrade < 4 )
      {
         //ShowTutorial($AlterVerse::PendingSkullUpgrade + 1);
         schedule(5000, 0, "ShowTutorial", $AlterVerse::PendingSkullUpgrade + 1);
      }
      if(!isObject(SkullLevelUpGui))      
         exec("art/gui/SkullLevelUpGui.gui");

      %message = strReplace(guiStrings.lvlUpLine2, "%1", %value);
      SkullLevelUpGui-->SkullLevelUpText.text = %message;
      Canvas.pushDialog(SkullLevelUpGui);
      $AlterVerse::PendingSkullUpgrade = "";
   }
}

function PlayGui::onSleep(%this)
{
   if ( isObject( MainChatHud ) )
      Canvas.popDialog( MainChatHud );
   
   $ChatAnchor = 0;
   
   if(isObject(numericalHealthHUD))
      numericalHealthHUD.stop();

   // pop the keymaps
   moveMap.pop();
   bindChatCommands();
}

function PlayGui::clearHud( %this )
{
   Canvas.popDialog( MainChatHud );

   while ( %this.getCount() > 0 )
      %this.getObject( 0 ).delete();
}

function PlayGui::onResize(%this, %newWidth, %newHeight)
{
   %this.ResizeCenterPrint(%newWidth);

   // Reposition the bottom bar to use the bottom 40 pixels
   %rowPos = %newHeight - 40;
   
   // Position the prefs and invite buttons on the left edge of the screen
   %this-->PrefsBtn.resize(0, %rowPos, 80, 40);
   %this-->OpenSiteBtn.resize(80, %rowPos, 107, 40);

   // Position the exit and citizen buttons on the right edge of the screen
   %this-->FriendBtn.resize(%newWidth - 187, %rowPos, 107, 40);
   %this-->ExitBtn.resize(%newWidth - 80, %rowPos, 80, 40);

   // and center
   %this-->RowCenter.resize((%newWidth - 650) / 2, %rowPos, 650, 40);
   
   // If the screen is too narrow, hide the invite and citizen links
   %visible = (%newWidth > 1000) ? 1 : 0;
   %this-->FriendBtn.visible = %visible;
   %this-->OpenSiteBtn.visible = %visible;

   // Position the bottom left hud buttons
   %this-->HealthBlock.resize(0, %newHeight - 91, 80, 51);
   %this-->WeaponBlock.resize(0, %newHeight - 131, 40, 40);
   
   // Position the bottom right hud buttons
   %this-->FPSBlock.resize(%newWidth - 80, %newHeight - 91, 80, 51);
   %this-->ArnBarButton.resize(%newWidth - 40, %newHeight - 131, 40, 40);

   if(MessageHud.isVisible())
   {
      %mhX = mFloor((%newWidth - getWord( OuterChatHud.extent, 0 )) / 2);
      %mhY = %newHeight - (getWord( OuterChatHud.extent, 1 ) + 40 + getWord( MessageHud_Frame.extent, 1 ));
      messageHud_Frame.position = %mhX SPC %mhY;
      messageHud_Frame.resize(%mhX, %mhY, getWord(messageHud_Frame.extent, 0),
                              getWord(messageHud_Frame.extent, 1));
   }
}

function PlayGui::ResizeCenterPrint(%this, %newWidth)
{  // Reposition the center print frame and text to be 10 pixels below the
   // toolbar and 18 pixels from each side of the screen
   %ctrlWidth = %newWidth - 36;
   %barHeight = getWord(AVToolbar.getExtent(), 1);
   //%barHeight = 30;
   centerPrintDlg.resize(18, %barHeight + 4, %ctrlWidth, 23);
   CenterPrintText.resize(2, 2, %ctrlWidth - 4, 19);
}

//------------------------------------------------------------------------------
// health hud
//------------------------------------------------------------------------------
function numericalHealthHUD::start(%this)
{
   if(!isEventPending(%this.updateSchedule))
      %this.updateSchedule = %this.schedule(250, update);
}

function numericalHealthHUD::stop(%this)
{
   if(isEventPending(%this.updateSchedule))
      cancel(%this.updateSchedule);  
}

function numericalHealthHUD::update(%this)
{
   %this.updateSchedule = %this.schedule(250, update);

   lblFps.setText(mRound($fps::real));

   if(!isObject(ServerConnection))
      return;

   %player = ServerConnection.getControlObject();
   if(!isObject(%player))
      return;

   %health = mCeil((1 - %player.getDamagePercent()) * 100);

   %this.setValue(%health);
}

// SkullLevel changed
function PlayGui::updateSkullLevel(%this)
{
   // update the skull level label
   if(isObject(AVToolbar))
      AVToolbar-->SLText.text = $AlterVerse::PlayerSkullLevel;
      
   %this.updateTotalEstate();
}

// net worth changed
function PlayGui::updateNetWorth(%this)
{
   if(isObject(AVToolbar))
      AVToolbar-->NWText.text = $AlterVerse::PlayerNetWorth;
      
   %this.updateTotalEstate();  
}

// total estate
function PlayGui::updateTotalEstate(%this)
{
   if(isObject(AVToolbar))
   {
      %TE = mMulBigNumbers($AlterVerse::PlayerNetWorth, $AlterVerse::PlayerSkullLevel);
      AVToolbar-->TEText.text = %TE;
   }
}

//-----------------------------------------------------------------------------
// HUD mouse functions
//-----------------------------------------------------------------------------

function PlayGui::onMouseOver(%this, %obj)
{
   if ( isEventPending(%this.hoverEvent) )
   {
      cancel(%this.hoverEvent);
   }
   %this.hideItemPopup();

   %this.callBack("onMouseOver", %obj);
}

function PlayGui::onMouseDown(%this, %obj)
{
   if ( isEventPending(%this.hoverEvent) )
   {
      cancel(%this.hoverEvent);
   }
   %this.hideItemPopup();
   
   %this.callBack("onMouseDown", %obj);
}

function PlayGui::onMouseUp(%this, %obj)
{
   return;
}

// GameTSCtrl::callBack re-routes the callback to different functions
// depending on the object type that we are dealing with
function PlayGui::callBack(%this, %funcName, %obj)
{
   // don't do anything if the object is not valid
   if(!isObject(%obj))
      return;
      
   // get the class name of the object
   %objClass = %obj.getClassName();

   if ( %objClass $= "AIPlayer" )
   {  // See if it's a horse
      %dbName = %obj.getDataBlock().getName();
      if ( strstr(%dbName, "Horse") != -1 )
         %objClass = "AIHorse";
      else
         %objClass = "Player";
   }

   if ( (strstr(%objClass, "Terrain") != -1) || (%objClass $= "TSStatic") )
      return;

   if ( (%objClass $= "WaterPlane") || (%objClass $= "WaterBlock")  || (%objClass $= "River"))
      %objClass = "Water";

   // construct the string that will be used for the object specific callback
   // e.g. %this.onMouseOverItem(%obj);
   %funcStr = "%this." @ %funcName @ %objClass @ "(" @ %obj @ ");";

   // call the function   
   eval(%funcStr);
}

// the object specific callbacks
function PlayGui::onMouseOverItem(%this, %item)
{
   %this.hoverEvent = %this.schedule(%this.hovertime, "showItemPopup", %item);
   %this.setNeedsMoveEvent(true); // Make sure the event is canceled if the mouse moves
   return;  
}

function PlayGui::onMouseDownItem(%this, %item)
{
   //echo("onMouseDownItem");
   
   // clicking on this item will pick it up if we are close enough
   %player = ServerConnection.getControlObject();
   
   if(!isObject(%player))
      return;
      
   %distSqr = VectorDistSquared(%item.position, %player.position);
   if(%distSqr <= $Alterverse::PickupRadius^2)
      CommandToServer('pickupItem', %item.getGhostID());
}

function PlayGui::onMouseOverPlayer(%this, %target)
{
   return;  
}

function PlayGui::onMouseDownPlayer(%this, %target)
{
   // clicking on this item will pick it up if we are close enough
   %player = ServerConnection.getControlObject();
   
   if(!isObject(%player))
      return;
      
   //ServerConnection.setSelectedObj(%target);
   CommandToServer('setSpellTarget', %target.getGhostID());
}

function PlayGui::onMouseDownWater(%this, %item)
{
   // Send the coordinates to the server if not too far away
   %player = ServerConnection.getControlObject();
   
   if(!isObject(%player))
      return;

   // Get the click location
   %pos = %this.GetLastClick();
   %distSqr = VectorDistSquared(%pos, %player.position);
   if(%distSqr <= $AlterVerse::FishingDistance * $AlterVerse::FishingDistance)
      CommandToServer('WaterClick', %item.getGhostID(), %pos);
   else
      MainChatHud.addLine(chatStrings.fishDistMsg, "l", false, true);
}

function clientCmdSendWaterClicks(%doSend)
{
   PlayGui.SendWaterClicks(%doSend);
}

function PlayGui::onMouseOverAIHorse(%this, %item)
{
   // We can determine the Item ID by the skin on the horse
   %skinName = %item.getSkinName();
   if ( %skinName $= "light" )
      %skinName = "Buckskin";
   else if ( %skinName $= "indian" )
      %skinName = "Painted";
   
   %this.hoverEvent = %this.schedule(%this.hovertime, "showHorsePopup", %item, %skinName);
   %this.setNeedsMoveEvent(true); // Make sure the event is canceled if the mouse moves
   return;  
}

function PlayGui::onMouseDownAIHorse(%this, %item)
{
   // clicking on this item will pick it up if we are close enough
   %player = ServerConnection.getControlObject();

   if(!isObject(%player))
      return;
      
   // If we clicked a horse that is mounted, chances are we meant to click the rider
   //%mountObj = %item.getMountedObject(0);
   //if ( isObject(%mountObj) )
   //{
      //%this.onMouseDownPlayer(%mountObj);
      //return;
   //}
   //else
   //{
      //%mountObj = %item.getMountedObject(5);
      //if ( isObject(%mountObj) )
      //{
         //%this.onMouseDownPlayer(%mountObj);
         //return;
      //}
   //}

   %owner = %item.getClanName();
   if ((%owner !$= "Buy") && (%owner !$= "Drop"))
      return;  // We can't pick up this horse

   %distSqr = VectorDistSquared(%item.position, %player.position);
   if(%distSqr <= ($AlterVerse::PickupRadius * $AlterVerse::PickupRadius))
   {
      // We can determine the Item ID by the skin on the horse
      %skinName = %item.getSkinName();
      %horseName = %skinName;
      if ( %skinName $= "arabian" )
         %horseName = "Chestnut";
      else if ( %skinName $= "light" )
      {
         %skinName = "Buckskin";
         %horseName = "Buckskin";
      }
      else if ( %skinName $= "mustang" )
         %horseName = "Spotted";
      else if ( %skinName $= "indian" )
      {
         %skinName = "Painted";
         %horseName = "Painted";
      }
      else if ( %skinName $= "palimino" )
         %horseName = "Gray";
 
      if ( %owner $= "Buy" )
      {  // Ask for confirmation before buying a horse
         // Find the itemID for this horse
         %horseName = strlwr(%horseName);
         for (%i = 104; %i <= 109; %i++)
         {
            %invItemString = $AlterVerse::invList.getValue($AlterVerse::invList.getIndexFromKey(%i));
            %cost = getWord(%invItemString, 0);
            %puName = getBarWord($AlterVerse::invDesc[%i], 1);
            %testName = strlwr(%puName);
            if ( strstr(%testName, %horseName) != -1 )
            {
               if ( $AlterVerse::ArnsInPocket >= %cost )
                  return %this.ConfirmHorseBuy(%item.getGhostID(), %skinName, %puName, %cost);
               break;
            }
         }
      }

      CommandToServer('pickupHorse', %item.getGhostID(), %skinName);
   }
}

function PlayGui::ConfirmHorseBuy(%this, %ghostID, %skinName, %horseName, %cost)
{
   %message = "Would you like to buy this " @ %horseName @ " for " @ %cost @ " arns?";
   %callback = "CommandToServer(\'pickupHorse\', " @ %ghostID @ ", \"" @ %skinName @ "\");";
   ShowQuestMessageBox("", %message, 0, "Yes", %callback, "No");
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
// InfoBox
function PlayGui::showItemPopup(%this, %item)
{
   if ( !isObject( %item ) )
      return;
   %itemID = %item.getDatablock().ItemID;
   if ( (%itemID > 0) && ($AlterVerse::invDesc[%itemID] !$= "") )
   {
      InfoBoxBackdrop.visible = true;
      InfoBox.visible = true;
      InfoBox.setPopupText(%item, $AlterVerse::invDesc[%itemID]);
   }
}

function PlayGui::showHorsePopup(%this, %item, %skinName)
{
   if ( !isObject( %item ) )
      return;
   
   // Find the itemID for this horse
   %itemID = 0;
   %skinName = strlwr(%skinName);
   for (%i = 104; %i < 109; %i++)
   {
      %puName = strlwr(getBarWord($AlterVerse::invDesc[%i], 1));
      if ( strstr(%puName, %skinName) != -1 )
      {
         %itemID = %i;
      }
   }

   if ( (%itemID > 0) && ($AlterVerse::invDesc[%itemID] !$= "") )
   {
      %owner = %item.getClanName();
      %name = stripChars( detag(%owner), "\cp\co\c6\c7\c8\c9" );
      if ( %name $= $currentUsername )
         return;
      %item.buyable = ( %owner $= "buy" );
      %item.owner = %owner;
      %item.isHorse = true;
      InfoBoxBackdrop.visible = true;
      InfoBox.visible = true;
      InfoBox.setPopupText(%item, $AlterVerse::invDesc[%itemID]);
   }
}

function PlayGui::hideItemPopup(%this)
{
   InfoBoxBackdrop.visible = false;
   InfoBox.visible = false;
}

function InfoBox::onWake(%this)
{
  ///echo("**** InfoBox WAKE **** " @ %this.getExtent());
}

function InfoBox::setPopupText(%this, %item, %invDescStr)
{
   %id = getBarWord(%invDescStr, 0);
   %puName = getBarWord(%invDescStr, 1);
   %desc = getBarWord(%invDescStr, 3);

   %invItemString = $AlterVerse::invList.getValue($AlterVerse::invList.getIndexFromKey(%id));
   %unitCost = getWord(%invItemString, 0);
   %category = getWord(%invItemString, 1);
   %invTag = getWord(%invItemString, 2);
   %extra = getWord(%invItemString, 4);
   
   // Name goes in top left
   %popupStr = "<just:left><font:Arial:20><color:FFD200>" @ %puName;

   // Target in top right for all magic spells
   if ( %category $= "magic" )
      %popupStr = %popupStr @ "<just:right><font:Arial:20><color:ACACAC>" @
         guiStrings.tgtHeader SPC guiStrings.target[%extra];

   // Description fills the body of text
   if (%item.isHorse && (%item.owner !$= "buy") && (%item.owner !$= "drop"))
   {
      //%desc = "This horse belongs to " @ %item.owner @ ". You can buy your own at the Tokara Stables.";
      %desc = strreplace(guiStrings.horsePopup, "%1", %item.owner);
      %popupStr = %popupStr @ "\n<just:left><font:Arial:16><color:ACACAC>" @ %desc;
   }
   else
      %popupStr = %popupStr @ "\n<just:left><font:Arial:16><color:ACACAC>" @ %desc;
   %popupStr = %popupStr @ "\n\n<color:FFFFFF>";   // Blank line and switch to white

   // Calculate the total cost or value
   if ( %item.count > 1 )
   {
      %totalCost = %item.count * %unitCost;
      %popupStr = %popupStr @ guiStrings.qtyHeader SPC %item.count @ "\n";
      %popupStr = %popupStr @ guiStrings.total  @ " ";
   }
   
   if ( %item.buyable )
      %popupStr = %popupStr @ guiStrings.cost @ " ";
   else
      %popupStr = %popupStr @ guiStrings.value @ " ";
      
   if ( %item.count > 1 )
      %popupStr = %popupStr @ %totalCost @ " Arn\n";
   else
      %popupStr = %popupStr @ %unitCost @ " Arn\n";

   if ( %invTag $= "food" )
      %popupStr = %popupStr @ guiStrings.nutHeader SPC %extra SPC ((%item.count > 1) ? guiStrings.each : "");
   InfoBox.setText(%popupStr);
}

function InfoBox::onResize(%this, %width, %height)
{
   %txt_margin = 8;

   %cursorpos = Canvas.getCursorPos();
   
   //%this_pos = Canvas.screenToClient(%cursorpos); 
   %this_pos = %cursorpos; 
   %pos_x = getWord(%this_pos,0); 
   %pos_y = getWord(%this_pos,1);

   %win_size = Canvas.getExtent();
   %win_wd = getWord(%win_size,0);
   %win_ht = getWord(%win_size,1);

   %box_wd = %width + 2*%txt_margin;
   %box_ht = %height + 2*%txt_margin;
   //%box_x = %win_wd - (%box_wd + 8);
   //%box_y = %win_ht - (%box_ht + 60 + 8);
   %box_x = %pos_x - (%box_wd/2);
   if ( %box_x < 0 )
      %box_x = 4;
   else if ( (%box_x + %box_wd ) >= %win_wd )
      %box_x = %win_wd - (%box_wd + 4);

   %box_y = %pos_y - (%box_ht + 4);
   if (%box_y < 0)
      %box_y = 4;

   InfoBoxBackdrop.resize(%box_x, %box_y, %box_wd, %box_ht);
   %this.resize(%box_x + %txt_margin, %box_y + %txt_margin, %width, %height);
}

