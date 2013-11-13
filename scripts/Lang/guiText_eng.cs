// Localized gui text in english

// The following 2 lines must be present and not altered or translated
if ( !isObject(guiStrings) )
   new ScriptObject(guiStrings);

// The following text between quotes should be translated to the target language
// Please do not translate comments so we know what the original text was.

// General button labels used on many guis -------------------------------------
guiStrings.btnOK = "OK";
guiStrings.btnCancel = "Cancel";
guiStrings.btnClose = "Close";
guiStrings.btnYes = "Yes";
guiStrings.btnNo = "No";
guiStrings.btnSend = "Send";
guiStrings.btnRemove = "Remove";
guiStrings.btnAccept = "Accept";  // Accept
guiStrings.btnDecline = "Decline";  // Decline
guiStrings.btnRelpy = "Reply";  // Reply
guiStrings.btnView = "View";  // View
guiStrings.btnDelete = "Delete";  // Delete
guiStrings.btnSearch = "Search";  // Search
guiStrings.btnDetails = "Details";  // Details


// General purpose phrases and words -------------------------------------------
guiStrings.selPlayer = "Select Player";
guiStrings.selInvite = "Select Invite";
guiStrings.noResults = "No Results Found";
guiStrings.cost = "Cost";
guiStrings.each = "Each";
guiStrings.value = "Value";
guiStrings.total = "Total";

// Chat Box Strings (MainChatHud) ----------------------------------------------
// The tab book labels
guiStrings.chatTab[0] = "Global";
guiStrings.chatTab[1] = "Local";
guiStrings.chatTab[2] = "Clan";
guiStrings.chatTab[3] = "Party";
guiStrings.chatTab[4] = "Friends";

// The Party pane Buttons
guiStrings.chatPBCreate = "Create Party";
guiStrings.chatPBInvite = "Invite Player";
guiStrings.chatPBRemove = "Remove Player";
guiStrings.chatPBClose = "Close Party";
guiStrings.chatPBLeave = "Leave Party";
guiStrings.chatPBAccept = "Accept Invite";
guiStrings.chatPBDecline = "Decline Invite";
guiStrings.selParty = "Select Party";
guiStrings.chatPBSndInt = "Send Invite";
guiStrings.chatPBConfirmDec = "Confirm Decline";
guiStrings.chatPBConfirmRem = "Confirm Remove";

// The Friend pane Buttons
guiStrings.chatFBAdd = "Add Friend";
guiStrings.chatFBRemove = "Remove Friend";

// User list column headings (UserListGui) -------------------------------------
// The column headings are clickable text: Name, Skulls, Clan
guiStrings.ulHeading[0] = "Name";
guiStrings.ulHeading[1] = "Skulls";
guiStrings.ulHeading[2] = "Clan";

// User popup menu options (UserPopup) -----------------------------------------
guiStrings.userOption[0] = "Send Friend Request";  // Send Friend Request
guiStrings.userOption[1] = "Remove Friend";  // Remove Friend
guiStrings.userOption[2] = "Send IM";  // Send IM
guiStrings.userOption[3] = "Send Telegram";  // Send Telegram
guiStrings.userOption[4] = "Invite To Party";  // Invite To Party
guiStrings.userOption[5] = "Remove From Party";  // Remove From Party
guiStrings.userOption[6] = "Mute";  // Mute
guiStrings.userOption[7] = "Unmute";  // Unmute

// Friend request/Player search (AddFriend) ------------------------------------
guiStrings.addFrTitle = "Send Friend Request To:";  // Send Friend Request To:

// Telegram windows (SendTelegram,ViewTelegram) --------------------------------
guiStrings.sendTGTitle = "Telegram To:";  // Send Telegram To:
guiStrings.viewTGTitle = "Telegram From:";  // Telegram From:
guiStrings.subjectHdr = "Subject:";  // Subject:
guiStrings.messageHdr = "Message:";  // Message:
guiStrings.replyPrefix = "Re: ";  // "Re: "

// Skull level dialog (SkullLevelUpGui) ----------------------------------------
guiStrings.lvlUpTitle = "!!Congratulations!!";  // !!Congratulations!!
guiStrings.lvlUpLine1 = "You Have Reached";     // You Have Reached
guiStrings.lvlUpLine2 = "Skull Level %1";       // Skull Level %1

// Banking strings (BankingGui) ------------------------------------------------
guiStrings.bankCaption = "Banking with %1"; // Banking with %1

// NPC Messages ----------------------------------------------------------------
guiStrings.npcMsgTitle[0] = "";  //
guiStrings.npcMsgBody[0] = "";   //

// Quest Messages --------------------------------------------------------------
guiStrings.questMsgBody[0] = "";

// Item Popup strings ----------------------------------------------------------
guiStrings.horsePopup = "This horse belongs to %1. You can buy your own at the stables.";
guiStrings.qtyHeader = "Quantity:";
guiStrings.nutHeader = "Nutrition:";
guiStrings.tgtHeader = "Target:";   // Target header
guiStrings.target[Enemy] = "Enemy";
guiStrings.target[Self] = "Self";

// Message box strings ---------------------------------------------------------
// Send friend request to %1?
guiStrings.mbFriendRequest = "Send friend request to %1?";
// Remove %1 from friends list?
guiStrings.mbFriendRemove = "Remove %1 from friends list?";
// Select the target area for the %1 spell.
guiStrings.mbAFXFreeTarget = "Select the target area for the %1 spell.";
// You hit the %1 treasury for %2 arns.
guiStrings.mbTreasuryHit = "You hit the %1 treasury for %2 arns.";

// You must be on a multi-player server to assign build rights.
guiStrings.mbRightsErr[0] = "You must be on a multi-player server to assign build rights.";
// Error assigning build rights.
guiStrings.mbRightsErr[1] = "Error assigning build rights.";

// Center Print Messages -------------------------------------------------------
// Neutral Zone messages
// You have entered a Neutral Zone, your weapons wont work here!
guiStrings.cpMsg[GenNZIn] = "You have entered a Neutral Zone, your weapons will not work here!";
// You have left the Neutral Zone, be on guard!
guiStrings.cpMsg[GenNZOut] = "You have left the Neutral Zone, be on guard!";
// You have entered the Tortuga NZ Market area, your weapons wont work here!
guiStrings.cpMsg[TortNZIn] = "You have entered the Tortuga NZ Market area, your weapons wont work here!";
// You have left the Tortuga Neutral Zone, arm yourself!
guiStrings.cpMsg[TortNZOut] = "You have left the Tortuga Neutral Zone, arm yourself!";
// Danger! You have left the Neutral Zone, watch out for the Yeti!
guiStrings.cpMsg[GMNZOut] = "Danger! You have left the Neutral Zone, watch out for the Yeti!";
