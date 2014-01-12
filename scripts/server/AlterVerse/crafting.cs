//-----------------------------------------------------------------------------
// Alterverse Crafting
//-----------------------------------------------------------------------------

// Function called when a static object is hit with a melee weapon
// %obj - The static object that was hit
// %player - The player in control of the weapon
// %weaponImg - Link to the weapon image for the melee weapon used
// %pos - The position of impact
function onStaticMeleeHit(%obj, %player, %weaponImg, %pos, %attack)
{
   // make sure the item hit has crafting materials
   //if (!%obj.craftMaterial || !isObject(%user.client))
   //   return;
   /*   
   %weaponName = %weaponImg.getName();
   if ( (strstr(%weaponName, "Sword") < 0) && (strstr(%weaponName, "Axe") < 0) )
      return;
   */
   if ( %obj.craftType $= "" )
    return;
   
   if ( %obj.craftType $= "wood" )
      %rnd = getRandom(1, 100);
      
   if (%rnd <= 90)
   {
      messageClient(%player.client, "", "Nothing");
   }
   else
   {
      %rnd = getRandom(1, 10);
      switch$ (%rnd)
      {
         case 1:
         messageClient(%player.client, "", "That's a nice wood you got there...");
         case 2:
         messageClient(%player.client, "", "You like that tree don't you?");
         case 3:
         messageClient(%player.client, "", "Oh my.... Does that happen often?");
         case 4:
         messageClient(%player.client, "", "Is that what happens when you hit things!?");
         default:
         messageClient(%player.client, "", "THWOK! Oh gross.. Is that... NAH!");
      }
   }
}