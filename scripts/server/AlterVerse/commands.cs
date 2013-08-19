/*
   commands.cs
   AlterVerse specific client->server command handling

   Guy Allard 2010
*/

// client is requesting to pickup an item
function ServerCmdPickupItem(%client, %objID)
{
   // prevent bogging down the server with multiple rapid clicks
   if(%client.canClick())
      %client.clickLock();
   else
      return;
   
   // the client sends us their ghostID for the object, so we need to convert
   // this to the server-side index for that object
   %obj = %client.resolveObjectFromGhostIndex(%objID);

   // check it exists   
   if(!isObject(%obj)) return;
   
   // and we must have a player
   if(!isObject(%client.player))
      return;
      
   // and the player must be alive
   if(%client.player.getState() $= "Dead")
      return;
   
   // now check that we can pick it up
   InitContainerRadiusSearch(%client.player.position, $AlterVerse::PickupRadius, $TypeMasks::ItemObjectType);
   %found = 0;
   //echo("searching");
   //echo(%obj);
   while ((%searchObj = containerSearchNext()) != 0)
   {
      //echo(%searchObj);
      if(%searchObj == %obj)
      {
         %found = 1;
         break;
      }
   }
   
   if(!%found)
      return;
      
   //echo("Picking it up!");
   %obj.getDatablock().onPickup(%obj, %client.player, 1);
}

// client is requesting to pickup a horse
function ServerCmdPickupHorse(%client, %objID, %skinName)
{
   // prevent bogging down the server with multiple rapid clicks
   if(%client.canClick())
      %client.clickLock();
   else
      return;

   %itemName = %skinName @ "_Horse_Item";
   %itemID = %itemName.ItemID;

   // the client sends us their ghostID for the object, so we need to convert
   // this to the server-side index for that object
   %obj = %client.resolveObjectFromGhostIndex(%objID);

   // check it exists   
   if(!isObject(%obj))
      return;

   // we must have a player
   if(!isObject(%client.player))
      return;

   // and the player must be alive
   if(%client.player.getState() $= "Dead")
      return;

   $AlterVerse::ItemNames[%itemID].onPickup(%obj, %client.player, 1);
}

// prevent the client from spamming the server by repeatedly clicking on items
// by introducing a delay between server responses to an item click event
function GameConnection::canClick(%client)
{
   if(%client.clickLocked $= "")
      %client.clickLocked = false;
   return !%client.clickLocked;  
}

function GameConnection::clickLock(%client)
{
   %client.clickLocked = true;
   %client.schedule(500, "clickUnlock");
}

function GameConnection::clickUnlock(%client)
{
   %client.clickLocked = false;
}

// player gender and skin request
function serverCmdSetPlayerSelections(%client, %gender, %skin, %avOptions)
{
   %client.gender = %gender;
   %client.skin = %skin;
   %client.avOptions = %avOptions;  // Avatar customization options (MAR)
   %client.giveClanWeapon();
}

// BloodClans Script Modification (MAR) - AFX Spell Casting >>>
function serverCmdsetAFXTarget(%client, %objID)
{
   // prevent bogging down the server with multiple rapid clicks
   if(%client.canClick())
      %client.clickLock();
   else
      return;

   %client.AFXTarget = 0;   
   // the client sends us their ghostID for the object, so we need to convert
   // this to the server-side index for that object
   %obj = %client.resolveObjectFromGhostIndex(%objID);

   // check it exists   
   if ( !isObject(%obj) )
      return;
   
   // and we must have a player
   if(!isObject(%client.player))
      return;
      
   // and the player must be alive
   if(%client.player.getState() $= "Dead")
      return;
      
   // Set the target
   %client.AFXTarget = %obj;
}
// BloodClans Script Modification (MAR) - AFX Spell Casting <<<

