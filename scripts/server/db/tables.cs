// placeholder for DB table creation/validation
// This should only be run once on startup and should not delete any tables
// that already exist.

// This builds a list of all tables in the database and prints their names
// out on a single, comma separated, line.
$show_tables = $db.Execute("SHOW TABLES;");
%foundTables = $show_tables.ValueIndex(0);
while ( $show_tables.nextRow() )
{
    %foundTables = %foundTables @ "," SPC $show_tables.ValueIndex(0);
}
if ($db_verbose)
{
    error("***** Found tables:" SPC %foundTables);
}

// This checks for our hard coded table names and if not found creates
// it "for the first time".
$show_tables = $db.Execute("SHOW TABLES;");
%create_tge_odbc_test = false;
if ( $show_tables.ValueIndex(0) !$= "" )
{
    if ( $show_tables.ValueIndex(0) $= "gameItems" )
    {
        %create_tge_odbc_test = false;
    }
}
if ( %create_tge_odbc_test )
{
    //$db.Execute("CREATE TABLE ...... etc
}


// Report that we've been loaded if verbose
if ($db_verbose)
{
    error("***** Database tables initialized");
}
