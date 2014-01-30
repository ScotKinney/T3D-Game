
singleton TSShapeConstructor(ProjectileDts)
{
   baseShape = "./projectile.dts";
};

function ProjectileDts::onLoad(%this)
{
   %this.setNodeTransform("bolt", "0.000144626 -3.81619e-008 0 0 0.707107 0.707107 3.14159", "1");
   %this.setBounds("-0.060119 -0.41183 -0.0602936 0.0604083 0.411829 0.0602417");
   %this.removeDetailLevel("-1");
   %this.removeNode("col-1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "bolt", "4", "30", "30", "32", "30", "30", "30");
}
