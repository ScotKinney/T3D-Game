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
// Variables used by client scripts & code.  The ones marked with (c)
// are accessed from code.  Variables preceeded by Pref:: are client
// preferences and stored automatically in the ~/client/prefs.cs file
// in between sessions.
//
//    (c) Client::MissionFile             Mission file name
//    ( ) Client::Password                Password for server join

//    (?) Pref::Player::CurrentFOV
//    (?) Pref::Player::DefaultFov
//    ( ) Pref::Input::KeyboardTurnSpeed

//-----------------------------------------------------------------------------
// These are variables used to control the shell scripts and
// can be overriden by mods:

//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// loadMaterials - load all materials.cs files that aren't in 
// packs, players or worlds...that only leaves art/inv and art/SpellSystem.
//-----------------------------------------------------------------------------
function loadMaterials()
{
   %filter = "art/inv/*/materials.cs";
   loadDirMaterials(%filter);
   %filter = "art/SpellSystem/*/materials.cs";
   loadDirMaterials(%filter);
}

function loadDirMaterials(%filter)
{
   // Load any materials files for which we only have DSOs.
   for( %file = findFirstFile( %filter @ ".dso" );
        %file !$= "";
        %file = findNextFile( %filter @ ".dso" ))
   {
      // Only execute, if we don't have the source file.
      %csFileName = getSubStr( %file, 0, strlen( %file ) - 4 );
      if( !isFile( %csFileName ) )
         exec( %csFileName );
   }

   // Load all source material files.
   for( %file = findFirstFile( %filter );
        %file !$= "";
        %file = findNextFile( %filter ))
   {
      exec( %file );
   }
}

function reloadMaterials()
{
   reloadTextures();
   loadMaterials();
   reInitMaterials();
   reloadCurtainMaterials();
}

function loadLocalizationFiles()
{  // exec the localization files for chat messages and gui text
   %msgFileName = "scripts/Lang/chatText_" @ $pref::Language @ ".cs";
   if ( !isFile(%msgFileName) )
   {
      $pref::Language = "eng";
      %msgFileName = "scripts/Lang/chatText_" @ $pref::Language @ ".cs";
   }
   exec(%msgFileName);

   %gtFileName = "scripts/Lang/guiText_" @ $pref::Language @ ".cs";
   if ( !isFile(%gtFileName) )
   {
      $pref::Language = "eng";
      %gtFileName = "scripts/Lang/guiText_" @ $pref::Language @ ".cs";
   }
   exec(%gtFileName);
}

