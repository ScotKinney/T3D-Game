//-----------------------------------------------------------------------------
// BLOODCLANS
// EPLS 9/13/2010
// MAR 11/2013

//-----------------------------------------------------------------------------
// Inventory server commands
//-----------------------------------------------------------------------------

function serverCmdUse(%client, %data)
{
   %client.getControlObject().use(%data);
}

function serverCmdUseItem(%client, %id, %amount, %type)
{
   if ( %client.isAFK && (%id != AFK_Rune.ItemID) )
      return;  // 68 is the AFK rune, it's the only use allowed while AFK

   if ( isObject(%client.player) && %client.player.inNeutralZone &&
         (%type == 2) && (%id != AFK_Rune.ItemID) && (%id != Astral_Passport.ItemID) )
      return;  // AFK and the key the only magic allowed in NZ

   if ( isObject(%client.player) && (%id == AFK_Rune.ItemID) && %client.player.isMounted() )
      return;  // Don't allow AFK while mounted

   if ( isObject(%client.player) && %client.player.isMounted() )
      %client.player.UseItem(%id, %amount, %type);
   else
      %client.getControlObject().UseItem(%id, %amount, %type);
}

//Types 0=Armor, 1=weapon, 2=magic, 3=food, 4=gems, 5=misc
function ShapeBase::UseItem(%this, %id, %amount, %type)
{
   %key = $AlterVerse::ItemNames[%id];
   switch (%type)
   {
      case 0:  // Armor
         messageClient(%this.client, 'LocalizedMsg', "", "noArmor", "a", true, true, 0);

      case 1:  // Weapons
         %spos = strstr(%key, "Ammo");
         if ( %spos > -1 ) // If using ammo, use the weapon instead
            %key = getSubStr(%key, 0, %spos) @ "Weapon";
         if ( isObject(%key.image) )
         {
            if ( %this.isFishing )
               Fishing_Pole.onUse(%this); // Put away the pole
            %slot = %key.image.weaponSlot;
            if ( %key $= %this.client.lastWeapon[%slot] )
               %key = "";
            %this.unmountImage(%slot);
            %this.schedule(500, "AVMountImage", %key, %slot);
            %this.schedule(532, "AVCheckWeapons");
         }

      case 2:  // Magic
         //messageClient(%this.client, 'LocalizedMsg', "", "noMagic", "a", true, true, 0);
         if ( %this.hasInventory(%key) )
            %this.castSpell(%key);

      case 3: //eat something
         if ( %this.decInventory(%key, %amount) )
         {
            %nutrition = %key.nutrition;
            if ( %nutrition < 1 )
               %nutrition = 1;

            // adjust nutrition amount based on percentage of max damage
            %maxDamage = %this.getDataBlock().maxDamage;
            %health = mCeil((1 - %this.getDamagePercent()) * 100);
            %damagePercent = 100 - %health;
            if(%nutrition > %damagePercent)
            {
               %nutrition = %damagePercent;
               messageClient(%this.client, 'InventoryMsg',"", "eatFull", %key.ItemID, "a", false, true, 1, %nutrition);
            }
            else
               messageClient(%this.client, 'InventoryMsg',"", "eatOK", %key.ItemID, "a", false, true, 1, %nutrition);

            %nutritionAdjusted = (%nutrition / 100) * %maxDamage;
            %this.applyRepair(%nutritionAdjusted);
         }

      case 4:
         messageClient(%this.client, 'LocalizedMsg', "", "noGems", "a", true, true, 0);

      case 5:
         if(%this.use(%key) == false)
            messageClient(%this.client, 'LocalizedMsg', "", "noMisc", "a", true, true, 0);

      default:
   }
}

function serverCmdDropItem(%client, %id, %amount)
{
   %client.getControlObject().DropItem(%id, %amount);
}

function serverCmdSellItem(%client, %id, %amount, %value)
{
   %key = $AlterVerse::ItemNames[%id];
   %player = %client.player;
   %qtyOnHand = %player.getInventory(%key);
   if (%qtyOnHand > 0)
   {
      if ( %amount > %qtyOnHand )
         %amount = %qtyOnHand;   // Don't let them sell more than they have
      %value = %key.cost;  // Don't take clients word for value
      %sellval = %amount*%value;
      %client.giveArns(%sellval);
      %player.decInventory(%key, %amount, true);

      if ( %amount > 1 )
         messageClient(%this.client, 'InventoryMsg',"", "sellMany", %key.ItemID, "a", true, true, 2, %amount, %sellval);
      else
         messageClient(%this.client, 'InventoryMsg',"", "sellOne", %key.ItemID, "a", true, true, 1, %sellval);
   }
}

