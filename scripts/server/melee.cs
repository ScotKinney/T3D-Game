//-----------------------------------------------------------------------------
// Melee Weapon Image Class
//-----------------------------------------------------------------------------

function MeleeImage::onMount(%this,%obj,%slot)
{
   if (%obj.client !$= "")
   {
      %obj.client.RefreshWeaponHud(0, %this.item.invIcon, "");
      
      //if ( %obj.client.clanWeapon.image.getID() == %this )
      //{
         //%obj.unmountEquipment("holsterNode");
         //%obj.updateMountedEquipment();
      //}
   }
}

function MeleeImage::onUnmount(%this, %obj, %slot)
{
   if (%obj.client !$= "")
   {
      %obj.client.RefreshWeaponHud(0, "", "");

      if ( %obj.client.clanWeapon.image.getID() == %this )
      {  // This is our clan weapon so holster it
         %this.holsterWeapon(%obj);
         return;
      }
   }
}

function MeleeImage::holsterWeapon(%this, %obj)
{
   %obj.mountEquipment(%this.holsterShape, "holsterNode");
   %obj.updateMountedEquipment();
   return;
}

// ----------------------------------------------------------------------------
// Melee attack triggers. The onFire callback is used when the trigger is
// pressed with no modifiers and generates a random attack. Up to 5 attacks can
// be defined per weapon.
// ----------------------------------------------------------------------------

function MeleeImage::onFire(%this, %obj, %slot)
{
   // Chose an attack randomly
   %index = mFloor(getRandom()*(%this.hthNumAttacks-0.0001));
   if (%index > (%this.hthNumAttacks-1))
      %index = (%this.hthNumAttacks-1);

   %this.SwingWeapon(%obj, %slot, %index);
}

function MeleeImage::onAttack0(%this, %obj, %slot)
{
   %this.SwingWeapon(%obj, %slot, 0);
}

function MeleeImage::onAttack1(%this, %obj, %slot)
{
   %this.SwingWeapon(%obj, %slot, 1);
}

function MeleeImage::onAttack2(%this, %obj, %slot)
{
   %this.SwingWeapon(%obj, %slot, 2);
}

function MeleeImage::onAttack3(%this, %obj, %slot)
{
   %this.SwingWeapon(%obj, %slot, 3);
}

function MeleeImage::onAttack4(%this, %obj, %slot)
{
   %this.SwingWeapon(%obj, %slot, 4);
}
// ----------------------------------------------------------------------------
function MeleeImage::SwingWeapon(%this, %obj, %slot, %attackNum)
{
   // If we're already in an attack, we can't start this one
   if ( %obj.inArmThreadPlayOnce() )
      return;

   if ( %obj.inNeutralZone )
   {
      sfxPlay(BaseFireEmptySound, %obj.getTransform());
      return;
   }

   // make sure the attack requested is legit
   if ( %attackNum >= %this.hthNumAttacks )
      %attackNum = %attackNum % %this.hthNumAttacks;
   %attack = %this.hthAttack[%attackNum];

   //if (%obj.getEnergyLevel() <= %this.MinEnergy) return;

   if (%obj.hthDamageSeqPlaying)
   {
      %obj.hthDamageSeqPlaying = false;
      //%obj.setArmThread("look");
   }
   
   if(%obj.hthStun) //|| %obj.shielded)
      return;

   // setup the "play once look anim"
   %obj.hthDamageAttack = %attack;
   %obj.hthDamageSeqPlaying = true;
   %obj.hthDamageStartMS =  $sim::Time;
   %obj.hthDamageLastId = -1;

   %attackSound = %attack.SwingSound;
   if ( %attack.soundDelay !$= "" )
      schedule(%attack.soundDelay, 0, "serverPlay3D", %attackSound,%obj.getTransform());
   else
      serverPlay3D(%attackSound,%obj.getTransform());

   %timeScale = %attack.timeScale;
   if ( (%timeScale $= "") || (%timeScale < 0) )
      %timeScale = 1.0;
   if (!%obj.setArmThreadPlayOnce(%attack.seqName, %timeScale))
      echo("ERROR in setArmThreadPlayOnce()");
}

