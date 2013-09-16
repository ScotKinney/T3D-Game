//-----------------------------------------------------------------------------
// Weapon Image Class
//-----------------------------------------------------------------------------

function MeleeImage::onMount(%this,%obj,%slot)
{
   // Images assume a false ammo state on load.  We need to
   // set the state according to the current inventory.
   if (%obj.client !$= "")
   {
      %obj.client.RefreshWeaponHud(0, %this.item.invIcon, "");
      
      if ( %obj.client.clanWeapon.image.getID() == %this )
      {
         %obj.unmountEquipment("mount3");
         %obj.updateMountedEquipment();
      }
   }
}

function MeleeImage::onUnmount(%this, %obj, %slot)
{
   //AISK Changes: Start
   if (%obj.client !$= "")
   {
      %obj.client.RefreshWeaponHud(0, "", "");

      if ( %obj.client.clanWeapon.image.getID() == %this )
      {  // This is our clan weapon so holster it
         %this.holsterWeapon(%obj);
         return;
      }
   }
   //AISK Changes: End
}

function MeleeImage::holsterWeapon(%this, %obj)
{
   %obj.mountEquipment(%this.holsterShape, "mount3");
   %obj.updateMountedEquipment();
   return;
}

// ----------------------------------------------------------------------------
// A "generic" weaponimage onFire handler for most weapons.  Can be overridden
// with an appropriate namespace method for any weapon that requires a custom
// firing solution.

// projectileSpread is a dynamic property declared in the weaponImage datablock
// for those weapons in which bullet skew is desired.  Must be greater than 0,
// otherwise the projectile goes straight ahead as normal.  lower values give
// greater accuracy, higher values increase the spread pattern.
// ----------------------------------------------------------------------------

function MeleeImage::onFire(%this, %obj, %slot)
{
   if ( %obj.inNeutralZone )
   {
      sfxPlay(BaseFireEmptySound, %obj.getTransform());
      return;
   }
   //echo("\c4WeaponImage::onFire( "@%this.getName()@", "@%obj.client.nameBase@", "@%slot@" )");

   if ( %obj.inArmThreadPlayOnce() )
   {
      %obj.setImageTrigger(%slot,false);
      return;
   }
   
   %this.onFireHandToHand(%obj, %slot);
   return;
}

function MeleeImage::onAltFire(%this, %obj, %slot)
{
   return %this.onFire(%obj, %slot);
}

function MeleeImage::onWetFire(%this, %obj, %slot)
{
   return %this.onFire(%obj, %slot);
}

