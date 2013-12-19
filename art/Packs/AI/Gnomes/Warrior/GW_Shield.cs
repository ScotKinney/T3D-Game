
singleton TSShapeConstructor(GW_ShieldDts)
{
   baseShape = "./GW_Shield.dts";
};

function GW_ShieldDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.0155475 0 0.0500074 -0.340194 -0.87419 -0.346497 0.333962", "1");
}
