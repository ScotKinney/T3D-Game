
singleton TSShapeConstructor(DracofireballDae)
{
   baseShape = "./dracofireball.dae";
};

function DracofireballDae::onLoad(%this)
{
   %this.setNodeTransform("S_DracoFireBall", "0 0 0 1 0 0 0", "1");
   %this.addNode("mountpoint", "S_DracoFireBall", "0 0.0545561 0 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.000195036 0.0547706 -0.000728158 0.480747 -0.868945 0.117548 1.1729", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.removeMesh("ColBox -1");
   %this.addNode("muzzlepoint", "S_DracoFireBall", "0 0.0547222 0 -1 0 0 1.13019", "1");
}
