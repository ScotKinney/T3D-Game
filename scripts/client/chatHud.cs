//-----------------------------------------------------------------------------
// Message Hud
//-----------------------------------------------------------------------------

// chat hud sizes in lines
$outerChatLenY[0] = 0;
$outerChatLenY[1] = 4;
$outerChatLenY[2] = 9;
$outerChatLenY[3] = 13;
$numChatLengths = 4;

// All messages are stored in a MessageVector, the actual
// MainChatHud only displays the contents of these vectors.
// Create a message vector for each chat pane
for ( %i = 0; %i < MainChatHud.numTabPages; %i++ )
   MainChatHud.messageVec[%i] = new MessageVector();
//new MessageVector(HudMessageVector);

$LastHudTarget = 0;
$ChatAnchor = 0;


//-----------------------------------------------------------------------------
function onChatMessage(%message, %voice, %pitch)
{
   // Chat goes to the global pane.
   if (getWordCount(%message)) {
      %message = "\c3 " @ getTimeStr() @ " - " @ %message;
      MainChatHud.addLine(%message, "g", true);
   }
}

function onServerMessage(%message)
{
   // Server messages go to the chat HUD too.
   if (getWordCount(%message)) {
      MainChatHud.addLine(%message, "g", true);
   }
}



//-----------------------------------------------------------------------------
// MainChatHud methods
//-----------------------------------------------------------------------------

function MainChatHud::onWake( %this )
{
   // Attach the message vectors to the controls
   for ( %i = 0; %i < %this.numTabPages; %i++ )
   {
      %paneName = "pane" @ %i;
      %paneCtrl = %this.findObjectByInternalName(%paneName, true);
      if ( isObject(%paneCtrl) )
      {
         %chatCtrl = %paneCtrl.findObjectByInternalName("chatHud", true);
         if ( isObject(%chatCtrl) )
            %chatCtrl.msgVec = %this.messageVec[%i];
      }
   }
   %this.schedule(100, setChatHudLength, 0 );

   // Initialize the chat log
   if ( !%this.logInit )
      %this.initChatLog();
   %this.logInit = true;

   // Make sure the text has been localized
   if ( !%this.localized )
      %this.localizeText();
}


//------------------------------------------------------------------------------
function MainChatHud::localizeText( %this )
{  // Replace all static text with localized versions

   // Put the tab label on all of the tabs
   for ( %i = 0; %i < %this.numTabPages; %i++ )
   {
      %paneName = "pane" @ %i;
      %paneCtrl = %this.findObjectByInternalName(%paneName, true);
      if ( isObject(%paneCtrl) )
         %paneCtrl.setText(guiStrings.chatTab[%i]);
   }

   // Panes with static content need updated too
   %this.setPartyButtons();   // Text on party page buttons
   //ChatFriendsPage.localizeText();  // Text on friends page

   // Don't do it again unless the language changes
   %this.localized = true;
}

