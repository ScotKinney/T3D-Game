
singleton TSShapeConstructor(SP_MK4_Rock2Dts)
{
   baseShape = "./SP_MK4_Rock2.dts";
};

function SP_MK4_Rock2Dts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "18-DOP", "Bounds", "4", "30", "16.5957", "32", "30", "30", "30");
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
