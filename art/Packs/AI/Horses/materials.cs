
////Hoof Print

new Material(HorseFootprintMaterial)
{
   diffuseMap[0] = "hoofprint";
   vertColor[0] = true;
   translucent = true;
   castShadows = "0";
   translucentZWrite = "1";
};

//////////Body Colors


singleton Material(Bay_Horse)
{
   mapTo = "Bay_Body_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Bay_Body_dif.dds";
   normalMap[0] = "art/Packs/AI/Horses/Body_nm.dds";
   specularMap[0] = "art/Packs/AI/Horses/Body_spec.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Horses";
};


singleton Material(Black_Horse)
{
   mapTo = "Black_Body_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Black_Body_dif.dds";
   normalMap[0] = "art/Packs/AI/Horses/Body_nm.dds";
   specularMap[0] = "art/Packs/AI/Horses/Body_spec.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Horses";
};

singleton Material(Gray_Horse)
{
   mapTo = "Gray_Body_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Gray_Body_dif.dds";
   normalMap[0] = "art/Packs/AI/Horses/Body_nm.dds";
   specularMap[0] = "art/Packs/AI/Horses/Body_spec.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Horses";
};

singleton Material(Palomino_Horse)
{
   mapTo = "Palomino_Body_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Palomino_Body_dif.dds";
   normalMap[0] = "art/Packs/AI/Horses/Body_nm.dds";
   specularMap[0] = "art/Packs/AI/Horses/Body_spec.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Horses";
};

singleton Material(Pinto_Horse)
{
   mapTo = "Pinto_Body_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Pinto_Body_dif.dds";
   normalMap[0] = "art/Packs/AI/Horses/Body_nm.dds";
   specularMap[0] = "art/Packs/AI/Horses/Body_spec.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Horses";
};

singleton Material(PintoTan_Horse)
{
   mapTo = "PintoTan_Body_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/PintoTan_Body_dif.dds";
   normalMap[0] = "art/Packs/AI/Horses/Body_nm.dds";
   specularMap[0] = "art/Packs/AI/Horses/Body_spec.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Horses";
};

singleton Material(Roan_Horse)
{
   mapTo = "Roan_Body_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Roan_Body_dif.dds";
   normalMap[0] = "art/Packs/AI/Horses/Body_nm.dds";
   specularMap[0] = "art/Packs/AI/Horses/Body_spec.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Horses";
};

singleton Material(White_Horse)
{
   mapTo = "White_Body_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/White_Body_dif.dds";
   normalMap[0] = "art/Packs/AI/Horses/Body_nm.dds";
   specularMap[0] = "art/Packs/AI/Horses/Body_spec.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Horses";
};

///Mane Colors

singleton Material(Black_Mane)
{
   mapTo = "Black_Mane_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Black_Mane_dif.png";
   specularMap[0] = "art/Packs/AI/Horses/mane_spec.dds";
   useAnisotropic[0] = "1";
   translucent = "1";
   translucentZWrite = "0";
   alphaRef = "127";
   translucentBlendOp = "None";
   alphaTest = "1";
   materialTag0 = "Miscellaneous";
   doubleSided = "1";
};

singleton Material(White_Mane)
{
   mapTo = "White_Mane_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/White_Mane_dif.png";
   specularMap[0] = "art/Packs/AI/Horses/mane_spec.dds";
   useAnisotropic[0] = "1";
   translucent = "1";
   translucentZWrite = "0";
   alphaRef = "127";
   translucentBlendOp = "None";
   alphaTest = "1";
   materialTag0 = "Miscellaneous";
   doubleSided = "1";
};

singleton Material(Tan_Mane)
{
   mapTo = "Tan_Mane_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Tan_Mane_dif.png";
   specularMap[0] = "art/Packs/AI/Horses/mane_spec.dds";
   useAnisotropic[0] = "1";
   translucent = "1";
   translucentZWrite = "0";
   alphaRef = "127";
   translucentBlendOp = "None";
   alphaTest = "1";
   materialTag0 = "Miscellaneous";
   doubleSided = "1";
};

singleton Material(Gray_Mane)
{
   mapTo = "Gray_Mane_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Gray_Mane_dif.png";
   specularMap[0] = "art/Packs/AI/Horses/mane_spec.dds";
   useAnisotropic[0] = "1";
   translucent = "1";
   translucentZWrite = "0";
   alphaRef = "127";
   translucentBlendOp = "Sub";
   alphaTest = "0";
   materialTag0 = "Miscellaneous";
   doubleSided = "0";
};

/////////Armor Saddle and Reins

singleton Material(Armor_Horse)
{
   mapTo = "Horse_armor_dif";
   diffuseMap[0] = "art/Packs/AI/Horses/Horse_armor_dif";
   normalMap[0] = "art/Packs/AI/Horses/Horse_armor_nm.dds";
   specularMap[0] = "art/Packs/AI/Horses/Horse_armor_spec.dds";
   useAnisotropic[0] = "1";
};
