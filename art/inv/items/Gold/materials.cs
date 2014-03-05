singleton Material(mat_MrN_GoldCoin)
{
   mapTo = "MrN_GoldCoin_dif";
   diffuseMap[0] = "art/inv/items/Gold/MrN_GoldCoin_dif";
   specularMap[0] = "art/inv/items/Gold/MrN_GoldCoin_spec.dds";
   useAnisotropic[0] = "1";
   normalMap[0] = "art/inv/items/Gold/MrN_GoldCoin_nm.dds";
};

singleton Material(mat_MrN_GoldBar)
{
   mapTo = "MrN_GoldBar_dif";
   diffuseMap[0] = "MrN_GoldBar_dif";
   normalMap[0] = "MrN_GoldBar_nm.dds";
   specularMap[0] = "MrN_GoldBar_spec.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
};