// this is the default function to call when firing a hand-to-hand weapon
function MeleeImage::onFireHandToHand(%this, %obj, %slot)
{
   %modifier = $Sim::Time - %this.startTime;
   if(%modifier > %this.maximumCharge)
   	%modifier = %this.maximumCharge;
   if(%modifier < 1)
   	%modifier = 1;
   %this.modifier = %modifier;	 

   //if (%obj.getEnergyLevel() <= %this.MinEnergy) return;
   
   if(%obj.getdatablock().category $= "Mounts")
      %isAnimal = true;
   //echo("when animals attack! ->"@%isAnimal);
   
   if (%obj.hthDamageSeqPlaying)
   {
      %obj.hthDamageSeqPlaying = false;
      if(!%isAnimal) %obj.setArmThread("look");
      %obj.setImageTrigger(%slot,false);
   }
   
    if(%obj.hthStun) //|| %obj.shielded)
       return;
    // there was code here for special attacks
       %action = "Normal";
    switch$(%action)
    {
       //case "JumpAttack":
          //%attack = %this.jumpAttack;
       case "Normal":
          // for now we randomly choose an attack
          %index = mFloor(getRandom()*(%this.hthNumAttacks-0.0001));
          if (%index > (%this.hthNumAttacks-1))
             %index = (%this.hthNumAttacks-1);

         //DisplayScreenMessage(%obj.client, "Action: "@%obj.getActionAnim() @ " Charged-up: "@%this.modifier);
         //%actionAnim = %obj.getActionAnim();
         %actionAnimName = %obj.getActionAnimName();
         //echo("Action: "@ %actionAnimName @ " Charged-up: "@%this.modifier);
          switch$(%actionAnimName)
          {
             case "runfull_forward"://Forward Free Arms
                %attack = %this.hthWAttack[%index];
             //case "xxx"://Sprint Free Arms
             //   %attack = %this.hthWAttack[%index];//Should be NEW attack ie. "while running special"
             case "runfull_back"://Back Free Arms
                %attack = %this.hthSAttack[%index];
             case "runfull_left"://Left Free Arms
                %attack = %this.hthAAttack[%index];
             case "runfull_right"://Right Free Arms
                %attack = %this.hthDAttack[%index];
             default:
                %attack = %this.hthAttack[%index];
          }
    }
    // setup the "play once look anim"
    %obj.hthDamageAttack = %attack;
    %obj.hthDamageSeqPlaying = 1;
    %obj.hthDamageStartMS =  $sim::Time;
    %obj.hthDamageLastId = -1;

    %attackSound = %this.hthSwingSound[%index];
    if ( %attack.soundDelay !$= "" )
      schedule(%attack.soundDelay, 0, "serverPlay3D", %attackSound,%obj.getTransform());
    else
       serverPlay3D(%attackSound,%obj.getTransform());
    //sfxPlayOnce(%attackSound, getWord(%obj.getTransform(), 0), getWord(%obj.getTransform(), 1), getWord(%obj.getTransform(), 2));
     
    if(!%isAnimal) // && !%attack.fullSkelAnim)
    {
        if (!%obj.setArmThreadPlayOnce(%attack.seqName))
           echo("ERROR in setArmThreadPlayOnce()");
    }
    else
    {
        //if (!%obj.setactionthread(%attack.seqName))
        if (!%obj.setactionthread(%attack.seqName))
           echo("ERROR in setActionThread()");
    }
    return;
}

