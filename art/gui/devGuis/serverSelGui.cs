// Functions for Server Selection screen

function ServerSelGui::onWake(%this)
{
   %this.onRefreshButton();   // Fill the server list
   
   if ( !$TAP::isTappedIn )
   {
      %this->ExitText.text = "LOGOUT";
      %this->ExitBtn.tooltip = "Click here to logout and return to the login screen.";
   }
   
   %screenExtent = Canvas.getExtent();
   %this.onResize( getWord(%screenExtent, 0), getWord(%screenExtent, 1));

   // Pop/Push the chat dialog so it is on top if connected to chat server
   if ( MainChatHud.isAwake() )
      Canvas.popDialog(MainChatHud);
   if (isObject(clientChat) && clientChat.connected)
      Canvas.pushDialog(MainChatHud);

   PutTLOnTop();  // Bring the TL gui back onto the canvas
}

function ServerSelGui::onSleep(%this)
{
}

function ServerSelGui::onResize(%this, %newWidth, %newHeight)
{  // Reposition the gui contents.
   %verticalScale = %newHeight / 900;
   %horizontalScale = %newWidth / 1600;

   // resize the fonts used on this page
   %useScale = (%verticalScale > %horizontalScale) ? %verticalScale : %horizontalScale;
   %this.resizeFonts(%useScale);

   // Center the info box
   %boxExtent = %this->InfoFrame.getExtent();
   %boxXExtent = getWord(%boxExtent, 0);
   %boxYExtent = getWord(%boxExtent, 1);
   %xPos = (%newWidth - %boxXExtent) / 2;
   %yPos = (%newHeight - %boxYExtent) / 2;
   %this->InfoFrame.resize(%xPos, %yPos, %boxXExtent, %boxYExtent);

   // The Prefs button is 54x41 and positioned at the bottom left of the screen
   %xExtent = mRound(54 * %useScale);
   %yExtent = mRound(41 * %useScale);
   %xPos = 12;
   %yPos = %newHeight - (%yExtent + 8);
   %textYExtent = mRound(19 * %useScale);
   %textYPos = %yPos - %textYExtent;
   %this->PrefsText.resize(%xPos, %textYPos, %xExtent, %textYExtent);
   %this->PrefsBtn.resize(%xPos, %yPos, %xExtent, %yExtent);
   
   // The exit button is 54x41 and positioned at the bottom right
   %xPos = %newWidth - (%xExtent + 12);
   %this->ExitText.resize(%xPos - 12, %textYPos, %xExtent + 24, %textYExtent);
   %this->ExitBtn.resize(%xPos, %yPos, %xExtent, %yExtent);
}

function ServerSelGui::resizeFonts(%this, %scaleFactor)
{
   // Torque adjusts font sizes, to get the true point size we need to increase
   // the requested point size x1.6 for Trajan and x1.2 for Arial
   %trajanMult = 1.6;
   %arialMult = 1.2;
   
   // The text input font is 16 point
   %fontPoint = 14 * %scaleFactor;
   //AVDevLabelProfile.fontsize = mRound(%fontPoint * %trajanMult);

   // The button font is 12 point
   %fontPoint = 12 * %scaleFactor;
   AVDevHeaderProfile.fontSize = mRound(%fontPoint * %trajanMult);
}

function ServerSelGui::onSelChange(%this)
{
   %serverID = %this-->ServerList.getSelectedId();
   if ( %serverID > 1 )
      %this.selectedServer = %serverID;
   %this-->JoinBtn.setActive(%serverID > 1);
}

function ServerSelGui::onJoinButton(%this)
{
   %serverID = %this-->ServerList.getSelectedId();

   if ( %serverID > 1 )
   {
      %this.selectedServer = %serverID;
      %text = %this-->ServerList.getRowTextById(%serverID);
      $serverToJoin = getField(%text, 4);
      $ServerName = getWord(%text, 0);
      $AlterVerse::serverPrefix = getField(%text, 5);

      loadLoadingGui();
      connectToServer($serverToJoin, "", false, false);
   }
}

function ServerSelGui::onQuitButton(%this)
{
   if ( $TAP::isTappedIn )
      quit();
   else
   {
      LoginGui.setActive( true );
      Canvas.popDialog(%this);
      //Canvas.schedule(10, "setContent", "LoginGui");
   }
}

function ServerSelGui::onRefreshButton(%this)
{
   %this-->RefreshBtn.setActive(false);
   %this-->JoinBtn.setActive(false);
   new HttpObject(httpServerList){
      status = "failure";
      message = "";
   };
   
   httpServerList.get( $serverPath, $scriptPath @ "getServerList.php", "" );
}

// process the results from the server list request
function httpServerList::process( %this )
{
   switch$( %this.status )
   {
      case "success":
         ServerSelGui-->ServerList.clear();
         for (%i = 0; %i < %this.NumServers; %i++)
         {
            %dbID = %this.ServerID[%i];
            %dataLine = %this.ServerName[%i];
            if ( %this.ServerName[%i] !$= %this.DisplayName[%i] )
               %dataLine = %dataLine @ " (" @ %this.DisplayName[%i] @ ")";
            if ( %this.ServerDesi[%i] !$= "" )
               %dataLine = %dataLine @ " - " @ %this.ServerDesi[%i];
            %dataLine = %dataLine TAB %this.PlayerCount[%i];
            %dataLine = %dataLine TAB %dbID TAB %this.WorldType[%i];
            %dataLine = %dataLine TAB %this.ServerAddr[%i];
            %dataLine = %dataLine TAB %this.prefix[%i];

            // Add the server to the list control
            ServerSelGui-->ServerList.addRow(%dbID, %dataLine);
         }
         if ( %this.NumServers > 0 )
            ServerSelGui-->ServerList.sortNumerical(3, true);
         else
            ServerSelGui-->ServerList.addRow(1, "No servers running." TAB " " TAB "1" TAB "0");
         %hasSelected = ( -1 !=
            ServerSelGui-->ServerList.getRowNumById(ServerSelGui.selectedServer) );
         if ( %hasSelected )
         {
            ServerSelGui-->ServerList.setSelectedById(ServerSelGui.selectedServer);
            ServerSelGui-->JoinBtn.setActive(true);
         }

         ServerSelGui-->RefreshBtn.setActive(true);
      default:
         //processLoginFailure( %this.message );
         ServerSelGui-->RefreshBtn.setActive(true);
   }
   
   %this.schedule(0, delete);
}