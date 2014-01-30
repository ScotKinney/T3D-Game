
singleton TSShapeConstructor(WizardsStaffDts)
{
   baseShape = "./WizardsStaff.dts";
};

function WizardsStaffDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "WizardAStaff", "4", "30", "30", "32", "30", "30", "30");

}
