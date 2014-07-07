
singleton TSShapeConstructor(AR_CP_castleDae)
{
   baseShape = "./AR_CP_castle.dae";
   unit = "0.05";
   adjustCenter = "1";
   loadLights = "0";
};

function AR_CP_castleDae::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "512", "0", "0");
   %this.setDetailLevelSize("2", "1200");
}