function serverCmdTransferArn(%client, %amount)
{  // Transfer the requested amount from reserve to active
   if ( !isObject(%client.pData) || (%amount <= 0) )
      return;

   if ( $Server::DB::Remote )
   {
      %args = "uID="@ %client.pData.dbID;
      %args = %args @ "&amount=" @ %amount;
      remoteDBCommand("TransferArn", %args, %client);
      return;
   }

   %results = DB::Select("reserveArns",
   /*FROM*/              "nuke_users",
   /*WHERE*/             "user_id='"@ %client.pData.dbID @ "'");

   %reserveArns = "0";
   if ( isObject(%results) )
   {
      if(%results.getNumRows() > 0)
         %reserveArns = %results.reserveArns;
      %results.delete();
   }

   if ( %amount <= %reserveArns )
   {
      %client.giveArns(%amount);
      %reserveArns = mSubBigNumbers(%reserveArns, %amount);
      DB::Update("nuke_users","reserveArns='" @ %reserveArns @ "'",
                  "user_id='"@ %client.pData.dbID @ "'");

      CommandToClient(%client, 'ReserveUpdate', %reserveArns);

      // update the clients net worth here
      %client.netWorth = mAddBigNumbers(%client.netWorth, %amount);
      %client.writeNetWorth();
      commandToClient(%client, 'setNetWorth', %client.netWorth);
   }
   else
      messageClient(%client, 'LocalizedMsg', "", "minTransfer", "a", true, true, 1, %amount);
}

function ShapeBase::DropItem(%this, %id, %amount)
{
   %key = $AlterVerse::ItemNames[%id];

   // Make sure they have at least the amount requested
   %invAmount = %this.getInventory(%key);
   if ( %invAmount < %amount )
      %amount = %invAmount;

   if (%amount > 0)
   {
      %obj = %key.onThrow(%this, %amount);
      if (%obj)
      {
         if ( %key.category !$= "horses" )
         {
            %this.throwObject(%obj);
            serverPlay3D(ThrowSnd, %this.getTransform());
         }
         
         if ( %amount > 1 )
            messageClient(%this.client, 'InventoryMsg',"", "dropMany", %key.ItemID, "a", true, true, 1, %amount);
         else
            messageClient(%this.client, 'InventoryMsg',"", "dropOne", %key.ItemID, "a", true, true, 0);

         return true;
      }
   }
   return false;
}

//-----------------------------------------------------------------------------
// ShapeBase inventory support
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

function ShapeBase::use(%this, %data)
{
   // Use an object in the inventory.

   // Need to prevent weapon changing when zooming
   //if ($ZoomOn $= false)
   //if ($ZoomOn)
   //{
      if (%this.getInventory(%data) > 0)
         return %data.onUse(%this);
   //}
   return false;
}

function ShapeBase::throw(%this, %data, %amount)
{
   // Throw objects from inventory. The onThrow method is
   // responsible for decrementing the inventory.

   if (%this.getInventory(%data) > 0)
   {
      %obj = %data.onThrow(%this, %amount);
      if (%obj)
      {
         %this.throwObject(%obj);
         serverPlay3D(ThrowSnd, %this.getTransform());
         return true;
      }
   }
   return false;
}

function ShapeBase::pickup(%this, %obj, %amount)
{
   // This method is called to pickup an object and add it to the inventory.
   // The datablock onPickup method is actually responsible for doing all the
   // work, including incrementing the inventory.

   %data = %obj.getDatablock();

   // Try and pickup the max if no value was specified
   if (%amount $= "")
      %amount = %this.maxInventory(%data) - %this.getInventory(%data);

   // The datablock does the work...
   if (%amount < 0)
      %amount = 0;
   if (%amount)
      return %data.onPickup(%obj, %this, %amount);
   return false;
}

//-----------------------------------------------------------------------------

function ShapeBase::hasInventory(%this, %data)
{
   if ( !isObject(%this.client.pInv) )
      return false;
      
   %amount = 0;
   %index = %this.client.pInv.getIndexFromKey(%data.ItemID);
   if (%index != -1)
      %amount = %this.client.pInv.getValue(%index);

   return (%amount > 0);
}

