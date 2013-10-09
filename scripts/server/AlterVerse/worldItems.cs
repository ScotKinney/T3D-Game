//BloodClans generated ItemData datablocks
//File: scripts/server/bloodclans/worldItems.cs

datablock ItemData(AFK_Rune)
{
   pickupName = "AFK Rune";

   ItemID = 68;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/Runes/rIVrune.dts";
   invIcon = "art/gui/icons/AFK_Rune.jpg";
   previewImage = "art/gui/icons/bfb.jpg";
   maxInventory = 999;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;
};
$BloodClans::ItemNames[68] = "AFK_Rune";

datablock ItemData(Apple)
{
   pickupName = "Apple";

   ItemID = 1;
   category = "food";
   className = "food";
   shapeFile = "art/inv/food/apple.dts";
   invIcon = "art/gui/icons/apple.jpg";
   previewImage = "art/gui/icons/food.jpg";
   maxInventory = 20;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10.000000;

   table = "Food";
   SubItemID = 16;
   nutrition = 10.0;
   drink = 0;
};
$BloodClans::ItemNames[1] = "Apple";

datablock ItemData(Arabian_Horse_Item)
{
   pickupName = "Chestnut Horse";

   ItemID = 123;
   category = "horses";
   className = "inv";
   shapeFile = "art/inv/weapons/dagger/dagger.dts";
   invIcon = "art/gui/icons/horse.jpg";
   previewImage = "art/gui/icons/horse.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 3000.000000;
};
$BloodClans::ItemNames[123] = "Arabian_Horse_Item";

datablock ItemData(Astral_Passport)
{
   pickupName = "Astral Passport";

   ItemID = 83;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/items/kit/healthkit.dts";
   invIcon = "art/gui/icons/astral_passport.jpg";
   previewImage = "art/gui/icons/fits.jpg";
   maxInventory = 999;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;
};
$BloodClans::ItemNames[83] = "Astral_Passport";

