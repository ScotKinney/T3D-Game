
singleton TSShapeConstructor(ValBuilding5LODDts)
{
   baseShape = "./ValBuilding5LOD.dts";
};

function ValBuilding5LODDts::onLoad(%this)
{
   %this.removeImposter();
}
