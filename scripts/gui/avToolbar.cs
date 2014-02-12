$AVToolbar::numWeaponSlots = 10;
$AVToolbar::firstWeaponSlot = 0;
$AVToolbar::lastWeaponSlot = 9;

$AVToolbar::numSpellSlots = 10;
$AVToolbar::firstSpellSlot = $AVToolbar::lastWeaponSlot + 1;
$AVToolbar::lastSpellSlot = 19;

$AVToolbar::numUtilitySlots = 6;
$AVToolbar::firstUtilitySlot = $AVToolbar::lastSpellSlot + 1;
$AVToolbar::lastUtilitySlot = 25;

$AVToolbar::numIconSlots = $AVToolbar::lastUtilitySlot + 1;

$AVToolbar::InvIconSlot = $AVToolbar::firstUtilitySlot;  //20
$AVToolbar::invIcon = "art/gui/icons/inventory.jpg";

$AVToolbar::HelpIconSlot = $AVToolbar::InvIconSlot + 1;  //21
$AVToolbar::HelpIcon = "art/gui/icons/Help.jpg";

$AVToolbar::MapIconSlot = $AVToolbar::HelpIconSlot + 1;  //22
$AVToolbar::MapIcon = "art/gui/icons/map.jpg";

$AVToolbar::TPKeyIconSlot = $AVToolbar::MapIconSlot + 1; //23
$AVToolbar::TPKeyIcon = "art/gui/icons/key.jpg";

$AVToolbar::FishingIconSlot = $AVToolbar::TPKeyIconSlot + 1;   //24
$AVToolbar::FishingIcon = "art/gui/icons/fishingpole.jpg";

$AVToolbar::HorseIconSlot = $AVToolbar::FishingIconSlot + 1;   //25
$AVToolbar::HorseIcon = "art/gui/icons/horse.jpg";

function AVToolbar::onWake(%this)
{
   %this.clearIcons();
   %this.updateIcons();
   InventoryGui.arnsLookup();
   %this.getPlayerRank(true);
   %this.httpFail = 0;
   %this.getArnsStats();
   
   %this.showArnsBar($pref::HUD::ArnsBarOn);
}

function AVToolbar::setIcon(%this, %iconSlot, %iconImage, %itemId, %tooltip)
{
   %icon = %this.getIcon(%iconSlot);
   %icon.setBitmap(%iconImage);
   %icon.itemID = %itemId;
   %icon.tooltip = %tooltip;  
}

function AVToolbar::getIcon(%this, %iconSlot)
{
   eval("%icon = AVToolbar-->icon" @ %iconSlot @ ";");
   return %icon;  
}

function AVToolbar::clearIcons(%this)
{
   // clear all icon slots
   for(%i=0; %i<$AVToolbar::numIconSlots; %i++)
      %this.setIcon(%i, "", -1, "");  
}

function AVToolbar::findEmptySlot(%this, %start, %end)
{
   for(%i=%start; %i <= %end; %i++)
   {
      %icon = %this.getIcon(%i);
      if(%icon.bitmap $= "")
         return %i;
   }
   return -1; // no empty slots
}

function AVToolbar::hasIconForItem(%this, %itemId)
{
   for(%i = 0; %i < $AVToolbar::numIconSlots; %i++)
   {
      %icon = %this.getIcon(%i);
      if(%icon.itemId == %itemId)
         return true;
   }
   
   return false;
}