// default weapon intersect
function MeleeImage::onImageIntersect(%this,%player,%slot,%startvec,%endvec)
{
    // if damage sequence is not playing then dont do damage
   if (!%player.hthDamageSeqPlaying || %player.getState() $= "Dead")
       return;

    // proves we are really moving the damage nodes server side...
	//echo("%startvec = " @ %startvec);
	//echo("%endvec = " @ %endvec);

    // determine if damage is active or if we can say the seq is done playing
    // based on current server time
    %offset = $sim::Time - %player.hthDamageStartMS;

    // depending on which attack is playing...
    %attack = %player.hthDamageAttack;
    %startOffset = %attack.startDamage;
    %endOffset = %attack.endDamage;
    if(%slot == 0)
    {
       if(%this.Skill $= "unarmedxp") %weaponslot = %this;
       else %weaponslot = %player.Weapon0;
    }
    if(%slot == 1)
    {
       if(%this.Skill $= "unarmedxp") %weaponslot = %this;
       else %weaponslot = %player.Weapon1;
    }

    // how long until the last damage is done
    // at which point we can say the seq has "Stopped playing"
    if (%offset > %endOffset)
    {
       %player.hthDamageSeqPlaying = 0;
       %player.hthDamageActive = 0;
	//   echo("seq stopping (all damage done) %offset = " @ %offset);
       return;
    }

    // how long it takes for damage to start...for now we just
    // have one interval and damage is active all during that interval
    if (%offset >%startOffset)
       %player.hthDamageActive = 1;

    // no damage yet?
    if (!%player.hthDamageActive)
    {
	//   echo("seq playing (no damage) %offset = " @ %offset);
       return;
    }

    // search for just players to damage
    //%searchMasks = $TypeMasks::PlayerObjectType | $TypeMasks::StaticShapeObjectType;
    %searchMasks = $TypeMasks::PlayerObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ShapeBaseObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::InteriorObjectType;
    // search for objects within the damage rays that fit the masks above
    %scanTarg = ContainerRayCast(%startvec, %endvec, %searchMasks, %slot);

    //if(%scanTarg && (%scanTarg.getType() & $TypeMasks::PlayerObjectType))
    if(%scanTarg)
    {
        // a target in range was found
        %target = firstWord(%scanTarg);
        //echo("target = " @ %target.getId() @ " and player = " @ %player.getId() @ "\n");
        if (%target.getId() $= %player.getId())
        {
            // this (can be) prevented by the weapon timing...i cant find
            // anywhere else it is prevented
        	//error("ATTEMPT TO DAMAGE SELF!!!!!!!! what in gods name!\n");
        	return;
        }
        if ( !isObject(%target.client) && !%target.isBot )
        {   // Hit something other than a player...Just play sound
           if (%target != %player.hthDamageLastId)
           {
              %player.hthDamageLastId = %target;
              %hitSound = %this.hthHitSound[0];
              serverPlay3D(%hitSound,%player.getTransform());
           }
           return;
        }
        if (%target.team == %player.team)
        {
        	//error("ATTEMPT TO DAMAGE Teammate!!!!!!!! what in gods name!\n");
        	return;
        }

        // store end point from raycast return buffer
        %pos = getWords(%scanTarg, 1, 3);

        // if we have hit this person already...apply no more damage
        if (%target == %player.hthDamageLastId)
        {
           //echo("already damaged this player: " @ %target);
           return;
        }

        // save who we last damaged
        %player.hthDamageLastId = %target;
         // shields and sword rebounding - JM The_Force
           if(%target.shielded || %target.hthDamageSeqPlaying)
           {

              //if(%target.hthDamageSeqPlaying)
              //   %swordBlock = 1;
              %block = 1;
              // Now we see if we hit from behind...
              %forwardVec = %target.getEyeVector();
              %objDir2D   = getWord(%forwardVec, 0) @ " " @ getWord(%forwardVec,1) @ " " @ "0";
              %objPos     = %target.getPosition();
              %dif        = VectorSub(%objPos, %player.getPosition());
              %dif        = getWord(%dif, 0) @ " " @ getWord(%dif, 1) @ " 0";
              %dif        = VectorNormalize(%dif);
              %dot        = VectorDot(%dif, %objDir2D);
              // 120 Deg angle test...
              // 1.05 == 60 degrees in radians
              //if (%dot >= mCos(1.05))
              //%blockCoF = (%blockxp / 100000);

              //%blockmod = 2.05 - (%player.getCombatXPLevel() * 0.00001) ;
              //%blockmod = %target.getBlockXPLevel() * 0.00002;
              //%blockmod = %target.Skill[blockxp] * 0.00002;
              %blockmod = %target.Skill[blockxp] * 0.00005;
              //echo("target block xp: " @ %target.Skill[blockxp]);
              if(%blockmod <= 0.05)
              {
                 %blockmod = 0.05;
              }
              //echo(%target.name@" Block Modifier: "@%blockmod);
              if (%dot >= mCos(3.15-%blockmod))
                 %block = 0;
              //echo(%target.name@" Block: "@3.15-%blockmod);
           }
           if(%block == 1)
           {
                //echo("attack blocked!!");
              //%player.playAudio(0,ShieldImpactSound);
               %hitSound = %this.hthHitSound[0];
               //serverPlay3D(%hitSound,%obj.getTransform());
               serverPlay3D(%hitSound,%pos);
/*
            // Create our projectile
            %p = new (Projectile)()
            {
                dataBlock = MeleeSparksProjectile;
                //initialVelocity = %velocity;
                initialPosition = %pos;
                sourceObject = %player;
                sourceSlot = %slot;

                //client = %obj.client;
            };
            MissionCleanup.add(%p);
*/
        
              //stunPlayer(%player,%attack);
              //pushPlayerBack(%player,%pos,%target,%attack);
              //if(%swordBlock == 1 || %block == 1)
              //{
                 //stunPlayer(%target,%attack);
              //   pushPlayerBack(%target,%pos,%player,%attack);
              //}
              return;
           }

//shields
        // Apply damage targetted object
   		// Works for all shapebase objects.
        //if (%target.dataBlock $= "StaticNPC" || %target.dataBlock $= "StaticNPC" || %target.dataBlock $= "FemaleHumanNPC" || %target.dataBlock $= " OHM1NPC)
        //   return;
        if(%target.getdataBlock().isInvincible == true || %target.isInvincible == true)
           return;

   		if (%target.getState() !$= "Dead" )
   		{
           %obj = %target;
           %location = %pos;

           %hitSound = %this.hthHitSound[1];
           serverPlay3D(%hitSound,%obj.getTransform());
		    // sfxPlayOnce(%hitSound, getWord(%pos, 0), getWord(%pos, 1), getWord(%pos, 2));

          //echo("Melee Weapon Damage: "@%this.item.directDamage);
          //echo("Melee Move Damage: "@%attack.damageAmount);
          //error("Melee Hit!");
          if (%weaponslot.DirectDamage $= "")
          {
             %damage = %attack.damageAmount + %this.directDamage;
             //error("No weapon stats, using default damages - Image:"@%this.directDamage@" Move:"@%attack.damageAmount@" Cumulative:"@%damage);             
          }
          else
          {
             //%damage = %attack.damageAmount + %this.item.directDamage;
             %damage = %attack.damageAmount + %weaponslot.DirectDamage;
             //error("Dynamic weapon stats, using statted damages - Image:"@%weaponslot.directDamage@" Move:"@%attack.damageAmount@" Cumulative:"@%damage);             
          }
         //if(isObject(%player.client.player))
           %damLoc = firstWord(%target.getDamageLocation(%pos));
           // you can use this to add limited loacational damage, but the head is whats hit the most - TF
           if ( %target.isBot )
   		  {
              %chance = getRandom(100);
              %chance += %player.knockdown;
              %chance += %weaponslot.knockdown;
              //error("KD Chance: "@%chance);
   		  }
   		  else
   		  {   // Don't knock down or change animation on live players
              %chance = 0;
              %damLoc = "";
   		  }
           if(%damLoc $= "head")
           {
              %hitmsg = "head";
              %damage = (%damage * 2);
              if(%chance < 90 && %target.isDown == false)
                  %target.setactionthread("damageHead1");
               else if (%target.isDown == false)
               {              
                  %target.isDown = true;
                  %target.setactionthread("death1");
                  //Lock the player
                  if(isObject(%target.client.player))
                  {
                  %eyeXfrm = %target.getEyeTransform();
                  %world_offset = MatrixMulVector(%eyeXfrm, "0 -3 0");
                  %world_pos = VectorAdd(getWords(%eyeXfrm, 0, 2), %world_offset); 
                  %camXfrm = %world_pos SPC getWords(%eyeXfrm, 3, 6);
                  %target.client.camera.setTransform(%camXfrm);
                  %target.client.camera.setMode("Locked", %target);
                  %target.client.setControlObject(%target.client.camera);
                  // Give control back to the player
                  schedule(2000, 0, restorePlayerControl, %target.client, %target);
                  }
                  else if(%target.isbot ==1)
                  {
                        cancel(%target.ailoop);
                        %target.ailoop = %target.schedule(3000,"Think", %target);
                  }
               }
           }
           else if(%damLoc $= "torso")
           {
              %hitmsg = "torso";
              if(%chance < 90 && %target.isDown == false)
                  %target.setarmthreadplayonce("damageBody1");
               else if (%target.isDown == false)
               {              
                  %target.isDown = true;
                  %target.setactionthread("death2");
                  //Lock the player
                  if(isObject(%target.client.player))
                  {
                  %eyeXfrm = %target.getEyeTransform();
                  %world_offset = MatrixMulVector(%eyeXfrm, "0 -3 0");
                  %world_pos = VectorAdd(getWords(%eyeXfrm, 0, 2), %world_offset); 
                  %camXfrm = %world_pos SPC getWords(%eyeXfrm, 3, 6);
                  %target.client.camera.setTransform(%camXfrm);
                  %target.client.camera.setMode("Locked", %target);
                  %target.client.setControlObject(%target.client.camera);
                  // Give control back to the player
                  schedule(2000, 0, restorePlayerControl, %target.client, %target);
                  }
                  else if(%target.isbot ==1)
                  {
                        cancel(%target.ailoop);
                        %target.ailoop = %target.schedule(3000,"Think", %target);
                  }
               }
           }
           else if(%damLoc $= "legs")
           {
              %hitmsg = "legs";
              %damage = (%damage / 2);
              if(%chance < 90 && %target.isDown == false)
                  %target.setactionthread("damageLegs1");
               else if (%target.isDown == false)
               {              
                  %target.isDown = true;
                  %target.setactionthread("death3");
                  //Lock the player
                  if(isObject(%target.client.player))
                  {
                  %eyeXfrm = %target.getEyeTransform();
                  %world_offset = MatrixMulVector(%eyeXfrm, "0 -3 0");
                  %world_pos = VectorAdd(getWords(%eyeXfrm, 0, 2), %world_offset); 
                  %camXfrm = %world_pos SPC getWords(%eyeXfrm, 3, 6);
                  %target.client.camera.setTransform(%camXfrm);
                  %target.client.camera.setMode("Locked", %target);
                  %target.client.setControlObject(%target.client.camera);
                  // Give control back to the player
                  schedule(2000, 0, restorePlayerControl, %target.client, %target);
                  }
                  else if(%target.isbot ==1)
                  {
                        //error("bot leg kd");
                        cancel(%target.ailoop);
                        %target.ailoop = %target.schedule(3000,"Think", %target);
                  }
               }
           }
         //error(%damloc @ " shot.  Modded Damage: "@%damage);
          %damageType = %this.item; // example: Axe / Sword etc
         if(%player.client) %target.CurrentEnemy = %player.getShapename();
         
/*
         %p = new (StaticShape)()
         {
             dataBlock = StaticMeleeBlood;
             scale = "4 4 4";
         };
         MissionCleanup.add(%p);
         %bloodpos = getword(%pos,0) @ " " @ getword(%pos,1) @ " " @ getword(%pos,2) @ " " @ getword(%player.gettransform(),3) @ " " @ getword(%player.gettransform(),4) @ " " @ getword(%player.gettransform(),5) @ " " @ (getword(%player.gettransform(),6));
         %p.settransform(%bloodpos);
         %blooddelay = (%damage /2);
         if(%blooddelay > 700) %blooddelay = 700;
         %p.schedule(%blooddelay,"delete");
*/
         if(%this.modifier < 1) %this.modifier = 1;         
         //%obj.applyDamage(%damage * %this.modifier);
         %obj.damage(%player, %pos, %damage * %this.modifier, "Melee");
         //error("Melee Hit End!\n");

            /*if(%obj.aiplayer != true)
            {
              %damageMsg = "You hit " @ %target.client.namebase @ " with "@%attack.seqName@" in the " @ %hitmsg @ " for " @ mfloor(%damage * %this.modifier) @ " damage.";
              messageClient(%player.client, 'experience', %damageMsg);
            }
            else
            {
                  %damageMsg = "You hit " @ %target.getshapename() @ " with "@%attack.seqName@" in the " @ %hitmsg @ " for " @ mfloor(%damage * %this.modifier) @ " damage.";
                  messageClient(%player.client, 'experience', %damageMsg);
            }*/

           // this is in the Armor::damage
           //%location = "Body";

           // Deal with client callbacks here because we don't have this
           // information in the onDamage or onDisable methods
           %client = %target.client;
           %sourceObject = %player;
           %sourceClient = %sourceObject ? %sourceObject.client : 0;

           if (%target.getState() !$= "Dead")
           //{
              //if(%client)
                 //%client.onDeath(%sourceObject, %sourceClient, %damageType, %pos);
           //}
           //// phdana stun ->
           //else
           {
             //stunPlayer(%obj,%attack);
                 pushPlayerBack(%obj,%pos,%player,%attack,%attack.impulse);
           }
           // <- phdana stun
      	}
    }
    else if(%scanTarg && (%scanTarg.getType() & $TypeMasks::StaticShapeObjectType))
    {
       %damage = %attack.damageAmount;
       %object = firstWord(%scanTarg);
       %object.applyDamage(%damage);
    }
}

