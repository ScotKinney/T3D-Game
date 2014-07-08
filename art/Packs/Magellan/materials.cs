///////////////////////////////////////
////The Magellan
///////////////////////////////////////


//--- science-labs-DAE.DAE MATERIALS BEGIN ---
singleton Material(mat_MagellanAlpha)
{
   mapTo = "_1_-_Default";

   diffuseMap[0] = "alpha_mat.dds";
   translucent = 1;
   //translucentBlendOp = "LerpAlpha";
   //translucentZWrite = "1";
   //alphaTest = "1";
   //alphaRef = "161";
   castShadows = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "Magellan";
   customFootstepSound = FootStepMetal1Sound;
   normalMap[0] = "alpha_matN.dds";
};

singleton Material(mat_MagellanMisc)
{
   mapTo = "_7_-_Default";

   diffuseMap[0] = "misc.dds";
   specularMap[0] = "";

   diffuseColor[0] = "1 1 1 1";
   specular[0] = "0 0.835294 1 1";
   specularPower[0] = "54";

   doubleSided = false;
   translucent = false;
   translucentBlendOp = "None";
   customFootstepSound = FootStepMetal1Sound;
   emissive[0] = "0";
   detailMap[0] = "";
   detailScale[0] = "5 5";
   subSurface[0] = "0";
   materialTag0 = "Magellan";
   pixelSpecular[0] = "0";
   alphaRef = "1";
   useAnisotropic[0] = "1";
};

singleton Material(mat_MagellanWalls)
{
   mapTo = "_8_-_Default";
   diffuseMap[0] = "walls.dds";
   normalMap[0] = "wallsN.dds";
   materialTag0 = "Magellan";
   customFootstepSound = FootStepMetal1Sound;
   useAnisotropic[0] = "1";
};

singleton Material(Mat_TeleporterSign1)
{
   mapTo = "PMat_TeleporterSign1";
   diffuseMap[0] = "teleports.png";
   materialTag0 = "Magellan";
};

singleton Material(Mat_srf4)
{
   mapTo = "PMat_srf4";
   diffuseMap[0] = "teleportsSmallDown.png";
   materialTag0 = "Magellan";
};

singleton Material(Mat_srf3)
{
   mapTo = "PMat_srf3";
   diffuseMap[0] = "teleportsSmallDown.png";
   materialTag0 = "Magellan";
};

singleton Material(Mat_srf2)
{
   mapTo = "PMat_srf2";
   diffuseMap[0] = "teleportsSmallDown.png";
   materialTag0 = "Magellan";
};

singleton Material(Mat_srf1)
{
   mapTo = "PMat_srf1";
   diffuseMap[0] = "teleportsSmallDown.png";
   materialTag0 = "Magellan";
};

singleton Material(Mat_tpSignLeft4)
{
   mapTo = "PMat_tpSignLeft4";
   diffuseMap[0] = "teleportsSmallLeft.png";
   materialTag0 = "Magellan";
};

singleton Material(Mat_tpSignLeft3)
{
   mapTo = "PMat_tpSignLeft3";
   diffuseMap[0] = "teleportsSmallLeft.png";
   materialTag0 = "Magellan";
};

singleton Material(Mat_tpSignLeft2)
{
   mapTo = "PMat_tpSignLeft2";
   diffuseMap[0] = "teleportsSmallLeft.png";
   materialTag0 = "Magellan";
};

singleton Material(Mat_tpSignLeft1)
{
   mapTo = "PMat_tpSignLeft1";
   diffuseMap[0] = "teleportsSmallLeft.png";
   materialTag0 = "Magellan";
};

singleton Material(mat_pathway_b)
{
   mapTo = "pathway_b";
   diffuseMap[0] = "core/art/transparent.png";
   translucent = "1";
   materialTag0 = "Magellan";
};

singleton Material(mat_pathway_a)
{
   mapTo = "pathway_a";
   diffuseMap[0] = "core/art/transparent.png";
   translucent = "1";
   specularPower[0] = "1";
   castShadows = "0";
   materialTag0 = "Magellan";
};

singleton Material(mat_column2_d)
{
   mapTo = "column2_d";
   diffuseMap[0] = "column2_d.png";
   normalMap[0] = "column2_n.png";
   materialTag0 = "Magellan";
};
