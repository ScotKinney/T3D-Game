// Localized chat messages in english

// The following 2 lines must be present and not altered or translated
if ( !isObject(chatStrings) )
   new ScriptObject(chatStrings);

// The following text between quotes should be translated to the target language
// Any character that follows a '\' is an escape character and should not be
// altered in translation.
// \c0, \c1, \c2, \c3, \c4 and \c5 are color codes.
// %N where N = {1-5} are arguments and will be supplied by the server

// Message 1 - Displayed to a user when they first login. %1 is the user name.
chatStrings.msg[1] = "\c2Welcome %1.";

// Message 2 - Displayed to all other users when a player joins the game. %1 is
// the user name for the joining player.
//chatStrings.msg[2] = "\c1%1 joined the game.";
chatStrings.msg[2] = "\c1%1 has entered the AlterVerse.";

// Message 3 - Displayed to all remaining players when a player leaves the game.
// %1 is the user name for the player that left.
chatStrings.msg[3] = "\c1%1 has left the AlterVerse.";

// Message 4 - Displayed to a player that tries to send local chat when not on
// a game server.
chatStrings.msg[4] = "\c1You must be on a game world to send local chat.";

// Message 5 - Displayed to a player that tries to teleport before reaching
// skull level 4.
chatStrings.msg[5] = "\c1You must be skull level 4 or higher to teleport.";

// Message 6 - When double-clicking a server that can't be teleported to
chatStrings.msg[6] = "\c1You must find a portal to get to this server.";

// Message 7 - Displayed when the chat server goes down
chatStrings.msg[7] = "\c2Lost connection to the chat server. Trying to reconnect.";

// Message 8 - Displayed when trying to create a party while in one
chatStrings.msg[8] = "\c1You must leave the current party before creating your own.";

// Message 9 - Displayed when a party has been created for this player
chatStrings.msg[9] = "\c1New party created.";

// Message 10 - Displayed to a user that closes a chat party
chatStrings.msg[10] = "\c1Party closed.";

// Message 11 - Displayed to all active members when their party is closed
// %1 is the name of the host player that closed the party
chatStrings.msg[11] = "\c1%1 has closed the party.";

// Message 12 - Displayed to a user when they leave a chat party
chatStrings.msg[12] = "\c1You have left the party.";

// Message 13 - Displayed to all active members when a member leaves 
// %1 is the name of the player leaving
chatStrings.msg[13] = "\c1%1 has left the party.";

// Message 14 - Displayed when a host clicks invite player, but there are no
// players left that aren't already in the party.
chatStrings.msg[14] = "\c1No players available to invite.";

// Message 15 - Displayed to all members of a party when a player is invited
// %1 is the name of the player invited
chatStrings.msg[15] = "\c1Invite sent to %1.";

// Message 16 - Displayed to host when trying to send a duplicate invite.
// %1 is the name of the player invited
chatStrings.msg[16] = "\c1You already have an invite pending for %1.";

// Message 17 - Displayed to a player when receiving a party invite.
// %1 is the name of parties host
chatStrings.msg[17] = "\c1%1 has invited you to join a party.";

// Message 18 - Displayed to all party members when a player is invited.
// %1 is the name of the player invited
chatStrings.msg[18] = "\c1Party invitation sent to %1.";

// Message 19 - Displayed to a player when being kicked out of a party.
// %1 is the party host.
chatStrings.msg[19] = "\c1You have been removed from the party by %1.";

// Message 20 - Displayed to all party members when a player is kicked.
// %1 is the name of the player joining
chatStrings.msg[20] = "\c1%1 has been removed from the party.";

// Message 21 - Displayed to a player when joining a party.
// %1 is the name of the party host.
// %2 is a list of all party members separated by commas(,).
chatStrings.msg[21] = "\c1You have joined the %1 party. Members: %2.";

// Message 22 - Displayed to all party members when a new player joins.
// %1 is the name of the player joining
chatStrings.msg[22] = "\c1%1 has joined the party.";

