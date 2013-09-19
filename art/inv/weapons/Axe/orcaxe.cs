
singleton TSShapeConstructor(OrcaxeDts)
{
   baseShape = "./orcaxe.dts";
};

function OrcaxeDts::onLoad(%this)
{
   %this.addNode("mountPoint0", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setBounds("-0.0977399 -0.61701 -0.35037 0.109801 1.73932 0.923946");
   %this.addNode("muzzlepoint", "", "0.00603074 1.29493 0.752023 1 0 0 0", "1");
}
