// Sound datablocks needed by all dinos
////////////////////////JAW SFX//////////////////////
datablock SFXProfile(Jaw1Sound)
{
   filename = "art/Packs/AI/Dinos/sound/Jaw1";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(Jaw2Sound)
{
   filename = "art/Packs/AI/Dinos/sound/Jaw2";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(Jaw3Sound)
{
   filename = "art/Packs/AI/Dinos/sound/Jaw3";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(JawHit1Sound)
{
   filename = "art/Packs/AI/Dinos/sound/TRexAttackCrunch";
   description = AudioClose3d;
   preload = false;
};

// All Dino Datablocks
exec("./Allosaurus/datablock.cs");
exec("./Compsognathus/datablock.cs");
exec("./Diplodocus/datablock.cs");
exec("./Parasaurolophus/datablock.cs");
exec("./Quetzalcoatlus/datablock.cs");
exec("./Spinosaurus/datablock.cs");
exec("./Stegosaurus/datablock.cs");
exec("./TRex/datablock.cs");
exec("./Triceratops/datablock.cs");
exec("./Velociraptor/datablock.cs");