// phdana stun ->
// call when %victim is hit with %attack but does not die
function stunPlayer(%vplayer, %attack)
{
   // for now we stun every time...

   // get the player for this object
   //if (!%victim.client || !%victim.client.player)
   if(!%vplayer.getType() & $TypeMasks::PlayerObjectType)
   {
      error("ATTEMPTING to STUN a non-player");
      return;
   }

   // if this player is in the middle of a hth swing themself, then
   // their swing is aborted. firstly we have to make sure they dont
   // do any damage, secondly we must blend their swing anim into
   // the stun anim
   if (%vplayer.hthDamageSeqPlaying)
   {
      // make sure they wont do damage....
      %vplayer.hthDamageSeqPlaying = false;

      // blend into the stun animation
      //echo("STUN: victim: " @ %vplayer @ " DOING transition once...");
      %vplayer.setArmThreadTransitionOnce("look");
   }
   else
   {
      // just start the stun animation
      //echo("STUN: victim: " @ %vplayer @ " only doing a playonce...");
      if(%vplayer.shielded)// not while stuned!
         %vplayer.setImageTrigger(1,false);
      %vplayer.setArmThreadPlayOnce("look");
   }

   // the victim is now in a stun state
   //%vplayer.hthStunSequencePlaying = true;
   %vplayer.hthStun = true;
   schedule(1000, %vplayer, "resetStun", %vplayer);
   //%vplayer.hthStunStartMS = $sim::Time;
}

