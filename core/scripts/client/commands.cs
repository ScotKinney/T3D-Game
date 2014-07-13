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

// Sync the Camera and the EditorGui
function clientCmdSyncEditorGui()
{
   if (isObject(EditorGui))
      EditorGui.syncCameraGui();
}

// client side skull level tracking
function clientCmdSetSkullLevel(%value, %upgrade, %wait)
{
   if ( %value !$= "" )
      $pref::Player::SkullLevel = %value;
   $AlterVerse::PlayerSkullLevel = $pref::Player::SkullLevel;

   // skull upgrade message
   if(%upgrade !$= "")
   {
      if(Canvas.getContent() == PlayGui.getId() && !%wait)
      {
         AVToolbar.getPlayerRank(true);
         if ( %value < 4 )
         {
            //ShowTutorial(%value + 1);
            schedule(5000, 0, "ShowTutorial", %value + 1);
         }
         if(!isObject(SkullLevelUpGui))      
            exec("art/gui/SkullLevelUpGui.gui");

         %message = strReplace(guiStrings.lvlUpLine2, "%1", %value);
         SkullLevelUpGui-->SkullLevelUpText.text = %message;
         Canvas.pushDialog(SkullLevelUpGui);
      }
      else // store the level up value for when the playgui becomes active
         $AlterVerse::PendingSkullUpgrade = %value;
   }
      
   // update the gui
   if(isObject(PlayGui))
      PlayGui.updateSkullLevel();
}

// clients net worth sent from server. Update the 
// related variables and GUIs
function clientCmdSetNetWorth(%value)
{
   $AlterVerse::PlayerNetWorth = %value;
   
   if(isObject(PlayGui))
   {
      AVToolbar.getPlayerRank(false);
      PlayGui.updateNetWorth();
   }
}

function clientCmdSetInventory(%str1, %str2, %str3, %str4)
{
   %value = %str1;
   if ( %str2 !$= "" )
      %value = %value @ %str2;
   if ( %str3 !$= "" )
      %value = %value @ %str3;
   if ( %str4 !$= "" )
      %value = %value @ %str4;

   if ( !isObject($AlterVerse::PlayerInventory) )
      $AlterVerse::PlayerInventory = new ArrayObject();
   $AlterVerse::PlayerInventory.empty();

   %numItems = getFieldCount(%value);
   for (%i = 0; %i < %numItems; %i++ )
   {
      %curItem = getField(%value, %i);
      %itemID = getWord(%curItem, 0);
      %count = getWord(%curItem, 1);
      if ( %count > 0 )
      {
         $AlterVerse::PlayerInventory.add(%itemID, %count);
      }
   }

   if ( InventoryGui.isAwake() )
   {
      InventoryGui.Refresh();
      InventoryGui.arnsLookup();
   }
   
   if(AVToolbar.isAwake())
      AVToolbar.updateIcons();
}

function clientCmdUpdateInventory(%itemID, %itemCount, %newNW)
{
   if ( !isObject($AlterVerse::PlayerInventory) )
      $AlterVerse::PlayerInventory = new ArrayObject();

   %index = $AlterVerse::PlayerInventory.getIndexFromKey(%itemID);
   if ( %index == -1 )
   {
      if ( %itemCount > 0 )
         $AlterVerse::PlayerInventory.add(%itemID, %itemCount);
   }
   else
   {
      if ( %itemCount == 0 )
         $AlterVerse::PlayerInventory.erase(%index);
      else
         $AlterVerse::PlayerInventory.setValue(%itemCount, %index);
   }

   if ( InventoryGui.isAwake() )
      InventoryGui.Refresh();
   
   if(AVToolbar.isAwake())
      AVToolbar.updateIcons();

   $AlterVerse::PlayerNetWorth = %newNW;
   if(isObject(PlayGui))
   {
      AVToolbar.getPlayerRank(false);
      PlayGui.updateNetWorth();
   }
}

//function clientCmdActivateBanking(%value)
//{
   //if ( !BankingGui.isAwake() )
   //{
      //Canvas.pushDialog(BankingGui);
      //%message = strReplace(guiStrings.bankCaption, "%1", %value);
      //BankingGui.setCaption(%message);
   //}
//}

function clientCmdActivateSelling(%value, %willbuy)
{
   if ( !InventoryGui.isAwake() )
   {
      $selling = true;
      $willbuy = %willbuy;
      
      // Set the inventory gui to the correct pane we're selling from
      InventoryGui.selectedtype = 4; // Default to gems
      if ( strstr("armor shields clothing", $willbuy) != -1 )
         InventoryGui.selectedtype = 0;
      else if ( strstr("weapons mstaves ammo stars tools pyro", $willbuy) != -1 )
         InventoryGui.selectedtype = 1;
      else if ( strstr("magic potions scrying wands", $willbuy) != -1 )
         InventoryGui.selectedtype = 2;
      else if ( strstr("food bread candy cheese eggs fish fruit fungi herbs liquor meat pies seaweed seeds veggies", $willbuy) != -1 )
         InventoryGui.selectedtype = 3;
      else if ( strstr("crystals gems jewelry mineral coins", $willbuy) != -1 )
         InventoryGui.selectedtype = 4;
      else if ( strstr("inv baskets books chests feed flowers gambling horses livestock misc music pouches sacks tackle utensils vessels wool", $willbuy) != -1 )
         InventoryGui.selectedtype = 5;
      $pref::gui::LastInventoryType = InventoryGui.selectedtype;
      Canvas.pushDialog(InventoryGui);
   }
}

