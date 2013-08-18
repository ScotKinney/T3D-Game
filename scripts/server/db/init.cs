//*****************************************************************************
// init.cs - ODBC Resource initialization script
//
//*****************************************************************************
// DB init settings
$db_verbose = true;
$db_run_testing = false;
$db_test_insert = false;
$db_test_prepared = false;

//-----------------------------------------------------------------------------
// ODBC Database connection prefs
//-----------------------------------------------------------------------------
$Server::DB::Software = 1; // 0 - MySQL Local, 1 - MySQL Remote, 2 - SQL Serv 2000, 3 - SQL Serv 2005, 4 - SQL Serv 2008, 5 - Oracle
$Server::DB::Port = ""; // DB Port number
//$Server::DB::Server = "localhost"; // Loopback address when run on same machine as DB
//$Server::DB::Server = "192.168.100.4"; // Server's url or ip from inside firewall
$Server::DB::Server = "69.168.242.197"; // Server's url or ip Use this in dev mode outside the firewall
$Server::DB::Database = "av"; // Database name
$Server::DB::User = "Administrator"; // username
$Server::DB::Password = "7361Happy"; // password

error("*******************************************************************************");
error("***** Initializing the database...");
$Server::DB::Remote = false;

//check database they are using
switch($Server::DB::Software)
{
   case 0:
   $Server::DB::Driver = "MySQL ODBC 3.51 Driver";
   case 1:
   $Server::DB::Driver = "MySQL ODBC 3.51 Driver";
   case 2:
   $Server::DB::Driver = "SQL Server";
   case 3:
   $Server::DB::Driver = "SQL Native Client";
   case 4:
   $Server::DB::Driver = "SQL Server Native Client 10.0";
   case 5:
   $Server::DB::Driver = "Microsoft ODBC for Oracle";
   default:
   $Server::DB::Driver = "ERROR: UNKNOWN DATABASE:" SPC $Server::DB::Database;
}

// test for valid configuration
if ( $db_verbose )
{
    if ( $Server::DB::Driver $= "" )
    {
        error("No database driver set!");
    }

   if ( $Server::DB::Database $= "" )
    {
        error("No database set!");
    }
    
    if ( $Server::DB::Server $= "" )
    {
        error("No database server specified!");
    }

    if ( $Server::DB::User $= "" )
    {
        error("No database user specified!");
    }
}

error("***** Using ODBC Driver:" SPC $Server::DB::Driver);
$db = new DatabaseConnection();
%rv = 0;
//set up the connection string
%connectionString = "server=" @ $Server::DB::Server @ ";";

error("***** software:" SPC $Server::DB::Software);
//add port for remote mysql
if(($Server::DB::Software == 1) && ($Server::DB::Port !$= ""))
   %connectionString = %connectionString @ "port=" @ $Server::DB::Port @ ";";

//filter out 'database' for oracle
if($Server::DB::Software != 5)
   %connectionString = %connectionString @ "database=" @ $Server::DB::Database @ ";";

//handle different 'username' names and 'password' names
if($Server::DB::Software == 0 || $Server::DB::Software == 1)
   %connectionString = %connectionString @ "user=" @ $Server::DB::User @ ";" @ "password=7361Happy;" @ "option=3;";
else
   %connectionString = %connectionString @ "uid=" @ $Server::DB::User @ ";" @ "pwd=7361Happy;";

   error("***** driver:" SPC $Server::DB::Driver);// SPC "connectionstring" SPC %connectionString);
   
%rv = $db.ConnectDriver($Server::DB::Driver, %connectionString);
if ( %rv == 0 )
{
   error("***** Database error received while trying to connect to database.");
   exec("./stubs.cs");
   exec("scripts/server/AlterVerse/remoteDBData.cs");
   $Server::DB::Remote = true;
}
else if ( %rv == 2 )
{
   error("***** Database feedback received while trying to connect to database.");
   exec("./utils.cs");

   if ( $db_run_testing )
   {
      exec("./test.cs");
   }
}
else if ( %rv == 1 )
{
   error("*****" SPC $Server::DB::Driver SPC "database connection established.");
   exec("./utils.cs");

   if ( $db_run_testing )
   {
      exec("./test.cs");
   }
}
else
{
    error("***** Unknown database connection return value (" SPC %rv SPC ")");
}
error("***** Database initialized.");
error("*******************************************************************************");
