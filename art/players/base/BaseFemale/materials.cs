/////////////////BODY

singleton Material(matBF_Body)
{
   mapTo = "BF_Body";
   diffuseMap[0] = "art/players/base/BaseFemale/BF_S1_Body";
   materialTag0 = "Avatar_BF";
};

singleton Material(matBF_Face)
{
   mapTo = "BF_Face";
   diffuseMap[0] = "art/players/base/BaseFemale/BF_S1_FaceM1";
   materialTag0 = "Avatar_BF";
};

singleton Material(matBF_Limbs)
{
   mapTo = "BF_Limbs";
   diffuseMap[0] = "art/players/base/BaseFemale/BF_S1_Limbs";
   materialTag0 = "Avatar_BF";
};

singleton Material(matBF_Eyes)
{
   mapTo = "BF_Eyes";
   diffuseMap[0] = "art/players/base/BaseFemale/BF_EyesLtBlue";
   materialTag0 = "Avatar_BF";
};

singleton Material(matBF_Eyelash)
{
   mapTo = "BF_Eyelash";
   diffuseMap[0] = "art/players/base/BaseFemale/BF_Eyelash";
   translucentZWrite = "0";
   alphaRef = "56";
   translucent = "1";
   translucentBlendOp = "Mul";
   alphaTest = "1";
   backLightFactor = "0.9 1.0 0.2";
   materialTag0 = "Avatar_BF";
   backlight = "1";
};

singleton Material(matBF_Eyelids)
{
   mapTo = "BF_Eyelids";
   diffuseMap[0] = "art/players/base/BaseFemale/BF_S1_Eyelids";
   animFlags[0] = "0x00000018";
   sequenceFramePerSec[0] = "4";
   sequenceSegmentSize[0] = "0.0625";
   translucent = "1";
   translucentZWrite = "1";
   alphaRef = "20";
   backLightFactor = "0.9 1.0 0.2";
   materialTag0 = "Avatar_BF";
   backlight = "1";
};

////////////HAIR

