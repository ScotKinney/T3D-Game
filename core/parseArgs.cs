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
// Support functions used to manage the directory list

function pushFront(%list, %token, %delim)
{
   if (%list !$= "")
      return %token @ %delim @ %list;
   return %token;
}

function pushBack(%list, %token, %delim)
{
   if (%list !$= "")
      return %list @ %delim @ %token;
   return %token;
}

function popFront(%list, %delim)
{
   return nextToken(%list, unused, %delim);
}

//-----------------------------------------------------------------------------
// The default global argument parsing

function defaultParseArgs()
{
   for ($i = 1; $i < $Game::argc ; $i++)
   {
      $arg = $Game::argv[$i];
      $nextArg = $Game::argv[$i+1];
      $hasNextArg = $Game::argc - $i > 1;
      $logModeSpecified = false;

      // Check for dedicated run
      if( stricmp($arg,"-dedicated") == 0  )
      {
         $userDirs = $defaultGame;
         $dirCount = 1;
         $TAP::isDedicated = true;
      }

      switch$ ($arg)
      {
         //--------------------
         case "-log":
            $argUsed[$i]++;
            if ($hasNextArg)
            {
               // Turn on console logging
               if ($nextArg != 0)
               {
                  // Dump existing console to logfile first.
                  $nextArg += 4;
               }
               setLogMode($nextArg);
               $logModeSpecified = true;
               $argUsed[$i+1]++;
               $i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -log <Mode: 0,1,2>");

         //--------------------
         case "-dir":
            $argUsed[$i]++;
            if ($hasNextArg)
            {
               // Append the mod to the end of the current list
               $userDirs = strreplace($userDirs, $nextArg, "");
               $userDirs = pushFront($userDirs, $nextArg, ";");
               $argUsed[$i+1]++;
               $i++;
               $dirCount++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -dir <dir_name>");
               
         //--------------------
         case "-level":
            $argUsed[$i]++;
            if ($hasNextArg)
            {
               %hasExt = strpos($nextArg, ".mis");
               if(%hasExt == -1)
               {
                  $levelToLoad = $nextArg @ " ";
                  
                  for(%i = $i + 2; %i < $Game::argc; %i++)
                  {
                     %arg = $Game::argv[%i];
                     %hasExt = strpos(%arg, ".mis");
                     
                     if(%hasExt == -1)
                     {
                        $levelToLoad = $levelToLoad @ %arg @ " ";
                     } else
                     {
                        $levelToLoad = $levelToLoad @ %arg;
                        break;
                     }
                  }
               } else
               $levelToLoad = $nextArg;
               $argUsed[$i+1]++;
               $i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -level <level file name (no path), with or without extension>");

         //-------------------
         case "-help":
            $displayHelp = true;
            $argUsed[$i]++;

         //-------------------
         case "-compileAll":
            $compileAll = true;
            $argUsed[$i]++;
            
         //-------------------
         case "-compileTools":
            $compileTools = true;
            $argUsed[$i]++;

         //-------------------
         case "-genScript":
            $genScript = true;
            $argUsed[$i]++;
            
         //-------------------
         case "-tap":
            $TAP::isTappedIn = true;
            $argUsed[$i]++;
            $currentPlayerID = $Game::argv[$i+1];
            $argUsed[$i+1]++;
            $currentHash = $Game::argv[$i+2];
            $argUsed[$i+2]++;
            $i += 2;
            echo("Tapped In! ID = " @ $currentPlayerID @ ", Hash = " @ $currentHash);
            
         //-------------------
         case "-serverID":
            $argUsed[$i]++;
            $TAP::serverID = $Game::argv[$i+1];
            $argUsed[$i+1]++;
            $i++;

         //-------------------
         case "-cacheDTS":
            $generateCachedDTS = true;
            $argUsed[$i]++;
         
         //-------------------
         case "-generateItemData":
            $generateItemData = true;
            $argUsed[$i]++;
         
         //-------------------
         case "-bindAddress": // gives the server a ip
            $argUsed[$i]++;
            if ($hasNextArg)
            {
               $AlterVerse::BindAddress = $nextArg;
               $argUsed[$i+1]++;
               $i++;
            }

         //-------------------
         case "-showAddress": // The address published to the database
            $argUsed[$i]++;
            if ($hasNextArg)
            {
               $AlterVerse::ShowAddress = $nextArg;
               $argUsed[$i+1]++;
               $i++;
            }

         //-------------------
         case "-startPort": // gives the first port to try binding to
            $argUsed[$i]++;
            if ($hasNextArg)
            {
               $AlterVerse::StartPort = $nextArg;
               $argUsed[$i+1]++;
               $i++;
            }

         //-------------------
         case "-staging":
            $AlterVerse::UseStaging = true;
            $argUsed[$i]++;

         //-------------------
         case "-murmur":
            $argUsed[$i]++;
            $Murmur::serverIP = $Game::argv[$i+1];
            $argUsed[$i+1]++;
            $i++;

         //-------------------
         default:
            $argUsed[$i]++;
            if($userDirs $= "")
               $userDirs = $arg;
      }
   }
}