function ShapeBase::hasAmmo(%this, %weapon)
{
   if (%weapon.image.ammo $= "")
      return(true);
   else
      return %this.hasInventory(%weapon.image.ammo);
}

function ShapeBase::maxInventory(%this, %data)
{
   return %data.maxInventory;
}

function ShapeBase::incInventory(%this, %data, %amount, %isBuySell)
{
   // Increment the inventory by the given amount.  The return value
   // is the amount actually added, which may be less than the
   // requested amount due to inventory restrictions.
   if ( !isObject(%this.client.pInv) )
      %this.client.pInv = new ArrayObject();

   %max = %this.maxInventory(%data);
   %total = 0;
   %index = %this.client.pInv.getIndexFromKey(%data.ItemID);
   if ( %index != -1 )
      %total = %this.client.pInv.getValue(%index);

   if (%total < %max)
   {
      if (%total + %amount > %max)
         %amount = %max - %total;
      %this.setInventory(%data, %total + %amount, %isBuySell);
      return %amount;
   }
   return 0;
}

function ShapeBase::decInventory(%this, %data, %amount, %isBuySell)
{
   // Decrement the inventory by the given amount. The return value
   // is the amount actually removed.
   if ( !isObject(%this.client.pInv) )
      %this.client.pInv = new ArrayObject();

   %total = 0;
   %index = %this.client.pInv.getIndexFromKey(%data.ItemID);
   if ( %index != -1 )
      %total = %this.client.pInv.getValue(%index);

   if (%total > 0)
   {
      if (%total < %amount)
         %amount = %total;
      %total -= %amount;
      %this.setInventory(%data, %total, %isBuySell);

      return %amount;
   }
   return 0;
}

//-----------------------------------------------------------------------------

function ShapeBase::getInventory(%this, %data)
{
   if ( !isObject(%this.client.pInv) )
      return 0;
      
   // Return the current inventory amount
   %total = 0;
   %index = %this.client.pInv.getIndexFromKey(%data.ItemID);
   if ( %index != -1 )
      %total = %this.client.pInv.getValue(%index);
   return %total;
}

function ShapeBase::setInventory(%this, %data, %value, %isBuySell)
{
   // Set the inventory amount for this datablock and invoke inventory
   // callbacks.  All changes to inventory go through this single method.
   
   if ( !isObject(%this.client.pInv) )
      %this.client.pInv = new ArrayObject();

   // Impose inventory limits
   if (%value < 0)
      %value = 0;
   else
   {
      %max = %this.maxInventory(%data);
      if (%value > %max)
         %value = %max;
   }

   %arnVal = 0;
   // Set the value and invoke object callbacks
   %index = %this.client.pInv.getIndexFromKey(%data.ItemID);
   if ( %index == -1 )
   {
      if ( %value == 0 )
         return %value;
      %this.client.pInv.add(%data.ItemID, %value);
      %index = %this.client.pInv.count()-1;
      %arnVal = %value * %data.cost;
   }
   %amount = %this.client.pInv.getValue(%index);
   if (%amount != %value)
   {
      %this.client.pInv.setValue(%value, %index);
      %data.onInventory(%this, %value);
      %this.getDataBlock().onInventory(%data, %value);
      %arnVal = (%value - %amount) * %data.cost;
   }
   if( %value == 0 )
      %this.client.pInv.erase(%index);

   // When buying or selling there will be a change in Arns to offset the value
   // so there will be no change to networth
   if ( !%isBuySell && (%arnVal != 0) )
   {
      if ( %arnVal > 0 )
         %this.client.netWorth = mAddBigNumbers(%this.client.netWorth, %arnVal);
      else
         %this.client.netWorth = mSubBigNumbers(%this.client.netWorth, mAbs(%arnVal));
      %this.client.writeNetWorth();
   }

   commandToClient(%this.client, 'UpdateInventory', %data.ItemID, %value, %this.client.netWorth);

   return %value;
}

function ShapeBase::isInInventory(%this, %check)
{
   if ( !isObject(%this.client.pInv) )
      return false;
      
   %amount = 0;
   %index = %this.client.pInv.getIndexFromKey(%check);
   if (%index != -1)
      %amount = %this.client.pInv.getValue(%index);

   return (%amount > 0);
}

