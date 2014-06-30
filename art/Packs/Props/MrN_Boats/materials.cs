
singleton Material(mat_MrN_Boat)
{
   mapTo = "MrN_boat_dif";
   diffuseMap[0] = "art/Packs/Props/MrN_Boats/MrN_boat_dif";
   normalMap[0] = "art/Packs/Props/MrN_Boats/MrN_boat_nm.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   customImpactSound = "FootStepWood1Sound";
   specularPower[0] = "61";
   specularStrength[0] = "1";
   pixelSpecular[0] = "1";
   backLightFactor = "0.9 1.0 0.2";
   materialTag0 = "Props_MrN";
};

singleton Material(mat_MrN_Rope)
{
   mapTo = "MrN_rope_dif";
   diffuseMap[0] = "art/Packs/Props/MrN_Boats/MrN_rope_dif";
   normalMap[0] = "art/Packs/Props/MrN_Boats/MrN_rope_nm";
   useAnisotropic[0] = "1";
   specularPower[0] = "1";
   specularStrength[0] = "0";
   materialTag0 = "Props_MrN";
   backLightFactor = "0.9 1.0 0.2";
};

singleton Material(mat_MrN_Sail)
{
   mapTo = "MrN_sail_dif";
   diffuseMap[0] = "art/Packs/Props/MrN_Boats/MrN_sail_dif";
   normalMap[0] = "art/Packs/Props/MrN_Boats/MrN_sail_nm";
   useAnisotropic[0] = "1";
   translucent = "1";
   backLightFactor = "0.9 1.0 0.2";
   materialTag0 = "Props_MrN";
};
