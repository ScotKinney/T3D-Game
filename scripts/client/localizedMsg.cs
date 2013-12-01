//-----------------------------------------------------------------------------
// Handlers for localized messages
//-----------------------------------------------------------------------------

// Generic message handler
addMessageCallback('LocalizedMsg', handleLocalizedMsg);

function handleLocalizedMsg(%msgType, %str, %msgCode, %channel, %notify, %skipLog, %numArgs, %a0, %a1, %a2, %a3, %a4)
{
   %message = chatStrings.msg[%msgCode];
   for (%i = 0; %i < %numArgs; %i++)
      %message = strReplace(%message, "%" @ (%i+1), %a[%i]);

   MainChatHud.addLine(%message, %channel, %notify, %skipLog);
}

// Inventory message handler
addMessageCallback('InventoryMsg', handleInventoryMsg);

function handleInventoryMsg(%msgType, %str, %msgCode, %itemID, %channel, %notify, %skipLog, %numArgs, %a0, %a1, %a2, %a3, %a4)
{
   %message = chatStrings.inv[%msgCode];

   %name = getBarWord($AlterVerse::invDesc[%itemId], 1);
   %pname = getBarWord($AlterVerse::invDesc[%itemId], 2);
   if ( %pname $= "" )
      %pname = %name @ "s";
   %desc = getBarWord($AlterVerse::invDesc[%itemId], 3);

   %message = strReplace(%message, "%name%", %name);
   %message = strReplace(%message, "%pname%", %pname);
   %message = strReplace(%message, "%desc%", %desc);

   for (%i = 0; %i < %numArgs; %i++)
      %message = strReplace(%message, "%" @ (%i+1), %a[%i]);

   MainChatHud.addLine(%message, %channel, %notify, %skipLog);
}

// Fishing specific handler that randomly pulls messages from localized lists
addMessageCallback('FishingMsg', handleFishingMsg);

function handleFishingMsg(%msgType, %str, %msgCode, %channel, %notify, %skipLog)
{
   if ( %msgCode $= "Junk" )
   {
      %msgNum = getRandom(0, chatStrings.NumJunkMsgs-1);
      %message = chatStrings.fishJunk[%msgNum];
   }
   else if ( %msgCode $= "NBJunk" )
   {
      %msgNum = getRandom(0, chatStrings.NumJunkNBMsgs-1);
      %message = chatStrings.fishJunk[%msgNum];
   }
   else // It's a wait message
   {
      %msgNum = getRandom(0, chatStrings.NumWaitMsgs-1);
      %message = chatStrings.fishWait[%msgNum];
   }

   MainChatHud.addLine(%message, %channel, %notify, %skipLog);
}
