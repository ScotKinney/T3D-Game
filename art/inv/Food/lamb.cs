
singleton TSShapeConstructor(LambDts)
{
   baseShape = "./lamb.dts";
};

function LambDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0480418 -0.000872761 0.268786 0.836618 -0.0669108 0.543684 3.118", "0");
   %this.addNode("ColBoxB-1", "Col-1", "0.0205241 0.0422178 0.567474 8.93357e-009 -1 -6.98995e-009 1.5708", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "def_surf_mat", "1", "60", "0", "64", "69.1489", "62.766", "44.6809");
   %this.removeMesh("ColBoxB -1");
}
