
singleton TSShapeConstructor(Sword_ValDts)
{
   baseShape = "./Sword_Val.dts";
};

function Sword_ValDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00487002 0.591069 0.216226 -0.188926 -0.171167 0.966958 1.60049", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.addNode("mountpoint", "Sword_Val0", "0 0 0.0570242 -0.258332 0.934674 0.244232 1.73082", "1");
}