// BloodClans Script Modification (MAR) - Clan selection >>>
function serverCmdSetPlayerClan(%client, %clanID, %team)
{  // Put the user into their selected clan
   if ( !$isDedicated )
   {  // Dev Mode
      %client.team = %team;
      %client.clanID = %clanID;
      %client.clanRole = 0;
      %client.giveClanWeapon();
      %clanName = "";
      messageClient(%client, 'MsgClientClanChanged', "", %client.playerName, %clanName, %client.clanID, %client);
      return;
   }

   %index = $Server::ClanData.teams.getIndexFromKey(%clanID);
   %team = $Server::ClanData.teams.getValue(%index);
   if ( %team < 2 )
      return;  // Invalid clan ID

   if ( !isObject(%client.pData) )
      return; // We don't have a db ID for this player yet.

   // If the user is a clan leader, find a new clan leader
   %results = DB::Select("id", "Clan", "owner_user_id = " @ %client.pData.dbID);
   if ( %results.getNumRows() > 0 )
   {  // Entry was found so replace the leader
      %leaderlessClan = %results.id;
      %results.Delete();

      // Select a new leader
      //%results = DB::Select("TOP 1 c.id,c.citizen_name,c.networth,c.subscribe",
      ///*FROM*/              "citizen_one c " @
                            //"LEFT JOIN Clan_members cm ON c.id=cm.user_id", 
      ///*WHERE*/             "cm.Clan_id='"@%leaderlessClan@"' AND c.subscribe='1'",
      ///*Order BY*/          "c.networth DESC");
      %results = DB::Select("TOP 1 c.id,c.citizen_name,c.networth,c.subscribe",
      /*FROM*/              "citizen_one c " @
                            "LEFT JOIN Clan_members cm ON c.id=cm.user_id", 
      /*WHERE*/             "cm.Clan_id='"@%leaderlessClan@"'",
      /*Order BY*/          "c.networth DESC");
      if ( %results.getNumRows() > 0 )
      {
         %newLeaderId = %results.id;
         %newLeaderName = %results.citizen_name;
      }
      %results.delete();

      // Remove any records for them from the clan members table
      DB::Delete("Clan_members", "user_id='"@%newLeaderId@"'");

      // Assign them in the clan table
      %retVal = DB::Update("Clan", 
      /*SET*/    "owner_user_id='"@%newLeaderId@"'",
      /*WHERE*/  "id='"@%leaderlessClan@"'");
      if ( !%retVal )
         error("Failed replacing leader in clan " @ %leaderlessClan @ "!");
      else
         error(%newLeaderName @ " has become the new leader in clan " @ %leaderlessClan @ "!");
   }

   // Remove any records for this user from the clan members table
   DB::Delete("Clan_members", "user_id='"@%client.pData.dbID@"'");
   
   // Now put them in their new clan
   if(!DB::Insert("Clan_members",
   /*SET*/        "Clan_id, user_id",
   /*VALUES*/     "'"@%clanID@"', '"@%client.pData.dbID@"'"))
   {
      error("Failed adding client to the Clan_members table! Clan_id = " @ %clanID @ ", user_id = " @ %client.pData.dbID);
   }

   %client.team = %team;
   %client.clanID = %clanID;
   %client.clanRole = 0;
   %client.giveClanWeapon();

   %clanName = $Server::ClanData.clan[%client.team];
   messageClient(%client, 'MsgClientClanChanged', "", %client.playerName, %clanName, %client.clanID, %client);
   messageAllExcept(%client, -1, 'MsgClientClanChanged', '\c1%1 has joined the %2 clan.',
      %client.playerName, %clanName, %client.clanID, %client);
}
// BloodClans Script Modification (MAR) - Clan selection <<<

function serverCmdSetBounty(%client, %amount, %tgtName)
{
   //messageClient(%client, 'MsgItemPickup', '\c1You cannot set bounties yet.');
   if ( !isObject(%client.pData) )
      return;

   // First check that it's a clan leader making the request
   %results = DB::Select("id", "Clan", "owner_user_id = " @ %client.pData.dbID);
   if ( %results.getNumRows() > 0 )
      %clanID = %results.id;
   %results.Delete();
   if ( %clanID $= "" )
   {
      messageClient(%client, 'MsgItemPickup', '\c1You must be a clan leader to set bounties.');
      return; // Not a clan leader, ignore the request
   }

   // Verify that the target player exists and get their ID
   %results = DB::Select("ID",
   /*FROM*/              "citizen_one",
   /*WHERE*/             "citizen_name='"@ %tgtName @ "'");
   if(%results.getNumRows() > 0)
      %tgtID = %results.ID;
   %results.delete();
   if ( %tgtID $= "" )
   {
      messageClient(%client, 'MsgItemPickup', '\c1Target player %1 not found. No bounty set.', %tgtName);
      return;
   }

   // Get the current treasury amount
   // note - the sql interface doesnt seem to like bigint, so we cast it to varchar
   %results = DB::Select("name, cast(isNull(treasury_amount,0) as VARCHAR) as coins",
   /*FROM*/              "clan",
   /*WHERE*/             "id='"@ %clanID @ "'");
   if(%results.getNumRows() > 0)
   {
      %clanName = %results.name;
      %treasuryAmount = %results.coins;
   }
   %results.delete();
   %maxBounty = mFloor(%treasuryAmount / 2);

   // Find the amount that has already been committed to bounties
   %commitAmount = 0;
   %oldBounty = 0;
   %results = DB::Select("amount, target_id",
   /*FROM*/              "bounties",
   /*WHERE*/             "clan_id='"@ %clanID @ "'");
   %numBounties = %results.getNumRows();
   for ( %i = 0; %i < %numBounties; %i++ )
   {
      if ( %tgtID == %results.target_id )
         %oldBounty = %results.amount;
      else
         %commitAmount += %results.amount;
      if ( !%results.nextRow() )
         break;
   }
   %results.delete();

   if ( (%commitAmount + %amount) > %maxBounty )
   {  // There is not enough arns in the treasury
      %amountLeft = %maxBounty - %commitAmount;
      if ( %amountLeft > 0 )
         messageClient(%client, 'MsgItemPickup', '\c1You do not have enough Arns in your treasury to set this bounty. The maximum available is %1.', %amountLeft);
      else
         messageClient(%client, 'MsgItemPickup', '\c1You do not have enough Arns in your treasury to set another bounty.');
      return;
   }

   // Add the bounty to the table and put a message in the message board
   if ( %oldBounty == 0 )
   {  // Add a new bounty
      DB::Insert("bounties",
              "amount, target_id, clan_id",
              "'"@ %amount @ "', '"@ %tgtID @ "', '" @ %clanID @ "'");
      DB::Insert("MessageBoard",
              "user_id, clan_id, messagetext",
              "'"@ %client.pData.dbID @ "', " @
              "'"@ %clanID @ "', " @
              "'<b>A bounty of "@ %amount @" Arns has been placed on "@ %tgtName @".</b>'");
   }
   else
   {  // Change the amount on the existing bounty
      DB::Update("bounties",
      /*SET*/    "amount = '" @ %amount @"'",
      /*WHERE*/  "target_id='" @ %tgtID @"' AND clan_id='" @ %clanID @"'");
      DB::Insert("MessageBoard",
              "user_id, clan_id, messagetext",
              "'"@ %client.pData.dbID @ "', " @
              "'"@ %clanID @ "', " @
              "'<b>The bounty on "@ %tgtName @" has been updated to "@ %amount @" Arns.</b>'");
   }
   //messageClient(%client, 'MsgItemPickup', '\c1A bounty of %1 Arns has been placed on %2.', %amount, %tgtName);
   messageAll('MsgItemPickup', 'The %1 clan has set a bounty of %2 arns on %3!', %clanName, %amount, %tgtName);
}

