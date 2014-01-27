
singleton TSShapeConstructor(PirateSwordDts)
{
   baseShape = "./PirateSword.dts";
};

function PirateSwordDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.0248786 -0.0080216 -0.0102928 0 1 0 3.20551", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00427702 0.524384 0.000205737 0.575103 -0.577505 0.579435 2.09416", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