singleton Material(matBF_HairA)
{
   mapTo = "BF_HairA";
   diffuseMap[0] = "art/players/base/BaseFemale/Hair/HairA/BF_HairA_Blk";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BF";
   doubleSided = "1";
   specularPower[0] = "128";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

singleton Material(matBF_HairB)
{
   mapTo = "BF_HairB";
   diffuseMap[0] = "art/players/base/BaseFemale/Hair/HairB/BF_HairB_Blk";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BF";
   doubleSided = "1";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

singleton Material(matBF_HairC)
{
   mapTo = "BF_HairC";
   diffuseMap[0] = "art/players/base/BaseFemale/Hair/HairB/BF_HairB_Blk";
   doubleSided = "1";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BF";
   specularPower[0] = "128";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

singleton Material(matBF_HairD)
{
   mapTo = "BF_HairD";
   diffuseMap[0] = "art/players/base/BaseFemale/Hair/HairD/BF_HairD_Black";
   doubleSided = "1";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BF";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

singleton Material(matBF_HairD_Scalp)
{
   mapTo = "BF_HairD_Scalp";
   diffuseMap[0] = "art/players/base/BaseFemale/Hair/HairD/BF_HairD_Scalp_Black";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BF";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

singleton Material(matBF_HairD_Sticks)
{
   mapTo = "BF_HairD_Sticks";
   diffuseMap[0] = "art/players/base/BaseFemale/Hair/HairD/BF_HairD_Sticks";
   materialTag0 = "Avatar_BF";
};

singleton Material(matBF_HairE)
{
   mapTo = "BF_HairE";
   diffuseMap[0] = "art/players/base/BaseFemale/Hair/HairB/BF_HairB_Blk";
   doubleSided = "1";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BF";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

singleton Material(matBF_HairF)
{
   mapTo = "BF_HairF";
   diffuseMap[0] = "art/players/base/BaseFemale/Hair/HairB/BF_HairB_Blk";
   doubleSided = "1";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BF";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

singleton Material(matBF_HairG)
{
   mapTo = "BF_HairG";
   diffuseMap[0] = "art/players/base/BaseFemale/Hair/HairG/BF_HairG_Black";
   doubleSided = "1";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BF";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};


/////////////////////////////////////TOKARA STUFF////////////////////////
/////////////////////////////////////////////////////////////////////////////////

singleton Material(BF_WristGrd_Tok)
{
   mapTo = "BF_WristGrd_Tok";
   diffuseMap[0] = "art/players/base/BaseFemale/Tokara/BF_WristGrd_Tok";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_WristGrdMtl_Tok)
{
   mapTo = "BF_WristGrdMtl_Tok";
   diffuseMap[0] = "art/players/base/BaseFemale/Tokara/BF_WristGrdMtl_Tok";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_ArmBands_Tok)
{
   mapTo = "BF_ArmBands_Tok";
   diffuseMap[0] = "art/players/base/BaseFemale/Tokara/BF_ArmBands_Tok";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Belt_Tok)
{
   mapTo = "BF_Belt_Tok";
   diffuseMap[0] = "art/players/base/BaseFemale/Tokara/BF_Belt_Tok";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Pantie_Tok)
{
   mapTo = "BF_Pantie_Tok";
   diffuseMap[0] = "art/players/base/BaseFemale/Tokara/BF_Pantie_Tok_Red";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_LoinCloth_Tok)
{
   mapTo = "BF_LoinCloth_Tok";
   diffuseMap[0] = "art/players/base/BaseFemale/Tokara/BF_LoinCloth_Tok_Red";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Shirt_Tok)
{
   mapTo = "BF_Shirt_Tok";
   diffuseMap[0] = "art/players/base/BaseFemale/Tokara/BF_Shirt_Tok_Red";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Mocs_Tok)
{
   mapTo = "BF_Mocs_Tok";
   diffuseMap[0] = "art/players/base/BaseFemale/Tokara/BF_Mocs_Tok";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Helmet_Tok)
{
   mapTo = "BF_Helmet_Tok";
   diffuseMap[0] = "art/players/base/BaseFemale/Tokara/BF_Helmet_Tok_Red";
   materialTag0 = "Avatar_BF";
};

////////////////////////////////////////KARDIA STUFF///////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

singleton Material(BF_Skirt_Kard)
{
   mapTo = "BF_Skirt_Kard";
   diffuseMap[0] = "art/players/base/BaseFemale/Kardia/BF_Skirt_Kard";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Helmet_Kard)
{
   mapTo = "BF_Helmet_Kard";
   diffuseMap[0] = "art/players/base/BaseFemale/Kardia/BF_Helmet_Kard";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Top_Kard)
{
   mapTo = "BF_Top_Kard";
   diffuseMap[0] = "art/players/base/BaseFemale/Kardia/BF_Top_Kard";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_LegWraps_Kard)
{
   mapTo = "BF_LegWraps_Kard";
   diffuseMap[0] = "art/players/base/BaseFemale/Kardia/BF_LegWraps_Kard";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Sandals_Kard)
{
   mapTo = "BF_Sandals_Kard";
   diffuseMap[0] = "art/players/base/BaseFemale/Kardia/BF_Sandals_Kard";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_WristGrd_Kard_R)
{
   mapTo = "BF_WristGrd_Kard_R";
   diffuseMap[0] = "art/players/base/BaseFemale/Kardia/BF_WristGrd_Kard_R";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_ArmBands_Kard)
{
   mapTo = "BF_ArmBands_Kard";
   diffuseMap[0] = "art/players/base/BaseFemale/Kardia/BF_ArmBands_Kard";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_WristGrd_Kard_L)
{
   mapTo = "BF_WristGrd_Kard_L";
   diffuseMap[0] = "art/players/base/BaseFemale/Kardia/BF_WristGrd_Kard_L";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_ShinGrd_Kard_R)
{
   mapTo = "BF_ShinGrd_Kard_R";
   diffuseMap[0] = "art/players/base/BaseFemale/Kardia/BF_ShinGrd_Kard_R";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_ShinGrd_Kard_L)
{
   mapTo = "BF_ShinGrd_Kard_L";
   diffuseMap[0] = "art/players/base/BaseFemale/Kardia/BF_ShinGrd_Kard_L";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Briefs_Kard)
{
   mapTo = "BF_Briefs_Kard";
   diffuseMap[0] = "art/players/base/BaseFemale/Kardia/BF_Briefs_Kard";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Choker_Kard)
{
   mapTo = "BF_Choker_Kard";
   diffuseMap[0] = "art/players/base/BaseFemale/Kardia/BF_Choker_Kard";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Cape_Kard)
{
   mapTo = "BF_Cape_Kard";
   diffuseMap[0] = "art/players/base/BaseFemale/Kardia/BF_Cape_Kard";
   doubleSided = "1";
   materialTag0 = "Avatar_BF";
};

/////////////////////////////////////////////MTYHRIEL STUFF/////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////



singleton Material(BF_Belt_Myth)
{
   mapTo = "BF_Belt_Myth";
   diffuseMap[0] = "art/players/base/BaseFemale/Mythriel/BF_Belt_Myth";
   translucent = "0";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Hood_Myth)
{
   mapTo = "BF_Hood_Myth";
   diffuseMap[0] = "art/players/base/BaseFemale/Mythriel/BF_Hood_Myth";
   doubleSided = "1";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_WristGrds_Myth)
{
   mapTo = "BF_WristGrds_Myth";
   diffuseMap[0] = "art/players/base/BaseFemale/Mythriel/BF_WristGrds_Myth";
   translucent = "0";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Pants_Myth)
{
   mapTo = "BF_Pants_Myth";
   diffuseMap[0] = "art/players/base/BaseFemale/Mythriel/BF_Pants_Myth";
   translucent = "0";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Top_Myth)
{
   mapTo = "BF_Top_Myth";
   diffuseMap[0] = "art/players/base/BaseFemale/Mythriel/BF_Top_Myth1.png";
   translucent = "0";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_ChestStrap_Myth)
{
   mapTo = "BF_ChestStrap_Myth";
   diffuseMap[0] = "art/players/base/BaseFemale/Mythriel/BF_ChestStrap_Myth";
   translucent = "0";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Boots_Myth)
{
   mapTo = "BF_Boots_Myth";
   diffuseMap[0] = "art/players/base/BaseFemale/Mythriel/BF_Boots_Myth";
   translucent = "0";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Quiver_Myth)
{
   mapTo = "BF_Quiver_Myth";
   diffuseMap[0] = "art/players/base/BaseFemale/Mythriel/BF_Quiver_Myth";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Horn_Myth)
{
   mapTo = "BF_Horn_Myth";
   diffuseMap[0] = "art/players/base/BaseFemale/Mythriel/BF_Horn_Myth";
   materialTag0 = "Avatar_BM";
};

singleton Material(mat_Darts)
{
   mapTo = "Dart";
   diffuseMap[0] = "art/inv/weapons/Dart/Dart.png";
   materialTag0 = "Avatar_BF";
   translucent = "0";
   forestWindEnabled = "1";
   backlight = "1";
   materialTag1 = "Vegetation";
   backLightFactor = "0.9 1.0 0.2";
};

////////////////////////////////////////////VALHALLA STUFF///////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////


singleton Material(BF_Cape_Val)
{
   mapTo = "BF_Cape_Val";
   diffuseMap[0] = "art/players/base/BaseFemale/Valhalla/BF_Cape_Val";
   materialTag0 = "Avatar_BF";
   doubleSided = "1";
};

singleton Material(BF_LoinCloth_Val)
{
   mapTo = "BF_LoinCloth_Val";
   diffuseMap[0] = "art/players/base/BaseFemale/Valhalla/BF_LoinCloth_Val";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Top_Val)
{
   mapTo = "BF_Top_Val";
   diffuseMap[0] = "art/players/base/BaseFemale/Valhalla/BF_Top_Val";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Horns_Val)
{
   mapTo = "BF_Horns_Val";
   diffuseMap[0] = "art/players/base/BaseFemale/Valhalla/BF_Horns_Val";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Pantie_Val)
{
   mapTo = "BF_Pantie_Val";
   diffuseMap[0] = "art/players/base/BaseFemale/Valhalla/BF_Pantie_Val";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Boots_Val)
{
   mapTo = "BF_Boots_Val";
   diffuseMap[0] = "art/players/base/BaseFemale/Valhalla/BF_Boots_Val";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Helmet_Val)
{
   mapTo = "BF_Helmet_Val";
   diffuseMap[0] = "art/players/base/BaseFemale/Valhalla/BF_Helmet_Val";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_HelmetHorns_Val)
{
   mapTo = "BF_HelmetHorns_Val";
   diffuseMap[0] = "art/players/base/BaseFemale/Valhalla/BF_HelmetHorns_Val";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_WristGrds_Val)
{
   mapTo = "BF_WristGrds_Val";
   diffuseMap[0] = "art/players/base/BaseFemale/Valhalla/BF_WristGrds_Val";
   materialTag0 = "Avatar_BF";
};

////////////////////////////////////////////FREE JACK STUFF///////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////


singleton Material(BF_Pants_FJ)
{
   mapTo = "BF_Pants_FJ";
   diffuseMap[0] = "art/players/base/BaseFemale/FreeJack/BF_Pants_FJ";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Top_FJ)
{
   mapTo = "BF_Top_FJ";
   diffuseMap[0] = "art/players/base/BaseFemale/FreeJack/BF_Top_FJ";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_DoRag_FJ)
{
   mapTo = "BF_DoRag_FJ";
   diffuseMap[0] = "art/players/base/BaseFemale/FreeJack/BF_DoRag_FJ_Red";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_EyePatch_FJ)
{
   mapTo = "BF_EyePatch_FJ";
   diffuseMap[0] = "art/players/base/BaseFemale/FreeJack/BF_EyePatch_FJ";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Hat_FJ)
{
   mapTo = "BF_Hat_FJ";
   diffuseMap[0] = "art/players/base/BaseFemale/FreeJack/BF_Hat_FJ";
   doubleSided = "1";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_ChestStrap_FJ)
{
   mapTo = "BF_ChestStrap_FJ";
   diffuseMap[0] = "art/players/base/BaseFemale/FreeJack/BF_ChestStrap_FJ";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_WristGrds_FJ)
{
   mapTo = "BF_WristGrds_FJ";
   diffuseMap[0] = "art/players/base/BaseFemale/FreeJack/BF_WristGrds_FJ";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Sash_FJ)
{
   mapTo = "BF_Sash_FJ";
   diffuseMap[0] = "art/players/base/BaseFemale/FreeJack/BF_Sash_FJ_Red";
   materialTag0 = "Avatar_BF";
};

singleton Material(BF_Boots_FJ)
{
   mapTo = "BF_Boots_FJ";
   diffuseMap[0] = "art/players/base/BaseFemale/FreeJack/BF_Boots_FJ";
   materialTag0 = "Avatar_BF";
};