function serverCmdRemoveBounty(%client, %tgtName)
{
   //messageClient(%client, 'MsgItemPickup', '\c1You cannot set or remove bounties yet.');
   if ( !isObject(%client.pData) )
      return;

   // First check that it's a clan leader making the request
   %results = DB::Select("id", "Clan", "owner_user_id = " @ %client.pData.dbID);
   if ( %results.getNumRows() > 0 )
      %clanID = %results.id;
   %results.Delete();
   if ( %clanID $= "" )
   {
      messageClient(%client, 'MsgItemPickup', '\c1You must be a clan leader to remove bounties.');
      return; // Not a clan leader, ignore the request
   }

   // Verify that the target player exists and get their ID
   if ( %tgtName $= "all" )
      %tgtID = 0;
   else
   {
      %results = DB::Select("ID",
      /*FROM*/              "citizen_one",
      /*WHERE*/             "citizen_name='"@ %tgtName @ "'");
      if(%results.getNumRows() > 0)
         %tgtID = %results.ID;
      %results.delete();
      if ( %tgtID $= "" )
      {
         messageClient(%client, 'MsgItemPickup', '\c1Target player %1 not found. No bounty removed.', %tgtName);
         return;
      }
   }
   
   if ( %tgtID > 0 )
   {
      // Check that the player has a bounty on them
      %results = DB::Select("id",
      /*FROM*/              "bounties",
      /*WHERE*/             "target_id='" @ %tgtID @ "' AND clan_id='" @ %clanID @"'");
      %numBounties = %results.getNumRows();
      %results.delete();
      if ( %numBounties <= 0 )
      {
         messageClient(%client, 'MsgItemPickup', '\c1There is no bounty on %1 to remove.', %tgtName);
         return;
      }

      DB::Delete("bounties", "target_id='" @ %tgtID @ "' AND clan_id='" @ %clanID @"'");
      DB::Insert("MessageBoard",
              "user_id, clan_id, messagetext",
              "'"@ %client.pData.dbID @ "', " @
              "'"@ %clanID @ "', " @
              "'<b>The bounty on "@ %tgtName @" has been removed.</b>'");
      messageClient(%client, 'MsgItemPickup', '\c1The bounty on %1 has been removed.', %tgtName);
   }
   else
   {
      // Check that there are bounties to remove
      %results = DB::Select("id",
      /*FROM*/              "bounties",
      /*WHERE*/             "clan_id='" @ %clanID @"'");
      %numBounties = %results.getNumRows();
      %results.delete();
      if ( %numBounties <= 0 )
      {
         messageClient(%client, 'MsgItemPickup', '\c1There are no bounties to remove.');
         return;
      }

      DB::Delete("bounties", "clan_id='" @ %clanID @"'");
      DB::Insert("MessageBoard",
              "user_id, clan_id, messagetext",
              "'"@ %client.pData.dbID @ "', " @
              "'"@ %clanID @ "', " @
              "'<b>All bounties have been removed.</b>'");
      messageClient(%client, 'MsgItemPickup', '\c1All bounties have been removed.');
   }
}
