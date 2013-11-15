
singleton TSShapeConstructor(ClubDts)
{
   baseShape = "./club.dts";
};

function ClubDts::onLoad(%this)
{
   %this.setNodeTransform("mountpoint", "0 0 0 1 0 0 0", "1");
   %this.renameNode("mountpoint", "mp");
   %this.addNode("mountpoint", "mp", "0.0551138 -0.0858085 0 0.286917 -0.026452 0.95759 2.58114", "1");
}
