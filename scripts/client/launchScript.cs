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
   
// stream required assets if needed, otherwise establish a connection immediately
function connectToLobbyServer(%serverAddress)
{
   if ( $Server::PublicIP !$= "" )
   {  // If testing a dedicated server on the same machine as the client
      if ( $Server::PublicIP $= getSubStr(%serverAddress, 0, strlen($Server::PublicIP)) )
      {  // Use loopback address to connect.
         %serverAddress = "127.0.0.1" @ getSubStr(%serverAddress, strlen($Server::PublicIP), -1);
      }
   }
   
   if(!$AlterVerse::Exec::Server && $manifestFile !$= "" && $manifestRoot !$= "")
   {  // Check manifest files for updated assets
      Canvas.schedule(0, pushDialog, DownloadProgressGui);
      StreamManager.streamLevelAssets($manifestRoot @ $manifestFile, $manifestRoot,
         "Canvas.popDialog(DownloadProgressGui);connectToServer(\"" @ %serverAddress @ "\");");
   }
   else
      connectToServer(%serverAddress);
}

// perform the actual connection process
function connectToServer(%serverAddress)
{
   echo("connecting to server");
   %conn = new GameConnection(ServerConnection);
   //RootGroup.add(ServerConnection);
   %conn.setConnectArgs($currentUsername, getStringMD5($currentPassword @ $currentPasswordHash), "", false);
   %conn.connect(%serverAddress);
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
   // Start connection to the chat server
   connectClientChat();

   // Play the teleport video
   if ( !isObject(TeleportGui) )
      exec("art/gui/teleportGui.gui");
   
   Canvas.pushDialog(TeleportGui);
   schedule(10000, 0, "stopIntroVideo");
}

function stopIntroVideo()
{
   //Canvas.pushDialog(AvSelectionGui);
   playIntroMusic($ServerName);
   Canvas.pushDialog(LoadingGui);
   LoadingProgress.setValue(1);
   //AVMainGui.setActive(true);

   Canvas.popDialog(TeleportGui);
   TeleportGui.delete();
   Canvas.repaint();

   if ( $DesignMode )
      StartLevel($curentMission);
   else
      AvSelectionGui.getClanInfo();
      //InventoryRequest();
}

function TeleportGui::onWake(%this)
{
   %screenExtent = Canvas.getExtent();
   %this.onResize(getWord(%screenExtent, 0), getWord(%screenExtent, 1));
}

function TeleportGui::onResize(%this, %newWidth, %newHeight)
{
   // The portal opening is 894x672 at 357, 118 on the 1600x900 frame image
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
      %portX = mRound(357 * %portScale) - %cropX;
      %portY = mRound(118 * %portScale);
   }
   else
   {
      %frameWidth = %newWidth;
      %frameHeight = mFloor(%newWidth / %wideAR);
      %frameY = mFloor((%newHeight - %frameHeight) / 2);
      %frameX = 0;
      %portScale = %newWidth/1600;
      %cropY = mRound(((900 * %portScale) - %newHeight) / 2);
      %portX = mRound(357 * %portScale);
      %portY = mRound(118 * %portScale) - %cropY;
   }
   %portWidth = mRound(894 * %portScale);
   %portHeight = mRound(672 * %portScale);

   // The video res is 1280x720
   %vidScale = %portHeight/720;
   %vidWidth = mRound(1280 * %vidScale);
   %vidX = %portX - (mRound((%vidWidth - %portWidth) / 2));

   VideoFrame.resize(%vidX, %portY, %vidWidth, %portHeight);
   VideoMask.resize(%frameX, %frameY, %frameWidth, %frameHeight);
}
