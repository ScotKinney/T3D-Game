
singleton TSShapeConstructor(MapleTreeDAE)
{
   baseShape = "./MapleTree.DAE";
   lodType = "TrailingNumber";
   loadLights = "0";
};

function MapleTreeDAE::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "256", "0", "0");
}
