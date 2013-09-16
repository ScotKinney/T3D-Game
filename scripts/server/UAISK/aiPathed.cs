//****************************************************************
//The Universal AI Starter Kit (AISK)
//Copyright (c) 2009-2011 Twisted Jenius - All rights reserved.
//This file is engine NEUTRAL.
//****************************************************************


//-----------------------------------------------------------------------------
//Pathed AI Functions
//-----------------------------------------------------------------------------

//This function gets the closest path node to the bot
function AIPlayer::followPath(%obj, %path)
{
   //Start the bot following a path
   %obj.stopThread(0);

   //Check if the bot is pathed
   if (!isObject(%path))
   {
      warn("Bot ID " @ %obj @ " is on an invalid path of: " @ %path);
      %obj.path = "";
      return;
   }

   %dist = 0;
   %tempdist = 0;
   %index = -1;
   %botpos = %obj.getPosition();
   %count = %path.getCount();

   //Cycle through all nodes on this path and set the closest node as the bot's current location
   while (%count > 0)
   {
      %nodepos = %path.getObject(%count - 1).getPosition();
      %tempdist = VectorDistSquared(%nodepos, %botpos);

      if (%tempdist < %dist || %dist == 0)
      {
         %dist = %tempdist;
         %index = %count;
      }

      %count--;
   }

   %index = %index - 1;
   %obj.moveToNode(%index);
}

//This function sets what path node the bot should move to next
function AIPlayer::moveToNextNode(%obj)
{
   //See if the bot just sidesteped
   if (%obj.returningPath == 2)
   {
      //Set returningPath back to 1 for other functions
      %obj.returningPath = 1;
      %obj.moveToNode(%obj.currentNode);

      return;
   }

    %path = %obj.path;

   //Get the msToNext for the node that the bot just came from
   %nextSec = %path.getObject(%obj.currentNode).msToNext;

   // Have the bot wait before moving to the next node if needed
   // This function can be called repeatedly from onReachDestination() if the
   // destination is not changed. add a check to prevent that
   if ( %obj.pathPaused )
      return;

   if (%nextSec > 10 && !%obj.nextNode)
   {
      cancel(%obj.nextNode);
      %obj.nextNode = schedule(%nextSec, %obj, "delayMovingToNode", %obj);
      %obj.pathPaused = true;
      return;
   }

   %obj.nextNode = 0;

   //Move to the next node, unless the bot is at the last node then move to the first
   if (%obj.currentNode < %path.getCount() - 1)
      %obj.moveToNode(%obj.currentNode + 1);
   else
   {
      //If the path is set to looping then the bot should loop
      if (%path.getFieldValue(isLooping) == 1)
         %obj.moveToNode(0);
      //If its not then start guarding at the last node
      else
      {
         %obj.returningPos = %path.getObject(%obj.currentNode).getPosition();
         //Set the bots destination's Z value to its current Z value,
         //this will cause the bot to ignore height which may prevent errors
         %obj.returningPos = setWord(%obj.returningPos, 2, (getWord(%obj.getPosition(), 2)));
         //Set this in case the bot needs to returnToMarker
         %obj.oldPath = %obj.returningPos;

         //If you wanted to make a scripted event, you'd likely want to put some code here
         %obj.currentNode = "";
         %obj.path = "";
         %obj.action = "Guarding";
      }
   }
}

//This function moves the bot to the next path node
function AIPlayer::moveToNode(%obj, %index)
{
   // Make sure there's a valid path
   if ( !isObject(%obj.path) )
      return;

   //Move to the given path node index
   %obj.currentNode = %index;
   %node = %obj.path.getObject(%index);

   // If the node has a speed defined, use it, otherwise set default path speed
   if ( %node.MoveSpeed !$= "" )
      %obj.setMoveSpeed(%node.MoveSpeed);
   else
      %obj.setMoveSpeed($AISK_PATH_SPEED);

   //The 0 at the end sets if the bot should slow down or not, you can change it if needed
   %obj.setMoveDestination(%node.getPosition(), 0);

   //Make the bot face the node it's moving to
   %obj.setAimLocation(%obj.path.getObject(%obj.currentNode).getPosition());
}

