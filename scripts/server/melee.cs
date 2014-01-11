//-----------------------------------------------------------------------------
// Melee Weapon Image Class
//-----------------------------------------------------------------------------

function MeleeImage::onMount(%this,%obj,%slot)
{
   if ((%obj.client !$= "") && (%slot == 0))
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
   if ((%obj.client !$= "") && (%slot == 0))
   {
      %obj.client.RefreshWeaponHud(0, "", "");

      //if ( %obj.client.clanWeapon.image.getID() == %this )
      //{  // This is our clan weapon so holster it
         //%this.holsterWeapon(%obj);
         //return;
      //}
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
      return;

   // make sure the attack requested is legit
   if ( %attackNum >= %this.hthNumAttacks )
      %attackNum = %attackNum % %this.hthNumAttacks;
   %attack = %this.hthAttack[%attackNum];

   //if (%obj.getEnergyLevel() <= %this.MinEnergy) return;

   if(%obj.hthStun)
      return;

   // setup the "play once look anim"
   %obj.hthDamageAttack = %attack;
   %obj.hthDamageSeqPlaying = %this;
   %obj.hthDamageStartMS =  $sim::Time;
   %obj.hthDamageLastId = -1;
   %obj.firingWeapon = %this;

   %attackSound = %attack.SwingSound;
   if ( %attackSound !$= "" )
   {  // If we have an attack sound, play at the appopriate time
      if ( %attack.soundDelay !$= "" )
         schedule(%attack.soundDelay, 0, "serverPlay3D",
                  %attackSound,%obj.getTransform());
      else
         serverPlay3D(%attackSound,%obj.getTransform());
   }

   %timeScale = %attack.timeScale;
   if ( (%timeScale $= "") || (%timeScale < 0) )
      %timeScale = 1.0;
   if ( %timeScale < 0.1 )
      %timeScale = 0.1;
   %attack.timeScaleInv = 1.0 / %timeScale;
   if ( %attack.fullSkelAnim )
   {
      if (!%obj.setAttackThread(%attack.seqName, %timeScale,
            %attack.startDamage, %attack.endDamage))
         echo("ERROR in setAttackThread()");
      else if ( %obj.isBot )
      {
         %obj.inAttackThread = true;
         %obj.setImageTrigger(%slot, false);
      }
   }
   else
   {
      if (!%obj.setArmThreadPlayOnce(%attack.seqName, %timeScale,
            %attack.startDamage, %attack.endDamage))
         echo("ERROR in setArmThreadPlayOnce()");
   }
}

// Weapon callback when it hits something
function MeleeImage::onImageIntersect(%this,%player,%slot,%startvec,%endvec)
{
   // if damage sequence is not playing then dont do damage
   if ((%player.hthDamageSeqPlaying != %this) || (%player.getState() $= "Dead"))
      return;

   // determine if damage is active or if we can say the seq is done playing
   // based on current server time
   %offset = $sim::Time - %player.hthDamageStartMS;

   // depending on which attack is playing...
   %attack = %player.hthDamageAttack;
   %startOffset = %attack.startDamage * %attack.timeScaleInv;
   %endOffset = %attack.endDamage * %attack.timeScaleInv;

   // how long until the last damage is done
   // at which point we can say the seq has "Stopped playing"
   if (%offset > %endOffset)
   {
      %player.hthDamageSeqPlaying = 0;
      return;
   }

   // Save the position so we can calculate impulse direction
   %player.hthDamageLastPos = %player.hthDamageCurPos;
   %player.hthDamageCurPos = %endvec;

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

      if (%target.getId() $= %player.getId())
         return;

      // if we have hit this person already...apply no more damage
      if (%target == %player.hthDamageLastId)
         return;

      // save what we last damaged
      %player.hthDamageLastId = %target;
      //%this.showHitPoints(%startvec, %endvec);
      //echo("target = " @ %target.getId() @ " and player = " @ %player.getId() @ "\n");

      // store end point and normal from raycast return buffer
      %pos = getWords(%scanTarg, 1, 3);
      //%normal = getWords(%scanTarg, 4, 6);

      if ( !isObject(%target.client) && !%target.isBot )
      {  // Hit something other than a player or AI...Just play sound
         %hitSound = %this.hitStaticSound;
         serverPlay3D(%hitSound,%player.getTransform());
         
         // Give crafting scripts a chance to process the hit
         onStaticMeleeHit(%target, %player, %this, %pos, %attack);
         return;
      }

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
         if(%player.client)
            %target.CurrentEnemy = %player.getShapename();
         
         %obj.damage(%player, %pos, %damage, "Melee");

         %client = %target.client;
         %sourceObject = %player;
         %sourceClient = %sourceObject ? %sourceObject.client : 0;

         if ( (%target.getState() !$= "Dead") && (%attack.impulse !$= "") )
         {
            %hitDir = VectorSub(%endvec, %player.hthDamageLastPos);
            applyImpactImpulse(%obj, %pos, %hitDir, %player, %attack, %attack.impulse);
         }
      }
   }
   //else if(%scanTarg && (%scanTarg.getType() & $TypeMasks::StaticShapeObjectType))
   //{
      //%damage = %attack.damageAmount;
      //%object = firstWord(%scanTarg);
      //%object.applyDamage(%damage);
   //}
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

function applyImpactImpulse(%victim, %pos, %direction, %attacker, %attack, %impulse)
{
   if (%target.isInvincible == true)
      return;

  //%vpos = %victim.getWorldBoxCenter();
  //%pushDirection = VectorSub(%vpos,%attacker.getWorldBoxCenter());
  //%pushDirection = VectorNormalize(%pushDirection);
  //%vPos = %pos;
  //%pushDirection = VectorSub("0 0 0", %normal); // reverse normal for push direction
  %pushDirection = VectorNormalize(%direction);

  // hardoded impluse
  if(!%impulse)
     %impulse = 12.0;
    
  %pushVec = VectorScale(%pushDirection, %impulse);
  %victim.applyImpulse(%vpos, %pushVec);
}

function restorePlayerControl(%client, %player)
{
   if ( isObject(%player) && %player.getState() !$= "Dead" )
      %client.setControlObject(%player);
}
// <- phdana hth

//function MeleeImage::showHitPoints(%this, %startvec, %endvec)
//{
   //%start = new TSStatic() {
         //shapeName = "art/inv/gems/emerald.dae";
         //playAmbient = "1";
         //meshCulling = "0";
         //originSort = "0";
         //collisionType = "None";
         //decalType = "Collision Mesh";
         //allowPlayerStep = "1";
         //renderNormals = "0";
         //forceDetail = "-1";
         //position = %startvec;
         //rotation = "-0 0 -1 89.8416";
         //scale = "0.2 0.2 0.2";
         //canSave = "1";
         //canSaveDynamicFields = "1";
      //};
//
   //%end = new TSStatic() {
         //shapeName = "art/inv/gems/ruby.dae";
         //playAmbient = "1";
         //meshCulling = "0";
         //originSort = "0";
         //collisionType = "None";
         //decalType = "Collision Mesh";
         //allowPlayerStep = "1";
         //renderNormals = "0";
         //forceDetail = "-1";
         //position = %endvec;
         //rotation = "-0 0 -1 89.8416";
         //scale = "0.2 0.2 0.2";
         //canSave = "1";
         //canSaveDynamicFields = "1";
      //};
   //MissionCleanup.add(%start);
   //MissionCleanup.add(%end);
//}