//------------------------------------------------------------------------------
function MainChatHud::setChatHudLength( %this, %length )
{
   %textHeight = ChatHudMessageProfile.fontSize;
   if (%textHeight <= 0)
      %textHeight = 12;
   %lengthInPixels = $outerChatLenY[%length] * %textHeight;
   %chatMargin = 27;
   if ( %length > 0 )
      %chatMargin += 2;
   OuterChatHud.setExtent(firstWord(OuterChatHud.extent), %lengthInPixels + %chatMargin);
   ChatTabBook.setExtent(firstWord(ChatTabBook.extent), %lengthInPixels + %chatMargin - 8);
   
   // Now resize all of the chat panes
   %selectedPane = ChatTabBook.getSelectedPage();
   for ( %i = 0; %i < MainChatHud.numTabPages; %i++ )
   {
      %paneName = "pane" @ %i;
      %paneCtrl = %this.findObjectByInternalName(%paneName, true);
      if ( isObject(%paneCtrl) )
      {
         %paneCtrl.setVisible((%selectedPane == %i) && (%length > 0));
         if ((%selectedPane == %i) && (%length > 0))
            %paneCtrl.setNotify(false);

         %paneCtrl.setExtent(firstWord(%paneCtrl.extent), %lengthInPixels+2);
         %scrollCtrl = %paneCtrl.findObjectByInternalName("scrollControl", false);
         if ( isObject(%scrollCtrl) )
            %scrollCtrl.setExtent(firstWord(%scrollCtrl.extent), %lengthInPixels);

         // Friend pane requires some special formatting
         //if ( %i == 4 )
         //{
            //%namesCtrl = %paneCtrl.findObjectByInternalName("friendScroll", false);
            //%namesCtrl.setExtent(firstWord(%namesCtrl.extent), %lengthInPixels);
            //%tgramCtrl = %paneCtrl.findObjectByInternalName("TelegramScroll", false);
            //%tgramCtrl.setExtent(firstWord(%tgramCtrl.extent), %lengthInPixels/2);
            //%scrollCtrl.setPosition(firstWord(%scrollCtrl.position), (%lengthInPixels/2 + 1));
            //%scrollCtrl.setExtent(firstWord(%scrollCtrl.extent), %lengthInPixels/2);
         //}
      }
   }
   //ChatScrollHud.scrollToBottom();
   //ChatPageDown.setVisible(false);

   %this-->ExpandButton.setVisible(%length < ($numChatLengths - 1));
   %this-->ShrinkButton.setVisible(%length > 0);

   //epls
   %h = getWord(Canvas.getExtent(),1);
   %h = %h - getWord(OuterChatHud.getExtent(),1) - $ChatAnchor;
   OuterChatHud.setPosition(getWord(OuterChatHud.getPosition(),0), %h);
   %this.currentLength = %length;
}


//------------------------------------------------------------------------------

function MainChatHud::nextChatHudLen( %this )
{
   %len = %this.currentLength + 1;
   if (%len >= $numChatLengths)
      %len = 0;
   $pref::ChatHudLength = %len;
   %this.setChatHudLength(%len);
}

function MainChatHud::lastChatHudLen( %this )
{
   %len = %this.currentLength - 1;
   if (%len < 0)
      %len = $numChatLengths - 1;
   $pref::ChatHudLength = %len;
   %this.setChatHudLength(%len);
}

//-----------------------------------------------------------------------------

function MainChatHud::addLine(%this, %text, %channel, %notify, %skipLog)
{
   if ( %channel $= "" )
      %channel = "a"; // If no channel is selected, put on the active pane
   if ( %notify $= "" )
      %notify = false; // No notification if not specified
   if ( %skipLog $= "" )
      %skipLog = false; // Log message unless explicitly skipped

   // Find the active chat pane
   %activePane = ChatTabBook.getSelectedPage();
   if ((%activePane < 0) || (%activePane >= MainChatHud.numTabPages))
      %activePane = 0;  // If none are active, use global pane as current

   // Select the message vector and chat pane to put the text into
   switch$(%channel)
   {
      case "g":  // Global chat pane
         %tgtIdx = 0;
      case "l":  // Local server chat pane
         %tgtIdx = 1;
      case "c":  // Clan chat pane
         %tgtIdx = 2;
      case "p":  // Party chat pane
         %tgtIdx = 3;
      //case "f":  // Friend chat pane
         //%tgtIdx = 4;
      default:   // Any others go to the currently active pane
         %tgtIdx = ((%activePane < 4) ? %activePane : 0); // But not on friends
   }
   %paneName = "pane" @ %tgtIdx;
   %paneCtrl = %this.findObjectByInternalName(%paneName, true);
   %paneTitle = %paneCtrl.text;

   //remove old messages from the top if we exceed the maximum size
   while( %this.messageVec[%tgtIdx].getNumLines() &&
         (%this.messageVec[%tgtIdx].getNumLines() >= $pref::HudMessageLogSize))
   {
      %tag = %this.messageVec[%tgtIdx].getLineTag(0);
      if(%tag != 0)
         %tag.delete();
      %this.messageVec[%tgtIdx].popFrontLine();
   }

   //add the message...
   %this.messageVec[%tgtIdx].pushBackLine(%text, $LastHudTarget);
   $LastHudTarget = 0;

   if ( isObject(%this.file) && !%skipLog )
      %this.logChatLine("[" @ %paneTitle @ "] " @ %text);

   // Set the notification if called for
   if (%notify && ((%this.currentLength == 0) || (%tgtIdx != %activePane)))
      %paneCtrl.setNotify(true);
}