// Message 23 - Displayed to a player when declining a party invitation.
// %1 is the party host.
chatStrings.msg[23] = "\c1Invite from %1 declined.";

// Message 24 - Displayed to all party members when an invitation is declined.
// %1 is the name of the player joining
chatStrings.msg[24] = "\c1%1 declined the invitation.";

// Message 25 - Displayed when a player tries to join a party that is no longer
// active.
chatStrings.msg[25] = "\c1Party is not available.";

// Message 26 - Displayed when a player tries to send party chat when not in a
// party.
chatStrings.msg[26] = "\c1You must be in a party to send party chat.";

// Message 27 - Displayed when muting a player.
// %1 is the name of the player being muted
chatStrings.msg[27] = "\c1You have muted %1.";

// Message 28 - Displayed when unmuting a player.
// %1 is the name of the player being unmuted
chatStrings.msg[28] = "\c1You have unmuted %1.";

// Message 29 - Text added to instant messages that we receive.
chatStrings.msg[29] = " (IM) ";

// Message 30 - Text added to instant messages that we send.
// %1 is the name of the player the IM was sent to
chatStrings.msg[30] = " (To %1) ";

// Message 31 - Message displayed if we attempt to add a friend that is already
// in our friends list.
// %1 is the name of the friend
chatStrings.msg[31] = "%1 is already in your friends list.";

// Message 32 - Message displayed if we attempt to send a friend request to a
// player that we already have a pending request for
// %1 is the name of the player we're sending a friend request to
chatStrings.msg[32] = "You already have a pending friend request for %1.";

// Message 33 - Message displayed when a friend request has been sent
// %1 is the name of the player we're sending a friend request to
chatStrings.msg[33] = "Friend request sent to %1.";

// Message 34 - Telegram subject when removed from a friends list
// %1 is the name of the player the telegram is from
chatStrings.msg[34] = "%1 has removed you from their friends list.";

// Message 35 - Telegram subject when receiving a friend request
// %1 is the name of the player the telegram is from
chatStrings.msg[35] = "Friend request from %1.";

// Message 36 - Telegram subject when a friend request has been accepted
// %1 is the name of the player the telegram is from
chatStrings.msg[36] = "%1 has joined your friends list.";

// Message 37 - Telegram subject when a friend request has been declined
// %1 is the name of the player the telegram is from
chatStrings.msg[37] = "%1 has declined joining your friends list.";

// Message 45 - Message displayed if we attempt to send a friend request to a
// player that does not exist
// %1 is the name of the player that we entered
chatStrings.msg[45] = "Cannot find a player named %1.";

// Message 46 - Message displayed when a telegram is sent
// %1 is the name of the player that it was sent to
chatStrings.msg[46] = "Telegram sent to %1.";

// Message 47 - Message displayed when a telegram cannot be read from the database
chatStrings.msg[47] = "Telegram is not available at this time.";

// Transfer Trigger Messages ---------------------------------------------------
// Message tgrLvl - Message displayed when a user enters a transfer trigger that
// requires a higher skull level
chatStrings.msg[tgrLvl] = "\c0You must be skull level %1 or greater to use this portal.";
// Message sttMag - Message displayed when a migrant tries to use the portal to the magellan
chatStrings.msg[sttMag] = "\c0You must be a Citizen to enter the Magellan!";
// Message noFDMag - Message displayed when a migrant tries to use the portal to
// the magellan without having the flex decapitator.
chatStrings.msg[noFDMag] = "\c1A Boglin has stolen the Flex Decapitator! You need to find it to operate the Teleporter.";
// Message lvlUp - Message displayed when a player receives a new lock level
chatStrings.msg[lvlUp] = "\c0%1 has reached Lock Level %2!";
// Message selfLvl - Message displayed to the player that gets a new Lock Level
chatStrings.msg[selfLvl] = "\c0Congratulations! You've reached Lock Level %1!";

