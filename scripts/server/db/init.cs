//*****************************************************************************
// init.cs - ODBC Resource initialization script
//
//*****************************************************************************
// DB init settings
$db_verbose = true;
$db_run_testing = false;
$db_test_insert = false;
$db_test_prepared = false;

error("*******************************************************************************");
error("***** Initializing the database...");
$Server::DB::Remote = false;

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

    if ( $Server::DB::Password $= "" )
    {
        error("No database password specified!");
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
   %connectionString = %connectionString @ "user=" @ $Server::DB::User @ ";" @ "password=" @ $Server::DB::Password @ ";" @ "option=3;";
else
   %connectionString = %connectionString @ "uid=" @ $Server::DB::User @ ";" @ "pwd=" @ $Server::DB::Password @ ";";

   error("***** driver:" SPC $Server::DB::Driver);// SPC "connectionstring" SPC %connectionString);
   
%rv = $db.ConnectDriver($Server::DB::Driver, %connectionString);
if ( %rv == 0 )
{
    error("***** Database error received while trying to connect to database.");
    exec("./stubs.cs");
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
