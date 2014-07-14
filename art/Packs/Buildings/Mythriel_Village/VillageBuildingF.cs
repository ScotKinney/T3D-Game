
singleton TSShapeConstructor(VillageBuildingFDts)
{
   baseShape = "./VillageBuildingF.dts";
};

function VillageBuildingFDts::onLoad(%this)
{
   %this.setDetailLevelSize("1500", "2500");
   %this.setDetailLevelSize("1000", "2000");
   %this.setDetailLevelSize("500", "400");
   %this.setDetailLevelSize("2000", "500");
}
