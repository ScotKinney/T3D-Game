// Login/launch functions for TAP

$serverPath = "www.alterverse.com:80";
$scriptPath = "/public_web_dev/";
//$scriptPath = "/public_web/";

function TapInStage1()
{
   new HttpObject(httpTapInStage1){
      status = "failure";
      message = "";
   };
   
   httpTapInStage1.get( $serverPath, $scriptPath @ "avTapInStage1.php", "uid=" @ $currentPlayerID );
}

// process the results from the stage 1 request
function httpTapInStage1::process( %this )
{
   switch$( %this.status )
   {
   case "success":
      $currentPasswordHash = %this.hash;
      $currentPlayerID = %this.playerID;
      $currentUsername = %this.playerName;
      $pref::Party = %this.playerID;
      
      // login stage 1 complete - server has sent us a hash that we will use
      // to encrypt our password for second stage of login check      
      // move onto stage 2
      loginStage2();
   
   default:
      processLoginFailure( %this.message );
   }
   
   %this.schedule(0, delete);
}

function loginStage2(%this)
{
   // hash our password combined with the supplied hash
   %pwdHash = getStringMD5( $currentHash @ $currentPasswordHash );
      
   new HttpObject(httpLoginStage2){
      status = "failure";
      message = "";
   };

   %args = "uname=" @ $currentUsername @"\t"@ "pwd=" @ %pwdHash;

   if ( $TAP::isTappedIn && ($TAP::serverID !$= "") )
      %args = %args @ "\tsvrID=" @ $TAP::serverID;

   httpLoginStage2.get( $serverPath, $scriptPath @ "avLoginStage2.php", %args );  
}

// process the results of the login stage 2 request
function httpLoginStage2::process(%this)
{
   switch$( %this.status )
   {
   case "success":
      // store updated hash string
      $currentPasswordHash = %this.hash;
      // and the server to log into
      $serverToJoin = %this.server;
      $ServerName = %this.svrName;
      $AlterVerse::serverPrefix = %this.filePrefix;
      // and the manifest paths
      $manifestRoot = %this.manifestRoot;
      $manifestFile = %this.manifestFile;
      // is user a subscriber
      $IsSubscriber = %this.subscriber;
      $TAP::isDev = %this.developer;
      $TAP::localIP = %this.your_ip;
      // the clan that the user belongs to
      $pref::Player::ClanID = %this.clan_id;
      $pref::Player::WorldID = %this.world_id;
      $pref::Player::SkullLevel = %this.skulls;
      $pref::Player::Gender = %this.gender;
      %timeLeft = %this.time_left - 3600; // Time zone issue, web reports 1 hour more than the real time
      $AlterVerse::RoundEnd = mFloor(getSimTime() / 1000) + %timeLeft;
      //%timeLeft = %this.time_left - (24 * 60 * 60);
      %timeLeft = %timeLeft - (24 * 60 * 60);
      $cutoffTime = mFloor(getSimTime() / 1000) + %timeLeft;
      $pref::Player::Name = %this.fullName;
      $currentUsername = $pref::Player::Name;

      // login stage 2 complete
      $TAP::isLoggedIn = true;
      if ( !$TAP::isTappedIn )
         startIntroVideo();
   
   default:
      processLoginFailure( %this.message );
   }
   
   %this.schedule(0, delete);
}

// login failed for some reason
function processLoginFailure( %message )
{
   error( "login failed -" SPC %message );
   MessageBoxOK( "Login Failed", 
                 %message, 
                 (($TAP::isTappedIn) ? "quit();" : "LoginGui.setActive(true);") );
}

function InventoryRequest()
{
   if( isObject($AlterVerse::invList) )
   {  // The inventory list has already been loaded, we can skip to ServerRequest
      ServerRequest();
      return;
   }
   
   %request = new HTTPObject() {
      class = "getInventoryList";
      status = "failure";
      message = "";
   };
   
   %request.get( $serverPath, $scriptPath @ "getAVInvList.php", "" );
}

