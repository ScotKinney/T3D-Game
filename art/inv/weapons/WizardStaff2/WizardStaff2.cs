
singleton TSShapeConstructor(WizardStaff2Dts)
{
   baseShape = "./WizardStaff2.dts";
};

function WizardStaff2Dts::onLoad(%this)
{
   %this.addNode("mountpoint", "DamageStart", "0.0160357 0 0.0173363 -0.189146 0.981926 0.00670601 0.977075", "1");
   %this.setNodeTransform("WizardStaff0", "0 0 0 1 0 0 0", "1");
}