//-----------------------------------------------------------------------------
function initClient()
{
   echo("\n--------- Initializing " @ $appName @ ": Client Scripts ---------");

   // Make sure this variable reflects the correct state.
   $TAP::isDedicated = false;

   // Game information used to query the master server
   $Client::GameTypeQuery = $appName;
   $Client::MissionTypeQuery = "Any";

   // These should be game specific GuiProfiles.  Custom profiles are saved out
   // from the Gui Editor.  Either of these may override any that already exist.
   exec("art/gui/defaultGameProfiles.cs");
   exec("art/gui/customProfiles.cs"); 
   exec("art/gui/avProfiles.cs"); 

   loadLocalizationFiles();   // Language specific files
   
   // The common module provides basic client functionality
   initBaseClient();

   // Use our prefs to configure our Canvas/Window
   configureCanvas();

   // Do console initialization for mumble
   InitMumble();

   // Script for localizing server mesages
   exec("./localizedMsg.cs");

   // Load up the Game GUIs
   exec("art/gui/PlayGui.gui");
   exec("art/gui/gameHUD.gui");
   exec("art/gui/riftPlayGui.gui");
   exec("art/gui/chat/ChatHud.gui");
   exec("./chatHud.cs");
   exec("./alterVerse/chatCommands.cs");
   exec("./chatParties.cs");
   exec("art/gui/chat/chatPopup.gui");
   exec("scripts/gui/chatPopupGui.cs");
   exec("art/gui/chat/userPopup.gui");
   exec("scripts/gui/userPopupGui.cs");
   exec("art/gui/chat/userList.gui");
   exec("scripts/gui/userListGui.cs");
   exec("art/gui/hudlessGui.gui");

   // Load up the shell GUIs
   exec("art/gui/StartupGui.gui");           // Splash screens
   exec("scripts/gui/startupGui.cs");
   exec("art/gui/loadingGui.gui");
   exec("art/gui/optionsDlg.gui");
   exec("art/gui/remapDlg.gui");
   
   // Gui scripts
   exec("./messageHud.cs");
   exec("scripts/gui/playGui.cs");
   exec("scripts/gui/riftPlayGui.cs");
   exec("scripts/gui/loadingGui.cs");
   exec("scripts/gui/optionsDlg.cs");

   // temporary toolbar scripts
   exec("art/gui/InventoryGui.gui");
   exec("scripts/gui/avToolbar.cs");
   exec("art/gui/arnTransfer.gui");
   exec("scripts/gui/arnTransferGui.cs");

   // Client scripts
   exec("./client.cs");
   exec("./game.cs");
   exec("./missionDownload.cs");
   exec("./serverConnection.cs");
   exec("./launchScript.cs");
   exec("./AlterVerse/ResolveIP.cs");
   exec("./AlterVerse/clientChat.cs");

   exec("core/art/gui/toolsLoading.gui");
   exec("./AlterVerse/clientTools.cs");

   // Load useful Materials
   exec("./shaders.cs");

   // Default player key bindings
   exec("./default.bind.cs");
   exec("art/gui/CodCustomProfiles.cs");
   exec("art/gui/craftingGui.gui");
   exec("art/gui/craftingGui.cs");
   exec("./craftingGui_clientSideScripts.cs");
	  

   if (isFile("./config.cs"))
      exec("./config.cs");

   loadMaterials();

   // Really shouldn't be starting the networking unless we are
   // going to connect to a remote server, or host a multi-player
   // game.
   setNetPort(0);

   // Copy saved script prefs into C++ code.
   setDefaultFov( $pref::Player::defaultFov );
   setZoomSpeed( $pref::Player::zoomSpeed );

   // Load a cursor
   Canvas.setCursor("DefaultCursor");

   // Initialize the curtain manager
   exec( "./curtainManager.cs" );
   setGuiCurtainMat("GuiCurtain_Mat");
   $CurtainManager::guiDistance = 5.0;
   setHUDCurtainMat("HUDCurtain_Mat");
   $CurtainManager::hudDistance = 5.2;
   $InRiftView = false;
   
   // Cheesy way to determine if the rift is connected and turned on
   // TODO: Replace with true detection of OVR display on.
   %curRot = getOVRSensorEulerRotation(0);
   if ( VectorLen(%curRot) > 0 )
      toggleRift(1);

   // Show the splash screen.
   if ( $TAP::isTappedIn )
      loadMainMenu();
   else
      loadStartup();
}


//-----------------------------------------------------------------------------

function loadMainMenu()
{
   // Startup the client guis
   if ( $TAP::isTappedIn )
   {  // If tapped in, start the game login process
      TapInStage1();

      if ( Canvas.getContent() != BlackGui.getId() ) 
         Canvas.setContent( BlackGui );
      startIntroVideo();
   }
   else
   {  // Otherwise show the login screen
      if ( !isObject( LoginGui ) )
      {
         exec("art/gui/AVFrontEnd/feProfiles.cs");
         exec("art/gui/AVFrontEnd/login.gui");
         exec("scripts/gui/loginGui.cs");
      }
      Canvas.setContent( LoginGui );
   }
   
   Canvas.setCursor("DefaultCursor");
}

function loadLoadingGui(%displayText)
{
   if ( Canvas.getContent() == LoadingGui.getId() )
      return;

   Canvas.setContent("LoadingGui");
   LoadingProgress.setValue(1);

   if (%displayText !$= "")
   {
      LoadingProgressTxt.setValue(%displayText);
   }
   else
   {
      LoadingProgressTxt.setValue("WAITING FOR SERVER");
   }

   Canvas.repaint();
}

function unmountWorldPacks()
{
   if ( $MountedWorld !$= "" )
   {  // Remove any lingering objects from last world
      if( isObject( ClientWorldMaterials ) )
         ClientWorldMaterials.delete();
      if( isObject( ClientMissionSounds ) )
         ClientMissionSounds.delete();

      // Remove textures from the pool
      cleanupTexturePool();
      flushTextureCache();

      // Unmount the world zip
      %zipName = strlwr("art/worlds/" @ $MountedWorld @ ".avw");
      if ( isFile(%zipName) )
         unmountWorld(%zipName);

      // Unmount the avatar pack
      %zipName = strlwr("art/players/" @ $LoadedAvSet @ ".avp");
      if ( isFile(%zipName) )
         unmountArtPack(%zipName);

      // Unmount all art packs
      %packCount = getFieldCount($LoadedArtPacks);
      for (%i = 0; %i < %packCount; %i++)
      {
         %packName = "art/packs/" @ getField($LoadedArtPacks, %i) @ ".avp";
         %zipName = strlwr(%packName);
         if ( isFile(%zipName) )
            unmountArtPack(%zipName);
      }
   }
}