//-----------------------------------------------------------------------------

function ShapeBase::clearInventory(%this)
{
   if ( !isObject(%this.client.pInv) )
      return;
      
   %this.client.pInv.empty();
}

function GameConnection::giveArns(%this, %amount)
{
   %camount = mAddBigNumbers(%this.arns, %amount);
   if ( %camount < 0 )
      return false;  // Can't result in a negative number
   %this.arns = %camount;
   if ( %amount < 0 )
      messageClient(%this, 'LocalizedMsg', "", "spendArn", "a", true, true, 1, strreplace(%amount,"-",""));
   else
      messageClient(%this, 'LocalizedMsg', "", "gainArn", "a", true, true, 1, %amount);
   CommandToClient(%this, 'ArnsUpdate', %camount);

   if ( $Server::DB::Remote )
   {
      %args = "uID="@ %this.pData.dbID;
      %args = %args @ "&amount=" @ %camount;
      remoteDBCommand("SetArn", %args, %this);
   }
   else
   {
      DB::Update("AVPlayers","Arns='" @ %camount @ "'",
                  "ID='"@ %this.pData.dbID @ "'");
   }

   return true;   // Transaction complete
}

//function GameConnection::giveBankCoins(%this, %type, %amount)
//{
   //%name = stripChars( detag( getTaggedString( %this.playerName ) ), "\cp\co\c6\c7\c8\c9" );
   //%coins = DB::Fetch("Coins", "Bank", "Name='" @ %name @ "'");
   //if ( %coins $= "" )
      //return false;
   //%coins = strreplace(%coins, " ", "  ");
   //%coins = strreplace(%coins, ":", " ");
   //%cnt = getFieldCount(%coins);
   //for ( %i = 0; %i < %cnt; %i++ )
   //{
      //%cfield = getField(%coins, %i);
      //%ctype = getWord(%cfield, 0);
      //%camount = getWord(%cfield, 1);
      //if ( %ctype $= %type )
      //{
         //%camount = mAddBigNumbers(%camount, %amount);
         //if ( %camount < 0 )
            //return false;  // Can't result in a negative number...no overdrafts
      //}
      //if ( %i == 0 )
         //%newcoins = %ctype @":"@ %camount;
      //else
         //%newcoins = %newcoins SPC %ctype @":"@ %camount;
   //}
   //DB::Update("Bank", "Coins='" @ %newcoins @ "'", "Name='" @ %name @ "'");
   //if ( %amount < 0 )
      //messageClient(%this, 'MsgItemPickup', '\c0You take %1 %2 from the bank.', strreplace(%amount,"-",""), %type);
   //else
      //messageClient(%this, 'MsgItemPickup', '\c0You deposit %1 %2 into the bank.', %amount, %type);
//
   //CommandToClient(%this, 'BankingUpdate', %camount);
   //return true;   // Transaction complete
//}

//-----------------------------------------------------------------------------

function ShapeBase::throwObject(%this, %obj)
{
   // Throw the given object in the direction the shape is looking.
   // The force value is hardcoded according to the current default
   // object mass and mission gravity (20m/s^2).

   %throwForce = %this.throwForce;
   if (!%throwForce)
      %throwForce = 5;

   // Start with the shape's eye vector...
   %eye = %this.getEyeVector();
   %vec = vectorScale(%eye, %throwForce);

   // Add a vertical component to give the object a better arc
   %verticalForce = %throwForce / 2;
   %dot = vectorDot("0 0 1", %eye);
   if (%dot < 0)
      %dot = -%dot;
   %vec = vectorAdd(%vec, vectorScale("0 0 "@%verticalForce, 1 - %dot));

   // Add the shape's velocity
   %vec = vectorAdd(%vec, %this.getVelocity());

   // Set the object's position and initial velocity
   %pos = getBoxCenter(%this.getWorldBox());
   %obj.setTransform(%pos);
   %obj.applyImpulse(%pos, %vec);

   // Since the object is thrown from the center of the shape,
   // the object needs to avoid colliding with it's thrower.
   %obj.setCollisionTimeout(%this);
}