// Chat Log Messages -----------------------------------------------------------
// chatLogOn - This message is displayed when user activates chat logging.
chatStrings.chatLogOn = "Chat logging is active. Press 'C' to turn off.";
// chatLogOn - This message is displayed when user deactivates chat logging.
chatStrings.chatLogOff = "Chat logging is disabled. Press 'C' to turn on.";
// chatLogOpen - This message is written to the log when the log is opened.
chatStrings.chatLogOpen = "*** Log opened ";
// chatLogClosed - This message is written to the log when the log is closed.
chatStrings.chatLogClosed = "*** Log closed ";


// Fishing messages ------------------------------------------------------------
// fishDistMsg - This message is displayed when a user tries to cast their
// fishing hook farther than the maximum distance.
chatStrings.fishDistMsg = "\c0You can't cast your line that far.";
// fishStart - Displayed when the fishing pole is equipped
chatStrings.msg[fishStart] = "\c0You take out your fishing pole. Click on water to begin fishing.";
// fishEnd - Displayed when the fishing pole is put away
chatStrings.msg[fishEnd] = "\c0You put your fishing pole away.";
// fishCast - Displayed when the line is cast
chatStrings.msg[fishCast] = "\c0You cast your line and wait...";
// fishMove - Displayed when a player leaves their fishing spot before catching a fish
chatStrings.msg[fishMove] = "\c0You leave your fishing spot and reel in your line.";
// fishingNA - Displayed when a player tries fishing in water where it is not allowed
chatStrings.msg[fishingNA] = "\c0This water has not been stocked with fish yet. No Fishing Here!";
// fishPoleFirst - Displayed when a player tries to bait their hook before equipping their pole.
chatStrings.msg[fishPoleFirst] = "\c0You must equip your fishing pole before you can bait your hook.";
// fishSteal - Displayed when the fish is stolen by an AI. %1 is the type of AI
chatStrings.msg[fishSteal] = "\c0A %1 stole your fish!";
// fishCaught - Displayed when a fish is caught, %1 is the type of fish
chatStrings.inv[fishCaught] = "\c5You caught a %name%!!! Bait your hook and cast again to keep fishing!";
// fishBaited - Displayed when a player baits their hook, %1 is the type of bait
chatStrings.inv[fishBaited] = "\c0You put a %name% on your hook.";
// fishReelBait - Displayed when a player baits their hook if the line is already cast
chatStrings.inv[fishReelBait] = "\c0You reel in your line and put a %name% on your hook.";
// fishHasBait - Displayed when trying to bait a hook that already has bait. %1 is the bait already on the hook
chatStrings.inv[fishHasBait] = "\c0You already have a %name% on your hook.";

// Fishing Junk messages
// These messages get displayed when "junk" is caught. A message will be
// randomly chosen from the list of messages. There are two sets, one for a 
// baited hook and one for a hook with no bait
chatStrings.fishJunk[0] = "\c0You reeled in a bunch of sea weed.";
chatStrings.fishJunk[1] = "\c0You caught a Madonna video. Throw it back!";
chatStrings.fishJunk[2] = "\c0You reeled in a rusty helmet";
chatStrings.fishJunk[3] = "\c0You reeled in an old sandal.";
chatStrings.fishJunk[4] = "\c0You snagged Michael Jackson's other glove!";
chatStrings.NumJunkNBMsgs = 5;
chatStrings.fishJunk[5] = "\c0A muskrat stole your bait. Try again.";
chatStrings.fishJunk[6] = "\c0A crab ate your bait. Try again.";
chatStrings.fishJunk[7] = "\c0A turtle took your bait and swam away. Try again.";
chatStrings.NumJunkMsgs = 8;

