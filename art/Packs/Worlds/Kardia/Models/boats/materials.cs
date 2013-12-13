
singleton Material(mat_Boat_Color)
{
   mapTo = "boat_color";
   diffuseMap[0] = "art/Packs/Worlds/Kardia/Models/boats/boat_color";
   normalMap[0] = "art/Packs/Worlds/Kardia/Models/boats/boat_normals.dds";
   specularMap[0] = "art/Packs/Worlds/Kardia/Models/boats/boat_specular.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   customImpactSound = "FootStepWood1Sound";
   specularPower[0] = "34";
   specularStrength[0] = "2.35294";
   pixelSpecular[0] = "1";
   backLightFactor = "0.9 1.0 0.2";
   materialTag0 = "Boats";

};

singleton Material(mat_Rope_Color)
{
   mapTo = "rope_color";
   diffuseMap[0] = "art/Packs/Worlds/Kardia/Models/boats/rope_color";
   normalMap[0] = "art/Packs/Worlds/Kardia/Models/boats/rope_normals.dds";
   specularMap[0] = "art/Packs/Worlds/Kardia/Models/boats/rope_specular.dds";
   useAnisotropic[0] = "1";
   specularPower[0] = "1";
   specularStrength[0] = "0";
   materialTag0 = "Boats";

};

singleton Material(mat_Sail_Color)
{
   mapTo = "sail_color";
   diffuseMap[0] = "art/Packs/Worlds/Kardia/Models/boats/sail_color";
   normalMap[0] = "art/Packs/Worlds/Kardia/Models/boats/sail_normals.dds";
   specularMap[0] = "art/Packs/Worlds/Kardia/Models/boats/sail_specular.dds";
   useAnisotropic[0] = "1";
   translucent = "1";
   backLightFactor = "0.9 1.0 0.2";
   materialTag0 = "Boats";
};
