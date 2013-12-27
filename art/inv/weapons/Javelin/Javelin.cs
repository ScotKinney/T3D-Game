
singleton TSShapeConstructor(JavelinDts)
{
   baseShape = "./Javelin.dts";
};

function JavelinDts::onLoad(%this)
{
   %this.setNodeTransform("mountpoint", "0.0353898 0 0.0067921 0.0175887 0.0546386 0.998351 3.35613", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Javelin", "4", "30", "30", "32", "30", "30", "30");
}
