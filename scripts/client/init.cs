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
// loadMaterials - load all materials.cs files
//-----------------------------------------------------------------------------
function loadMaterials()
{
   // Load any materials files for which we only have DSOs.
   for( %file = findFirstFile( "*/materials.cs.dso" );
        %file !$= "";
        %file = findNextFile( "*/materials.cs.dso" ))
   {
      if ( getSubStr(%file, 0, 11) $= "art/Worlds/" )
         continue;

      // Only execute, if we don't have the source file.
      %csFileName = getSubStr( %file, 0, strlen( %file ) - 4 );
      if( !isFile( %csFileName ) )
         exec( %csFileName );
   }

   // Load all source material files.
   for( %file = findFirstFile( "*/materials.cs" );
        %file !$= "";
        %file = findNextFile( "*/materials.cs" ))
   {
      if ( getSubStr(%file, 0, 11) $= "art/Worlds/" )
         continue;
      exec( %file );
   }
}

function loadWorldMaterials()
{
   %filter = $WorldPath @ "/*/materials.cs";
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

   // Script for localizing server mesages
   exec("./localizedMsg.cs");

   // Load up the Game GUIs
   exec("art/gui/PlayGui.gui");
   exec("art/gui/chat/ChatHud.gui");
   exec("./chatHud.cs");
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
   exec("scripts/gui/loadingGui.cs");
   exec("scripts/gui/optionsDlg.cs");

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

   if( isFile( "./audioData.cs" ) )
      exec( "./audioData.cs" );

   // Show the splash screen.
   Canvas.setCursor("DefaultCursor");

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

function initWorld(%worldName)
{  // Mount the world and initialize textures and materials
   if ( $MountedWorld $= %worldName )
      return;  // We already have this world mounted and initialized

   %oldGroup = $instantGroup;
   $instantGroup = 0;

   if ( $MountedWorld !$= "" )
   {  // Remove the objects from last world
      if( isObject( ClientWorldMaterials ) )
         ClientWorldMaterials.delete();

      // Remove textures from the pool
      cleanupTexturePool();
      flushTextureCache();

      // Unmount the world zip
      %zipName = strlwr("art/worlds/" @ $MountedWorld @ ".avw");
      if ( isFile(%zipName) )
         unmountWorld(%zipName);
   }

   // Mount the new world zip
   %zipName = strlwr("art/worlds/" @ %worldName @ ".avw");
   if ( isFile(%zipName) )
      mountWorld(%zipName);
   $MountedWorld = %worldName;

   %matGroup = new SimGroup(ClientWorldMaterials);
   $instantGroup = %matGroup;

   reloadTextures();
   loadWorldMaterials();
   reInitMaterials();

   $instantGroup = %oldGroup;
}
