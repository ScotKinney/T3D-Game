/*
   chatCommands.cs
   
   functions dealing with the parsing of commands issued
   via the chat hud interface
   
   Guy Allard 2010
   Eric PL Smith 2010
*/

// handleChatCommand takes the entered string, and either calls the 
// local command if it's defined, otherwise it routes the command to the server
function handleChatCommand(%text)
{
   // check that 1st character is /
   if(strstr(%text,"/") != 0)
      return;
      
   // remove the / from the beginning
   %text = getSubStr(%text, 1, strlen(%text)-1);
   
   // and extract the command and the parameters from it
   %cmd = firstWord(%text);
   %params = restWords(%text);
   
   // call the local function if it's defined, otherwise send
   // the command to the server for processing
   if(isFunction(%cmd@"chatCmdHandler"))
      call(%cmd@"chatCmdHandler", %params);
   else
      commandToServer(addTaggedString(%cmd), %params);
}

// individual command handlers

//==============================================================================
// arns
//==============================================================================
function arnsChatCmdHandler(%params)
{
   echo("arns command handler");
   %lookup = new HTTPObject() {
      class = arnLookup;
      status = "failure";
   };
   %lookup.get( $serverPath, $scriptPath @ "checkArns.php", "uID="@$currentPlayerID );
}

// process the result from the lookup
function arnLookup::process(%this)
{
   switch$( %this.status )
   {
   case "success":
      echo("You have "@%this.arns@" active arns.");
   default:
      echo("could not find record");
   }
   %this.schedule(0, delete);  
}

//==============================================================================
// inv - Inventory panel
//==============================================================================
function invChatCmdHandler(%params)
{
   if (isObject( InventoryGui ))
   {
      if ( InventoryGui.isAwake() )
         Canvas.popDialog( InventoryGui );
      else
         Canvas.pushDialog( InventoryGui );
   }
}

function locationChatCmdHandler(%params)
{
   commandToServer('ShowMyLocation');
}

function tpChatCmdHandler(%params)
{
   commandToServer('TeleportToLevel', %params);
}

function bountyChatCmdHandler(%params)
{
   %amount = firstWord(%params);
   %tgtName = restWords(%params);
   if ( %amount < 1000 )
   {
      MainChatHud.addLine("Bounties must be at least 1000 Arns.", "a", true, true);
      return;
   }
   if ( %tgtName $= "" )
   {
      MainChatHud.addLine("Usage: /bounty amount name", "a", true, true);
      return;
   }
   commandToServer('SetBounty', %amount, %tgtName);
}

function unbountyChatCmdHandler(%params)
{
   commandToServer('RemoveBounty', %params);
}

function afkChatCmdHandler(%params)
{
   commandToServer('UseItem', 68, "1", "2");
}