datablock ItemData(AxeWeapon)
{
   pickupName = "Axe";

   ItemID = 39;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/PAxes/Axe1.dts";
   invIcon = "art/gui/icons/wpn.jpg";
   previewImage = "art/gui/icons/axe.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "THROWN";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10.000000;

   table = "Weapons";
   SubItemID = 150;
   damage = "1#10";
   range = 4000;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 1;
   image = AxeImage;
   ammo = AxeAmmo;
   effectWeap = "[THROWN]";
   exclusive = " ";
   skill_used = "Throwing";
   delay = 4;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 0;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[39] = "AxeWeapon";

datablock ItemData(AxeAmmo)
{
   pickupName = "Axe";

   ItemID = 40;
   category = "ammo";
   className = "ammo";
   shapeFile = "art/inv/weapons/PAxes/Axe1.dts";
   invIcon = "art/gui/icons/wpn.jpg";
   previewImage = "art/gui/icons/axe.jpg";
   maxInventory = 50;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 50.000000;
};
$BloodClans::ItemNames[40] = "AxeAmmo";

datablock ItemData(Banana)
{
   pickupName = "Banana";

   ItemID = 18;
   category = "food";
   className = "food";
   shapeFile = "art/inv/food/banana.dts";
   invIcon = "art/gui/icons/banana.jpg";
   previewImage = "art/gui/icons/banana.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 30.000000;

   table = "Food";
   SubItemID = 183;
   nutrition = 30.0;
   drink = 0;
};
$BloodClans::ItemNames[18] = "Banana";

datablock ItemData(Barracuda)
{
   pickupName = "Barracuda";
   pluralName = "Barracuda";

   ItemID = 5;
   category = "fish";
   className = "food";
   shapeFile = "art/inv/food/bluebarracuda.dts";
   invIcon = "art/gui/icons/barracuda.jpg";
   previewImage = "art/gui/icons/bluegill.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 30.000000;

   table = "Food";
   SubItemID = 149;
   nutrition = 30.0;
   drink = 0;
};
$BloodClans::ItemNames[5] = "Barracuda";

datablock ItemData(Bay_Horse_Item)
{
   pickupName = "Bay Horse";

   ItemID = 122;
   category = "horses";
   className = "inv";
   shapeFile = "art/inv/weapons/dagger/dagger.dts";
   invIcon = "art/gui/icons/horse.jpg";
   previewImage = "art/gui/icons/horse.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 3000.000000;
};
$BloodClans::ItemNames[122] = "Bay_Horse_Item";

datablock ItemData(BBQ_Ribs_Potion)
{
   pickupName = "BBQ Ribs Potion";

   ItemID = 69;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/potions/pbottle2-3.dts";
   invIcon = "art/gui/icons/BBQ_Ribs_Potion.jpg";
   previewImage = "art/gui/icons/bfb.jpg";
   maxInventory = 5;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 600.000000;
};
$BloodClans::ItemNames[69] = "BBQ_Ribs_Potion";

datablock ItemData(Blue_Striped_Perch)
{
   pickupName = "Blue Striped Perch";
   pluralName = "Blue Striped Perch";

   ItemID = 4;
   category = "fish";
   className = "food";
   shapeFile = "art/inv/food/bluestripedperch.dts";
   invIcon = "art/gui/icons/blue_striped_perch.jpg";
   previewImage = "art/gui/icons/bluegill.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 20.000000;

   table = "Food";
   SubItemID = 152;
   nutrition = 20.0;
   drink = 0;
};
$BloodClans::ItemNames[4] = "Blue_Striped_Perch";

datablock ItemData(Boglin_Toes)
{
   pickupName = "Boglin Toe";
   pluralName = "Boglin Toes";

   ItemID = 139;
   category = "tackle";
   className = "Bait";
   shapeFile = "art/inv/items/bait/boglintoes.dts";
   invIcon = "art/gui/icons/BoglinToes.jpg";
   previewImage = "art/gui/icons/BoglinToes.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 5.000000;
};
$BloodClans::ItemNames[139] = "Boglin_Toes";

datablock ItemData(BoltAmmo)
{
   pickupName = "Crossbow Bolt";

   ItemID = 3;
   category = "ammo";
   className = "ammo";
   shapeFile = "art/inv/weapons/projectile.dts";
   invIcon = "art/gui/icons/ammo.jpg";
   previewImage = "art/gui/icons/ammo.jpg";
   maxInventory = 100;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10.000000;
};
$BloodClans::ItemNames[3] = "BoltAmmo";

datablock ItemData(Brook_Trout)
{
   pickupName = "Brook Trout";
   pluralName = "Brook Trout";

   ItemID = 10;
   category = "fish";
   className = "food";
   shapeFile = "art/inv/food/brooktrout.dts";
   invIcon = "art/gui/icons/brook_trout.jpg";
   previewImage = "art/gui/icons/bluegill.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 30.000000;

   table = "Food";
   SubItemID = 154;
   nutrition = 30.0;
   drink = 0;
};
$BloodClans::ItemNames[10] = "Brook_Trout";

datablock ItemData(Buckskin_Horse_Item)
{
   pickupName = "Buckskin Horse";

   ItemID = 126;
   category = "horses";
   className = "inv";
   shapeFile = "art/inv/weapons/dagger/dagger.dts";
   invIcon = "art/gui/icons/horse.jpg";
   previewImage = "art/gui/icons/horse.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 3000.000000;
};
$BloodClans::ItemNames[126] = "Buckskin_Horse_Item";

datablock ItemData(CrossbowWeapon)
{
   pickupName = "Crossbow";

   ItemID = 2;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/crossbow/weapon.dts";
   invIcon = "art/gui/icons/crossbow.jpg";
   previewImage = "art/gui/icons/crossbow.jpg";
   maxInventory = 2;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 500.000000;

   table = "Weapons";
   SubItemID = 24;
   damage = "1#10";
   range = 4000;
   pass_armor = 0;
   no_instant_kill = 0;
   TwoHanded = 1;
   indestructible = 0;
   ranged = 1;
   image = CrossbowImage;
   ammo = boltAmmo;
   skill_used = "Archery";
   delay = 4;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[2] = "CrossbowWeapon";

datablock ItemData(DaggerWeapon)
{
   pickupName = "Dagger";

   ItemID = 97;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/dagger/dagger.dts";
   invIcon = "art/gui/icons/dagger.jpg";
   previewImage = "art/gui/icons/dagger.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "THROWN";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10.000000;

   table = "Weapons";
   SubItemID = 165;
   damage = "1#10";
   range = 4000;
   pass_armor = 0;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 1;
   image = DaggerImage;
   ammo = DaggerAmmo;
   effectWeap = "[THROWN]";
   skill_used = "Throwing";
   delay = 4;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 0;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[97] = "DaggerWeapon";

datablock ItemData(DaggerAmmo)
{
   pickupName = "Dagger";

   ItemID = 98;
   category = "ammo";
   className = "ammo";
   shapeFile = "art/inv/weapons/dagger/dagger.dts";
   invIcon = "art/gui/icons/dagger.jpg";
   previewImage = "art/gui/icons/dagger.jpg";
   maxInventory = 50;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10.000000;
};
$BloodClans::ItemNames[98] = "DaggerAmmo";

datablock ItemData(Deer_Hide)
{
   pickupName = "Deer Hide";

   ItemID = 109;
   category = "wool";
   className = "inv";
   shapeFile = "art/inv/items/deerhide/deerhide.dts";
   invIcon = "art/gui/icons/deerhide.jpg";
   previewImage = "art/gui/icons/deerhide.jpg";
   maxInventory = 10;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 5000.000000;
};
$BloodClans::ItemNames[109] = "Deer_Hide";

datablock ItemData(Emerald)
{
   pickupName = "Emerald";

   ItemID = 26;
   category = "gems";
   className = "gem";
   shapeFile = "art/inv/gems/emerald.dae";
   invIcon = "art/gui/icons/emerald.jpg";
   previewImage = "art/gui/icons/gem.jpg";
   maxInventory = 150;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 300.000000;
};
$BloodClans::ItemNames[26] = "Emerald";

datablock ItemData(Evil_Eye_Potion)
{
   pickupName = "Evil Eye Potion";

   ItemID = 76;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/potions/pbottle3-1.dts";
   invIcon = "art/gui/icons/evil_eye_potion.jpg";
   previewImage = "art/gui/icons/fits.jpg";
   maxInventory = 10;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 100.000000;
};
$BloodClans::ItemNames[76] = "Evil_Eye_Potion";

datablock ItemData(Fishing_Pole)
{
   pickupName = "Fishing Pole";

   ItemID = 138;
   category = "tackle";
   className = "Pole";
   shapeFile = "art/inv/items/FishingPole/fishingpole.dts";
   invIcon = "art/gui/icons/fishingpole.jpg";
   previewImage = "art/gui/icons/fishingpole.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10.000000;
};
$BloodClans::ItemNames[138] = "Fishing_Pole";

datablock ItemData(FJFemaleSwordWeapon)
{
   pickupName = "Sword";

   ItemID = 99;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/Scimi/scimitar1_4.dts";
   invIcon = "art/gui/icons/Sword.jpg";
   previewImage = "art/gui/icons/Sword.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;

   table = "Weapons";
   SubItemID = 168;
   damage = "1#10";
   range = 100;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 0;
   image = FJFemaleSwordImage;
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[99] = "FJFemaleSwordWeapon";

datablock ItemData(FJMaleSwordWeapon)
{
   pickupName = "Sword";

   ItemID = 100;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/Scimi/scimitar1_4.dts";
   invIcon = "art/gui/icons/Sword.jpg";
   previewImage = "art/gui/icons/Sword.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;

   table = "Weapons";
   SubItemID = 167;
   damage = "1#10";
   range = 100;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 0;
   image = FJMaleSwordImage;
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[100] = "FJMaleSwordWeapon";

datablock ItemData(FlintlockWeapon)
{
   pickupName = "Rusty Flintlock";

   ItemID = 59;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/flintloc/flintlock.dts";
   invIcon = "art/gui/icons/flintlock.jpg";
   previewImage = "art/gui/icons/flintlock.jpg";
   maxInventory = 2;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 600.000000;

   table = "Weapons";
   SubItemID = 158;
   damage = "1#10";
   range = 4000;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 1;
   indestructible = 0;
   ranged = 1;
   image = FlintlockImage;
   ammo = ShotAmmo;
   effectWeap = "[RIFLE]";
   skill_used = "Firearms";
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[59] = "FlintlockWeapon";

datablock ItemData(Gargoyles_Fire_Balls)
{
   pickupName = "Gargoyles Fire Balls";

   ItemID = 84;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/garballs/garballs.dts";
   invIcon = "art/gui/icons/Gargoyles_Fire_Balls.jpg";
   previewImage = "art/gui/icons/fits.jpg";
   maxInventory = 6;
   keepOnDeath = 1;
   skullLevel = 6;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 6000.000000;
};
$BloodClans::ItemNames[84] = "Gargoyles_Fire_Balls";

datablock ItemData(Grasshoppers)
{
   pickupName = "Grasshopper";
   pluralName = "Grasshoppers";

   ItemID = 141;
   category = "tackle";
   className = "Bait";
   shapeFile = "art/inv/items/bait/ghoppers.dts";
   invIcon = "art/gui/icons/GHoppers.jpg";
   previewImage = "art/gui/icons/GHoppers.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 2.000000;
};
$BloodClans::ItemNames[141] = "Grasshoppers";

datablock ItemData(Green_Gill)
{
   pickupName = "Green Gill";
   pluralName = "Green Gill";

   ItemID = 8;
   category = "fish";
   className = "food";
   shapeFile = "art/inv/food/greengill.dts";
   invIcon = "art/gui/icons/green_gill.jpg";
   previewImage = "art/gui/icons/bluegill.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 25.000000;

   table = "Food";
   SubItemID = 151;
   nutrition = 25.0;
   drink = 0;
};
$BloodClans::ItemNames[8] = "Green_Gill";

datablock ItemData(GrenadeWeapon)
{
   pickupName = "Grenade";

   ItemID = 47;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/grenade/grenade.dts";
   invIcon = "art/gui/icons/grenade.jpg";
   previewImage = "art/gui/icons/grenade.jpg";
   maxInventory = 50;
   keepOnDeath = 0;
   skullLevel = 5;
   effect = "THROWN";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 200.000000;

   table = "Weapons";
   SubItemID = 153;
   damage = "1#10";
   range = 4000;
   pass_armor = 0;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 1;
   image = GrenadeImage;
   ammo = GrenadeAmmo;
   delay = 10;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 0;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[47] = "GrenadeWeapon";

datablock ItemData(GrenadeAmmo)
{
   pickupName = "Grenade";

   ItemID = 48;
   category = "ammo";
   className = "ammo";
   shapeFile = "art/inv/weapons/grenade/grenade.dts";
   invIcon = "art/gui/icons/grenade.jpg";
   previewImage = "art/gui/icons/grenade.jpg";
   maxInventory = 5;
   keepOnDeath = 0;
   skullLevel = 5;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;
};
$BloodClans::ItemNames[48] = "GrenadeAmmo";

datablock ItemData(Ham)
{
   pickupName = "Ham";

   ItemID = 51;
   category = "food";
   className = "food";
   shapeFile = "art/inv/food/Ham.dts";
   invIcon = "art/gui/icons/ham.jpg";
   previewImage = "art/gui/icons/food.jpg";
   maxInventory = 10;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 60.000000;

   table = "Food";
   SubItemID = 217;
   nutrition = 60.0;
   drink = 0;
};
$BloodClans::ItemNames[51] = "Ham";

datablock ItemData(Huge_Gold_Nugget)
{
   pickupName = "Huge Gold Nugget";

   ItemID = 16;
   category = "mineral";
   className = "gem";
   shapeFile = "art/inv/Gems/nugget_g_h.dae";
   invIcon = "art/gui/icons/huge_gold_nugget.jpg";
   previewImage = "art/gui/icons/gem.jpg";
   maxInventory = 2;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1000.000000;
};
$BloodClans::ItemNames[16] = "Huge_Gold_Nugget";

datablock ItemData(Human_Torch_Potion)
{
   pickupName = "Human Torch Potion";

   ItemID = 72;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/potions/pbottle3-2.dts";
   invIcon = "art/gui/icons/Human_Torch_Potion.jpg";
   previewImage = "art/gui/icons/bfb.jpg";
   maxInventory = 3;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 2000.000000;
};
$BloodClans::ItemNames[72] = "Human_Torch_Potion";

datablock ItemData(InsectInside_Potion)
{
   pickupName = "InsectInside Potion";

   ItemID = 73;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/potions/pbottle3-3.dts";
   invIcon = "art/gui/icons/InsectInside_Potion.jpg";
   previewImage = "art/gui/icons/bfb.jpg";
   maxInventory = 3;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 2000.000000;
};
$BloodClans::ItemNames[73] = "InsectInside_Potion";

datablock ItemData(Invisibility_Rune)
{
   pickupName = "Invisibility Rune";

   ItemID = 71;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/Runes/rIrune.dts";
   invIcon = "art/gui/icons/Invisibility_Rune.jpg";
   previewImage = "art/gui/icons/bfb.jpg";
   maxInventory = 10;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 500.000000;
};
$BloodClans::ItemNames[71] = "Invisibility_Rune";

datablock ItemData(JavelinWeapon)
{
   pickupName = "Javelin";

   ItemID = 86;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/Javelin/Javelin.dts";
   invIcon = "art/gui/icons/Javelin.jpg";
   previewImage = "art/gui/icons/javelin.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "THROWN";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10.000000;

   table = "Weapons";
   SubItemID = 160;
   damage = "1#10";
   range = 4000;
   pass_armor = 0;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 1;
   image = JavelinImage;
   ammo = JavelinAmmo;
   effectWeap = "[THROWN]";
   skill_used = "Throwing";
   delay = 4;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 0;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[86] = "JavelinWeapon";

datablock ItemData(JavelinAmmo)
{
   pickupName = "Javelin";

   ItemID = 87;
   category = "ammo";
   className = "ammo";
   shapeFile = "art/inv/weapons/Javelin/Javelin.dts";
   invIcon = "art/gui/icons/Javelin.jpg";
   previewImage = "art/gui/icons/javelin.jpg";
   maxInventory = 50;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10.000000;
};
$BloodClans::ItemNames[87] = "JavelinAmmo";

datablock ItemData(KardFemaleSwordWeapon)
{
   pickupName = "Sword";

   ItemID = 101;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/KarSword/SpartanSword1_4.dts";
   invIcon = "art/gui/icons/Sword.jpg";
   previewImage = "art/gui/icons/Sword.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;

   table = "Weapons";
   SubItemID = 170;
   damage = "1#10";
   range = 100;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 0;
   image = KardFemaleSwordImage;
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[101] = "KardFemaleSwordWeapon";

datablock ItemData(KardMaleSwordWeapon)
{
   pickupName = "Sword";

   ItemID = 102;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/KarSword/SpartanSword1_4.dts";
   invIcon = "art/gui/icons/Sword.jpg";
   previewImage = "art/gui/icons/Sword.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;

   table = "Weapons";
   SubItemID = 169;
   damage = "1#10";
   range = 100;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 0;
   image = KardMaleSwordImage;
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[102] = "KardMaleSwordWeapon";

datablock ItemData(Lamp_Oil)
{
   pickupName = "Lamp Oil";

   ItemID = 89;
   category = "misc";
   className = "inv";
   shapeFile = "art/inv/magic/potions/pbottle5-2.dts";
   invIcon = "art/gui/icons/Lamp_Oil.jpg";
   previewImage = "art/gui/icons/Lamp_Oil.jpg";
   maxInventory = 30;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10.000000;
};
$BloodClans::ItemNames[89] = "Lamp_Oil";

datablock ItemData(Lantern)
{
   pickupName = "Lantern";

   ItemID = 88;
   category = "misc";
   className = "inv";
   shapeFile = "art/inv/items/Lantern/Lantern.dts";
   invIcon = "art/gui/icons/Lantern.jpg";
   previewImage = "art/gui/icons/Lantern.jpg";
   maxInventory = 2;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10.000000;
};
$BloodClans::ItemNames[88] = "Lantern";

datablock ItemData(Large_Diamond)
{
   pickupName = "Large Diamond";

   ItemID = 23;
   category = "gems";
   className = "gem";
   shapeFile = "art/inv/gems/diamondLarge.dae";
   invIcon = "art/gui/icons/large_diamond.jpg";
   previewImage = "art/gui/icons/gem.jpg";
   maxInventory = 50;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 600.000000;
};
$BloodClans::ItemNames[23] = "Large_Diamond";

datablock ItemData(Large_Gold_Nugget)
{
   pickupName = "Large Gold Nugget";

   ItemID = 34;
   category = "mineral";
   className = "gem";
   shapeFile = "art/inv/Gems/nugget_g_l.dae";
   invIcon = "art/gui/icons/large_gold_nugget.jpg";
   previewImage = "art/gui/icons/gem.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 400.000000;
};
$BloodClans::ItemNames[34] = "Large_Gold_Nugget";

datablock ItemData(Large_Silver_Nugget)
{
   pickupName = "Large Silver Nugget";

   ItemID = 61;
   category = "mineral";
   className = "gem";
   shapeFile = "art/inv/Gems/SilverNuggetLg.dts";
   invIcon = "art/gui/icons/silver_nugget.jpg";
   previewImage = "art/gui/icons/gem.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 400.000000;
};
$BloodClans::ItemNames[61] = "Large_Silver_Nugget";

datablock ItemData(Laser_Drone)
{
   pickupName = "Laser Drone";

   ItemID = 85;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/occams/laserDrone.dts";
   invIcon = "art/gui/icons/Laser_Drone.jpg";
   previewImage = "art/gui/icons/fits.jpg";
   maxInventory = 9;
   keepOnDeath = 1;
   skullLevel = 9;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 9000.000000;
};
$BloodClans::ItemNames[85] = "Laser_Drone";

datablock ItemData(Leaf_Me_Alone_Potion)
{
   pickupName = "Leaf Me Alone Potion";

   ItemID = 74;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/potions/pbottle3-4.dts";
   invIcon = "art/gui/icons/Leaf_Me_Alone_Potion.jpg";
   previewImage = "art/gui/icons/bfb.jpg";
   maxInventory = 3;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 2000.000000;
};
$BloodClans::ItemNames[74] = "Leaf_Me_Alone_Potion";

datablock ItemData(Lemon)
{
   pickupName = "Lemon";

   ItemID = 19;
   category = "food";
   className = "food";
   shapeFile = "art/inv/food/lemon.dts";
   invIcon = "art/gui/icons/lemon.jpg";
   previewImage = "art/gui/icons/food.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 15.000000;

   table = "Food";
   SubItemID = 184;
   nutrition = 15.0;
   drink = 0;
};
$BloodClans::ItemNames[19] = "Lemon";

datablock ItemData(Level_3_Badge)
{
   pickupName = "Skull Level 3 Badge";

   ItemID = 92;
   category = "misc";
   className = "gem";
   shapeFile = "art/inv/items/levelBadges/lvl3badge.dts";
   invIcon = "art/gui/icons/coin.jpg";
   previewImage = "art/gui/icons/coin.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 3;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;
};
$BloodClans::ItemNames[92] = "Level_3_Badge";

datablock ItemData(Levitation_Rune)
{
   pickupName = "Levitation Rune";

   ItemID = 79;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/Runes/rVIIIrune.dts";
   invIcon = "art/gui/icons/Levitation_Rune.jpg";
   previewImage = "art/gui/icons/fits.jpg";
   maxInventory = 10;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 100.000000;
};
$BloodClans::ItemNames[79] = "Levitation_Rune";

datablock ItemData(Lime)
{
   pickupName = "Lime";

   ItemID = 20;
   category = "food";
   className = "food";
   shapeFile = "art/inv/food/lime.dts";
   invIcon = "art/gui/icons/lime.jpg";
   previewImage = "art/gui/icons/food.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 20.000000;

   table = "Food";
   SubItemID = 194;
   nutrition = 20.0;
   drink = 0;
};
$BloodClans::ItemNames[20] = "Lime";

datablock ItemData(Loaf_of_Bread)
{
   pickupName = "Loaf of Bread";
   pluralName = "Loaves of Bread";

   ItemID = 17;
   category = "food";
   className = "food";
   shapeFile = "art/inv/food/bread.dae";
   invIcon = "art/gui/icons/loaf_of_bread.jpg";
   previewImage = "art/gui/icons/food.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 40.000000;

   table = "Food";
   SubItemID = 15;
   nutrition = 40.0;
   drink = 0;
};
$BloodClans::ItemNames[17] = "Loaf_of_Bread";

datablock ItemData(Magical_Key)
{
   pickupName = "Magical Key";

   ItemID = 56;
   category = "misc";
   className = "inv";
   shapeFile = "art/inv/items/HODKey/HoDKey.dae";
   invIcon = "art/gui/icons/key.jpg";
   previewImage = "art/gui/icons/key.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 4;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 100.000000;
};
$BloodClans::ItemNames[56] = "Magical_Key";

datablock ItemData(Medium_Diamond)
{
   pickupName = "Medium Diamond";

   ItemID = 22;
   category = "gems";
   className = "gem";
   shapeFile = "art/inv/gems/diamondMed.dae";
   invIcon = "art/gui/icons/medium_diamond.jpg";
   previewImage = "art/gui/icons/gem.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 340.000000;
};
$BloodClans::ItemNames[22] = "Medium_Diamond";

datablock ItemData(Medium_Silver_Nugget)
{
   pickupName = "Medium Silver Nugget";

   ItemID = 62;
   category = "mineral";
   className = "gem";
   shapeFile = "art/inv/Gems/SilverNuggetMed.dts";
   invIcon = "art/gui/icons/silver_nugget.jpg";
   previewImage = "art/gui/icons/gem.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 200.000000;
};
$BloodClans::ItemNames[62] = "Medium_Silver_Nugget";

datablock ItemData(Minnows)
{
   pickupName = "Minnow";
   pluralName = "Minnows";

   ItemID = 142;
   category = "tackle";
   className = "Bait";
   shapeFile = "art/inv/items/bait/minnows.dts";
   invIcon = "art/gui/icons/Minnows.jpg";
   previewImage = "art/gui/icons/Minnows.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 3.000000;
};
$BloodClans::ItemNames[142] = "Minnows";

datablock ItemData(Mudfish)
{
   pickupName = "Mudfish";
   pluralName = "Mudfish";

   ItemID = 15;
   category = "fish";
   className = "food";
   shapeFile = "art/inv/food/mudfish.dts";
   invIcon = "art/gui/icons/mudfish.jpg";
   previewImage = "art/gui/icons/bluegill.jpg";
   maxInventory = 20;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 15.000000;

   table = "Food";
   SubItemID = 157;
   nutrition = 15.0;
   drink = 0;
};
$BloodClans::ItemNames[15] = "Mudfish";

datablock ItemData(Multi_Mine_Potion)
{
   pickupName = "Multi Mine Potion";

   ItemID = 75;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/potions/pbottle3-8.dts";
   invIcon = "art/gui/icons/Multi_Mine_Potion.jpg";
   previewImage = "art/gui/icons/bfb.jpg";
   maxInventory = 3;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 2000.000000;
};
$BloodClans::ItemNames[75] = "Multi_Mine_Potion";

datablock ItemData(Mustang_Horse_Item)
{
   pickupName = "Spotted Horse";

   ItemID = 127;
   category = "horses";
   className = "inv";
   shapeFile = "art/inv/weapons/dagger/dagger.dts";
   invIcon = "art/gui/icons/horse.jpg";
   previewImage = "art/gui/icons/horse.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 3000.000000;
};
$BloodClans::ItemNames[127] = "Mustang_Horse_Item";

datablock ItemData(MythFemaleSwordWeapon)
{
   pickupName = "Sword";

   ItemID = 106;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/l_sword/longsword.dts";
   invIcon = "art/gui/icons/Sword.jpg";
   previewImage = "art/gui/icons/Sword.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;

   table = "Weapons";
   SubItemID = 173;
   damage = "1#10";
   range = 100;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 0;
   image = MythFemaleSwordImage;
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[106] = "MythFemaleSwordWeapon";

datablock ItemData(MythMaleSwordWeapon)
{
   pickupName = "Sword";

   ItemID = 103;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/l_sword/longsword.dts";
   invIcon = "art/gui/icons/Sword.jpg";
   previewImage = "art/gui/icons/Sword.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;

   table = "Weapons";
   SubItemID = 166;
   damage = "1#10";
   range = 100;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 0;
   image = MythMaleSwordImage;
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[103] = "MythMaleSwordWeapon";

datablock ItemData(Nightcrawlers)
{
   pickupName = "NightCrawler";
   pluralName = "Nightcrawlers";

   ItemID = 140;
   category = "tackle";
   className = "Bait";
   shapeFile = "art/inv/items/bait/nightcrawlers.dts";
   invIcon = "art/gui/icons/NightCrawlers.jpg";
   previewImage = "art/gui/icons/NightCrawlers.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 2.000000;
};
$BloodClans::ItemNames[140] = "Nightcrawlers";

datablock ItemData(Orange_Sea_Bass)
{
   pickupName = "Bright Orange Sea Bass";
   pluralName = "Bright Orange Sea Bass";

   ItemID = 6;
   category = "fish";
   className = "food";
   shapeFile = "art/inv/food/orangeseabass.dts";
   invIcon = "art/gui/icons/orange_sea_bass.jpg";
   previewImage = "art/gui/icons/bluegill.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 40.000000;

   table = "Food";
   SubItemID = 156;
   nutrition = 40.0;
   drink = 0;
};
$BloodClans::ItemNames[6] = "Orange_Sea_Bass";

datablock ItemData(Painted_Horse_Item)
{
   pickupName = "Painted Horse";

   ItemID = 125;
   category = "horses";
   className = "inv";
   shapeFile = "art/inv/weapons/dagger/dagger.dts";
   invIcon = "art/gui/icons/horse.jpg";
   previewImage = "art/gui/icons/horse.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 3000.000000;
};
$BloodClans::ItemNames[125] = "Painted_Horse_Item";

datablock ItemData(Palimino_Horse_Item)
{
   pickupName = "Gray Horse";

   ItemID = 124;
   category = "horses";
   className = "inv";
   shapeFile = "art/inv/weapons/dagger/dagger.dts";
   invIcon = "art/gui/icons/horse.jpg";
   previewImage = "art/gui/icons/horse.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 3000.000000;
};
$BloodClans::ItemNames[124] = "Palimino_Horse_Item";

datablock ItemData(Pike)
{
   pickupName = "Pike";
   pluralName = "Pike";

   ItemID = 12;
   category = "fish";
   className = "food";
   shapeFile = "art/inv/food/pike.dts";
   invIcon = "art/gui/icons/pike.jpg";
   previewImage = "art/gui/icons/bluegill.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 40.000000;

   table = "Food";
   SubItemID = 155;
   nutrition = 30.0;
   drink = 0;
};
$BloodClans::ItemNames[12] = "Pike";

datablock ItemData(Rainbow_Trout)
{
   pickupName = "Rainbow Trout";
   pluralName = "Rainbow Trout";

   ItemID = 14;
   category = "fish";
   className = "food";
   shapeFile = "art/inv/food/rainbowtrout.dts";
   invIcon = "art/gui/icons/rainbow_trout.jpg";
   previewImage = "art/gui/icons/bluegill.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 35.000000;

   table = "Food";
   SubItemID = 166;
   nutrition = 35.0;
   drink = 0;
};
$BloodClans::ItemNames[14] = "Rainbow_Trout";

datablock ItemData(Red_Devil)
{
   pickupName = "Red Devil";

   ItemID = 13;
   category = "fish";
   className = "food";
   shapeFile = "art/inv/food/reddevil.dts";
   invIcon = "art/gui/icons/red_devil.jpg";
   previewImage = "art/gui/icons/bluegill.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 120.000000;

   table = "Food";
   SubItemID = 162;
   nutrition = 35.0;
   drink = 0;
};
$BloodClans::ItemNames[13] = "Red_Devil";

datablock ItemData(Red_Head)
{
   pickupName = "Red Head";
   pluralName = "Red Head";

   ItemID = 9;
   category = "fish";
   className = "food";
   shapeFile = "art/inv/food/redhead.dts";
   invIcon = "art/gui/icons/red_head.jpg";
   previewImage = "art/gui/icons/bluegill.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 20.000000;

   table = "Food";
   SubItemID = 158;
   nutrition = 20.0;
   drink = 0;
};
$BloodClans::ItemNames[9] = "Red_Head";

datablock ItemData(Ring_of_Fire_Rune)
{
   pickupName = "Ring of Fire Rune";

   ItemID = 78;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/Runes/rIXrune.dts";
   invIcon = "art/gui/icons/Ring_Of_Fire_Rune.jpg";
   previewImage = "art/gui/icons/fits.jpg";
   maxInventory = 3;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1500.000000;
};
$BloodClans::ItemNames[78] = "Ring_of_Fire_Rune";

datablock ItemData(Roast)
{
   pickupName = "Roast";

   ItemID = 32;
   category = "food";
   className = "food";
   shapeFile = "art/inv/food/meat_roll.dts";
   invIcon = "art/gui/icons/roast.jpg";
   previewImage = "art/gui/icons/food.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 50.000000;

   table = "Food";
   SubItemID = 208;
   nutrition = 50.0;
   drink = 0;
};
$BloodClans::ItemNames[32] = "Roast";

datablock ItemData(Ruby)
{
   pickupName = "Ruby";

   ItemID = 24;
   category = "gems";
   className = "gem";
   shapeFile = "art/inv/gems/ruby.dae";
   invIcon = "art/gui/icons/ruby.jpg";
   previewImage = "art/gui/icons/gem.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 400.000000;
};
$BloodClans::ItemNames[24] = "Ruby";

datablock ItemData(Sapphire)
{
   pickupName = "Sapphire";

   ItemID = 25;
   category = "gems";
   className = "gem";
   shapeFile = "art/inv/gems/sapphire.dae";
   invIcon = "art/gui/icons/sapphire.jpg";
   previewImage = "art/gui/icons/gem.jpg";
   maxInventory = 200;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 200.000000;
};
$BloodClans::ItemNames[25] = "Sapphire";

datablock ItemData(Sazzons_Scepter)
{
   pickupName = "Sazzons Scepter";

   ItemID = 81;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/s_scepter/scepter.dts";
   invIcon = "art/gui/icons/Sazzons_Scepter.jpg";
   previewImage = "art/gui/icons/fits.jpg";
   maxInventory = 7;
   keepOnDeath = 1;
   skullLevel = 7;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 7000.000000;
};
$BloodClans::ItemNames[81] = "Sazzons_Scepter";

datablock ItemData(Shard_of_Boltarc)
{
   pickupName = "Shard of Boltarc";
   pluralName = "Shards of Boltarc";

   ItemID = 65;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/shard/shardofboltarc.dts";
   invIcon = "art/gui/icons/Shard_of_Boltarc.jpg";
   previewImage = "art/gui/icons/fits.jpg";
   maxInventory = 10;
   keepOnDeath = 1;
   skullLevel = 10;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10000.000000;
};
$BloodClans::ItemNames[65] = "Shard_of_Boltarc";

datablock ItemData(Shards_of_Ice_Crystal)
{
   pickupName = "Shards of Ice Crystal";

   ItemID = 80;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/Crystals/crys5_Small.dts";
   invIcon = "art/gui/icons/shards_of_ice_crystal.jpg";
   previewImage = "art/gui/icons/fits.jpg";
   maxInventory = 5;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 800.000000;
};
$BloodClans::ItemNames[80] = "Shards_of_Ice_Crystal";

datablock ItemData(Shark_Steak)
{
   pickupName = "Shark Steak";

   ItemID = 27;
   category = "food";
   className = "food";
   shapeFile = "art/inv/food/sharksteak.dts";
   invIcon = "art/gui/icons/shark_steak.jpg";
   previewImage = "art/gui/icons/food.jpg";
   maxInventory = 10;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 80.000000;

   table = "Food";
   SubItemID = 200;
   nutrition = 80.0;
   drink = 0;
};
$BloodClans::ItemNames[27] = "Shark_Steak";

datablock ItemData(Shieldof10_1)
{
   pickupName = "Shield 1";

   ItemID = 110;
   category = "misc";
   className = "inv";
   shapeFile = "art/inv/items/medallions/medallion1.dts";
   invIcon = "art/gui/icons/shieldof10.jpg";
   previewImage = "art/gui/icons/shieldof10.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1000.000000;
};
$BloodClans::ItemNames[110] = "Shieldof10_1";

datablock ItemData(Shieldof10_10)
{
   pickupName = "Shield 10";

   ItemID = 119;
   category = "misc";
   className = "inv";
   shapeFile = "art/inv/items/medallions/medallion10.dts";
   invIcon = "art/gui/icons/shieldof10.jpg";
   previewImage = "art/gui/icons/shieldof10.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1000.000000;
};
$BloodClans::ItemNames[119] = "Shieldof10_10";

datablock ItemData(Shieldof10_2)
{
   pickupName = "Shield 2";

   ItemID = 111;
   category = "misc";
   className = "inv";
   shapeFile = "art/inv/items/medallions/medallion2.dts";
   invIcon = "art/gui/icons/shieldof10.jpg";
   previewImage = "art/gui/icons/shieldof10.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1000.000000;
};
$BloodClans::ItemNames[111] = "Shieldof10_2";

datablock ItemData(Shieldof10_3)
{
   pickupName = "Shield 3";

   ItemID = 112;
   category = "misc";
   className = "inv";
   shapeFile = "art/inv/items/medallions/medallion3.dts";
   invIcon = "art/gui/icons/shieldof10.jpg";
   previewImage = "art/gui/icons/shieldof10.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1000.000000;
};
$BloodClans::ItemNames[112] = "Shieldof10_3";

datablock ItemData(Shieldof10_4)
{
   pickupName = "Shield 4";

   ItemID = 113;
   category = "misc";
   className = "inv";
   shapeFile = "art/inv/items/medallions/medallion4.dts";
   invIcon = "art/gui/icons/shieldof10.jpg";
   previewImage = "art/gui/icons/shieldof10.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1000.000000;
};
$BloodClans::ItemNames[113] = "Shieldof10_4";

datablock ItemData(Shieldof10_5)
{
   pickupName = "Shield 5";

   ItemID = 114;
   category = "misc";
   className = "inv";
   shapeFile = "art/inv/items/medallions/medallion5.dts";
   invIcon = "art/gui/icons/shieldof10.jpg";
   previewImage = "art/gui/icons/shieldof10.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1000.000000;
};
$BloodClans::ItemNames[114] = "Shieldof10_5";

datablock ItemData(Shieldof10_6)
{
   pickupName = "Shield 6";

   ItemID = 115;
   category = "misc";
   className = "inv";
   shapeFile = "art/inv/items/medallions/medallion6.dts";
   invIcon = "art/gui/icons/shieldof10.jpg";
   previewImage = "art/gui/icons/shieldof10.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1000.000000;
};
$BloodClans::ItemNames[115] = "Shieldof10_6";

datablock ItemData(Shieldof10_7)
{
   pickupName = "Shield 7";

   ItemID = 116;
   category = "misc";
   className = "inv";
   shapeFile = "art/inv/items/medallions/medallion7.dts";
   invIcon = "art/gui/icons/shieldof10.jpg";
   previewImage = "art/gui/icons/shieldof10.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1000.000000;
};
$BloodClans::ItemNames[116] = "Shieldof10_7";

datablock ItemData(Shieldof10_8)
{
   pickupName = "Shield 8";

   ItemID = 117;
   category = "misc";
   className = "inv";
   shapeFile = "art/inv/items/medallions/medallion8.dts";
   invIcon = "art/gui/icons/shieldof10.jpg";
   previewImage = "art/gui/icons/shieldof10.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1000.000000;
};
$BloodClans::ItemNames[117] = "Shieldof10_8";

datablock ItemData(Shieldof10_9)
{
   pickupName = "Shield 9";

   ItemID = 118;
   category = "misc";
   className = "inv";
   shapeFile = "art/inv/items/medallions/medallion9.dts";
   invIcon = "art/gui/icons/shieldof10.jpg";
   previewImage = "art/gui/icons/shieldof10.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1000.000000;
};
$BloodClans::ItemNames[118] = "Shieldof10_9";

datablock ItemData(ShotAmmo)
{
   pickupName = "Flintlock Shot";

   ItemID = 60;
   category = "ammo";
   className = "ammo";
   shapeFile = "art/inv/weapons/flintloc/shot.dae";
   invIcon = "art/gui/icons/wpn.jpg";
   previewImage = "art/gui/icons/ammo.jpg";
   maxInventory = 100;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1.000000;
};
$BloodClans::ItemNames[60] = "ShotAmmo";

datablock ItemData(SlingDartWeapon)
{
   pickupName = "Sling Dart";

   ItemID = 95;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/dart/slingdart.dts";
   invIcon = "art/gui/icons/slingdart.jpg";
   previewImage = "art/gui/icons/slingdart.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "THROWN";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10.000000;

   table = "Weapons";
   SubItemID = 164;
   damage = "1#10";
   range = 4000;
   pass_armor = 0;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 1;
   image = SlingDartImage;
   ammo = SlingDartAmmo;
   effectWeap = "[THROWN]";
   skill_used = "Throwing";
   delay = 4;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 0;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[95] = "SlingDartWeapon";

datablock ItemData(SlingDartAmmo)
{
   pickupName = "Sling Dart";

   ItemID = 96;
   category = "ammo";
   className = "ammo";
   shapeFile = "art/inv/weapons/dart/slingdart.dts";
   invIcon = "art/gui/icons/slingdart.jpg";
   previewImage = "art/gui/icons/slingdart.jpg";
   maxInventory = 50;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10.000000;
};
$BloodClans::ItemNames[96] = "SlingDartAmmo";

datablock ItemData(Small_Diamond)
{
   pickupName = "Small Diamond";

   ItemID = 21;
   category = "gems";
   className = "gem";
   shapeFile = "art/inv/gems/diamond.dae";
   invIcon = "art/gui/icons/small_diamond.jpg";
   previewImage = "art/gui/icons/gem.jpg";
   maxInventory = 300;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 140.000000;
};
$BloodClans::ItemNames[21] = "Small_Diamond";

datablock ItemData(Small_Gold_Nugget)
{
   pickupName = "Small Gold Nugget";

   ItemID = 43;
   category = "mineral";
   className = "gem";
   shapeFile = "art/inv/Gems/nugget_g_s.dae";
   invIcon = "art/gui/icons/small_gold_nugget.jpg";
   previewImage = "art/gui/icons/gem.jpg";
   maxInventory = 150;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 100.000000;
};
$BloodClans::ItemNames[43] = "Small_Gold_Nugget";

datablock ItemData(Small_Silver_Nugget)
{
   pickupName = "Small Silver Nugget";

   ItemID = 63;
   category = "mineral";
   className = "gem";
   shapeFile = "art/inv/Gems/SilverNuggetSm.dts";
   invIcon = "art/gui/icons/silver_nugget.jpg";
   previewImage = "art/gui/icons/gem.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 60.000000;
};
$BloodClans::ItemNames[63] = "Small_Silver_Nugget";

datablock ItemData(Solo_Mine_Potion)
{
   pickupName = "Solo Mine Potion";

   ItemID = 70;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/potions/pbottle3-6.dts";
   invIcon = "art/gui/icons/Solo_Mine_Potion.jpg";
   previewImage = "art/gui/icons/bfb.jpg";
   maxInventory = 3;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 1500.000000;
};
$BloodClans::ItemNames[70] = "Solo_Mine_Potion";

datablock ItemData(Swordfish)
{
   pickupName = "Swordfish";
   pluralName = "Swordfish";

   ItemID = 11;
   category = "fish";
   className = "food";
   shapeFile = "art/inv/food/swordfish.dts";
   invIcon = "art/gui/icons/swordfish.jpg";
   previewImage = "art/gui/icons/bluegill.jpg";
   maxInventory = 20;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 300.000000;

   table = "Food";
   SubItemID = 174;
   nutrition = 100.0;
   drink = 0;
};
$BloodClans::ItemNames[11] = "Swordfish";

datablock ItemData(The_Claw_Potion)
{
   pickupName = "Potion for The Claw";
   pluralName = "Potions for The Claw";

   ItemID = 77;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/potions/pbottle2-1.dts";
   invIcon = "art/gui/icons/The_Claw_Potion.jpg";
   previewImage = "art/gui/icons/fits.jpg";
   maxInventory = 5;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 800.000000;
};
$BloodClans::ItemNames[77] = "The_Claw_Potion";

datablock ItemData(Thors_Hammer)
{
   pickupName = "Thors Hammer";

   ItemID = 82;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/th_hammer/th_hammer.dts";
   invIcon = "art/gui/icons/thors_hammer.jpg";
   previewImage = "art/gui/icons/fits.jpg";
   maxInventory = 8;
   keepOnDeath = 1;
   skullLevel = 8;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 8000.000000;
};
$BloodClans::ItemNames[82] = "Thors_Hammer";

datablock ItemData(Thunderbolt_Potion)
{
   pickupName = "Thunderbolt Potion";

   ItemID = 64;
   category = "magic";
   className = "inv";
   shapeFile = "art/inv/magic/potions/pbottle2-2.dts";
   invIcon = "art/gui/icons/Thunderbolt_potion.jpg";
   previewImage = "art/gui/icons/bfb.jpg";
   maxInventory = 5;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 600.000000;
};
$BloodClans::ItemNames[64] = "Thunderbolt_Potion";

datablock ItemData(TokaraMushroom)
{
   pickupName = "TokaraMushroom";

   ItemID = 46;
   category = "food";
   className = "food";
   shapeFile = "art/inv/food/fp_mushroomGRN002.dts";
   invIcon = "art/gui/icons/tokaramushroom.jpg";
   previewImage = "art/gui/icons/mushroom.jpg";
   maxInventory = 20;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 15.000000;

   table = "Food";
   SubItemID = 216;
   nutrition = 15.0;
   drink = 0;
};
$BloodClans::ItemNames[46] = "TokaraMushroom";

datablock ItemData(TokFemaleSwordWeapon)
{
   pickupName = "Sword";

   ItemID = 105;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/TokSword/SwordTok.dts";
   invIcon = "art/gui/icons/Sword.jpg";
   previewImage = "art/gui/icons/Sword.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;

   table = "Weapons";
   SubItemID = 172;
   damage = "1#10";
   range = 100;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 0;
   image = TokFemaleSwordImage;
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[105] = "TokFemaleSwordWeapon";

datablock ItemData(TokMaleSwordWeapon)
{
   pickupName = "Sword";

   ItemID = 104;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/TokSword/SwordTok.dts";
   invIcon = "art/gui/icons/Sword.jpg";
   previewImage = "art/gui/icons/Sword.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;

   table = "Weapons";
   SubItemID = 171;
   damage = "1#10";
   range = 100;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 0;
   image = TokMaleSwordImage;
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[104] = "TokMaleSwordWeapon";

datablock ItemData(TomahawkWeapon)
{
   pickupName = "TomaHawk";

   ItemID = 90;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/Tomahawk/thawk.dts";
   invIcon = "art/gui/icons/tomahawk.jpg";
   previewImage = "art/gui/icons/tomahawk.jpg";
   maxInventory = 100;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "THROWN";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 10.000000;

   table = "Weapons";
   SubItemID = 161;
   damage = "1#10";
   range = 4000;
   pass_armor = 0;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 1;
   image = TomahawkImage;
   ammo = TomahawkAmmo;
   effectWeap = "[THROWN]";
   skill_used = "Throwing";
   delay = 4;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 0;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[90] = "TomahawkWeapon";

datablock ItemData(TomahawkAmmo)
{
   pickupName = "TomaHawk";

   ItemID = 91;
   category = "ammo";
   className = "ammo";
   shapeFile = "art/inv/weapons/Tomahawk/thawk.dts";
   invIcon = "art/gui/icons/tomahawk.jpg";
   previewImage = "art/gui/icons/tomahawk.jpg";
   maxInventory = 50;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 50.000000;
};
$BloodClans::ItemNames[91] = "TomahawkAmmo";

datablock ItemData(ValFemaleSwordWeapon)
{
   pickupName = "Sword";

   ItemID = 94;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/valsword/Sword_Val.dts";
   invIcon = "art/gui/icons/Sword.jpg";
   previewImage = "art/gui/icons/Sword.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;

   table = "Weapons";
   SubItemID = 163;
   damage = "1#10";
   range = 100;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 0;
   image = ValFemaleSwordImage;
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[94] = "ValFemaleSwordWeapon";

datablock ItemData(ValMaleSwordWeapon)
{
   pickupName = "Sword";

   ItemID = 93;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/valsword/Sword_Val.dts";
   invIcon = "art/gui/icons/Sword.jpg";
   previewImage = "art/gui/icons/Sword.jpg";
   maxInventory = 1;
   keepOnDeath = 1;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;

   table = "Weapons";
   SubItemID = 162;
   damage = "1#10";
   range = 100;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 0;
   image = ValMaleSwordImage;
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[93] = "ValMaleSwordWeapon";

datablock ItemData(Venison_Chop)
{
   pickupName = "Venison Chop";

   ItemID = 33;
   category = "food";
   className = "food";
   shapeFile = "art/inv/food/lamb.dts";
   invIcon = "art/gui/icons/leg_of_lamb.jpg";
   previewImage = "art/gui/icons/food.jpg";
   maxInventory = 10;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 100.000000;

   table = "Food";
   SubItemID = 45;
   nutrition = 100.0;
   drink = 0;
};
$BloodClans::ItemNames[33] = "Venison_Chop";

datablock ItemData(WizardsStaffWeapon)
{
   pickupName = "Wizards Staff";

   ItemID = 145;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/wizardstaff/wizardsstaff.dts";
   invIcon = "art/gui/icons/wizardstaff.jpg";
   previewImage = "art/gui/icons/wizardstaff.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;

   table = "Weapons";
   SubItemID = 179;
   damage = "1#10";
   range = 100;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 0;
   image = WizardsStaffImage;
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[145] = "WizardsStaffWeapon";

datablock ItemData(WizardStaffWeapon)
{
   pickupName = "WizardStaff";

   ItemID = 144;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/wizardstaff/wizardstaff.dts";
   invIcon = "art/gui/icons/wizardstaff.jpg";
   previewImage = "art/gui/icons/wizardstaff.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;

   table = "Weapons";
   SubItemID = 178;
   damage = "1#10";
   range = 100;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 0;
   image = WizardStaffImage;
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[144] = "WizardStaffWeapon";

datablock ItemData(WizardStaff2Weapon)
{
   pickupName = "WizardStaff";

   ItemID = 146;
   category = "weapons";
   className = "wpn";
   shapeFile = "art/inv/weapons/wizardstaff2/wizardstaff2.dts";
   invIcon = "art/gui/icons/wizardstaff.jpg";
   previewImage = "art/gui/icons/wizardstaff.jpg";
   maxInventory = 1;
   keepOnDeath = 0;
   skullLevel = 0;
   effect = "NONE";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   sticky = true;


   cost = 0.000000;

   table = "Weapons";
   SubItemID = 180;
   damage = "1#10";
   range = 100;
   pass_armor = 1;
   no_instant_kill = 1;
   TwoHanded = 0;
   indestructible = 0;
   ranged = 0;
   image = WizardStaff2Image;
   delay = 1;
   reticle = 'reticle_rocketlauncher';
   ignoreDistance = 50;
   usesAmmo = 1;
   fireDelay = 100;
   triggerDown = 50;
   cameraMaxDist = "0.69869";
   class = "Weapon";
   diffuseMap0 = "art/inv/weapons/crossbow/crossbow.jpg";
};
$BloodClans::ItemNames[146] = "WizardStaff2Weapon";


