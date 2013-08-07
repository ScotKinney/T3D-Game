//-----------------------------------------------------------------------------
// This script assumes a valid $db connection is established.
//

//-----------------------------------------------------------------------------
// managed Select statement
// $result = DB::Select( "*", "gameAccounts", "userName like '%user%'", "ASC" );
function DB::Select(%these,%table,%clause,%sort)
{
   return -1;
}

//-----------------------------------------------------------------------------
// select a single column from the first row returned by the query.
// $string = DB::Fetch( "player", "tge_odbc_test", "number = 200" );
function DB::Fetch(%column,%table,%clause)
{
   return -1;
}

//-----------------------------------------------------------------------------
// Insert a single row into the database table
// $result = DB::Insert("tge_odbc_test","'Some Player',200,'20 20 -10'", "Name = 'myName'");
function DB::Insert(%table, %fields, %values, %clause)
{
   return -1;
}

// Report that we've been loaded if verbose
if ($db_verbose)
{
    error("***** Database utility functions initialized");
}

//-----------------------------------------------------------------------------
// stored proc call
// $result = DB::Sproc("myProcedure", "'parameter1', 'parameter2'");
function DB::Sproc(%sprocName, %inParameters)
{
   return -1;
}

//-----------------------------------------------------------------------------
// update table call
// $result = DB::Update("myTable", "column1 = 'blah', column2 = 3");
function DB::Update(%table, %update, %clause)
{
   return -1;
}

//-----------------------------------------------------------------------------
// delete call
// $result = DB::Delete("myTable", "column1 = 'blah'");
function DB::Delete(%table, %clause)
{
   return -1;
}

//-----------------------------------------------------------------------------
// stored proc call with no return value
// DB::Sproc("myProcedure", "'parameter1', 'parameter2'");
function DB::SprocNoRet(%sprocName, %inParameters)
{
   return false;
}
