
singleton TSShapeConstructor(CecropiaTree01DAE)
{
   baseShape = "./CecropiaTree01.DAE";
};

function CecropiaTree01DAE::onLoad(%this)
{
   %this.setDetailLevelSize("512", "1500");
   %this.setDetailLevelSize("256", "200");
   %this.removeImposter();
   %this.setDetailLevelSize("-2", "199");
}
