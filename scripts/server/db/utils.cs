//-----------------------------------------------------------------------------
// This script assumes a valid $db connection is established.
//

//-----------------------------------------------------------------------------
// managed Select statement
// $result = DB::Select( "*", "gameAccounts", "userName like '%user%'", "ASC" );
function DB::Select(%these,%table,%clause,%sort)
{
    if(!isObject($db))
    {
       error("DB::select ERROR: database connection does not exist");
       return;
    }
    
    %query = "";
    if ( %these !$= "" )
    {
        if ( %table !$= "" )
        {
            if ( %clause !$= "" )
            {
                if ( %sort !$= "" )
                {
                    %query = "SELECT" SPC %these SPC "FROM" SPC %table SPC "WHERE" SPC %clause SPC "ORDER BY" SPC %sort @ ";";
                }
                else
                {
                    %query = "SELECT" SPC %these SPC "FROM" SPC %table SPC "WHERE" SPC %clause @ ";";
                }
            }
            else
            {
                %query = "SELECT" SPC %these SPC "FROM" SPC %table @ ";";
            }
            return( $db.Execute( %query ) );
        }
        else
        {
            echo("DB::Select() ERROR: Unable to determine where you want to select from. Missing second argument.");
        }
    }
    else
    {
        echo("DB::Select() ERROR: Unable to determine what you want to select. Missing first argument.");
    }
}

//-----------------------------------------------------------------------------
// select a single column from the first row returned by the query.
// $string = DB::Fetch( "player", "tge_odbc_test", "number = 200" );
function DB::Fetch(%column,%table,%clause)
{
    if(!isObject($db))
    {
       error("DB::Fetch ERROR: database connection does not exist");
       return;
    }
    
    %query = "";
    if ( %column !$= "" )
    {
        if ( %table !$= "" )
        {
            if ( %clause !$= "" )
            {
                %query = "SELECT" SPC %column SPC "FROM" SPC %table SPC "WHERE" SPC %clause @ ";";
            }
            else
            {
                %query = "SELECT" SPC %column SPC "FROM" SPC %table @ ";";
            }
            %results = $db.Execute( %query );
            if(%results.getNumRows() > 0)
               %ret_val = %results.ValueIndex( 0 );
            else
               %ret_val = "";
            %results.delete();
            return( %ret_val );
            
        }
        else
        {
            echo("DB::Fetch() ERROR: Unable to determine where you want to fetch from. Missing second argument.");
        }
    }
    else
    {
        echo("DB::Fetch() ERROR: Unable to determine what you want to fetch. Missing first argument.");
    }
}

//-----------------------------------------------------------------------------
// Insert a single row into the database table
// $result = DB::Insert("tge_odbc_test","'Some Player',200,'20 20 -10'", "Name = 'myName'");
function DB::Insert(%table, %fields, %values, %clause)
{
   if(!isObject($db))
   {
      error("DB::insert ERROR: database connection does not exist");
      return;
   }
   %query = "";
   
   if ( %table !$= "" )
   {
      if ( %values !$= "" )
      {
         if(%clause !$= "")
		 {
			//error("if");
            %query = "INSERT INTO" SPC %table SPC "(" @ %fields @ ") VALUES (" @ %values @ ") WHERE" SPC %clause SPC ";";
			//error(%query);
		 }
         else
		 {
			//error("else");
            %query = "INSERT INTO" SPC %table SPC "(" @ %fields @ ") VALUES (" @ %values @ ");";
			//error(%query);
		 }
            
         %results = $db.Execute( %query );
		   //error(%results);
         %results.Commit();
         %numRows = %results.getNumRows();
         %results.delete();
         return(%numRows);
      }
      else
         echo("DB::Insert() ERROR: Unable to determine what you want to insert. Missing second argument.");
   }
   else
      echo("DB::Insert() ERROR: Unable to determine where you want to insert a row. Missing first argument.");
   
   return(false);
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
   if(!isObject($db))
   {
      error("DB::Sproc ERROR: database connection does not exist");
      return;
   }
    
   %query = "";
   
   //make sure they sent us a sproc name
   if(%sprocName !$= "")
   {
	  //error("testing db software");
      //test for db software
      if($Server::DB::Software == 2 || $Server::DB::Software == 3
		|| $Server::DB::Software == 4)
      {
         //see if they are passing parameters
         if(%inParameters !$= "")
		 {
            %query = "EXEC" SPC %sprocName SPC %inParameters @ ";";
		 }
         else
		 {
            %query = "EXEC" SPC %sprocName @ ";";
		 }
      }
      else
      {
         //see if they are passing parameters
         if(%inParameters !$= "")
            %query = "CALL" SPC %sprocName @ "(" @ %inParameters @ ");";
         else
            %query = "CALL" SPC %sprocName @ "();";
      }
         
      return( $db.Execute( %query ) );
   }
   else
     echo("DB::Sproc() ERROR: Unable to determine what sproc you want to call. Missing first argument.");
}

