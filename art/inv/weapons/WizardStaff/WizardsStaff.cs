
singleton TSShapeConstructor(WizardsStaffDts)
{
   baseShape = "./WizardsStaff.dts";
};

function WizardsStaffDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColCapsule-1", "Col-1", "-0.00882868 0.0975592 0.0144079 0.884491 -0.0155118 0.4663 3.21237", "0");
   %this.addCollisionDetail("-1", "Capsule", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
