//-----------------------------------------------------------------------------
// BLOODCLANS
// EPLS 9/18/2010

function GameConnection::updateClientInventory(%client)
{
   %value = %client.getPersistantStat("inventory");
   //commandToClient(%client, 'SetInventory', %value);
   SendClientInventory(%client, %value);
}

function GameConnection::readInventory(%client)
{
   %inventory = %client.retrievePersistantStat("inventory");
   return %inventory;
}

function GameConnection::writeInventory(%client, %inventory)
{
   %client.storePersistantStat("inventory", %inventory);
}

function GameConnection::setInventory(%client, %inventory)
{
   %client.setPersistantStat("inventory", %inventory);
   %client.updateClientInventory();
}

function GameConnection::storeInventory(%client)
{
   %client.storePersistantStat("inventory", %client.player.inventoryString);
   //%client.storeInventoryTimer = %client.schedule(30000, storeInventory);
}

// GUY >>
// networth calculation
function GameConnection::calcNetWorth(%client)
{
   %worth = 0;
   // get current inventory list
   %inventoryString = %client.getPersistantStat("inventory");

   // add up the value for each item in the inventory   
   %cnt = getFieldCount(%inventoryString);
   for ( %i = 0; %i < %cnt; %i++ )
   {
      %item = getField(%inventoryString, %i);
      %id = getWord(%item,0);
      
      // get the datablock for this item type
      %itemBlock = $AlterVerse::ItemNames[%id];
      
      // add the value for this item
      %amount = getWord(%item, 1);
      %cost = %itemBlock.cost;
      %worth = mAddBigNumbers(%worth, mMulBigNumbers(%amount, %cost));
   }

   ///Add arns in bank to net worth
   %name = stripChars( detag( getTaggedString( %client.playerName ) ), "\cp\co\c6\c7\c8\c9" );
   %coins = DB::Fetch("Coins", "Bank", "Name='" @ %name @ "'");
   %bankedArns = 0;
   if ( %coins !$= "" )
   {
      %coins = strreplace(%coins, " ", "  ");
      %coins = strreplace(%coins, ":", " ");
      %cnt = getFieldCount(%coins);
      for ( %i = 0; %i < %cnt; %i++ )
      {
         %cfield = getField(%coins, %i);
         %ctype = getWord(%cfield, 0);
         %camount = getWord(%cfield, 1);
         if ( %ctype $= "arn" )
         {
            %bankedArns = mAddBigNumbers(%camount, %bankedArns);
         }
      }
   }
   %worth = mAddBigNumbers(%worth, %bankedArns);
   ///end
   
   ///Add arns on person to net worth
   %coins = %client.retrievePersistantStat("coins");
   %carriedArns = 0;
   if ( %coins !$= "" )
   {
      %coins = strreplace(%coins, " ", "  ");
      %coins = strreplace(%coins, ":", " ");
      %cnt = getFieldCount(%coins);
      for ( %i = 0; %i < %cnt; %i++ )
      {
         %cfield = getField(%coins, %i);
         %ctype = getWord(%cfield, 0);
         %camount = getWord(%cfield, 1);
         if ( %ctype $= "arn" )
         {
            %carriedArns = mAddBigNumbers(%camount, %carriedArns);
         }
      }
   }
   %worth = mAddBigNumbers(%worth, %carriedArns);
///end

   %client.netWorth = %worth;
}

// save the clients net worth in the database
function GameConnection::writeNetWorth(%client)
{
   if(!isObject(%client.pData))
      return;
      
   %worth = %client.netWorth;
   
   DB::Update("citizen_one",
   /*set*/    "networth='"@ %worth @ "'",
   /*where*/  "id='"@ %client.pData.dbID @"'");
}