//TGE can't call the other function directly
function delayMovingToNode(%obj)
{
   %obj.pathPaused = false;
   AIPlayer::moveToNextNode(%obj);
}


//-----------------------------------------------------------------------------
//Path Management Functions
//-----------------------------------------------------------------------------

//Reverse the direction that the bot will travel the path in
function reversePathOrder(%path)
{
   if (!isObject(%path))
   {
      if ($AISK_SHOW_NAME $= "Debug")
         warn("Invalid path of: " @ %path);

      return;
   }

   %count = %path.getCount();

   //Change around each node's seqNum
   for (%j = 0; %j < %count; %j++)
   {
      %node = %path.getObject(%j);
      %node.seqNum = %count - %j;
   }

   %first = %path.getObject(0);

   //Change around each node's position in the path,
   //has to be done after the above for large paths
   for (%j = 0; %j < %count; %j++)
   {
      %last = %path.getObject(%count - 1);

      if (%last != %first)
         %path.reorderChild(%last, %first);
   }
}

//Move each node on the path a certain amount
function moveWholePath(%path, %offset)
{
   if (!isObject(%path) || %offset $= "")
   {
      warn("No offset given or invalid path of: " @ %path);
      return;
   }

   if (getWord(%offset, 0) == 0 && getWord(%offset, 1) == 0 && getWord(%offset, 2) == 0)
   {
      warn("The given offset was 0.");
      return;
   }

   %count = %path.getCount();

   //Add an offset to the position of each node
   for (%j = 0; %j < %count; %j++)
   {
      %node = %path.getObject(%j);
      %pos = vectorAdd(%node.position, %offset);
      %node.position = %pos;
   }
}

//Change the scale of a path by moving each node a % to/from the center
function rescalePath(%path, %scale)
{
   if (!isObject(%path) || %scale $= "")
   {
      warn("No scale given or invalid path of: " @ %path);
      return;
   }

   %scaleX = getWord(%scale, 0) / 100;
   %scaleY = getWord(%scale, 1) / 100;
   %scaleZ = getWord(%scale, 2) / 100;

   //Give just scale 1 value for even scaling in all directions
   if (getWordCount(%scale) == 1)
   {
      %scaleY = %scaleX;
      %scaleZ = %scaleX;
   }
   //Give 2 values for X and Y scaling only
   else if (getWordCount(%scale) == 2)
      %scaleZ = 0;
   //Give all 3 values for separate X, Y, Z scaling

   %count = %path.getCount();

   //Find the center of this path
   for (%j = 0; %j < %count; %j++)
   {
      %pos = %path.getObject(%j).getPosition();

      %avgX = ((%avgX * %j) + getWord(%pos, 0)) / (%j + 1);
      %avgY = ((%avgY * %j) + getWord(%pos, 1)) / (%j + 1);
      %avgZ = ((%avgZ * %j) + getWord(%pos, 2)) / (%j + 1);
   }

   //Make each node go toward or away from the center by a percentage
   for (%i = 0; %i < %count; %i++)
   {
      %node = %path.getObject(%i);
      %pos = %node.getPosition();

      //X
      %diffX = %avgX - getWord(%pos, 0);
      %diffX = %diffX * %scaleX;
      %diffX = getWord(%pos, 0) - %diffX;

      //Y
      %diffY = %avgY  - getWord(%pos, 1);
      %diffY = %diffY * %scaleY;
      %diffY = getWord(%pos, 1) - %diffY;

      //Z
      %diffZ = %avgZ  - getWord(%pos, 2);
      %diffZ = %diffZ * %scaleZ;
      %diffZ = getWord(%pos, 2) - %diffZ;

      //Change to the new position
      %node.position = %diffX SPC %diffY SPC %diffZ;
   }
}
