
singleton TSShapeConstructor(SharksteakDts)
{
   baseShape = "./sharksteak.dts";
};

function SharksteakDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColCapsule-1", "Col-1", "-3.75671e-006 0.00131207 0.025722 0.000939851 0.00434021 0.99999 1.57421", "0");
   %this.addCollisionDetail("-1", "Capsule", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