function mountWorldPacks(%worldName)
{  // Mount the world and all needed art packs
   if ( $MountedWorld $= %worldName )
      return;  // We already have this world mounted and initialized

   if ( $MountedWorld !$= "" )
      unmountWorldPacks();

   // Mount the world zip
   %zipName = strlwr("art/worlds/" @ %worldName @ ".avw");
   if ( isFile(%zipName) )
      mountWorld(%zipName);
   $MountedWorld = %worldName;
   
   // exec the config file to get the new AvSet and pack list
   // TODO: This is temporary needs read from DB on server and passed to client
   exec("art/worlds/" @ %worldName @ "/config.cs");

   // Mount the avatar pack
   %packName = strlwr("art/players/" @ $AlterVerse::AvSet @ ".avp");
   if ( isFile(%packName) )
      mountArtPack(%packName);
   $LoadedAvSet = $AlterVerse::AvSet;

   // Mount all art packs
   %packCount = getFieldCount($AlterVerse::ArtPacks);
   for (%i = 0; %i < %packCount; %i++)
   {
      %packName = "art/Packs/" @ getField($AlterVerse::ArtPacks, %i) @ ".avp";
      %zipName = strlwr(%packName);
      if ( isFile(%zipName) )
         mountArtPack(%zipName);
   }
   $LoadedArtPacks = $AlterVerse::ArtPacks;
}

function loadWorldSFX(%makeClientGroup)
{  // Load all SFXProfiles and Ambiences needed by the world
   if ( %makeClientGroup )
   {  // Create a group for the audio data blocks
      %oldGroup = $instantGroup;
      $instantGroup = 0;
      if( isObject( ClientMissionSounds ) )
         ClientMissionSounds.delete();
      %newGroup = new SimGroup(ClientMissionSounds);
      $instantGroup = %newGroup;
   }

   // Any singleton SFXProfiles that the mission references by name on the server
   %packCount = getFieldCount($LoadedArtPacks);
   for (%i = 0; %i < %packCount; %i++)
   {
      %sfxFile = "art/Packs/" @ getField($LoadedArtPacks, %i) @ "/audioSFX.cs";
      if ( isFile(%sfxFile) || isFile(%sfxFile @ ".dso") )
         exec(%sfxFile);
   }

   %sfxFile = "art/players/" @ $LoadedAvSet @ "/audioSFX.cs"; 
   if ( isFile(%sfxFile) || isFile(%sfxFile @ ".dso") )
      exec(%sfxFile);

   %sfxFile = $WorldPath @ "/audioSFX.cs";
   if ( isFile(%sfxFile) || isFile(%sfxFile @ ".dso") )
      exec(%sfxFile);

   %ambienceFile = $WorldPath @ "/audioAmbiences.cs";
   if ( isFile(%ambienceFile) || isFile(%ambienceFile @ ".dso") )
      exec(%ambienceFile);

   if ( %makeClientGroup )
      $instantGroup = %oldGroup;
}

function loadWorldMats(%makeClientGroup)
{  // Load all materials needed by the world
   if ( %makeClientGroup )
   {  // Create a group for the materials
      if( isObject( ClientWorldMaterials ) )
         ClientWorldMaterials.delete();
      %oldGroup = $instantGroup;
      $instantGroup = 0;
      %matGroup = new SimGroup(ClientWorldMaterials);
      $instantGroup = %matGroup;
   }

   reloadTextures();

   %packCount = getFieldCount($LoadedArtPacks);
   for (%i = 0; %i < %packCount; %i++)
   {
      %filter = "art/Packs/" @ getField($LoadedArtPacks, %i) @ "/*/materials.cs";
      loadDirMaterials(%filter);
   }

   %filter = "art/players/" @ $LoadedAvSet @ "/*/materials.cs";
   loadDirMaterials(%filter);

   %filter = $WorldPath @ "/*/materials.cs";
   loadDirMaterials(%filter);

   reInitMaterials();

   if ( %makeClientGroup )
      $instantGroup = %oldGroup;

   reloadCurtainMaterials();
}
