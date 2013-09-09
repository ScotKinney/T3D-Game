// Server Build Tools

function serverCmdGetBuildRights(%client)
{
   %isOwner = ( (%client.dbUserID == $AlterVerse::serverOwner) ||
      ($Server::ServerType !$= "MultiPlayer") );
   commandToClient(%client, 'SetBuildRights', %client.buildRights,
      $AlterVerse::ownerName, %isOwner);
}
