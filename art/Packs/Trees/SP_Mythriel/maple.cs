
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
   %this.removeImposter();
   %this.setDetailLevelSize("-1", "399");
}
