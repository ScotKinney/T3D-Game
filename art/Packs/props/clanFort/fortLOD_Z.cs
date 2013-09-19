
singleton TSShapeConstructor(FortLOD_ZDae)
{
   baseShape = "./fortLOD_Z.dae";
   unit = "1";
   loadLights = "0";
};

function FortLOD_ZDae::onLoad(%this)
{
   %this.setDetailLevelSize("2", "300");
   %this.addImposter("0", "6", "0", "0", "256", "0", "0");
}