function AVToolbar::updateIcons(%this)
{
   // check that we have all the item information
   if(!isObject($AlterVerse::invList) && !$DesignMode)
      return;
      
   // set any special icons
   // inventory icon   
   %this.setIcon($AVToolbar::InvIconSlot, $AVToolbar::invIcon, -1, "Inventory");
   // help icon   
   //%this.setIcon($AVToolbar::HelpIconSlot, $AVToolbar::helpIcon, -1);

   // horse icon. Horse IDs in the AVItems table range 104-109
   %horseID = -1;
   if ( isObject($AlterVerse::PlayerInventory) )
   {
      for ( %i = 104; %i <= 109; %i++)
      {
         %index = $AlterVerse::PlayerInventory.getIndexFromKey(%i);
         if ((-1 < %index) && (0 < $AlterVerse::PlayerInventory.getValue(%index)))
         {
            %horseID = %i;
            break;
         }
      }
   }

   if(%horseID != -1)
   {
      %this.setIcon($AVToolbar::HorseIconSlot, $AVToolbar::HorseIcon, %horseID, "Summon/Hide Horse");
   }
   else
      %this.setIcon($AVToolbar::HorseIconSlot, "", -1, "");

   // tp key icon
   //if((strstr($AlterVerse::PlayerInventory, "56 1") != -1) || $DesignMode)
   //{
      //%this.setIcon($AVToolbar::TPKeyIconSlot, $AVToolbar::TPKeyIcon, 56, "Magical Pass Key");
   //}
   //else
      %this.setIcon($AVToolbar::TPKeyIconSlot, "", -1, "");

   // Help icon
   //%this.setIcon($AVToolbar::HelpIconSlot, $AVToolbar::HelpIcon, -1, "Show Help");
   %this.setIcon($AVToolbar::HelpIconSlot, "", -1, "");

   // Map Icon
   //%this.setIcon($AVToolbar::MapIconSlot, $AVToolbar::MapIcon, -1, "Map of Aureus");
   %this.setIcon($AVToolbar::MapIconSlot, "", -1, "");

   // fishing pole icon ID #110 in AVItems table
   if( isObject($AlterVerse::PlayerInventory) &&
      ($AlterVerse::PlayerInventory.getIndexFromKey("110") > -1) )
   {
      %this.setIcon($AVToolbar::FishingIconSlot, $AVToolbar::FishingIcon, 110, "Fishing Pole");
   }
   else
      %this.setIcon($AVToolbar::FishingIconSlot, "", -1, "");

   if(!isObject($AlterVerse::invList) || !isObject($AlterVerse::PlayerInventory))
      return;  // Bail if no inventory even in design mode
   
   // Then do weapons
   %this.updateIconSet($AVToolbar::firstWeaponSlot, $AVToolbar::lastWeaponSlot, "weapons");
   
   // Then magic
   %this.updateIconSet($AVToolbar::firstSpellSlot, $AVToolbar::lastSpellSlot, "magic");
}

function AVToolbar::updateIconSet(%this, %iconStart, %iconEnd, %itemCategory)
{
   // first remove any icons for weapons we don't have
   for(%i = %iconStart; %i <= %iconEnd; %i++)
   {
      %icon = %this.getIcon(%i);
      if(%icon.itemId == -1)
         continue;
      
      %index = $AlterVerse::PlayerInventory.getIndexFromKey(%icon.itemId);
      if ((%index == -1) || ($AlterVerse::PlayerInventory.getValue(%index) < 1))
         %this.setIcon(%i, "", -1, "");
   }

   // Bail if we don't have our inventory yet
   if ( !isObject($AlterVerse::PlayerInventory) )
      return;

   // now add icons for weapons that we do have
   %cnt = $AlterVerse::PlayerInventory.count();
   
   for(%i=0; %i < %cnt; %i++)
   {
      // get inventory item
      %itemId = $AlterVerse::PlayerInventory.getKey(%i);
         
      // get item category
      %invItemString = $AlterVerse::invList.getValue($AlterVerse::invList.getIndexFromKey(%itemId));
      %category = getWord(%invItemString, 1);
      
      // skip if not a weapon         
      if(%category !$= %itemCategory)
         continue;
            
      // skip if we're already displaying icon for it
      if(%this.hasIconForItem(%itemId))
         continue;
         
      // get icon for it
      %iconImage = "";
      %file = "art/gui/icons/" @ getWord(%invItemString, 3);
      if ( isFile( %file ) )
         %iconImage = %file;
      else
         %iconImage =  "";
        
      // get empty icon slot
      %iconSlot = %this.findEmptySlot(%iconStart, %iconEnd);
      if(%iconSlot == -1) // no empty slots!
         return;
            
      // set the icon
      //%tooltip = strreplace(getWord(%invItemString, 0),"_"," ");
      %tooltip = getBarWord($AlterVerse::invDesc[%itemId], 1);
      %this.setIcon(%iconSlot, %iconImage, %itemId, %tooltip);
   }
}