function ShapeBase::scatterObject(%this, %obj)
{
   // Throw the given object randomly into the world
   // pick a random direction angled slightly up
   %vec = ((getRandom()*2)-1) SPC ((getRandom()*2)-1) SPC ((getRandom()/2)+0.1);
   
   // Pick a force between 10 and 30
   %throwForce = getRandom() * 20 + 10;
   
   %vec = vectorScale(%vec, %throwForce);

   // Set the object's position and initial velocity
   %pos = getBoxCenter(%this.getWorldBox());
   %obj.setTransform(%pos);
   %obj.applyImpulse(%pos, %vec);

   // Since the object is thrown from the center of the shape,
   // the object needs to avoid colliding with it's thrower.
   %obj.setCollisionTimeout(%this);
}

//-----------------------------------------------------------------------------
// Callback hooks invoked by the inventory system
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// ShapeBase object callbacks invoked by the inventory system

function ShapeBase::onInventory(%this, %data, %value)
{
   // Invoked on ShapeBase objects whenever their inventory changes
   // for the given datablock.
}

//-----------------------------------------------------------------------------
// ShapeBase datablock callback invoked by the inventory system.

function ShapeBaseData::onUse(%this, %user)
{
   // Invoked when the object uses this datablock, should return
   // true if the item was used.
   if ( %this.category $= "horses" )
   {  // Trying to bring a horse to a no horse level
      if( isObject(%user.client) )
         messageClient(%user.client, 'LocalizedMsg', "", "noHorse", "a", true, true, 0);
      return true;
   }

   return false;
}

function ShapeBaseData::onThrow(%this, %user, %amount)
{
   // Invoked when the object is thrown.  This method should
   // construct and return the actual mission object to be
   // physically thrown.  This method is also responsible for
   // decrementing the user's inventory.

   return 0;
}

function ShapeBaseData::onPickup(%this, %obj, %user, %amount)
{
   // Invoked when the user attempts to pickup this datablock object.
   // The %amount argument is the space in the user's inventory for
   // this type of datablock.  This method is responsible for
   // incrementing the user's inventory is something is addded.
   // Should return true if something was added to the inventory.

   return false;
}

function ShapeBaseData::onInventory(%this, %user, %value)
{
   // Invoked whenever an user's inventory total changes for
   // this datablock.
}

// GUY >>
// lose inventory items on death
// BloodClans::RandomItemLossBias (defined in defaults.cs) controls wheter the 
// random item loss prefers to make the player lose more or less items. Numbers 
// greater than 1 bias towards losing more items, numbers less than 1 bias 
// towards losing less items
function ShapeBase::inventoryOnDeath(%this)
{
   if ( %this.client $= "" || %this.client == 0 )
      return;

   if ( !isObject(%this.client.pInv) )
      return;

   %cnt = %this.client.pInv.count();
   %lostItems = "";
   %newInv = "";
   for ( %i = 0; %i < %cnt; %i++ )
   {
      %itemID = %this.client.pInv.getKey(%i);
      %key = $AlterVerse::ItemNames[%itemID];

      %amount = %this.client.pInv.getValue(%i);

      // check if we should keep this item on death
      if(%key.keepOnDeath)
      {
         %newInv = %newInv $= "" ? %newInv : %newInv TAB "";
         %newInv = %newInv @ %key.ItemID SPC %amount;
         continue;
      }

      if(%amount > 0)
      {
         // random fractional number between 0 and 1
         %rnd = getRandom(0, 1000) / 1000;

         // apply the bias
         %rnd = mPow(%rnd, $AlterVerse::RandomItemLossBias);

         // calculate amount of items to keep   
         %newAmount = mRound(%rnd * %amount);
         %newInv = %newInv $= "" ? %newInv : %newInv TAB "";
         %newInv = %newInv @ %key.ItemID SPC %newAmount;
         
         // and the amount lost
         %lostAmount = %amount - %newAmount;
         if(%lostAmount > 0)
         {
            // record the loss
            %lostItems = %lostItems $= "" ? %lostItems : %lostItems TAB "";
            %lostItems = %lostItems @ %key.ItemID SPC %lostAmount;
            
            // Throw the item into the world 
            %obj = %key.createDropItem(%this, %lostAmount);
            if (%obj)
               %this.scatterObject(%obj);
         }
      }
   }
   
   // now apply the losses to the players inventory
   %this.client.resetInventory(%newInv);
   
   // tell the client about it
   commandToClient(%this.client, 'showDeathLoss', %lostItems);
}
