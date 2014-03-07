
// This is the default save location for any TSForestItemData(s) created in the
// Forest Editor Editor (this script is executed from onServerCreated())

datablock TSForestItemData(CanopyTree_01_noVines)
{
   internalName = "CanopyTree_01_noVines";
   shapeFile = "art/packs/trees/Canopy/canopytree_one_novines.dae";
   windScale = "1";
   branchAmp = "0.03";
   detailAmp = "0.05";
   detailFreq = "0.1";
   rigidity = "20";
   trunkBendScale = "0.005";
   radius = "1";
};

datablock TSForestItemData(canopytree_two)
{
   internalName = "canopytree_two";
   shapeFile = "art/packs/trees/Canopy/canopytree_two.dae";
   windScale = "1";
   trunkBendScale = "0.005";
   branchAmp = "0.03";
   detailAmp = "0.07";
   detailFreq = "0.02";
   radius = "1";
};

datablock TSForestItemData(canopytree_three)
{
   internalName = "canopytree_three";
   shapeFile = "art/packs/trees/Canopy/canopytree_three.dae";
   windScale = "1";
   trunkBendScale = "0.005";
   branchAmp = "0.03";
   detailAmp = "0.01";
   detailFreq = "0.01";
   radius = "1";
};

datablock TSForestItemData(PalmTree_Short_01)
{
   internalName = "PalmTree_Short_01";
   shapeFile = "art/packs/trees/palm/palmtree_short.dae";
   branchAmp = "0.1";
   detailAmp = "0.15";
   detailFreq = "0.04";
   trunkBendScale = "0.001";
   mass = "0.5";
   rigidity = "10";
   tightnessCoefficient = "0.2";
   dampingCoefficient = "4";
   windScale = "1";
};

datablock TSForestItemData(palmtree_tall)
{
   internalName = "palmtree_tall";
   shapeFile = "art/packs/trees/palm/palmtree_tall.dae";
   trunkBendScale = "0.005";
   branchAmp = "0.2";
   detailAmp = "0.3";
   detailFreq = "0.02";
   radius = "1.5";
   mass = "2";
   rigidity = "10";
   tightnessCoefficient = "2";
   dampingCoefficient = "1";
   windScale = "1";
};

datablock TSForestItemData(TallPalmLeaning)
{
   internalName = "TallPalmLeaning";
   shapeFile = "art/packs/trees/palm/palmtree_tall_leaning.dae";
   trunkBendScale = "0.005";
   branchAmp = "0.02";
   detailAmp = "0.08";
   detailFreq = "0.15";
   mass = "2";
   tightnessCoefficient = "2";
   dampingCoefficient = "1";
   windScale = "1";
};

datablock TSForestItemData(BananaMature)
{
   internalName = "BananaMature";
   shapeFile = "art/packs/trees/banana/bananatree_mature.DAE";
   radius = "1";
   trunkBendScale = "0.001";
   branchAmp = "0.04";
   detailAmp = "0.04";
   detailFreq = "0.05";
   windScale = "1";
};

datablock TSForestItemData(Bush2)
{
   internalName = "Bush2";
   shapeFile = "art/packs/veg/Bush01/Bush01.DAE";
   windScale = "1";
   branchAmp = "0.02";
   detailAmp = "2";
   detailFreq = "0.05";
};

datablock TSForestItemData(Shrub_Large)
{
   internalName = "Shrub_Large";
   shapeFile = "art/Packs/trees/canopy/shrub_one.DAE";
   collidable = "0";
   radius = "0.5";
   mass = "0.5";
   rigidity = "20";
   tightnessCoefficient = "0.9";
   dampingCoefficient = "0.7";
   windScale = "1";
   trunkBendScale = "0.001";
   branchAmp = "0.4";
   detailAmp = "0.5";
   detailFreq = "0.01";
};

datablock TSForestItemData(BigLeaf_Plant)
{
   internalName = "BigLeaf_Plant";
   shapeFile = "art/packs/veg/bigleaf/bigleaf.dae";
   trunkBendScale = "0.003";
   branchAmp = "10";
   detailAmp = "30";
   detailFreq = "0.003";
   radius = "1";
   mass = "0.5";
   rigidity = "2";
   tightnessCoefficient = "2";
   windScale = "1";
   dampingCoefficient = "10";
};

datablock TSForestItemData(Phila2)
{
   internalName = "Phila2";
   shapeFile = "art/packs/veg/Phila01/Phila01.DAE";
   radius = "0.5";
   windScale = "1";
   branchAmp = "0.02";
   detailAmp = "0.04";
   detailFreq = "0.05";
};

datablock TSForestItemData(TropicFern2)
{
   internalName = "TropicFern2";
   shapeFile = "art/packs/veg/TropicFern/TropicFern01.DAE";
   radius = "0.5";
   windScale = "1";
   branchAmp = "0.02";
   detailAmp = "0.04";
   detailFreq = "0.05";
};

datablock TSForestItemData(rivergrass0)
{
   internalName = "rivergrass0";
   shapeFile = "art/packs/env/groundcover/rivergrass.DAE";
   collidable = "0";
   rigidity = "1";
   windScale = "0.1";
   branchAmp = "1";
   detailAmp = "3";
   detailFreq = "0.05";
   radius = "0.1";
};

datablock TSForestItemData(bigrock01)
{
   internalName = "bigrock01";
   shapeFile = "art/packs/rocks/SP_Rocks/SP_ShortConeRock.dts";
};

datablock TSForestItemData(bigrock03)
{
   internalName = "bigrock03";
   shapeFile = "art/packs/rocks/SP_Rocks/SP_PrismRock1.dts";
};
