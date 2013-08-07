//*****************************************************************************
// test.cs - ODBC Resource test script
//
//*****************************************************************************
error("***** BEGIN DB TESTING *****");

error("***** Begin select test *****");
//error("Select return: " @ $db.Execute("select * from testTable;"));
error("****** End select test ******");

// declare some test variables
%testName = "";
%testPass = "";
%testFName = "";
%testLName = "";
%testEmail = "";
%testNumber = false;

// insertion test
if ( $db_test_insert )
{
    %testName = "NewPlayer" @ getRandom(1024);
    %testPass = %testName;
    %testFName = %testName;
    %testLName = %testName;
    %testEmail = %testName;
    
    %testNumber = getRandom(50000);
    error("***** Inserting new row for player name \"" @ %testName @ "\"");
    %Results = DB::Insert("Players", "Name, Email" , "'" @ %testName @ "','" @ %testEmail @ "'");
}

if($db_test_prepared)
{
    %testName = "NewPlayer" @ getRandom(1024);
    %testPass = %testName;
    %testFName = %testName;
    %testLName = %testName;
    %testEmail = %testName;
    
    %testNumber = getRandom(50000);
    error("***** Prepared Insert of new row for player name \"" @ %testName @ "\"");
	
    %query = "INSERT INTO Players ( Name, Email ) VALUES ( ?, ? );";
    %prepared=$db.Prepare(%query,5);
    %results=$db.ExecutePrepared(%prepared,%testName,%testEmail);

    error("Prepared SQL: "@%prepared.getSql());

    $db.FreePrepared(%prepared);
}

if($db_test_prepared)
{
	// selection tests
	error("***** DB Prepared Selection test: (will print all rows in the gameAccounts table)");
	
	%query = "SELECT * FROM Players;";
	%prepared=$db.Prepare(%query,0);
	%results=$db.ExecutePrepared(%prepared);
	error("***** DB SELECT ROW #1:" SPC %Results.userID SPC %Results.userName SPC %Results.password SPC %Results.firstName SPC %Results.lastName SPC %Results.emailAddress SPC %Results.isActive SPC %Results.isAdmin);
	%counter = 2;
	while ( %Results.nextRow() )
	{
		error("***** DB SELECT ROW #" @ %counter @ ":" SPC %Results.userID SPC %Results.userName SPC %Results.password SPC %Results.firstName SPC %Results.lastName SPC %Results.emailAddress SPC %Results.isActive SPC %Results.isAdmin);
		%counter++;
	}
	$db.FreePrepared(%prepared);
}

/*error("***** DB Selection test: (will print all rows in the gameAccounts table)");
%Results = DB::Select("*","gameAccounts");

error("***** DB SELECT ROW #1:" SPC %Results.userID SPC %Results.userName SPC %Results.password SPC %Results.firstName SPC %Results.lastName SPC %Results.emailAddress SPC %Results.isActive SPC %Results.isAdmin);
%counter = 2;

while ( %Results.nextRow() )
{
    error("***** DB SELECT ROW #" @ %counter @ ":" SPC %Results.userID SPC %Results.userName SPC %Results.password SPC %Results.firstName SPC %Results.lastName SPC %Results.emailAddress SPC %Results.isActive SPC %Results.isAdmin);
    %counter++;
}

// insert/fetch test
if ( $db_test_insert )
{
    %value = DB::Fetch( "Name", "Players", "email = '" @ %testEmail @ "'" );
    error("***** DB INSERT/FETCH TEST: this \"" @ %value @ "\" should be the same as \"" @ %testName @ "\"");
}
else
{
    %value = DB::Fetch( "Name", "Players", "ID = 1" );
    error("***** DB FETCH TEST:" SPC %value);
}*/
error("****** END DB TESTING ******");
