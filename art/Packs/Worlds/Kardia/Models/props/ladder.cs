
singleton TSShapeConstructor(LadderDae)
{
   baseShape = "./ladder.dae";
};

function LadderDae::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.138445 0.162241 109.674 0.00147982 0 0.999999 1.57086", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
