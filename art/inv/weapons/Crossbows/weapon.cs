
singleton TSShapeConstructor(WeaponDts)
{
   baseShape = "./weapon.dts";
};

function WeaponDts::onLoad(%this)
{
   %this.removeDetailLevel("-1");
   %this.removeNode("col-1");
   %this.addNode("muzzlepoint", "", "0 0.5 0 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.addNode("mountPoint", "", "0 -0.0192755 -0.0545249 -0.59608 -0.566689 -0.568816 2.04295", "1");
}