function resetStun(%obj)
{
   %obj.hthStun = false;
}

function pushPlayerBack(%victim, %pos, %attacker, %attack, %impulse)
{
    if (%target.dataBlock $= "StaticNPC" || %target.dataBlock $= "StaticNPC" || %target.dataBlock $= "FemaleHumanNPC" || %target.dataBlock $= "OHM1NPC")
       return;
    if (%target.isInvincible == true)
      return;

  
  // the push back is relative to the attacker
  // a straight push back would be along the attackers
  // Y axis....

  // right now we always push the victim at his center
  // we could explore what happnes if we push at the
  // point of contact instead (might turn or do something intersting)

  // get the usual direction to push...we could get the Y axis of
  // the attacker with getTransform() then grabbing the rotation part
  // and passing that to VectorOrthoBasis() and then using column 1
  // whichi would be words 3,4,5 (couting from 0)...but that's overkill
  // for something that can be approximated pretty good by a line drawn
  // from attacker to victim...so let's use that instead
  %vpos = %victim.getWorldBoxCenter();
  %pushDirection = VectorSub(%vpos,%attacker.getWorldBoxCenter());
  %pushDirection = VectorNormalize(%pushDirection);

  // hardoded impluse
  if(!%impulse)
  {
     %impulse = 12.0;
  }
    
  // ok apply impulse to victim's center
  %mass = %victim.getDataBlock().mass;
  %pushVec = VectorScale(%pushDirection,%impulse * %mass);

  //error("Applying, to player " @ %victim @ " of mass " @ %mass @ ", an impulseVec: " @ %pushVec);

  %victim.applyImpulse(%vpos, %pushVec);
  if(%victim.getdatablock().category $= "Mounts")
     %isAnimal = true;
  //echo("impulse: "@%impulse);
  //if(!%isAnimal && %impulse >= 15)
  if(!%isAnimal && %impulse >= 15)
  {
     %victim.setactionthread("death4");
    //afxPerformSpellCast(%attacker,GreatBallSpell,%victim,%victim.client);     
  }
}

function restorePlayerControl(%client, %player)
{
   if ( isObject(%player) && %player.getState() !$= "Dead" )
      %client.setControlObject(%player);
}
// <- phdana hth