function AVToolbar::onIconClick(%this, %icon)
{
   // clicked on an empty icon?
   if(%icon.bitmap $= "")
      return;
   
   // get the icon slot
   nextToken(%icon.internalName, "iconID", "icon");
         
   // handle any special commands
   if(%iconID == $AVToolbar::InvIconSlot)
   {
      handleChatCommand("/inv");
   }
   // teleport key
   //else if(%iconID == $AVToolbar::TPKeyIconSlot)
   //{
      //// The key activates the astral passport spell which is item ID 56 in 
      //// the database. It can only be used if the player is on Aureus...not any more
      ////if ( $ServerName !$= "Aureus" )
         ////clientCmdCenterPrint("The magic of the Key has no effect here", 5, 1, false);
      ////else
         //commandToServer('UseItem', 83, "1", "2");
      ////hideCursor();
   //}
   //// Help icon
   //else if(%iconID == $AVToolbar::HelpIconSlot)
      //AVHelpGui.toggle();
   // Horse
   else if((%iconID == $AVToolbar::HorseIconSlot) || (%iconID == $AVToolbar::FishingIconSlot))
      commandToServer('UseItem', %icon.itemID, "1", "5");
   // map
   //else if(%iconID == $AVToolbar::MapIconSlot)
      //BCMapGui.toggleMap();
   // then weapons
   else if(%iconID >= $AVToolbar::firstWeaponSlot && %iconID <= $AVToolbar::lastWeaponSlot)
   {
      commandToServer('UseItem', %icon.itemID, "1", "1");
      sfxPlayOnce(AvGuiSound);
      hideCursor();
   }
   // then magic
   else if(%iconID >= $AVToolbar::firstSpellSlot && %iconID <= $AVToolbar::lastSpellSlot)
   {
      commandToServer('UseItem', %icon.itemID, "1", "2");
      hideCursor();
   }
}

function AVToolbar::toggleArnsBar(%this)
{
   $pref::HUD::ArnsBarOn = !AVToolbarArnsBar.visible;
   %this.showArnsBar($pref::HUD::ArnsBarOn);
}

function AVToolbar::showArnsBar(%this, %turnOn)
{
   AVToolbarArnsBar.visible = %turnOn;
   %ScreenWidth = getWord(AVToolbar.getExtent(), 0);
   %barHeight = %turnOn ? 133 : 89;
   AVToolbar.resize(0, 0, %ScreenWidth, %barHeight);
   PlayGui.ResizeCenterPrint(%ScreenWidth);
}

function AVToolbar::updateArnsBar(%this)
{
   AVToolbar-->AB_AIPText.setText($AlterVerse::ArnsInPocket);
   AVToolbar-->AB_AIBText.setText($AlterVerse::ArnsInBank);
   AVToolbar-->SLText.setText($AlterVerse::PlayerSkullLevel);
}

function AVToolbar::getArnsStats(%this)
{  // Get the initial value for all arns bar stats
   if ( $currentPlayerID $= "" )
      return;

   %lookup = new HTTPObject() {
      class = arnsBarLookup;
      status = "failure";
   };
   %lookup.get( $serverPath, $scriptPath @ "getArnsStats.php",
      "uID="@$currentPlayerID@"\tclanID="@$pref::Player::ClanID );
}

function AVToolbar::getPlayerRank(%this, %force)
{  // Update the displayed rank value
   if ( $currentPlayerID $= "" )
      return;

   if ( !%force && ($AlterVerse::PlayerNetWorth < (%this.lastRankNW + 1500)) &&
      ($AlterVerse::PlayerNetWorth > (%this.lastRankNW - 1500)) )
      return;

   %this.lastRankNW = $AlterVerse::PlayerNetWorth;
   
   %lookup = new HTTPObject() {
      class = rankLookup;
      status = "failure";
   };
   %lookup.get( $serverPath, $scriptPath @ "getPlayerRank.php", "uID="@$currentPlayerID );
}

// process the result from the arns lookup
function arnsBarLookup::process(%this)
{
   switch$( %this.status )
   {
   case "success":
      $AlterVerse::ArnsInReserve = %this.reserve;
      $AlterVerse::ArnsInTreasury = %this.treasury;
         
   default:
      $AlterVerse::ArnsInReserve = "N/A";
      $AlterVerse::ArnsInTreasury = "N/A";
      if ( AVToolbar.httpFail < 10 )
      {  // Try again in a minute if it hasn't happened repeatedly.
         AVToolbar.httpFail++;
         AVToolbar.schedule(60000, "getArnsStats");
      }
   }

   AVToolbar-->AB_AIRText.setText($AlterVerse::ArnsInReserve);
   AVToolbar-->AB_AITText.setText($AlterVerse::ArnsInTreasury);
   %this.schedule(0, delete);
}

// process the result from the rank lookup
function rankLookup::process(%this)
{
   switch$( %this.status )
   {
   case "success":
      $AlterVerse::PlayerRank = %this.rank;
         
   default:
      $AlterVerse::PlayerRank = "N/A";
   }

   AVToolbar-->AB_RankText.setText($AlterVerse::PlayerRank);
   %this.schedule(0, delete);  
}
