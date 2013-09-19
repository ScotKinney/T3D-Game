
singleton TSShapeConstructor(BugClawDts)
{
   baseShape = "./BugClaw.dts";
};

function BugClawDts::onLoad(%this)
{
   %this.addNode("mountpoint", "BugClaw0", "0 0 0 0 0 1 0", "0");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.117018 -0.497027 -0.322096 0.52051 0.829773 -0.20136 3.57915", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
