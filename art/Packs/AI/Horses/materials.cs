singleton Material(base)
{
   mapTo = "base.horse";
   diffuseMap[0] = "base.horse";
};

singleton Material(arabian)
{
   mapTo = "arabian.horse";
   diffuseMap[0] = "arabian.horse";
};

singleton Material(bay)
{
   mapTo = "bay.horse";
   diffuseMap[0] = "bay.horse";
};

singleton Material(indian)
{
   mapTo = "indian.horse";
   diffuseMap[0] = "indian.horse";
};

singleton Material(light)
{
   mapTo = "light.horse";
   diffuseMap[0] = "light.horse";
};

singleton Material(mustang)
{
   mapTo = "mustang.horse";
   diffuseMap[0] = "mustang.horse";
};

singleton Material(palimino)
{
   mapTo = "palimino.horse";
   diffuseMap[0] = "palimino.horse";
};

new Material(HorseFootprintMaterial)
{
   diffuseMap[0] = "hoofprint";
   vertColor[0] = true;
   translucent = true;
   castShadows = "0";
   translucentZWrite = "1";
};




singleton Material(Bay_Horse)
{
   mapTo = "Bay_Body_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Bay_Body_dif";
   normalMap[0] = "art/Packs/AI/Horses/Body_nm.dds";
   specularMap[0] = "art/Packs/AI/Horses/Body_spec.dds";
   useAnisotropic[0] = "1";
};

singleton Material(Black_Mane)
{
   mapTo = "Black_Mane_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Black_Mane_dif";
   specularMap[0] = "art/Packs/AI/Horses/mane_spec.dds";
   useAnisotropic[0] = "1";
   translucent = "1";
   translucentZWrite = "1";
   alphaRef = "20";
};

singleton Material(Armor_Horse)
{
   mapTo = "Horse_armor_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Horse_armor_dif";
   normalMap[0] = "art/Packs/AI/Horses/Horse_armor_nm.dds";
   specularMap[0] = "art/Packs/AI/Horses/Horse_armor_spec.dds";
   useAnisotropic[0] = "1";
};
