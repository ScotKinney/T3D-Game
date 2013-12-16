/*
   playerPersistance.cs
   Framework for managing persistant data for connected clients
   
   Guy Allard 2010
   MAR 2013
*/

function GameConnection::createPersistantStats(%client, %id, %name, %inventory)
{
   if(!isObject(%client.pData))
   {
      echo("creating persistant data for "@%name);
      %client.pData = new ScriptGroup(){
         class = PersistantPlayerStats;
         dbID = %id;
         dbName = %name;
      };
   }

   if(!isObject(%client.pInv))
      %client.pInv = new ArrayObject();

   if ( %inventory !$= "" )
      %client.resetInventory(%inventory);
}

function GameConnection::deletePersistantStats(%client)
{
   if(isObject(%client.pData))
   {
      echo("deleting persistant stats for "@%client);
      %client.pData.delete();
      %client.pData = "";
   }

   if(isObject(%client.pInv))
      %client.pInv.delete();
   %client.pInv = "";
}

function GameConnection::resetInventory(%client, %inventory)
{
   // Calculate the clients networth while creating their inventory
   %worth = 0;

   %client.pInv.empty();
   %numItems = getFieldCount(%inventory);
   for (%i = 0; %i < %numItems; %i++ )
   {
      %curItem = getField(%inventory, %i);
      %itemID = getWord(%curItem, 0);
      %count = getWord(%curItem, 1);
      if ( %count > 0 )
      {
         %client.pInv.add(%itemID, %count);

         // get the cost from the datablock for this item type
         %itemBlock = $AlterVerse::ItemNames[%itemID];
         %cost = %itemBlock.cost;
         %worth = mAddBigNumbers(%worth, mMulBigNumbers(%count, %cost));
      }
   }

   %worth = mAddBigNumbers(%worth, %client.arns);
   %client.netWorth = %worth;
   %client.writeNetWorth();
   
   // Send the inventory list to the client
   %client.SendClientInventory(%inventory);
}

function GameConnection::SendClientInventory(%client, %invStr)
{
   if ( strlen(%invStr) > 250 )
   {  // We need to break the string into parts to transmit
      %part[0] = "";
      %part[1] = "";
      %part[2] = "";
      %part[3] = "";
      %i = 0;
      %strIdx = 0;
      %numItems = GetFieldCount(%invStr);
      %nMinusOne = %numItems - 1;
      while (%i < %numItems)
      {
         %pitem = getField(%invStr,%i);
         %part[%strIdx] = %part[%strIdx] @ %pitem;
         if (%i < %nMinusOne)
            %part[%strIdx] = %part[%strIdx] @ "\t";
         %i++;
         if ( (%i % 31) == 0 )
            %strIdx++;
      }
      commandToClient(%client, 'SetInventory', %part[0], %part[1], %part[2], %part[3]);
   }
   else
      commandToClient(%client, 'SetInventory', %invStr);
}

function GameConnection::getInventoryString(%client)
{
   %cnt = %client.pInv.count();
   %newInv = "";
   for ( %i = 0; %i < %cnt; %i++ )
   {
      %itemID = %client.pInv.getKey(%i);
      %value = %client.pInv.getValue(%i);
      if ( %value > 0 )
      {
         if ( %newInv !$= "" )
            %newInv = %newInv @ "\t";
         %newInv = %newInv @ %itemID SPC %value;
      }
   }
   return %newInv;
}

// Remove any private server items
function GameConnection::CleanInventory(%client)
{
   if ( !isObject(%client.pInv) || ($Server::PrivateInventory $= "") )
      return;

   %count = getWordCount($Server::PrivateInventory);
   for (%i = 0; %i < %count; %i++)
   {
      %itemName = getWord($Server::PrivateInventory, %i);
      %index = %client.pInv.getIndexFromKey(%itemName.ItemID);
      if ( (%index > -1) && (%itemName.cost == 0) )
         %client.pInv.erase(%index);
   }
}

// save the clients net worth in the database
function GameConnection::writeNetWorth(%client, %forceWrite)
{
   if(!isObject(%client.pData))
      return;

   if ( %client.lastNWWrite $= "" )
      %client.lastNWWrite = 0;

   %diff = mAbs(mSubBigNumbers(%client.netWorth, %client.lastNWWrite));
   if ( (%client.lastNWWrite == %client.netWorth) || ((%diff < 1000) && !%forceWrite) )
      return;

   if ( $Server::DB::Remote )
   {
      %args = "uID="@ %client.pData.dbID;
      %args = %args @ "&amount=" @ %client.netWorth;
      remoteDBCommand("SetNetWorth", %args, %client);
   }
   else
   {
      DB::Update("nuke_users",
      /*set*/    "networth='"@ %client.netWorth @ "'",
      /*where*/  "user_id='"@ %client.pData.dbID @"'");
   }
   %client.lastNWWrite = %client.netWorth;
}

// Client has been awarded a new lock level.
function GameConnection::awardLockLevel(%client, %skullLevel, %delayForTransfer)
{  // Update the DB field
   if ( $Server::DB::Remote )
   {
      %args = "uID="@ %client.pData.dbID;
      %args = %args @ "&level=" @ %skullLevel;
      remoteDBCommand("SetLockLevel", %args, %client);
   }
   else
   {
      DB::Update("AVPlayers","skulls='" @ %skullLevel @ "'",
                  "ID='"@ %client.pData.dbID @ "'");
   }

   %client.skullLevel = %skullLevel;

   // Tell the user so they can celebrate
   commandToClient(%client, 'setSkullLevel', %skullLevel, true, %delayForTransfer);

   // Tell everyone else
   serverChat.sendGameMsg("ae", %client.dbUserID, "lvlUp", "g", true, %client.nameBase, %skullLevel);
}