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

// Load up core script base
loadDir("core"); // Should be loaded at a higher level, but for now leave -- SRZ 11/29/07

//-----------------------------------------------------------------------------
// Package overrides to initialize the mod.
package fps {

function displayHelp() {
   Parent::displayHelp();
   error(
      "Fps Mod options:\n"@
      "  -dedicated             Start as dedicated server\n"@
      "  -connect <address>     For non-dedicated: Connect to a game at <address>\n" @
      "  -mission <filename>    For dedicated: Load the mission\n"
   );
}

function parseArgs()
{
   // Call the parent
   Parent::parseArgs();

   // Arguments, which override everything else.
   for (%i = 1; %i < $Game::argc ; %i++)
   {
      %arg = $Game::argv[%i];
      %nextArg = $Game::argv[%i+1];
      %hasNextArg = $Game::argc - %i > 1;
   
      switch$ (%arg)
      {
         //--------------------
         case "-dedicated":
            $TAP::isDedicated = true;
            enableWinConsole(true);
            $argUsed[%i]++;

         //--------------------
         case "-mission":
            $argUsed[%i]++;
            if (%hasNextArg) {
               $missionArg = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -mission <filename>");

         //--------------------
         case "-connect":
            $argUsed[%i]++;
            if (%hasNextArg) {
               $JoinGameAddress = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -connect <ip_address>");

         //--------------------
         case "-name": // gives the server a name
            $argUsed[%i]++;
            if(%hasNextArg)
            {
               $AlterVerse::serverName = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
               error("-name used without specifying a name for the server");

         //--------------------
         // manifest file root location
         case "-manifestRoot":
            $argUsed[%i]++;
            if(%hasNextArg)
            {
               $AlterVerse::manifestRoot = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
            {
               $AlterVerse::manifestRoot = "";
               error("-manifestRoot used without specifying a path");
            }

         //--------------------
         // manifest file location relative to manifest root
         case "-manifestFile":
            $argUsed[%i]++;
            if(%hasNextArg)
            {
               $AlterVerse::manifestFile = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
            {
               $AlterVerse::manifestFile = "";
               error("-manifestFile used without specifying a file");
            }
            if ( $AlterVerse::manifestRoot $= "" )
               $AlterVerse::manifestRoot = "http://www.alterverse.com/aureus-download/stream/";

         //--------------------
         case "-initialLogin": // determines whether this server allows connections from newly logged in clients
            $AlterVerse::allowInitialLogin = true;
            $argUsed[%i]++;

         //--------------------
         // The type of server being launched. 0-Listen server. Greater than 0
         // are all dedicated servers. 1-Homeworld. 2-quest level. 3-Homestead
         case "-worldType":
            $argUsed[%i]++;
            if(%hasNextArg)
            {
               $AlterVerse::worldType = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
            {
               $AlterVerse::worldType = "3";
               error("-worldType used without specifying a value");
            }

         //--------------------
         // The homeworld ID for this server
         case "-worldID":
            $argUsed[%i]++;
            if(%hasNextArg)
            {
               $AlterVerse::worldID = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
            {
               $AlterVerse::worldID = "0";
               error("-worldID used without specifying a value");
            }

         //--------------------
         // The kingdom # for this server
         case "-kingdom":
            $argUsed[%i]++;
            if(%hasNextArg)
            {
               $AlterVerse::kingdom = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
            {
               $AlterVerse::kingdom = "0";
               error("-kingdom used without specifying a value");
            }

         //--------------------
         // The user ID for this servers owner
         case "-owner":
            $argUsed[%i]++;
            if(%hasNextArg)
            {
               $AlterVerse::serverOwner = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
            {
               $AlterVerse::serverOwner = "10";
               error("-owner used without specifying a value");
            }

         //--------------------
         // The text designation for this server
         case "-desi":
            $argUsed[%i]++;
            if(%hasNextArg)
            {
               $AlterVerse::serverDesi = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
            {
               $AlterVerse::serverDesi = "";
               error("-desi used without specifying a text designation");
            }
      }
   }
}

function onStart()
{
   // The core does initialization which requires some of
   // the preferences to loaded... so do that first.  
   exec( "./client/defaults.cs" );
   exec( "./server/defaults.cs" );
             
   Parent::onStart();
   echo("\n--------- Initializing Directory: scripts ---------");

   // Load the scripts that start it all...
   exec("./client/init.cs");
   exec("./server/init.cs");
   
   // Init the physics plugin.
   //physicsInit();  // default is bullet
   physicsInit("Torque");
      
   // Start up the audio system.
   sfxStartup();

   // Server gets loaded for all sessions, since clients
   // can host in-game servers, but most won't, so don't init until requested
   // initServer();

   // Start up in either client, or dedicated server mode
   if ($TAP::isDedicated)
      initDedicated();
   else
      initClient();
}

function onExit()
{
   // Ensure that we are disconnected and/or the server is destroyed.
   // This prevents crashes due to the SceneGraph being deleted before
   // the objects it contains.
   if ($TAP::isDedicated)
      destroyServer();
   else if ( isFunction("disconnect") )
   {
      disconnect();
      echo("Exporting client prefs");
      export("$pref::*", "./client/prefs.cs", False);
   }
   
   // Destroy the physics plugin.
   physicsDestroy();

   //BanList::Export("./server/banlist.cs");

   //Parent::onExit();
}

}; // package fps

// Activate the game package.
activatePackage(fps);
