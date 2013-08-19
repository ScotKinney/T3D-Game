/*
   playerPersistance.cs
   Framework for managing persistant data for connected clients
   
   Guy Allard 2010
*/

function GameConnection::createPersistantStats(%client, %id, %name)
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
}

function GameConnection::deletePersistantStats(%client)
{
   if(isObject(%client.pData))
   {
      echo("deleting persistant stats for "@%client);
      %client.pData.delete();
      %client.pData = "";
   }
}

function GameConnection::registerPersistantStat(%this, %varName, %colName)
{
   if(isObject(%this.pData))
      %this.pData.registerStat(%varName, %colName);
}

function GameConnection::getPersistantStat(%this, %varName)
{
   if(!isObject(%this.pData)) return;
   return %this.pData.get(%varName);
}

function GameConnection::setPersistantStat(%this, %varName, %value)
{
   if(!isObject(%this.pData)) return;
   %this.pData.set(%varName, %value);  
}

function GameConnection::retrievePersistantStat(%this, %varName)
{
   if(!isObject(%this.pData)) return;
   return %this.pData.retrieve(%varName);
}

function GameConnection::storePersistantStat(%this, %varName, %value)
{
   if(!isObject(%this.pData)) return;
   %this.pData.store(%varName, %value);
}

function GameConnection::readPersistantStat(%this, %varName)
{
   if(!isObject(%this.pData)) return;
   %this.pData.read(%varName);  
}

function GameConnection::writePersistantStat(%this, %varName)
{
   if(!isObject(%this.pData)) return;
   %this.pData.write(%varName);
}

function GameConnection::readAllPersistantStats(%this)
{
   if(!isObject(%this.pData)) return;
   %this.pData.readAll();
}

function GameConnection::writeAllPersistantStats(%this)
{
   if(!isObject(%this.pData)) return;
   %this.pData.writeAll();
}


function PersistantPlayerStats::onRemove(%this)
{
   // cleanup   
   %this.deleteAllObjects();
}

function PersistantPlayerStats::findEntry(%this, %varName)
{
   foreach(%obj in %this)
   {
      if(%obj.varName $= %varName)
      {
         return %obj;
      }
   }
   return "";
}

function PersistantPlayerStats::registerStat(%this, %varName, %colName)
{   
   %entry = %this.findEntry(%varName);
   if(isObject(%entry))
   {
      %entry.colName = %colName;
   }
   else
   {
      %entry = new ScriptObject();
      %entry.varName = %varName;
      %entry.colName = %colName;
      %entry.value = "";
      %this.add(%entry);
   }
}

function PersistantPlayerStats::set(%this, %varName, %value)
{
   %entry = %this.findEntry(%varName);
   if(isObject(%entry))
      %entry.value = %value;
}

function PersistantPlayerStats::get(%this, %varName)
{
   %entry = %this.findEntry(%varName);
   if(isObject(%entry))
      return %entry.value;
   
   return "";
}

function PersistantPlayerStats::read(%this, %varName)
{
   %entry = %this.findEntry(%varName);
   if(isObject(%entry))
   {
      %entry.value = DB::Fetch(%entry.colName, "Players", "id='"@%this.dbID@"'");
   }
}

function PersistantPlayerStats::write(%this, %varName)
{
   %entry = %this.findEntry(%varName);
   if(isObject(%entry))
   {
      DB::Update("Players", %entry.colName@"='"@%entry.value@"'", "id='"@%this.dbID@"'");
   }
}

function PersistantPlayerStats::retrieve(%this, %varName)
{
   %entry = %this.findEntry(%varName);
   if(isObject(%entry))
   {
      %entry.value = DB::Fetch(%entry.colName, "Players", "id='"@%this.dbID@"'");
      return %entry.value;
   }
   return "";
}

function PersistantPlayerStats::store(%this, %varName, %value)
{
   %entry = %this.findEntry(%varName);
   if(isObject(%entry))
   {
      %entry.value = %value;
      DB::Update("Players", %entry.colName@"='"@%entry.value@"'", "id='"@%this.dbID@"'");
   }
}

function PersistantPlayerStats::readAll(%this)
{
   %query = "";
   foreach(%entry in %this)
   {
      %query = %query $= "" ? %entry.colName : %query @ ", " @ %entry.colName;
   }
   if(%query !$= "")
   {
      %results = DB::Select(%query, "Players", "id='" @ %this.dbID @ "'");
      if(%results.getNumRows() > 0)
      {
         foreach(%entry in %this)
         {
            eval("%entry.value = %results." @ %entry.colName @";");
            //echo("ENTRY.VALUE" SPC %entry.value);
         }
      }
      %results.delete();
   }
}

function PersistantPlayerStats::writeAll(%this)
{
   %query = "";
   foreach(%entry in %this)
   {
      %query = %query $= "" ? %query : %query @ ", ";
      %query = %query @ %entry.colName@"='"@%entry.value@"'";
   }
   
   if(%query !$= "")
      DB::Update("Players", %query, "id='"@%this.dbID@"'");
}
