/*
   clanTreasury.cs
   
   Treasury item
   
   Guy Allard 2011
*/

$AlterVerse::TreasuryRespawnTime = 5; // 10 minutes
$AlterVerse::AttackAlertID = 51594; // id of the 'Attack Alert' account used for messages

$Treasury::HitMin = 3; // Default treasury hit gets between 3 and 6% of treasury
$Treasury::HitMax = 6;
$Treasury::InRaidHour = false;

datablock ItemData(ClanTreasuryItem)
{
   category = "AlterVerse Objects";
   className = ClanTreasury;
   shapeFile = "art/inv/items/chests/chest.dts";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
};

// onAdd
// fill out treasury information from the database
//function ClanTreasury::onAdd(%this, %obj)
//{
   //if ( %obj.clanName $= "" )
      //%this.updateStats(%obj);
   //else
   //{
      //%displayName = %obj.clanName SPC "Treasury";
      //if(%obj.getShapeName() !$= %displayName)
         //%obj.setShapeName("\c2" @ %displayName);
   //}
//}

// get the owning clan name, and treasury value from the DB
//function ClanTreasury::updateStats(%this, %obj)
//{
   //if(%obj.clanID $= "")
      //return;
      //
   //// get the clan name and treasury value from the database
   //// note - the sql interface doesnt seem to like bigint, so we cast it to varchar
   //%results = DB::Select("name, cast(isNull(treasury_amount,0) as VARCHAR) as coins",
   ///*FROM*/              "clan",
   ///*WHERE*/             "id='"@ %obj.clanID @ "'");
   //
   //if(%results.getNumRows() > 0)
   //{
      //%obj.clanName = %results.name;
      //%obj.coins = %results.coins;
   //}
   //
   //%results.delete();
   //
   //// display the treasury name above the object
   //%displayName = %obj.clanName SPC "Treasury";
   //if(%obj.getShapeName() !$= %displayName)
      //%obj.setShapeName("\c2" @ %displayName);
   ////if(%obj.getShapeName() !$= "Treasury")
   ////{
      ////%obj.setShapeName("\c2" @ "Treasury");
      ////%obj.setClanName("\c2" @ %obj.clanName);
   ////}
//}

// onPickup is called when a player tries to 'hit' the treasury
//function ClanTreasury::onPickup(%this, %obj, %player, %amount)
//{
   //// check that the player is a real player
   //%client = %player.client;
   //if(!isObject(%client))
      //return;
//
   //// The player must be at least SL 3 to hit a treasury
   //if( %client.getPersistantStat("skulls") < 3 )
      //return;
//
   //// and check that the treasury belongs to a clan
   //if(%obj.clanID $= "")
      //return;
//
   //%eyeHeight = getWord(%player.getEyePoint(), 2);
   //%treasuryHeight = getWord(%obj.getPosition(), 2);
   //if ( %player.inNeutralZone || (%eyeHeight < %treasuryHeight) )
   //{
      ////messageAllExcept(%client, -1, 'MsgItemPickup', '\c0%1 just tried (and failed) to hack into the %2 treasury!', %client.pData.dbName, %obj.clanName);
      //return;
   //}
      //
   //// update treasury info
   //%this.updateStats(%obj);
      //
   //// get the clan for the player
   //%playerID = %client.pData.dbID;
   //%playerClanId = "";
   //
   //// check if the player is a clan member or owner
   //%results = DB::Select("TOP 1 c.id, c.name",
   ///*FROM*/              "Clan c " @
                         //"LEFT JOIN Clan_members cm ON c.id=cm.clan_id", 
   ///*WHERE*/             "(c.owner_user_id='"@ %playerID @ "' " @
                         //"OR cm.user_id='"@ %playerID @"') " @
                         //"AND isnull(c.official,0)='1'");
   //
   //if(%results.getNumRows() > 0)
   //{
      //%playerClanId = %results.id;
      //%playerClanName = %results.name;
   //}
   //
   //%results.delete();
   //
   //// didn't find an official clan for the player?
   //if(%playerClanId $= "")
   //{
      //// send them a message
      //centerPrint(%client, "You must be a member of an official clan to attack this treasury!", 10, 1);
      //return;
   //}
   //
   //// ok, so player is from an official clan, 
   //// make sure he's not in the owning clan
   //if(%playerClanId == %obj.clanID)
   //{
      //// send them a message
      //centerPrint(%client, "You cannot attack your own treasury!", 5, 1);
      //return;
   //}
   //
   //// now we can take their money!
   ////%percentageToTake = getRandom(1, 10);
   //%percentageToTake = $Treasury::HitMin + (getRandom() * ($Treasury::HitMax - $Treasury::HitMin));
   //%amountToTake = mRound(%obj.coins * (%percentageToTake / 100));
   //%obj.coins -= %amountToTake;
   //
   //// take the money from the owning clan
   //DB::Update("Clan",
   ///*SET*/    "treasury_amount = (treasury_amount - "@ %amountToTake @")",
   ///*WHERE*/  "id='"@ %obj.clanID @"'");
