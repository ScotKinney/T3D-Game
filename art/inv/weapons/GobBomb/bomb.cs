
singleton TSShapeConstructor(BombDts)
{
   baseShape = "./bomb.dts";
};

function BombDts::onLoad(%this)
{
   %this.setNodeTransform("mountpoint", "0.0014479 -0.000733018 -0.124446 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColSphere-1", "Col-1", "-0.0954457 -0.050664 0.0449979 1 0 0 0", "0");
   %this.addCollisionDetail("-1", "Sphere", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
