
singleton TSShapeConstructor(WeaponDts)
{
   baseShape = "./weapon.dts";
};

function WeaponDts::onLoad(%this)
{
   %this.removeDetailLevel("-1");
   %this.removeNode("col-1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBoxF-1", "Col-1", "0.181208 0.768449 0.334373 0.970369 -0.170612 0.171102 1.60374", "0");
   %this.addNode("ColBoxI-1", "Col-1", "-0.180909 0.768397 0.334363 0.123899 -0.700651 0.702664 2.89575", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   //%this.addNode("muzzlepoint", "", "0 0.992132 0.247449 1 0 0 0", "1");
   %this.addNode("muzzlepoint", "", "0 .5 0 1 0 0 0", "1");
   %this.addNode("mountpoint", "Col-1", "0.0423975 -0.0321459 -0.0264124 -0.447134 -0.815674 -0.36708 1.68438", "1");
}