//
   //// and give half to the attacking player
   //%playerShare = mRound(%amountToTake / 2);
   //%client.giveCoins("arn", %playerShare);
   //%client.netWorth = mAddBigNumbers(%client.netWorth, %playerShare);
   //%client.writeNetWorth();
      //
   //// and half to the attacking clan
   //%clanShare = %amountToTake - %playerShare;
   //DB::Update("Clan",
   ///*SET*/    "treasury_amount = (treasury_amount + "@ %clanShare @")",
   ///*WHERE*/  "id='"@ %playerClanId @"'");
   //
   //// let the attacker know what he's taken
   ////centerPrint(%client, "you hit the " @ %obj.clanName @ " treasury for " @ %amountToTake @ " arns.", 10, 1);
   //commandToClient(%client, 'TreasuryHit', %obj.clanName, %playerShare);
//
   //// Add to his treasury hit stat
   //DB::SprocNoRet("sp_StatsTreasuryHit", "'" @ %playerID @ "'");
   //
   ////// get players kingdom
   ////%kingdom="";
   ////%results = DB::Select("s.shield",
   /////*FROM*/   "shield s left join citizen_one co on s.id = co.shield_id",
   /////*WHERE*/  "co.id = '" @ %playerID @ "'");
   //
   ////if(%results.getNumRows() > 0)
      ////%kingdom = %results.shield;
   ////%results.delete();
   //
   //// post a message to the owner clans messageboard to let 
   //// them know that they've been spanked
   //DB::Insert("MessageBoard",
              //"user_id, clan_id, messagetext",
              //"'"@ $AlterVerse::AttackAlertID @ "', " @
              //"'"@ %obj.clanID @ "', " @
              //"'<b>"@ %client.pData.dbName @" of the "@ %playerClanName @" clan "@
              //"hit your clan treasury for " @ %amountToTake @ " arns.</b>'");
              //
   //// and send a message to all connected clients
   //messageAllExcept(%client, -1, 'MsgItemPickup', '\c0%1 just hit the %2 treasury!', %client.pData.dbName, %obj.clanName);
//
   //// Notify all clients on the attacked and attacking teams to update HUD value
   //%index = $Server::ClanData.teams.getIndexFromKey(%obj.clanID);
   //%attackedTeam = $Server::ClanData.teams.getValue(%index);
	//%count = ClientGroup.getCount();	
	//for ( %i = 0; %i < %count; %i++ )
	//{
	   //%msgClient = ClientGroup.getObject( %i );
	   //if ( %msgClient.team == %client.team )
	      //CommandToClient( %msgClient, 'TreasuryUpdate', %clanShare, "Add");
	   //if ( %msgClient.team == %attackedTeam )
	      //CommandToClient( %msgClient, 'TreasuryUpdate', %amountToTake, "Sub");
	//}
//
   //// hide the treasury
   //%obj.treasuryRespawn();
//}

// treasury respawn
// based on Item::respawn
function Item::treasuryRespawn(%this)
{
   // hide it
   %this.startFade(0, 0, true);
   %this.setHidden(true);
   
   // Schedule a reapearance
   %respawnTime = $AlterVerse::TreasuryRespawnTime * 60 * 1000;
   %this.schedule(%respawnTime, "setHidden", false);
   %this.schedule(%respawnTime + 100, "startFade", 1000, 0, false);
}
