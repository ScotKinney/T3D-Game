
singleton TSShapeConstructor(CopalTree01DAE)
{
   baseShape = "./CopalTree01.DAE";
   loadLights = "0";
};

function CopalTree01DAE::onLoad(%this)
{
   %this.setDetailLevelSize("256", "500");
   %this.removeImposter();
   %this.setDetailLevelSize("-2", "199");
}
