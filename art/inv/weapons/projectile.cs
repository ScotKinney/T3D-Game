
singleton TSShapeConstructor(ProjectileDts)
{
   baseShape = "./projectile.dts";
};

function ProjectileDts::onLoad(%this)
{
   %this.setNodeTransform("bolt", "0.000144626 -3.81619e-008 0 0 0.707107 0.707107 3.14159", "1");
   %this.setNodeTransform("col-1", "2.92549e-008 -3.81639e-008 0 -0.57735 -0.57735 -0.57735 2.07613", "1");
   %this.setBounds("-0.060119 -0.41183 -0.0602936 0.0604083 0.411829 0.0602417");
}