function getInventoryList::process( %this )
{
   switch$( %this.status )
   {
   case "success":
      if( !isObject($AlterVerse::invList) )
      {
         $AlterVerse::invList = new ArrayObject();
      }
      $AlterVerse::invList.empty();
      
      //echo("ITEMS" SPC %this.items);
      %cnt = getWordCount(%this.items);
      for ( %i = 0; %i < %cnt; %i++ )
      {
         //%item = strreplace(getWord(%this.items, %i), "|", " ");
         %item = getWord(%this.items, %i);
         %id = getBarWord(%item, 0);
         //%name = getWords(%item, 1, getWordCount(%item)-1);
         %value = getBarWord(%item, 1) SPC getBarWord(%item, 2) SPC getBarWord(%item, 3) SPC getBarWord(%item, 4) SPC getBarWord(%item, 5);
         $AlterVerse::invList.add(%id, %value);
      }
      DescriptionsRequest();
      if(BCToolbar.isAwake())
         BCToolbar.updateIcons();
   default:
      echo(%this.message);
      MessageBoxOK( "Could not get inventory list", 
                 %this.message );// canvas.popdialog(loginDlg);" );
   }
   %this.schedule(0, delete);
}

function DescriptionsRequest()
{  
   %request = new HTTPObject() {
      class = "getDescriptionList";
      status = "failure";
      message = "";
   };
   
   //www.alterverse.com/public_web_dev/getInvDescriptions.php
   %request.get($serverPath, $scriptPath @ "getAVDescriptions.php",
               "lang=" @ $pref::Language);
}

function getDescriptionList::process( %this )
{
   switch$( %this.status )
   {
   case "success":
      %cnt = getBarWordCount(%this.descriptions);
      for ( %i = 0; %i < %cnt; %i+=4)
      {
         for ( %j = 0; %j < 4; %j++ )
         {
            if ( %j == 0 )
            {
               %outStr = getBarWord(%this.descriptions, %i + %j);
               %id = %outStr;
            }
            else
               %outStr = %outStr @ "|" @ getBarWord(%this.descriptions, %i + %j);
         }
         $AlterVerse::invDesc[%id] = %outStr;
      }

      ServerRequest();
   default:
      echo(%this.message);
      MessageBoxOK( "Could not get inventory description list", 
                 %this.message);
                 //"canvas.popdialog(AvSelectionGui);");// canvas.popdialog(loginDlg);" );
   }
   %this.schedule(0, delete);
}

function ServerRequest()
{
   if ( isDevBuild() && $DesignMode )
      return;  // If this is design mode, we're already in the level
      
   if($JoinLobbyName $= "")
   {
      playIntroMusic($ServerName);
      connectToLobbyServer($serverToJoin);
   }
   else
   {
      playIntroMusic($JoinLobbyName);
      %request = new HTTPObject() {
         class = "lobbyServerRequest";
         status = "failure";
         message = "";
      };
 
      // get the address of the lobby server
      %request.get( $serverPath, $scriptPath @ "joinLobbyServer.php", "lobbyName="@$JoinLobbyName );
   }
}

// do something with the results of the query
function lobbyServerRequest::process( %this )
{
   switch$( %this.status )
   {
   case "success":
      connectToLobbyServer(%this.address);
   default:
      echo(%this.message);
      MessageBoxOK( "Could not connect", 
                 %this.message, 
                 "canvas.popdialog(AvSelectionGui);");// canvas.popdialog(loginDlg);" );
      stopIntroMusic();
   }
   %this.schedule(0, delete);
}
   
// perform the actual connection process
function connectToServer(%serverAddress, %spawnPoint, %isTransfer, %isResolved)
{
   // If we're connecting to a homestead server on our machine, the IP addresses
   // will be the same, so we can use the loopback address
   if ( $TAP::localIP !$= "" && !%isResolved )
   {
      if ( $TAP::localIP $= getSubStr(%serverAddress, 0, strlen($TAP::localIP)) )
      {
         $LocalTries = 0; // try 5 times before giving up
         ResolveLocalIP(%serverAddress, %spawnPoint, %isTransfer);
         return;
         //%address = "127.0.0.1" @ getSubStr(%address, strlen($TAP::localIP), -1);
      }
   }

   echo("connecting to server");
   %conn = new GameConnection(ServerConnection);
   //RootGroup.add(ServerConnection);
   %conn.setConnectArgs($currentUsername, getStringMD5($currentHash @ $currentPasswordHash), %spawnPoint, %isTransfer);
   %conn.setJoinPassword($Client::Password);
   %conn.connect(%serverAddress);
   $IsOneWorld=1;
   ServerConnection.setFirstPerson(true);
}

