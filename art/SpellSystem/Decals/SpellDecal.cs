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