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


singleton Material(mat_horseBrown)
{
   mapTo = "Horse_brown_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Horse_brown_dif.dds";
   normalMap[0] = "art/Packs/AI/Horses/Horse_nm.dds";
   specularMap[0] = "art/Packs/AI/Horses/Horse_spec.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Miscellaneous";
};

singleton Material(mat_HorseMane)
{
   mapTo = "mane_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/mane_black_dif.png";
   specularMap[0] = "art/Packs/AI/Horses/mane_spec.dds";
   useAnisotropic[0] = "1";
   doubleSided = "0";
   alphaTest = "0";
   alphaRef = "127";
   translucentBlendOp = "LerpAlpha";
   translucent = "1";
   translucentZWrite = "0";
   specularPower[0] = "1";
   specularStrength[0] = "0";
   pixelSpecular[0] = "1";
   materialTag0 = "Miscellaneous";
};