// Weapon callback when it hits something
function MeleeImage::onImageIntersect(%this,%player,%slot,%startvec,%endvec)
{
   // if damage sequence is not playing then dont do damage
   if (!%player.hthDamageSeqPlaying || %player.getState() $= "Dead")
      return;

   // determine if damage is active or if we can say the seq is done playing
   // based on current server time
   %offset = $sim::Time - %player.hthDamageStartMS;

   // depending on which attack is playing...
   %attack = %player.hthDamageAttack;
   %startOffset = %attack.startDamage;
   %endOffset = %attack.endDamage;

   // how long until the last damage is done
   // at which point we can say the seq has "Stopped playing"
   //if (%offset > %endOffset)
   //{
      //%player.hthDamageSeqPlaying = false;
      //return;
   //}

   // how long it takes for damage to start...for now we just
   // have one interval and damage is active all during that interval
   if (%offset < %startOffset)
      return;

   // Find the object we hit
   %searchMasks = $TypeMasks::PlayerObjectType |
      $TypeMasks::StaticShapeObjectType | $TypeMasks::ShapeBaseObjectType;
   // search for objects within the damage rays that fit the masks above
   %scanTarg = ContainerRayCast(%startvec, %endvec, %searchMasks, %player);
   //%reverseTarg = ContainerRayCast(%endvec, %startvec, %searchMasks, %player);
   //if (firstWord(%scanTarg) !$= firstWord(%reverseTarg))
   //{
      //echo("\n***Trace results differ");
      //echo("   Scan: " @ %scanTarg);
      //echo("Reverse: " @ %reverseTarg);
   //}

   if(%scanTarg)
   {   // a target in range was found
      %target = firstWord(%scanTarg);
      //echo("target = " @ %target.getId() @ " and player = " @ %player.getId() @ "\n");

      if (%target.getId() $= %player.getId())
         return;

      if ( !isObject(%target.client) && !%target.isBot )
      {  // Hit something other than a player or AI...Just play sound
         if (%target != %player.hthDamageLastId)
         {
            %player.hthDamageLastId = %target;
            %hitSound = %this.hitStaticSound;
            serverPlay3D(%hitSound,%player.getTransform());
         }
         return;
      }

      //if (%target.team == %player.team)
         //return;

      // store end point from raycast return buffer
      %pos = getWords(%scanTarg, 1, 3);

      // if we have hit this person already...apply no more damage
      if (%target == %player.hthDamageLastId)
         return;

      // save who we last damaged
      %player.hthDamageLastId = %target;

      // shields and weapon rebounding
      if(%target.shielded || %target.hthDamageSeqPlaying)
      {
         %block = 1;
         // Now we see if we hit from behind...
         %forwardVec = %target.getEyeVector();
         %objDir2D   = getWord(%forwardVec, 0) @ " " @ getWord(%forwardVec,1) @ " " @ "0";
         %objPos     = %target.getPosition();
         %dif        = VectorSub(%objPos, %player.getPosition());
         %dif        = getWord(%dif, 0) @ " " @ getWord(%dif, 1) @ " 0";
         %dif        = VectorNormalize(%dif);
         %dot        = VectorDot(%dif, %objDir2D);

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
      {  // Attack was blocked
         %hitSound = %this.hitStaticSound;
         serverPlay3D(%hitSound,%pos);
         return;
      }

      // Apply damage to targetted object
      if(%target.getdataBlock().isInvincible == true || %target.isInvincible == true)
         return;

      if (%target.getState() !$= "Dead" )
      {
         %obj = %target;
         %location = %pos;
         %hitSound = %this.hitLiveSound;
         serverPlay3D(%hitSound,%obj.getTransform());

         %damage = %attack.damageAmount;

         %damLoc = firstWord(%target.getDamageLocation(%pos));
         // you can use this to add limited loacational damage, but the head is whats hit the most - TF
         if ( %target.isBot )
         {
            %chance = getRandom(100);
            %chance += %player.knockdown;
            %chance += %weaponslot.knockdown;
         }
         else
         {   // Don't knock down or change animation on live players
            %chance = 0;
            %damLoc = "";
         }
         %damageType = %this.item; // example: Axe / Sword etc
         if(%player.client)
            %target.CurrentEnemy = %player.getShapename();
         
         if(%this.modifier < 1) %this.modifier = 1;         
         %obj.damage(%player, %pos, %damage * %this.modifier, "Melee");

         %client = %target.client;
         %sourceObject = %player;
         %sourceClient = %sourceObject ? %sourceObject.client : 0;

         //if (%target.getState() !$= "Dead")
            //pushPlayerBack(%obj,%pos,%player,%attack,%attack.impulse);
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
