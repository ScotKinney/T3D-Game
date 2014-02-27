//****************************************************************
//The Universal AI Starter Kit (AISK)
//Copyright (c) 2009-2011 Twisted Jenius - All rights reserved.
//This file is engine NEUTRAL.
//****************************************************************

//-----------------------------------------------------------------------------
//Weapon Equiping Functions
//-----------------------------------------------------------------------------

// Mount the bots weapon image
function equipBotWeapon(%obj)
{
   %count = getWordCount(%obj.botWeapon);
   if ( (%count > 0) && (%count < 5) )
   {
      for ( %i = 0; %i < %count; %i++ )
      {
         %weapRoot = getWord(%obj.botWeapon, %i);
         %weapItem = %weapRoot @ "Weapon";
         %weapSkin = "";
         if ( isObject(%weapItem) )
         {
            %weapImage = %weapItem.image;
            %weapSkin = %weapItem.skinMat;
         }
         else
            %weapImage = %weapRoot @ "Image";

         // mountImage( image, slot, loaded, skinTag )
         %obj.mountImage(%weapImage, %i, true, addTaggedString(%weapSkin));
      }
   }
   else
   {
      %obj.mountImage(getWord(%obj.botWeapon, 0) @ "Image", 0);
      %obj.setImageAmmo(0, true);
   }
}


//-----------------------------------------------------------------------------
//Weapon Firing Functions
//-----------------------------------------------------------------------------

//This function sets the bots aim to the current target, and 'pulls' the trigger
//of the weapon of the bot to begin the firing sequence.
function AIPlayer::openFire(%this, %obj, %tgt, %rtt)
{
   if ( !isObject(%obj) || !isObject(%tgt) )
      return;

   //If the bot or the target is dead or in a neutral zone, don't fire.
   if (%tgt.getstate() $= "Dead" || %obj.getState() $= "Dead" ||
         %obj.inNeutralZone || %tgt.inNeutralZone)
   {
      %obj.clearaim();
      %obj.firing = false;
      return;
   }

   //Have the bot fire/cast less often if they're confused
   if (%obj.isConfused > 0)
   {
      if ((%obj.isConfused % 3) != 0)
      return;
   }

   //We've got two live ones. So let's kill something.
   //The firing variable is set while firing and is cleared at the end of the delay cycle.
   //This is done to allow the use of a firing delay - and prevent a bot from firing again prematurely.
   if (!%obj.firing)
   {
      //Get the name of the weapon
      %count = getWordCount(%obj.botWeapon);
      if ( %count > 4 )
         %count = 1;
      %slot = 0;
      if ( %count > 1 )
         %slot = getRandom(1, %count) - 1;
      %tempWeapon = getWord(%obj.botWeapon, %slot);

      if (%tempWeapon $= "-noweapon")
      {
         //Sets the firing variable to true
         %obj.firing = true;
         //This sets a delay of $AISK_TRIGGER_DOWN to hold the trigger down for.
         %this.trigger = %this.schedule($AISK_TRIGGER_DOWN, "ceaseFire", %obj, 0);
         return;
      }

      %weapItem = %tempWeapon @ "Weapon";
      if ( isObject(%weapItem) )
         %weapImage = %weapItem.image;
      else
         %weapImage = %tempWeapon @ "Image";

      //If the weapon doesn't have an ignoreDistance set, then use the default
      if (%weapImage.ignoreDistance > 1)
         %weapMax = %weapImage.ignoreDistance;
      else
         %weapMax = $AISK_IGNORE_DISTANCE;

      //If the weapon doesn't have an minIgnoreDistance set, then use the default
      if (%weapImage.minIgnoreDistance !$= "")
         %weapMin = %weapImage.minIgnoreDistance;
      else
         %weapMin = $AISK_MIN_IGNORE_DISTANCE;

      //If the target is within our weapon's ignore distance then we will attack. Range To Target - rtt
      if (%rtt < %weapMax && %rtt > %weapMin)
      {
         //Make sure the bot doesn't fire prematurely
         if (%obj.fireLater <= 0 && %obj.getAimLocation() != %tgt.getposition())
         {
            %obj.fireLater++;
            return;
         }

         //If the weapon isn't ready to fire, don't try to fire it
         if (%obj.getImageState(%slot) !$= "Ready")
            return;

         //Do a line of sight (LoS) test for players
         %eyeTrans = %obj.getEyeTransform();
         %eyeEnd = vectorAdd(%tgt.getPosition(), $AISK_CHAR_HEIGHT);
         %searchResult = containerRayCast(%eyeTrans, %eyeEnd, $TypeMasks::PlayerObjectType, %obj);
         %foundObject = getword(%searchResult, 0);

         //Make sure the bot can see its target
         if (%foundObject != %tgt && %foundObject != 0)
         {
            //If it's not the bot's traget, move and don't fire on it
            %this.sidestep(%obj);
            return;
         }

         //Sets the firing variable to true
         %obj.firing = true;

         //Pull the trigger on the bot gun
         %obj.setImageTrigger(%slot, true);

         //If the weapon doesn't have a triggerDown set, then use the default
         if (%weapImage.triggerDown !$= "")
            %l = %weapImage.triggerDown;
         else
            %l = $AISK_TRIGGER_DOWN;

         //This sets a delay of %l length to hold the trigger down for.
         %this.trigger = %this.schedule(%l, "ceaseFire", %obj, %weapImage, %slot);
      }
      else
      {
         //This simply clears the bots aim to have it look forward relative to it's movement
         //since there is now no target in range.
         %obj.clearaim();
      }
   }
}

//ceaseFire is called by the openFire function after the set delay to hold the trigger down is met.
function AIPlayer::ceaseFire(%this, %obj, %weapImage, %slot)
{
   if (!isObject(%weapImage) || %weapImage.getClassName() !$= $AISK_AFX_DATA_TYPE)
      //Stop holding the trigger
      %obj.setImageTrigger(%slot, false);
   else
      %obj.isCasting = false;

   //If the weapon doesn't have a fireDelay set, then use the default
   if (%weapImage.fireDelay !$= "")
      %k = %weapImage.fireDelay;
   else
      %k = $AISK_FIRE_DELAY;

   //Set a delay between when the bot lets off the trigger and when it can fire again
   if ( !%obj.inAttackThread )
      %this.ceasefiretrigger = %this.schedule(%k, "delayFire", %obj);
}

//delayFire is called to clear the firing variable. Clearing this allows
//the bot to fire again in the openFire function.
function AIPlayer::delayFire(%this, %obj)
{
   //this is the end of the firing cycle
   %obj.firing = false;
   //%obj.firingWeapon = "";
}
