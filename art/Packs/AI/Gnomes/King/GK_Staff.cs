
singleton TSShapeConstructor(GK_StaffDts)
{
   baseShape = "./GK_Staff.dts";
};

function GK_StaffDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.000311356 -0.00301979 0 0.597497 -0.571703 0.562275 2.10979", "1");
   %this.setNodeTransform("Root", "0 0 0 1 0 0 0", "1");
}
