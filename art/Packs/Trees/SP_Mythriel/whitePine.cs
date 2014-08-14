
singleton TSShapeConstructor(WhitePineDae)
{
   baseShape = "./whitePine.dae";
   upAxis = "Z_AXIS";
   loadLights = "0";
};

function WhitePineDae::onLoad(%this)
{
   %this.setDetailLevelSize("300", "1500");
   %this.setDetailLevelSize("150", "400");
   %this.setDetailLevelSize("-1", "399");
   %this.addImposter("0", "4", "0", "0", "256", "0", "0");
}
