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

   commandToClient(%client, 'RightsAccepted');
}