function clientCmdNPCMessage(%npcID, %ttlNum, %msgNum, %format, %val1, %val2)
{  // Display generic message box for client
   %title = guiStrings.npcMsgTitle[%ttlNum];
   %message = guiStrings.npcMsgBody[%msgNum];
   %namePos = StrPos(%message, "<username>");
   if ( %namePos != -1 )
      %message = strReplace(%message, "<username>", $pref::Player::Name);

   %callback1 = "NPCCallback(" @ %npcID @ ", " @ %val1 @ ");";
   if ( %format == 0 )
   {  // Display OK message box
      MessageBoxOK(%title, %message, %callback1);
   }
   else if ( %format == 1 )
   {  // Display yes/no message box
      %callback2 = "NPCCallback(" @ %npcID @ ", " @ %val2 @ ");";
      MessageBoxYesNo(%title, %message, %callback1, %callback2);
   }
}

function clientCmdQNPCMessage(%npcID, %msgNum, %numChoices, %choice1, %choice2, %choice3)
{  // Display generic message box for client
   %message = guiStrings.questMsgBody[%msgNum];
   %message = %msgNum;
   %namePos = StrPos(%message, "<username>");
   if ( %namePos != -1 )
      %message = strReplace(%message, "<username>", $pref::Player::Name);

   %callback1 = "NPCCallback(" @ %npcID @ ", 1);";
   %callback2 = "NPCCallback(" @ %npcID @ ", 2);";
   %callback3 = "NPCCallback(" @ %npcID @ ", 3);";
   ShowQuestMessageBox("", %message, 0, %choice1, %callback1,
      %choice2, %callback2, %choice3, %callback3);
}

function NPCCallback( %npcID, %newVal)
{
   commandToServer('NPCDecision', %npcID, %newVal);
}

function clientCmdSelectFreeTarget(%book_slot, %spell_name)
{
   %message = strReplace(guiStrings.mbAFXFreeTarget, "%1", %spell_name);
   clientCmdCenterPrint(%message, 10);
   showCursor();
   afxStartFreeTargetingMode(%book_slot, $afxCurrentSelectronStyle);
}

function clientCmdTreasuryHit(%clanName, %gotArns)
{
   %message = strReplace(guiStrings.mbTreasuryHit, "%1", %clanName);
   %message = strReplace(%message, "%2", %gotArns);
   // Put message in chat on the currently active pane
   MainChatHud.addLine(%message, "a", true);
   sfxPlayOnce(TreasuryHitSFX);
   $AlterVerse::PlayerNetWorth = mAddBigNumbers($AlterVerse::PlayerNetWorth, %gotArns);
   if(isObject(PlayGui))
   {
      AVToolbar.getPlayerRank(false);
      PlayGui.updateNetWorth();
   }
}

function clientCmdArnsUpdate(%arnsVal)
{
   $AlterVerse::ArnsInPocket = %arnsVal;
   AVToolbar-->AB_AIPText.setText($AlterVerse::ArnsInPocket);
}

function clientCmdBankingUpdate(%arnsVal)
{
   $AlterVerse::ArnsInBank = %arnsVal;
   AVToolbar-->AB_AIBText.setText($AlterVerse::ArnsInBank);
}

function clientCmdReserveUpdate(%arnsVal)
{
   $AlterVerse::ArnsInReserve = %arnsVal;
   AVToolbar-->AB_AIRText.setText($AlterVerse::ArnsInReserve);
}

function clientCmdTreasuryUpdate(%arnsVal, %opperation)
{
   switch$(%opperation)
   {
      case "Add":
         $AlterVerse::ArnsInTreasury = mAddBigNumbers($AlterVerse::ArnsInTreasury, %arnsVal);
      case "Sub":
         $AlterVerse::ArnsInTreasury = mSubBigNumbers($AlterVerse::ArnsInTreasury, %arnsVal);
      default:
         $AlterVerse::ArnsInTreasury = %arnsVal;
   }

   AVToolbar-->AB_AITText.setText($AlterVerse::ArnsInTreasury);
}

function clientCmdGiveBounty(%value)
{
   $AlterVerse::PlayerNetWorth = mAddBigNumbers($AlterVerse::PlayerNetWorth, %value);
   $AlterVerse::ArnsInPocket = mAddBigNumbers($AlterVerse::ArnsInPocket, %value);
   
   if(isObject(PlayGui))
   {
      AVToolbar-->AB_AIPText.setText($AlterVerse::ArnsInPocket);
      AVToolbar.getPlayerRank(false);
      PlayGui.updateNetWorth();
   }
}

function clientCmdshowDeathLoss(%lostItems)
{
   %numItems = getFieldCount(%lostItems);
   if ( (%lostItems $= "") || (%numItems < 1) )
   {
      %message = chatStrings.msg[deathNoLoss];
   }
   else
   {
      %message = chatStrings.msg[deathLoss];
      %fieldAdded = false;
      for (%i = 0; %i < %numItems; %i++ )
      {
         %curItem = getField(%lostItems, %i);
         %itemID = getWord(%curItem, 0);
         %count = getWord(%curItem, 1);
         if ( %count > 0 )
         {
            if ( %fieldAdded )
               %message = %message @ ", ";
            %message = %message @ getBarWord($AlterVerse::invDesc[%itemID], 1);
            %message = %message @ "(" @ %count @ ")";
            %fieldAdded = true;
         }
      }
   }

   MainChatHud.addLine(%message, "a", true);
}

