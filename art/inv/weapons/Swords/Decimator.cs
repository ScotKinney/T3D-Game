
singleton TSShapeConstructor(DecimatorDts)
{
   baseShape = "./Decimator.dts";
};

function DecimatorDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColCapsule-1", "Col-1", "4.06277e-006 0.771059 -1.77011e-005 0.70711 7.68538e-006 0.707104 3.14162", "0");
   %this.addCollisionDetail("-1", "Capsule", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
