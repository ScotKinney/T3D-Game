////Body

singleton Material(matBM_Eyelash)
{
   mapTo = "BM_Eyelash";
   diffuseMap[0] = "art/players/base/BaseMale/BM_Eyelash";
   castShadows = "0";
   translucent = "1";
   translucentBlendOp = "Mul";
   alphaTest = "1";
   alphaRef = "80";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Eyelids)
{
   mapTo = "BM_Eyelids";
   diffuseMap[0] = "art/players/base/BaseMale/BM_S1_Eyelids";
   animFlags[0] = "0x00000018";
   sequenceFramePerSec[0] = "4";
   sequenceSegmentSize[0] = "0.0625";
   castShadows = "0";
   translucent = "1";
   translucentZWrite = "1";
   alphaRef = "20";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Eyes)
{
   mapTo = "BM_Eyes";
   diffuseMap[0] = "art/players/base/BaseFeMale/BF_EyesLtBlue";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Face)
{
   mapTo = "BM_Face";
   diffuseMap[0] = "art/players/base/BaseMale/BM_S1_Face";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Body)
{
   mapTo = "BM_Body";
   diffuseMap[0] = "art/players/base/BaseMale/BM_S1_Body";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Limbs)
{
   mapTo = "BM_Limbs";
   diffuseMap[0] = "art/players/base/BaseMale/BM_S1_Limbs";
   materialTag0 = "Avatar_BM";
};



/////////////////////////////HAIR///////////////////////////////////////
//////////////////////////////////////////////////////////////////////

singleton Material(matBM_HairA)
{
   mapTo = "BM_HairA";
   diffuseMap[0] = "art/players/base/BaseMale/Hair/HairA/HairA_Black";
   doubleSided = "1";
   translucent = "1";
   alphaTest = "1";
   alphaRef = 100; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   useAnisotropic[0] = "0";
   materialTag0 = "Avatar_BM";
};


////HairB

singleton Material(matBM_HairB_Scalp)
{
   mapTo = "BM_HairB_Scalp";
   diffuseMap[0] = "art/players/base/BaseMale/Hair/HairB/HairB_Scalp_Black";
   doubleSided = "0";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BM";
   useAnisotropic[0] = "0";
   showFootprints = "0";
};

singleton Material(matBM_HairB_Strands)
{
   mapTo = "BM_HairB_Strands";
   diffuseMap[0] = "art/players/base/BaseMale/Hair/HairB/HairB_Strands_Black";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "1";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BM";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   showFootprints = "0";
   specularPower[0] = "128";
   specularStrength[0] = "1";
   pixelSpecular[0] = "1";
};


////HairC

singleton Material(matBM_HairC_Strands)
{
   mapTo = "BM_HairC_Strands";
   diffuseMap[0] = "art/players/base/BaseMale/Hair/HairC/HairC_Strands_Black";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BM";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   showFootprints = "0";
};

singleton Material(matBM_HairC_Scalp)
{
   mapTo = "BM_HairC_Scalp";
   diffuseMap[0] = "art/players/base/BaseMale/Hair/HairC/HairC_Scalp_Black";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   castShadows = "0";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0";
   showFootprints = "0";
   materialTag0 = "Avatar_BM";
};


////HairD

singleton Material(matBM_HairD_Strands)
{
   mapTo = "BM_HairD_Strands";
   diffuseMap[0] = "art/players/base/BaseMale/Hair/HairD/HairD_Strands_Black";
   doubleSided = "1";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BM";
   useAnisotropic[0] = "1";
   showFootprints = "1";
   specularPower[0] = "1";
   specularStrength[0] = "1";
};

singleton Material(matBM_HairD_Strands)
{
   mapTo = "BM_HairD_Strands";
   diffuseMap[0] = "art/players/base/BaseMale/Hair/HairD/HairD_Strands_Black";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BM";
   doubleSided = "1";
   specularPower[0] = "128";
   pixelSpecular[0] = "1";
};

singleton Material(matBM_HairD_Scalp)
{
   mapTo = "BM_HairD_Scalp";
   diffuseMap[0] = "art/players/base/BaseMale/Hair/HairD/HairD_Scalp_Black";
   translucent = "1";
   alphaTest = "1";
   alphaRef = 50; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "None";
   materialTag0 = "Avatar_BM";
};