//-----------------------------------------------------------------------------

function MainChatHud::pageUp(%this)
{
   // Find the active chat pane
   %activePane = ChatTabBook.getSelectedPage();
   if ((%activePane < 0) || (%activePane >= %this.numTabPages) ||
         ($pref::ChatHudLength == 0))
      return;  // If none are active or chat is minimized, return

   // Get the pane, scroll control and chat control
   %paneName = "pane" @ %activePane;
   %paneCtrl = %this.findObjectByInternalName(%paneName, true);
   %scrollCtrl = %paneCtrl.findObjectByInternalName("scrollControl", false);
   %chatCtrl = %paneCtrl.findObjectByInternalName("chatHud", true);

   // Find out the text line height
   %textHeight = ChatHudMessageProfile.fontSize;
   if (%textHeight <= 0)
      %textHeight = 12;

   // Find out how many lines per page are visible
   %chatScrollHeight = getWord(%scrollCtrl.extent, 1) -
         (2 * %scrollCtrl.profile.borderThickness);
   if (%chatScrollHeight <= 0)
      return;

   %pageLines = mFloor(%chatScrollHeight / %textHeight) - 1; // have a 1 line overlap on pages
   if (%pageLines <= 0)
      %pageLines = 1;

   // See how many lines we actually can scroll up:
   %chatPosition = -1 * (getWord(%chatCtrl.position, 1) -
         %scrollCtrl.profile.borderThickness);
   %linesToScroll = mFloor((%chatPosition / %textHeight) + 0.5);
   if (%linesToScroll <= 0)
      return;

   if (%linesToScroll > %pageLines)
      %scrollLines = %pageLines;
   else
      %scrollLines = %linesToScroll;

   // Now set the position
   %chatCtrl.position = firstWord(%chatCtrl.position) SPC
         (getWord(%chatCtrl.position, 1) + (%scrollLines * %textHeight));

   // Display the pageup icon
   //chatPageDown.setVisible(true);
}


//-----------------------------------------------------------------------------

function MainChatHud::pageDown(%this)
{
   // Find the active chat pane
   %activePane = ChatTabBook.getSelectedPage();
   if ((%activePane < 0) || (%activePane >= %this.numTabPages) ||
         ($pref::ChatHudLength == 0))
      return;  // If none are active or chat is minimized, return

   // Get the pane, scroll control and chat control
   %paneName = "pane" @ %activePane;
   %paneCtrl = %this.findObjectByInternalName(%paneName, true);
   %scrollCtrl = %paneCtrl.findObjectByInternalName("scrollControl", false);
   %chatCtrl = %paneCtrl.findObjectByInternalName("chatHud", true);

   // Find out the text line height
   %textHeight = ChatHudMessageProfile.fontSize;
   if (%textHeight <= 0)
      %textHeight = 12;

   // Find out how many lines per page are visible
   %chatScrollHeight = getWord(%scrollCtrl.extent, 1) -
         (2 * %scrollCtrl.profile.borderThickness);
   if (%chatScrollHeight <= 0)
      return;

   %pageLines = mFloor(%chatScrollHeight / %textHeight) - 1;
   if (%pageLines <= 0)
      %pageLines = 1;

   // See how many lines we actually can scroll down:
   %chatPosition = getWord(%chatCtrl.extent, 1) - %chatScrollHeight +
         getWord(%chatCtrl.position, 1) - %scrollCtrl.profile.borderThickness;
   %linesToScroll = mFloor((%chatPosition / %textHeight) + 0.5);
   if (%linesToScroll <= 0)
      return;

   if (%linesToScroll > %pageLines)
      %scrollLines = %pageLines;
   else
      %scrollLines = %linesToScroll;

   // Now set the position
   %chatCtrl.position = firstWord(%chatCtrl.position) SPC
         (getWord(%chatCtrl.position, 1) - (%scrollLines * %textHeight));

   // See if we have should (still) display the pagedown icon
   //if (%scrollLines < %linesToScroll)
      //chatPageDown.setVisible(true);
   //else
      //chatPageDown.setVisible(false);
}