//-----------------------------------------------------------------------------
// update table call
// $result = DB::Update("myTable", "column1 = 'blah', column2 = 3");
function DB::Update(%table, %update, %clause)
{
    if(!isObject($db))
    {
       error("DB::Update ERROR: database connection does not exist");
       return;
    }
    
    %query = "";
   
    if ( %table !$= "" )
    {
        if ( %update !$= "" )
        {
           if(%clause !$= "")
               %query = "UPDATE" SPC %table SPC "SET" SPC %update SPC "WHERE" SPC %clause SPC ";";
           else
               %query = "UPDATE" SPC %table SPC "SET" SPC %update SPC ";";
           
            %results = $db.Execute( %query );
            %results.Commit();
            %numRows = %results.getNumRows();
            %results.delete();
            return(%numRows);
        }
        else
        {
            echo("DB::Update() ERROR: Unable to determine what you want to Update. Missing second argument.");
        }
    }
    else
    {
        echo("DB::Update() ERROR: Unable to determine where you want to Update a row. Missing first argument.");
    }
    
    return(false);
}

//-----------------------------------------------------------------------------
// delete call
// $result = DB::Delete("myTable", "column1 = 'blah'");
function DB::Delete(%table, %clause)
{
    if(!isObject($db))
    {
       error("DB::Delete ERROR: database connection does not exist");
       return;
    }
    
    %query = "";
   
    if ( %table !$= "" )
    {
        if(%clause !$= "")
            %query = "DELETE FROM" SPC %table SPC "WHERE" SPC %clause SPC ";";
        else
            %query = "DELETE FROM" SPC %table SPC ";";
        
         %results = $db.Execute( %query );
         %results.Commit();
         %results.delete();
         return(true);
    }
    else
    {
        echo("DB::Delete() ERROR: Unable to determine where you want to Delete a row. Missing first argument.");
    }
    
    return(false);
}

//-----------------------------------------------------------------------------
// stored proc call with no return value
// DB::Sproc("myProcedure", "'parameter1', 'parameter2'");
function DB::SprocNoRet(%sprocName, %inParameters)
{
   if(!isObject($db))
   {
      error("DB::Sproc ERROR: database connection does not exist");
      return false;
   }
    
   %query = "";
   
   //make sure they sent us a sproc name
   if(%sprocName !$= "")
   {
	  //error("testing db software");
      //test for db software
      if($Server::DB::Software == 2 || $Server::DB::Software == 3
		|| $Server::DB::Software == 4)
      {
         //see if they are passing parameters
         if(%inParameters !$= "")
		 {
            %query = "EXEC" SPC %sprocName SPC %inParameters @ ";";
		 }
         else
		 {
            %query = "EXEC" SPC %sprocName @ ";";
		 }
      }
      else
      {
         //see if they are passing parameters
         if(%inParameters !$= "")
            %query = "CALL" SPC %sprocName @ "(" @ %inParameters @ ");";
         else
            %query = "CALL" SPC %sprocName @ "();";
      }
      %retVal = $db.Execute( %query );
      if ( isObject(%retVal) )
         %retVal.delete();
         
      return true;
   }
   else
     echo("DB::Sproc() ERROR: Unable to determine what sproc you want to call. Missing first argument.");
   
   return false;
}
