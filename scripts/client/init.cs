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

//    (c) pref::Master[n]                 List of master servers
//    (c) pref::Net::RegionMask
//    (c) pref::Client::ServerFavoriteCount
//    (c) pref::Client::ServerFavorite[FavoriteCount]
//    .. Many more prefs... need to finish this off

// Moves, not finished with this either...
//    (c) firstPerson
//    $mv*Action...

//-----------------------------------------------------------------------------
// These are variables used to control the shell scripts and
// can be overriden by mods:

//-----------------------------------------------------------------------------
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
   exec("art/gui/ChatHud.gui");
   exec("art/gui/playerList.gui");
   exec("art/gui/hudlessGui.gui");

   // Load up the shell GUIs
   //exec("art/gui/mainMenuGui.gui");
   //exec("art/gui/joinServerDlg.gui");
   //exec("art/gui/endGameGui.gui");
   exec("art/gui/StartupGui.gui");           // Splash screens
   exec("scripts/gui/startupGui.cs");
   exec("art/gui/loadingGui.gui");
   exec("art/gui/optionsDlg.gui");
   exec("art/gui/remapDlg.gui");
   
   // Gui scripts
   exec("./playerList.cs");
   exec("./chatHud.cs");
   exec("./messageHud.cs");
   exec("scripts/gui/playGui.cs");
   exec("scripts/gui/loadingGui.cs");
   exec("scripts/gui/optionsDlg.cs");

   // Client scripts
   exec("./client.cs");
   exec("./game.cs");
   exec("./missionDownload.cs");
   exec("./serverConnection.cs");
   exec("scripts/client/launchScript.cs");

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
   loadStartup();
}


//-----------------------------------------------------------------------------

function loadMainMenu()
{
   // Startup the client guis
   if ( $TAP::isTappedIn )
   {
      if ( Canvas.getContent() != BlackGui.getId() ) 
         Canvas.setContent( BlackGui );
      if ( !$TAP::isLoggedIn )
      {  // If the login hasn't completed, delay the vid
         schedule(250, 0, loadMainMenu);
         return;
      }
      startIntroVideo();
   }
   else
   {
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
