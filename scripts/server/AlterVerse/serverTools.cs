// Server Build Tools

function serverCmdGetBuildRights(%client)
{
   commandToClient(%client, 'SetBuildRights', %client.buildRights,
      $AlterVerse::ownerName);
}
