
singleton TSShapeConstructor(Raptor_JawDts)
{
   baseShape = "./Raptor_Jaw.dts";
};

function Raptor_JawDts::onLoad(%this)
{
   %this.setNodeParent("mountpoint", "");
   %this.setNodeParent("DamageStart", "mountpoint");
   %this.setNodeTransform("DamageStart", "-0.00095405 -2.26498e-006 -4.25693e-009 -5.98927e-005 0.122935 0.992415 3.14163", "1");
}
