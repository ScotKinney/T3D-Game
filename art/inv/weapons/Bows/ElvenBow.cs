
singleton TSShapeConstructor(ElvenBowDts)
{
   baseShape = "./ElvenBow.dts";
};

function ElvenBowDts::onLoad(%this)
{
   %this.addSequence("./FireBow.dsq", "FireBow", "0", "49", "1", "0");
   %this.setNodeParent("Body", "");
   %this.removeNode("Root");
   %this.setNodeTransform("mountPoint", "0.0111654 0.00326181 0.00894045 0.351278 0.7802 -0.517583 0.35493", "1");
}
