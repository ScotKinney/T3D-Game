
singleton TSShapeConstructor(ValBuilding6LODDts)
{
   baseShape = "./ValBuilding6LOD.dts";
};

function ValBuilding6LODDts::onLoad(%this)
{
   %this.setDetailLevelSize("2", "150");
   %this.removeImposter();
}
