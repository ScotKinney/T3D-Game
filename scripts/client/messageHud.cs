//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

//----------------------------------------------------------------------------
// Chat Message Hud
//----------------------------------------------------------------------------

//------------------------------------------------------------------------------

function MessageHud::onWake(%this)
{
   // If it's not an IM, set the chat pane name as the target
   if ( !%this.isIMHud )
   {  // Select the leading text from the current chat pane.
      %activePane = ChatTabBook.getSelectedPage();
      if ((%activePane < 0) || (%activePane >= MainChatHud.numTabPages))
         %activePane = 0;  // If none are active, use global pane as current

      // If we're on the friends pane, it's an IM
      if ( %activePane == 4 )
      {
         %playerID = ChatFriendsPage-->FriendNames.getSelectedId();

         // Make sure there's a friend selected and they're online
         if ((%playerID == -1) || (UserListGuiList.getRowNumById(%playerID) == -1))
         {
            %this.schedule(100, "close");
            return;
         }

         %this.isIMHud = true;
         %this.imTarget = %playerID;
         %text = ChatFriendsPage-->FriendNames.getRowTextById(%playerID);
         %paneTitle = getField(%text, 0);
      }
      else
      {
         %paneName = "pane" @ %activePane;
         %paneCtrl = MainChatHud.findObjectByInternalName(%paneName, true);
         %paneTitle = %paneCtrl.text;
         %this.chatPane = %activePane;
      }

      MessageHud_Text.setValue(%paneTitle @ ":");
   }
}

function MessageHud::onSleep(%this)
{
   %this.isIMHud = false;
}

function MessageHud::open(%this)
{
   // If the enter key was bound, unbind it but remember the state so
   // it can be restored in the close function
   %this.oldEnterBind = globalActionMap.getCommand(keyboard, enter);
   if ( %this.oldEnterBind !$= "" )
      globalActionMap.unbind( keyboard, enter);

   Canvas.pushDialog(%this);
   %this.setVisible(true);
   %this.RefreshPosition();
   //deactivateKeyboard();
   MessageHud_Edit.makeFirstResponder(true);
}

function MessageHud::RefreshPosition(%this)
{
   //%windowPos = "0 " @ ( getWord( outerChatHud.position, 1 ) + getWord( outerChatHud.extent, 1 ) + 1 );
   %windowPos = getWord( outerChatHud.position, 0 ) SPC ( getWord( outerChatHud.position, 1 ) - getWord( messageHud_Frame.extent, 1 ));
   %windowExt = getWord( OuterChatHud.extent, 0 ) SPC getWord( MessageHud_Frame.extent, 1 );
   
   %textExtent = getWord(MessageHud_Text.extent, 0) + 14;
   %ctrlExtent = getWord(%windowExt, 0);

   
   messageHud_Frame.position = %windowPos;
   messageHud_Frame.extent = %windowExt;
   messageHud_Frame.resize(getWord(%windowPos, 0), getWord(%windowPos, 1),
                           getWord(%windowExt, 0), getWord(%windowExt, 1));
   MessageHud_Edit.position = setWord(MessageHud_Edit.position, 0, %textExtent);
   MessageHud_Edit.extent = setWord(MessageHud_Edit.extent, 0, %ctrlExtent - %textExtent - 4);
   MessageHud_Edit.resize(getWord(MessageHud_Edit.position, 0),
                          getWord(MessageHud_Edit.position, 1),
                          getWord(MessageHud_Edit.extent, 0),
                          getWord(MessageHud_Edit.extent, 1));
}
//------------------------------------------------------------------------------

function MessageHud::close(%this)
{
   if(!%this.isVisible())
      return;
      
   Canvas.popDialog(%this);
   %this.setVisible(false);
   //if ( $enableDirectInput )
      //activateKeyboard();
   MessageHud_Edit.setValue("");

   // restore the enter key bind
   if ( %this.oldEnterBind !$= "" )
      globalActionMap.bind(keyboard, enter, %this.oldEnterBind);
}


//------------------------------------------------------------------------------

function MessageHud::toggleState(%this)
{
   if(%this.isVisible())
      %this.close();
   else
      %this.open();
}

//------------------------------------------------------------------------------

function MessageHud::ChatFilter(%this, %text)
{
   %filterFile = new fileObject();
   if(%filterFile.openForRead("scripts/client/alterVerse/filter.txt"))
   {
      %testStr = strlwr(%text);  // all compares are lower case
      while(!%filterFile.isEOF())
      {
         %badWord = %filterFile.readLine();
         %wordPos = strstr(%testStr, %badWord);
         while ( %wordPos != -1 )
         {
            %outStr = "";
            if ( %wordPos > 0 )
               %outStr = getSubStr(%text, 0, %wordPos);
            %outStr = %outStr @ strrepeat("*", strlen(%badWord), "") @
                     getSubStr(%text, %wordPos + strlen(%badWord), -1);
            %text = %outStr;

            // Update our test string and check again so we catch multiple
            // occurrences of the same word
            %newTest = "";
            if ( %wordPos > 0 )
               %newTest = getSubStr(%testStr, 0, %wordPos);
            %newTest = %newTest @ strrepeat("*", strlen(%badWord), "") @
                     getSubStr(%testStr, %wordPos + strlen(%badWord), -1);
            %testStr = %newTest;
            %wordPos = strstr(%testStr, %badWord);
         }
      }
      
      %filterFile.close();
   }
   %filterFile.delete();
   return %text;
}

//------------------------------------------------------------------------------

function MessageHud_Edit::onEscape(%this)
{
   MessageHud.close();
}

//------------------------------------------------------------------------------

function MessageHud_Edit::eval(%this)
{
   %text = collapseEscape(trim(%this.getValue()));

   if(%text !$= "")
   {
      // check for lines beginning with / as these will be commands eg /inv or /use
      // so we may need to pre process them here on the client
      if(strstr(%text,"/") == 0)
         handleChatCommand(%text);
      else
      {
         // Remove any inappropriate content from the chat before sending
         %text = MessageHud.ChatFilter(%text);
         if ( MessageHud.isIMHud )
            sendIMMessage(%text, MessageHud.imTarget);
         else
            sendChatMessage(%text, MessageHud.chatPane);
      }
   }

   MessageHud.close();
}

function MessageHud::makeIMHUD(%this, %playerID)
{
   // If the message hud is already on the screen, close it first
   if(%this.isVisible())
      %this.close();

   %this.isIMHud = true;
   %this.imTarget = %playerID;

   // Set the recipients name as the target
   %text = UserListGuiList.getRowTextById(%playerID);
   %name = getField(%text, 0);
   MessageHud_Text.setValue(%name @ ":");

   %this.open();
}

   
//----------------------------------------------------------------------------
// MessageHud key handlers

function toggleMessageHud(%make)
{
   if(%make)
   {
      MessageHud.toggleState();
   }
}

function teamMessageHud(%make)
{
   if(!%make)
      return;

   // Select the team (clan) chat pane first, always page index 2
   ChatTabBook.selectPage(2);
   MessageHud.toggleState();
}
