
singleton TSShapeConstructor(BoglinShieldDts)
{
   baseShape = "./BoglinShield.dts";
};

function BoglinShieldDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.0338211 -0.0999022 0.0819859 -0.589302 -0.217195 0.77817 1.04443", "1");
}
