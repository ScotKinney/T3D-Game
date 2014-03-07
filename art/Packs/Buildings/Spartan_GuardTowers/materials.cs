singleton Material(mat_GrdRoofs)
{
   mapTo = "Med2512";
   diffuseMap[0] = "art/Packs/Buildings/Spartan_GuardTowers/KardRoof";
   materialTag0 = "Kardia";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   normalMap[0] = "art/Packs/Buildings/Spartan_Castle/svtqroof1N.dds";
   customFootstepSound = "FootStepSand1Sound";
};

singleton Material(mat_Wood_5)
{
	mapTo = "wood_5";

	diffuseMap[0] = "wood_5.png";
	normalMap[0] = "wood_5N.png";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "Kardia";
};

singleton Material(mat_Aurstone2)
{
  mapTo = "aurstone2";
  diffuseMap[0] = "aurstone2";
};

singleton Material(mat_GrdRopes)
{
   mapTo = "grdropes";
   diffuseMap[0] = "rope_dif.dds";
   materialTag0 = "Kardia";
   useAnisotropic[0] = "1";
   normalMap[0] = "rope_nm.dds";
   specularMap[0] = "rope_spec.dds";
};

singleton Material(mat_GrdWalls)
{
   mapTo = "grdwalls";
   diffuseMap[0] = "KardWallA.dds";
   materialTag0 = "Kardia";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
   normalMap[0] = "KardWallAN.dds";
};
