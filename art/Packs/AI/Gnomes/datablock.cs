// Sound datablocks needed by all Gnomes


///Death Cries
datablock SFXProfile(GnomeDeathCry1)
{
   fileName = "art/Packs/AI/Gnomes/sound/GnomeDeathCry1";
   description = AudioClose3d;
   preload = false;
};


///Pain Cries

datablock SFXProfile(GnomePain1)
{
   fileName = "art/Packs/AI/Gnomes/sound/GnomePain1";
   description = AudioClose3d;
   preload = false;
};



// Exec each Gnome Datablock
exec("./Archer/datablock.cs");
exec("./Warrior/datablock.cs");