// Waiting messages
// These messages get displayed while the user is waiting for a bite.
chatStrings.fishWait[0] = "\c0You ponder the meaning of it all while you wait for a bite...";
chatStrings.fishWait[1] = "\c0No bites yet...You wonder if you are using the right bait...";
chatStrings.fishWait[2] = "\c0The breeze feels good in your hair...no bites yet...";
chatStrings.fishWait[3] = "\c0You think you see something moving in the water...";
chatStrings.fishWait[4] = "\c0You think you smell something burning...naw...";
chatStrings.fishWait[5] = "\c0You rip a silent but deadly one and hope no one walks over...";
chatStrings.fishWait[6] = "\c0You scratch your butt and hope that no one noticed...still no nibbles...";
chatStrings.fishWait[7] = "\c0You think back to a simpler time while waiting for a bite...";
chatStrings.fishWait[8] = "\c0You decide to Invite A Friend while you wait for a fish to bite...";
chatStrings.fishWait[9] = "\c0You think to yourself, man fishing sure is fun...";
chatStrings.fishWait[10] = "\c0You pick your nose and wonder if it would work as bait...";
chatStrings.fishWait[11] = "\c0You wonder if the Hokey Pokey might really be what it's all about...nothing yet...";
chatStrings.fishWait[12] = "\c0Your senses are on high alert for any Boglins that might steal your fish...no they're not...";
chatStrings.fishWait[13] = "\c0You find yourself humming that Stones tune Waiting on a Friend...no fish yet...";
chatStrings.fishWait[14] = "\c0You decide to buy some Arns while you wait for a fish...just because you can...";
chatStrings.fishWait[15] = "\c0Is it your imagination or are you really getting better looking each day?...still no nibbles...";
chatStrings.fishWait[16] = "\c0You kick yourself for thinking bell bottom jeans looked cool...twice...";
chatStrings.fishWait[17] = "\c0You feel a tug on your line and...wait...someone's pulling your leg too!...doh!";
chatStrings.fishWait[18] = "\c0Now that you think about it, a fish taco sounds kind of gross...no bites yet...";
chatStrings.fishWait[19] = "\c0One more fish and then it's time to go hunting! Yeah, that's the ticket!";
chatStrings.NumWaitMsgs = 20;

// Inventory messages ----------------------------------------------------------
// Substitution codes: do not change the text between the %'s
// %name% - Item name
// %pname% - Plural name
// %desc% - Item description
//
// tooMany - Displayed when a player tries to pickup an item they already have
// the maximum of.
chatStrings.inv[tooMany] = "\c0You cannot carry another %name%.";
// noAmmo - Displayed when a player runs out of ammo
chatStrings.inv[noAmmo] = "\c0Your %name% is out of ammo.";
// noThrown - Displayed when a player runs out of a throwing weapon
chatStrings.inv[noThrown] = "\c0You have no more %pname% to throw.";
// eatFull - Displayed when eating more than needed to restore full health
chatStrings.inv[eatFull] = "\c0You gorge yourself on %name% then puke on your shoes. %1 point(s) were added to your Health.";
// eatOK - Displayed when eating to restore health
chatStrings.inv[eatOK] = "\c0You eat a %name% restoring %1 point(s) to your Health.";
// sellOne - Displayed when selling an item
chatStrings.inv[sellOne] = "\c0You sell 1 %name% for %1 arn.";
// sellMany - Displayed when selling multiples of an item
chatStrings.inv[sellMany] = "\c0You sell %1 %pname% for %2 arn.";
// buyOne - Displayed when buying an item
chatStrings.inv[buyOne] = "\c0You buy 1 %name% for %1 arn.";
// buyMany - Displayed when buying multiples of an item
chatStrings.inv[buyMany] = "\c0You buy %1 %pname% for %2 arn.";
// affordOne - Displayed when trying to buy an item
chatStrings.inv[affordOne] = "\c0You can\'t afford %1 arn for a %name%.";
// affordMany - Displayed when trying to buy multiples of an item
chatStrings.inv[affordMany] = "\c0You can\'t afford %1 arn for %pname%.";
// pickOne - Displayed when picking up an item
chatStrings.inv[pickOne] = "\c0You picked up 1 %name%.";
// pickMany - Displayed when picking up multiples of an item
chatStrings.inv[pickMany] = "\c0You picked up %1 %pname%.";
// dropOne - Displayed when dropping an item
chatStrings.inv[dropOne] = "\c0You drop 1 %name%.";
// dropMany - Displayed when dropping multiples of an item
chatStrings.inv[dropMany] = "\c0You drop %1 %pname%.";

