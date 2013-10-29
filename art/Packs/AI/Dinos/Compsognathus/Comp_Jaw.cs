
singleton TSShapeConstructor(Comp_JawDts)
{
   baseShape = "./Comp_Jaw.dts";
};

function Comp_JawDts::onLoad(%this)
{
   %this.setNodeParent("mountpoint", "");
   %this.setNodeParent("DamageStart", "mountpoint");
   %this.setNodeTransform("DamageStart", "-0.000987752 -2.5332e-007 3.60807e-015 0 0 1 3.14141", "1");
}