//-----------------------------------------------------------------------------
// Support functions
//-----------------------------------------------------------------------------

function pageUpMessageHud()
{
   MainChatHud.pageUp();
}

function pageDownMessageHud()
{
   MainChatHud.pageDown();
}

function cycleMessageHudSize()
{
   MainChatHud.nextChatHudLen();
}

function MainChatHud::initChatLog(%this)
{
   if ( $pref::ChatLogOn )
   {
      %this.openChatLog();
      %this.schedule(500, "addLine", chatStrings.chatLogOn, "a", false, true);
   }
   else
      %this.schedule(500, "addLine", chatStrings.chatLogOff, "a", false, true);
   return;
}

function MainChatHud::onRemove(%this)
{
   %this.closeChatLog();
   return;
}

function MainChatHud::openChatLog(%this)
{
   %file = new FileObject();      
   if(isObject(%file))
   {
      if ( !%file.openForAppend($pref::ChatLogName) )
      {
         %file.delete();
         return;
      }
      %this.file = %file;
      
      %ltStr = getLocalTime();
      %dateStr = GetWord(%ltStr,0) @ "/" @ GetWord(%ltStr,1) @ "/" @ GetWord(%ltStr,2);
      %timeStr = GetWord(%ltStr,3) @ ":" @ GetWord(%ltStr,4) @ ":" @ GetWord(%ltStr,5);
      %this.file.WriteLine(chatStrings.chatLogOpen @ %dateStr SPC %timeStr);
   }
   return;
}

function MainChatHud::closeChatLog(%this)
{
   if( isObject(%this.file) )
   {
      %ltStr = getLocalTime();
      %dateStr = GetWord(%ltStr,0) @ "/" @ GetWord(%ltStr,1) @ "/" @ GetWord(%ltStr,2);
      %timeStr = GetWord(%ltStr,3) @ ":" @ GetWord(%ltStr,4) @ ":" @ GetWord(%ltStr,5);
      %this.file.WriteLine(chatStrings.chatLogClosed @ %dateStr SPC %timeStr);
      %this.file.close();
      %this.file.delete();
      %this.file = -1;
   }
   return;
}

function MainChatHud::logChatLine(%this, %text)
{  // Strip off any control or color characters
   %text = stripChars(%text, "\cp\co\c0\c1\c2\c3\c4\c5\c6\c7\c8\c9");
   %this.file.WriteLine(%text);
}

function MainChatHud::toggleChatLog(%this, %toggleVar)
{
   if ( %toggleVar )
      $pref::ChatLogOn = !$pref::ChatLogOn;

   if ( $pref::ChatLogOn )
   {
      %this.openChatLog();
      %this.addLine(chatStrings.chatLogOn, "a", false, true);
   }
   else
   {
      %this.closeChatLog();
      %this.addLine(chatStrings.chatLogOff, "a", false, true);
   }
}

function ChatTabBook::onTabSelected(%this, %tabText, %tabIndex)
{  // A new tab pane has been selected. If the chat is visible, turn off
   // notifications for this pane,
   if ( MainChatHud.currentLength > 0 )
   {
      %paneName = "pane" @ %tabIndex;
      %paneCtrl = %this.findObjectByInternalName(%paneName, true);
      %paneCtrl.setNotify(false);
   }
}

function GuiMessageVectorCtrl::onWake(%this)
{  // Make sure the message vector is attached
   if ( %this.msgVec $= "" )
      %this.msgVec = MainChatHud.messageVec[%this.vecIdx];
   %ret = %this.attach(%this.msgVec);
}

function GuiMessageVectorCtrl::urlClickCallback(%this, %urlText)
{  // Open a browser with the web page they clicked on.
   gotoWebPage(%urlText);
}
