
singleton TSShapeConstructor(SmallCavern001LODDts)
{
   baseShape = "./smallCavern001LOD.dts";
};

function SmallCavern001LODDts::onLoad(%this)
{
   %this.setDetailLevelSize("145", "1000");
   %this.setDetailLevelSize("60", "500");
}
