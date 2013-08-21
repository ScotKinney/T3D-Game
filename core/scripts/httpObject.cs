/*
   httpObject.cs
   defines the behaviour for HTTPObjects used for php lookups
   
   Guy Allard
   20 Apr 2010
*/

function HTTPObject::onLine( %this, %line )
{
   if( strstr( %line, ":=" ) != -1 )
   {
      %params = NextToken( %line, "varName", ":=");
      eval("%this."@%varName@"="@"\""@%params@"\";");
   }
   // uncomment the following to output full response to the console
   if ( $pref::MarsMachine )
      warn( %line );
}

function HTTPObject::onConnectionDied( %this )
{
	//error( "HTTPObject - onConnectionDied" );
	%this.status = "failure";
	%this.message = "Connection to the server has been lost";
  	%this.process();
}

function HTTPObject::onDNSFailed( %this )
{
	//error( "HTTPObject - onDNSFailed" );
	%this.status = "failure";
	%this.message = "Could not connect to the server";
 	%this.process();
}

function HTTPObject::onConnectFailed( %this )
{
	//error( "HTTPObject - onConnectFailed" );
	%this.status = "failure";
	%this.message = "Could not connect to the server";
 	%this.process();
}

function HTTPObject::onConnected( %this )
{
   //error( "HTTPObject - onConnected" );
}

function HTTPObject::onDisconnect( %this )
{
   //error( "HTTPObject - onDisconnect" );
   %this.process();
}

function HTTPObject::onRemove( %this )
{
   //error( "HTTPObject - deleted");
}