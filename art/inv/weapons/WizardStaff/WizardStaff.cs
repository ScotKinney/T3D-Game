
singleton TSShapeConstructor(WizardStaffDts)
{
   baseShape = "./WizardStaff.dts";
};

function WizardStaffDts::onLoad(%this)
{
   %this.addNode("MountPoint", "DamageEnd", "0.0191623 0 0.0199416 0.0252923 0.0136223 0.999587 1.56047", "1");
   %this.addNode("ParticleMount", "DamageStart", "0 0.897976 0 1 0 0 0", "1");
}