function playIntroMusic(%serverName)
{
   if ( isObject($IntroMusic) )
      return;  // Intro music is already playing...

   %musicFile = "art/sound/loading/" @ %serverName @ "Intro.ogg";
   
   if ( !isFile(%musicFile) )
      %musicFile = "art/sound/loading/AVIntro.ogg";

   $IntroMusic = new SFXProfile()
   {
      filename    = %musicFile;
      description = AudioMusicLoop2D;
   };
   $IntroMusicId = sfxPlay($IntroMusic);
}

function stopIntroMusic()
{
   if ( isObject($IntroMusic) )
   {
      sfxStop($IntroMusicId);
      $IntroMusic.delete();
      $IntroMusic = 0;
   }
}

function startIntroVideo()
{
   // Play the teleport video
   if ( !isObject(TeleportGui) )
      exec("art/gui/teleportGui.gui");
   
   Canvas.pushDialog(TeleportGui);
   schedule(10000, 0, "stopIntroVideo");
}

function stopIntroVideo()
{
   if ( !$TAP::isLoggedIn )
   {  // If the login hasn't completed, delay loading
      schedule(250, 0, stopIntroVideo);
      return;
   }

   // Start connection to the chat server
   connectClientChat();

   if ( ($TAP::serverID $= "") && $TAP::isDev && isFile("art/gui/devGuis/serverSel.gui") )
   {  // If it's a developer, bring up the server selection gui.
      if ( !isObject(ServerSelGui) )
      {
         exec("art/gui/devGuis/devProfiles.cs");
         exec("art/gui/devGuis/serverSel.gui");
         exec("art/gui/devGuis/serverSelGui.cs");

         if ( $pref::HostMultiPlayer $= "" )
            $pref::HostMultiPlayer = "1";
         exec("art/gui/devGuis/chooseLevel.gui");
         exec("art/gui/devGuis/chooseLevelGui.cs");
      }
      canvas.pushDialog(ServerSelGui);
   }
   else
   {  // For all others load the level selected by the login script.
      loadLoadingGui();
      connectToServer($serverToJoin, "", false, false);
   }

   Canvas.popDialog(TeleportGui);
   TeleportGui.delete();
   Canvas.repaint();

}

// clientCmdServerTransfer is called by the current game server 
// to transfer the client to a different server.
function clientCmdServerTransfer( %address, %spawnSphere, %hash, %serverName, %serverPrefix )
{
   LagIcon.setVisible(false);
   $currentPasswordHash = %hash;
   $ServerName = %serverName;
   $AlterVerse::serverPrefix = %serverPrefix;

   schedule(0, 0, disconnect, true);
   schedule(100, 0, loadLoadingGui);
   schedule(100, 0, connectToServer, %address, %spawnSphere, true, false);
}

function TeleportGui::onWake(%this)
{
   %screenExtent = Canvas.getExtent();
   %this.onResize(getWord(%screenExtent, 0), getWord(%screenExtent, 1));

   PutTLOnTop();  // Bring the TL gui back onto the canvas
}

function TeleportGui::onResize(%this, %newWidth, %newHeight)
{
   // The portal opening is 691x691 at 455, 98 on the 1600x900 frame image
   %wideAR = 16/9;
   %cropX = 0;
   %cropY = 0;
   if ( (%newWidth/%newHeight) < %wideAR )
   {
      %frameHeight = %newHeight;
      %frameWidth = mFloor(%newHeight * %wideAR);
      %frameX = mFloor((%newWidth - %frameWidth) / 2);
      %frameY = 0;
      %portScale = %newHeight/900;
      %cropX = mRound(((1600 * %portScale) - %newWidth) / 2);
      %portX = mRound(455 * %portScale) - %cropX;
      %portY = mRound(98 * %portScale);
   }
   else
   {
      %frameWidth = %newWidth;
      %frameHeight = mFloor(%newWidth / %wideAR);
      %frameY = mFloor((%newHeight - %frameHeight) / 2);
      %frameX = 0;
      %portScale = %newWidth/1600;
      %cropY = mRound(((900 * %portScale) - %newHeight) / 2);
      %portX = mRound(455 * %portScale);
      %portY = mRound(98 * %portScale) - %cropY;
   }
   %portSize = mRound(691 * %portScale);

   // The video res is 1280x720, 1296x736 with frame
   %vidScale = %portSize/736;
   %vidWidth = mRound(1296 * %vidScale);
   %vidX = %portX - (mRound((%vidWidth - %portSize) / 2));

   VideoFrame.resize(%vidX, %portY, %vidWidth, %portSize);
   VideoMask.resize(%frameX, %frameY, %frameWidth, %frameHeight);
}