////HairE

singleton Material(matBM_HairE)
{
   mapTo = "BM_HairE";
   diffuseMap[0] = "art/players/base/BaseMale/Hair/HairE/BM_HairE_Black";
   doubleSided = "1";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "LerpAlpha";
   materialTag0 = "Avatar_BM";
   specularPower[0] = "1";
   specularStrength[0] = "0";
   pixelSpecular[0] = "0";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

singleton Material(matBM_HairE)
{
   mapTo = "BM_HairE";
   diffuseMap[0] = "art/players/base/BaseMale/Hair/HairE/BM_HairE_Black";
   doubleSided = "1";
   translucent = "1";
   alphaTest = "1";
   alphaRef = 50; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "None";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_HairE_Tie)
{
   mapTo = "BM_HairE_Tie";
   diffuseMap[0] = "art/players/base/BaseMale/Hair/HairE/BM_HairE_Tie";
   materialTag0 = "Avatar_BM";
};

///////////////////////////////////ACCESSORIES////////////////////////
///////////////////////////////////////////////////////////////////

/////////////HeadGear

////////////Crown

singleton Material(matBM_Crown)
{
   mapTo = "BM_Crown";
   diffuseMap[0] = "art/players/base/BaseMale/Accessories/Crown01";
   materialTag0 = "Avatar_BM";
};

////////////////Eye Patch

singleton Material(matBM_EyePatch)
{
   mapTo = "BM_EyePatch";
   diffuseMap[0] = "art/players/base/BaseMale/Accessories/BM_EyePatch_Brn";
   translucent = "0";
   materialTag0 = "Avatar_BM";
};


///////////////Earring_Pirate

singleton Material(matBM_Earring_Pirate)
{
   mapTo = "BM_Earring_Pirate";
   diffuseMap[0] = "art/players/base/BaseMale/Accessories/BM_Earring_Pirate_Gld";
   materialTag0 = "Avatar_BM";
};


//////////////ShoulderGuards

singleton Material(matBM_ShldrGrds_Ax)
{
   mapTo = "BM_ShldrGrds_Ax";
   diffuseMap[0] = "art/players/base/BaseMale/Accessories/BM_ShinGuardsAx_Rust";
   materialTag0 = "Avatar_BM";
};

////////ArmBands

singleton Material(matBM_ArmBands_Ax)
{
   mapTo = "BM_ArmBands_Ax";
   diffuseMap[0] = "art/players/base/BaseMale/Accessories/BM_ShinGuardsAx_Rust";
   materialTag0 = "Avatar_BM";
};


////////////LegBands

singleton Material(matBM_LegBands_Ax)
{
   mapTo = "BM_LegBands_Ax";
   diffuseMap[0] = "art/players/base/BaseMale/Accessories/BM_ShinGuardsAx_Rust";
   materialTag0 = "Avatar_BM";
};



////////////////Spartan Stuff//////////////////////////////////////////////////
/////////////////////////////////////////////


singleton Material(matBM_SpartanCape)
{
   mapTo = "BM_SpartanCape";
   diffuseMap[0] = "art/players/base/BaseMale/Kardia/BM_SpartanCape_Red";
   materialTag0 = "Avatar_BM";
   doubleSided = "1";
};

singleton Material(matBM_SpartanHelmet)
{
   mapTo = "BM_SpartanHelmet";
   diffuseMap[0] = "art/players/base/BaseMale/Kardia/BM_SpartanHelmet_Red";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_WristGrds_Spartan)
{
   mapTo = "BM_WristGrds_Spartan";
   diffuseMap[0] = "art/players/base/BaseMale/Kardia/BM_WristGrds_Spartan";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_ShinGrds_Spartan)
{
   mapTo = "BM_ShinGrds_Spartan";
   diffuseMap[0] = "art/players/base/BaseMale/Kardia/BM_ShinGrds_Spartan";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Sandals_Ax)
{
   mapTo = "BM_Sandals_Ax";
   diffuseMap[0] = "art/players/base/BaseMale/Kardia/BM_ShinGuardsAx_Rust";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_SpartanBriefs)
{
   mapTo = "BM_SpartanBriefs";
   diffuseMap[0] = "art/players/base/BaseMale/Kardia/BM_SpartanBriefs_Rust";
   materialTag0 = "Avatar_BM";
   doubleSided = "1";
};

///////////Spartan Scabbard

singleton Material(matBM_SpartanScabbard)
{
   mapTo = "BM_SpartanScabbard";
   diffuseMap[0] = "art/players/base/BaseMale/Kardia/BM_SpartanScabbard";
   materialTag0 = "Avatar_BM";
};



/////////////////Pirate Stuff//////////////////////////////////////
//////////////////////////////////////////////////////////////////


singleton Material(matBM_Pants_Pirate)
{
   mapTo = "BM_Pants_Pirate";
   diffuseMap[0] = "art/players/base/BaseMale/FreeJack/BM_Pants_Pirate_Gray";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Sash_Pirate)
{
   mapTo = "BM_Sash_Pirate";
   diffuseMap[0] = "art/players/base/BaseMale/FreeJack/BM_Sash_Pirate_Blue";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Boots_Pirate)
{
   mapTo = "BM_Boots_Pirate";
   diffuseMap[0] = "art/players/base/BaseMale/FreeJack/BM_Boots_Pirate_Gray";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Vest_Pirate)
{
   mapTo = "BM_Vest_Pirate";
   diffuseMap[0] = "art/players/base/BaseMale/FreeJack/BM_Vest_Pirate_Blue";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_WristGuards_Ev)
{
   mapTo = "BM_WristGuards_Ev";
   diffuseMap[0] = "art/players/base/BaseMale/FreeJack/BM_WristGuards_Ev";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_DoRag)
{
   mapTo = "BM_DoRag";
   diffuseMap[0] = "art/players/base/BaseMale/FreeJack/BM_DoRag_Blue";
   materialTag0 = "Avatar_BM";
};


///////////////ValHalla Stuff//////////////////////////////////
///////////////////////////////////////////////////////////////


singleton Material(matBM_V_HelmBase)
{
   mapTo = "BM_VHelmBase";
   diffuseMap[0] = "art/players/base/BaseMale/Valhalla/BM_VHelmBase";
   materialTag0 = "Avatar_BM";
   doubleSided = "1";
};

singleton Material(matBM_V_HelmHorns)
{
   mapTo = "BM_VHelmHorns";
   diffuseMap[0] = "art/players/base/BaseMale/Valhalla/BM_VHelmHorns";
   normalMap[0] = "art/players/base/BaseMale/Valhalla/BM_VHelmHorns_nrm";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_V_HelmTop)
{
   mapTo = "BM_VHelmTop";
   diffuseMap[0] = "art/players/base/BaseMale/Valhalla/BM_VHelmTop";
   normalMap[0] = "art/players/base/BaseMale/Valhalla/BM_VHelmTop_nrm";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Val_Armor)
{
   mapTo = "BM_Val_Armor";
   diffuseMap[0] = "art/players/base/BaseMale/Valhalla/BM_Val_ArmorFur";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Cape_Val)
{
   mapTo = "BM_Cape_Val";
   diffuseMap[0] = "art/players/base/BaseMale/Valhalla/BM_Cape_Val_Fur";
   doubleSided = "1";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Boots_Val)
{
   mapTo = "BM_Boots_Val";
   diffuseMap[0] = "art/players/base/BaseMale/Valhalla/BM_Boots_Val.png";
   materialTag0 = "Avatar_BM";
};

//////////WristGuards_Ax

singleton Material(matBM_WristGrds_Ax)
{
   mapTo = "BM_WristGrds_Ax";
   diffuseMap[0] = "art/players/base/BaseMale/Valhalla/BM_ShinGuardsAx_Rust";
   materialTag0 = "Avatar_BM";
};



/////////////////Mythriel Stuff///////////////////////////////////////
////////////////////////////////////////////////////////////////////

singleton Material(matBM_Hood_Myth)
{
   mapTo = "BM_Hood_Myth";
   diffuseMap[0] = "art/players/base/BaseMale/Mythriel/BM_Vest_Myth3";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Vest_Myth)
{
   mapTo = "BM_Vest_Myth";
   diffuseMap[0] = "art/players/base/BaseMale/Mythriel/BM_Vest_Myth1";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_WaistBand_Myth)
{
   mapTo = "BM_WaistBand_Myth";
   diffuseMap[0] = "art/players/base/BaseMale/Mythriel/BM_Vest_Myth1";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_WristGrds_Myth)
{
   mapTo = "BM_WristGrds_Myth";
   diffuseMap[0] = "art/players/base/BaseMale/Mythriel/BM_Vest_Myth1";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_ChestStrap_Myth)
{
   mapTo = "BM_ChestStrap_Myth";
   diffuseMap[0] = "art/players/base/BaseMale/Mythriel/BM_ChestStrap_Myth";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Belt_Myth)
{
   mapTo = "BM_Belt_Myth";
   diffuseMap[0] = "art/players/base/BaseMale/Mythriel/BM_Belt_Myth";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Boots_Myth)
{
   mapTo = "BM_Boots_Myth";
   diffuseMap[0] = "art/players/base/BaseMale/Mythriel/BM_Boots_Myth";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Pants_Myth)
{
   mapTo = "BM_Pants_Myth";
   diffuseMap[0] = "art/players/base/BaseMale/Mythriel/BM_Pants_Myth";
   materialTag0 = "Avatar_BM";
};

//////////////LongSword Holster


singleton Material(matBM_LSHolster_Metal)
{
   mapTo = "LS_Holster_Metal";
   diffuseMap[0] = "art/players/base/BaseMale/Mythriel/LS_Holster_Metal.png";
   materialTag0 = "Avatar_BM";
   translucent = "0";
};

singleton Material(matBM_LSHolster_Leather)
{
   mapTo = "LS_Holster_Leather";
   diffuseMap[0] = "art/players/base/BaseMale/Mythriel/LS_Holster_Leather.png";
   materialTag0 = "Avatar_BM";
};

//////////////////////////////////////TOKARA STUFF/////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////

singleton Material(matBM_Helmet_Tok)
{
   mapTo = "BM_Helmet_Tok";
   diffuseMap[0] = "art/players/base/BaseMale/Tokara/BM_Helmet_Tok";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Poncho_Tok)
{
   mapTo = "BM_Poncho_Tok";
   diffuseMap[0] = "art/players/base/BaseMale/Tokara/BM_Poncho_Tok_Red";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Mocs_Tok)
{
   mapTo = "BM_Mocs_Tok";
   diffuseMap[0] = "art/players/base/BaseMale/Tokara/BM_Mocs_Tok";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_WristGrd_Tok)
{
   mapTo = "BM_WristGrd_Tok";
   diffuseMap[0] = "art/players/base/BaseMale/Tokara/BM_WristGrd_Tok";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Necklace_Tok)
{
   mapTo = "BM_Necklace_Tok";
   diffuseMap[0] = "art/players/base/BaseMale/Tokara/BM_Necklace_Tok_Red";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_LoinCloth_Tok)
{
   mapTo = "BM_LoinCloth_Tok";
   diffuseMap[0] = "art/players/base/BaseMale/Tokara/BM_LoinCloth_Tok_Red";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Sheath_Tok)
{
   mapTo = "BM_Sheath_Tok";
   diffuseMap[0] = "art/players/base/BaseMale/Tokara/BM_Sheath_Tok";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Briefs_Tok)
{
   mapTo = "BM_Briefs_Tok";
   diffuseMap[0] = "art/players/base/BaseMale/Tokara/BM_Briefs_Tok";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_WristGrdMtl_Tok)
{
   mapTo = "BM_WristGrdMtl_Tok";
   diffuseMap[0] = "art/players/base/BaseMale/Tokara/BM_WristGrdMtl_Tok";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_ArmBands_Tok)
{
   mapTo = "BM_ArmBands_Tok";
   diffuseMap[0] = "art/players/base/BaseMale/Tokara/BM_ArmBands_Tok";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_ArmBandsMtl_Tok)
{
   mapTo = "BM_ArmBandsMtl_Tok";
   diffuseMap[0] = "art/players/base/BaseMale/Tokara/BM_WristGrdMtl_Tok";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Belt_Tok)
{
   mapTo = "BM_Belt_Tok";
   diffuseMap[0] = "art/players/base/BaseMale/Tokara/BM_Belt_Tok.png";
   materialTag0 = "Avatar_BM";
};

singleton Material(matBM_Scabbard_Tok)
{
   mapTo = "Scabbard_Tok";
   diffuseMap[0] = "art/inv/weapons/TokSword/Scabbard_Tok";
   materialTag0 = "Avatar_BM";
};


