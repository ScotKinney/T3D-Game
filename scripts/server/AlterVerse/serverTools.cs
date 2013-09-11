// Server Build Tools

function serverCmdGetBuildRights(%client)
{
   %isOwner = ( (%client.dbUserID == $AlterVerse::serverOwner) ||
      ($Server::ServerType !$= "MultiPlayer") );
   commandToClient(%client, 'SetBuildRights', %client.buildRights,
      $AlterVerse::ownerName, %isOwner);
}

function serverCmdAssignBuildRights(%client, %playerID, %newRights)
{
   if ( $Server::ServerType !$= "MultiPlayer" )
   {
      commandToClient(%client, 'RightsRefused', 0);
      return;
   }

   if (%client.dbUserID != $AlterVerse::serverOwner)
   {
      commandToClient(%client, 'RightsRefused', 1);
      return;
   }

   if ( $Server::DB::Remote )
   {
      %args = "sOwner=" @ %client.dbUserID;
      %args = %args @ "&playerID=" @ %playerID;
      %args = %args @ "&bRights=" @ %newRights;
      remoteDBCommand("AssignRights", %args, %client);
      return;
   }

   // See if there is already a rights record for this player
   %result = DB::Select("buildRights",
   /*FROM*/             "AVBuildRights",
   /*WHERE*/            "ownerID='" @ $AlterVerse::serverOwner @
                        "' AND playerID='" @ %playerID @ "'");
   %hasRights = (%result.getNumRows() > 0);
   %result.delete();

   if ( %hasRights )
   {
      if ( %newRights == 0 )
      {  // Rights have been removed, so delete the record
         DB::Delete("AVBuildRights", "ownerID='" @ $AlterVerse::serverOwner @
                        "' AND playerID='" @ %playerID @ "'");
      }
      else
      {
         DB::Update("AVBuildRights",
         /*SET*/    "buildRights='" @ %newRights @ "'",
         /*WHERE*/  "ownerID='" @ $AlterVerse::serverOwner @
                        "' AND playerID='" @ %playerID @ "'");
      }
   }
   else
   {
      DB::Insert("AVBuildRights", "ownerID, playerID, buildRights",
        "'"@ $AlterVerse::serverOwner @ "', '"@ %playerID @ "', '" @ %newRights @ "'");
   }

   // If the target player is on the server, update their data
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++)
   {
      %tmpClient = ClientGroup.getObject(%i);
      if ( %tmpClient.dbUserID == %playerID )
      {
         %tmpClient.buildRights = %newRights;
         break;
      }
   }

   commandToClient(%client, 'RightsAccepted');
}