// noArmor - You cannot equip armor yet.
chatStrings.msg[noArmor] = "\c0You cannot equip armor yet.";
// noMagic - You cannot use magic yet.
chatStrings.msg[noMagic] = "\c0You cannot use magic yet.";
// noGems - You cannot use gems yet.
chatStrings.msg[noGems] = "\c0You cannot use gems yet.";
// noMisc - You cannot use this yet.
chatStrings.msg[noMisc] = "\c0You cannot use this yet.";
// noClan - This item does not belong to your clan.
chatStrings.msg[noClan] = "\c0This item does not belong to your clan.";
// lowSkull - You must be skull level %1 to pick up this item.
chatStrings.msg[lowSkull] = "\c0You must be skull level %1 to pick up this item.";
// gainArn - You gain $1 arn.
chatStrings.msg[gainArn] = "\c0You gain %1 arn.";
// spendArn - You spend $1 arn.
chatStrings.msg[spendArn] = "\c0You spend %1 arn.";
// minTransfer - You do not have %1 reserve arns to transfer.
chatStrings.msg[minTransfer] = "\c0You do not have %1 reserve arns to transfer.";

// Mount/Horse messages --------------------------------------------------------
// mountMsg - Displayed when a player tries to mount an AI that is driven by
// another player. %1 is the drivers name.
chatStrings.msg[mountMsg] = "\c1Asking %1 if you can ride along...";
// mountRequest - Displayed to a driver when a passenger tries to mount.
// %1 is the passengers name.
chatStrings.msg[mountRequest] = "Can %1 ride with you?";
// stowHorse - Displayed when a horse is put away.
chatStrings.msg[stowHorse] = "\c0You put your horse back in the stable.";
// horseLeave - Displayed when a horse is abandoned.
chatStrings.msg[horseLeave] = "\c0Your horse has gotten lonely and disowned you. It will accept whoever claims it and puts it back in the stable, as it's new owner.";
// horseDie - Displayed when an owned horse dies.
chatStrings.msg[horseDie] = "\c0Your horse has died.";
// horseNoDrop - Displayed when trying to drop a horse on a no horse level.
chatStrings.msg[horseNoDrop] = "\c0You can\'t drop a horse here.";
// noHorse - Displayed when trying to ride a horse on a no horse level.
chatStrings.msg[noHorse] = "\c0You can\'t bring your horse here.";

// Lantern/Lamp Oil messages ---------------------------------------------------
// lntnOn - You turned on the Lantern.
chatStrings.msg[lntnOn] = "\c0You turned on the Lantern.";
// lntnOff - You turned off the Lantern.
chatStrings.msg[lntnOff] = "\c0You turned off the Lantern.";
// noLntn - You don't have a Lantern.
chatStrings.msg[noLntn] = "\c0You don\'t have a Lantern.";
// needLntn - You need a Lantern to burn the oil in.
chatStrings.msg[needLntn] = "\c0You need a Lantern to burn the oil in.";
// noOil - You need oil to burn in the Lantern.
chatStrings.msg[noOil] = "\c0You need oil to burn in the Lantern.";
// oilOut - You ran out of Lamp Oil. Better get some more!
chatStrings.msg[oilOut] = "\c0You ran out of Lamp Oil. Better get some more!";
// oneOil - You have 1 bottle of Lamp Oil left.
chatStrings.msg[oneOil] = "\c0You have 1 bottle of Lamp Oil left.";
// numOil - You have %1 bottles of Lamp Oil left.
chatStrings.msg[numOil] = "\c0You have %1 bottles of Lamp Oil left.";
// noOilImm - You don't have enough Lamp Oil to perform Self Immolation.
chatStrings.msg[noOilImm] = "\c0You don't have enough Lamp Oil to perform Self Immolation.";

// Death messages --------------------------------------------------------------
// deathLoss - You have died, losing
chatStrings.msg[deathLoss] = "\c1You have died, losing ";
// deathNoLoss - You have died.
chatStrings.msg[deathNoLoss] = "\c1You have died.";
