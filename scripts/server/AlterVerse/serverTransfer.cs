/*
   serverTransfer.cs
   Functions for all server to server transfers.
*/

function serverCmdTeleportToServer(%client, %serverID)
{
   if ( %client.teleDest !$= "" )
      return; //They're already teleporting

   TransferToServer(%client, %serverID, "Spawn0", "");
}

function TPToTriggerServer(%client, %serverName, %spawnSphere)
{
   if ( %client.teleDest !$= "" )
      return; //They're already teleporting

   // Find the ID of the requested server
   %serverID = getServerIDFromName(%serverName);

   TransferToServer(%client, %serverID, %spawnSphere, "");
}

function TransferToServer(%client, %serverID, %spawnSphere, %serverName)
{
   %client.teleDest = %serverID;
   %timeSec = getTimeSec();   // Used when making new session key

   // get the details of the requested server
   if ( $Server::DB::Remote )
   {
      if ( %serverName $= "" )
      {
         %client.triggeredMove = false;
         %args = "tgtID="@%serverID;
      }
      else
      {
         %client.triggeredMove = true;
         %args = "tgtName="@%serverName;
      }
      %args = %args @ "&uName=" @ %client.nameBase;
      %args = %args @ "&uID=" @ %client.pData.dbID;
      %args = %args @ "&tVal=" @ %timeSec;
      %args = %args @ "&sPoint=" @ %spawnSphere;
      remoteDBCommand("MoveUser", %args, %client);
      return;
   }

   if ( %serverName $= "" )
      %results = DB::Select("serverId,serverName,serverAddress,loadPrefix,manifestRoot,manifestFile", 
      /*FROM*/              "AVServerList", 
      /*WHERE*/             "serverId='"@%serverID@"'");
   else
      %results = DB::Select("serverId,serverName,serverAddress,loadPrefix,manifestRoot,manifestFile", 
      /*FROM*/              "AVServerList", 
      /*WHERE*/             "serverName='"@%serverName@"'");
                         
   if(%results.getNumRows() == 0)
   {
      error("TransferToServer: cannot find destination server, ID = " @ %serverID @ ", name = " @ %serverName);
      %results.delete();
      %client.teleDest = "";
      return;
   }
   %destAddress = %results.serverAddress;
   %destination = %results.serverName;
   %manifestURL = %results.manifestFile;
   %pathToRoot = %results.manifestRoot;
   %loadPrefix = %results.loadPrefix;
   %serverID = %results.serverId;
   
   %results.delete();

   // create a new hash key   
   %hashKey = getStringMD5(%client.pData.dbID @ %client.pData.dbName @ %timeSec);
   
   // update the userLogin table so that we know the client is allowed in the next server
   DB::Update("AVUserLogin", 
   /*SET*/     "nextServerId='"@%serverID@"', "@
               "currentServerId='', " @ 
               "sessionKey='"@%hashKey@"'", 
   /*WHERE*/   "id='"@%client.pData.dbID@"'");

   // Play any teleport effect here.
   %transferDelay = 50;
   if ( %serverName $= "" )
   {
      %client.player.playLeaveEffect();
      %transferDelay = 2000;
   }

   if ( (%manifestURL !$= "") && (%pathToRoot !$= "") )
      schedule(%transferDelay, 0, "commandToClient", %client, 
                      'serverTransferStream',
                      %manifestURL,
                      %pathToRoot,
                      %destAddress,
                      %spawnSphere,
                      %hashKey,
                      %destination,
                      %loadPrefix);
   else
      schedule(%transferDelay, 0, "commandToClient", %client, 
                      'serverTransfer', 
                      %destAddress, 
                      %spawnSphere, 
                      %hashKey,
                      %destination,
                      %loadPrefix);
}
