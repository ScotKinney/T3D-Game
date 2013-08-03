//**********************************Materials**********************************
singleton Material(ArrowDecalMat)
{
   mapTo = "unmapped_mat";
   diffuseMap[0] = "./arrows.png";
   specularPower[0] = "1";
   glow[0] = "0";
   translucent = "1";
};

//**********************************DecalData**********************************

datablock DecalData(ArrowIndicatorDecalData)
{
   Material = "ArrowDecalMat";
   textureCoordCount = "0";
   size = 3;
};

datablock DecalData(BigArrowIndicatorDecalData : ArrowIndicatorDecalData) { size = 10; };

//****************************SpellDecalManagerData****************************
datablock SpellDecalManagerData(DefaultSpellIndicator)
{
   DecalData = BigArrowIndicatorDecalData;
   PositionType = "Cursor";
};

//******************************DecalIndicatorData*****************************
datablock DecalIndicatorData(DefaultDecalIndicator)
{
   DecalData = ArrowIndicatorDecalData;
};