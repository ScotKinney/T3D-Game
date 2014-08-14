
singleton TSShapeConstructor(MapleDae)
{
   baseShape = "./maple.dae";
   upAxis = "Z_AXIS";
   loadLights = "0";
};

function MapleDae::onLoad(%this)
{
   %this.setDetailLevelSize("250", "1500");
   %this.setDetailLevelSize("150", "400");
   %this.setDetailLevelSize("-1", "399");
   %this.addImposter("0", "4", "0", "0", "256", "0", "0");
}
