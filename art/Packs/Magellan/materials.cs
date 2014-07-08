///////////////////////////////////////
////The Magellan
///////////////////////////////////////


//--- science-labs-DAE.DAE MATERIALS BEGIN ---

singleton Material(mat_AlphaMat)
{
   mapTo = "_1_-_Default";
   diffuseMap[0] = "art/Packs/Magellan/alpha_mat.dds";
   normalMap[0] = "art/Packs/Magellan/alpha_mat_nm.png";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   translucent = "1";
};

singleton Material(mat_misc)
{
   mapTo = "_7_-_Default";
   diffuseMap[0] = "art/Packs/Magellan/misc.dds";
   normalMap[0] = "art/Packs/Magellan/misc_nm.png";
   specularPower[0] = "21";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
};

singleton Material(mat_MagellanWalls)
{
   mapTo = "_8_-_Default";

   diffuseMap[0] = "art/Packs/Magellan/walls.dds";
   normalMap[0] = "art/Packs/Magellan/walls_nm.png";
   castShadows = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "Magellan";
   customFootstepSound = FootStepMetal1Sound;
   specularPower[0] = "39";
   pixelSpecular[0] = "1";
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
