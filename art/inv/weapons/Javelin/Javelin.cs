
singleton TSShapeConstructor(JavelinDts)
{
   baseShape = "./Javelin.dts";
};

function JavelinDts::onLoad(%this)
{
   %this.setNodeTransform("mountpoint", "0.0353898 0 0.0067921 0.0175887 0.0546386 0.998351 3.35613", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.000256797 -0.155804 0.00474368 -0.991085 -0.0871448 0.100776 1.57473", "0");
   %this.addCollisionDetail("-1", "Box", "Javelin", "4", "30", "30", "32", "30", "30", "30");
}
