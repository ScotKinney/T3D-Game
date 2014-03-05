
singleton TSShapeConstructor(MrN_CasketChestDts)
{
   baseShape = "./MrN_CasketChest.dts";
};

function MrN_CasketChestDts::onLoad(%this)
{
   %this.addSequence("./OpenCasketChest.dsq", "OpenCasketChest", "0", "-1", "1", "0");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00432612 -0.0304935 0.213493 0.573991 -0.575496 0.582528 2.07963", "1");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
