
singleton Material(mat_A3D_cart1)
{
   mapTo = "vik_int_floor_1024";
   diffuseMap[0] = "vik_int_floor_1024.dds";
   normalMap[0] = "vik_int_floor_nm1024.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "Props_A3D";
};

singleton Material(mat_A3D_cart2)
{
   mapTo = "cart1";
   diffuseMap[0] = "cart2";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "Props_A3D";
};

singleton Material(mat_A3D_cart3)
{
   mapTo = "cart3";
   diffuseMap[0] = "cart3";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "Props_A3D";
};

singleton Material(mat_caravan)
{
   mapTo = "caravan";
   diffuseMap[0] = "art/Packs/Props/A3D_Carts/caravan";
   materialTag0 = "Props_A3D";
   useAnisotropic[0] = "1";
   normalMap[0] = "art/Packs/Props/A3D_Carts/caravan_NRM.jpg";
   specularPower[0] = "49";
   pixelSpecular[0] = "1";
};
