
singleton TSShapeConstructor(GT_AxeDts)
{
   baseShape = "./GT_Axe.dts";
};


function GT_AxeDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "9.48464e-005 0.0489565 0 0.532714 -0.55503 0.638873 1.94869", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0783618 0.296388 0.00359799 -0.995321 -0.0863024 -0.0434414 1.58445", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
