
singleton Material(mat_ironSpear)
{
   mapTo = "ironspear_dif";
   diffuseMap[0] = "art/inv/weapons/Spears/ironspear_dif";
   normalMap[0] = "art/inv/weapons/Spears/ironspear_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(mat_StoneSpear)
{
   mapTo = "StoneSpear_dif";
   diffuseMap[0] = "art/inv/weapons/Spears/StoneSpear_dif";
   normalMap[0] = "art/inv/weapons/Spears/stonespear_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(mat_SPSpear)
{
   mapTo = "superpowerfulspear_dif";
   diffuseMap[0] = "art/inv/weapons/Spears/superpowerfulspear_dif";
   normalMap[0] = "art/inv/weapons/Spears/superpowerfulspear_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(mat_StoneSpear_trans)
{
   mapTo = "stonespear_trans";
   diffuseMap[0] = "art/inv/weapons/spears/stonespear_trans";
   useAnisotropic[0] = "1";
   alphaTest = "1";
};
