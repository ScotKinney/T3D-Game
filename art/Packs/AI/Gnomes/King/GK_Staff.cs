
singleton TSShapeConstructor(GK_StaffDts)
{
   baseShape = "./GK_Staff.dts";
};

function GK_StaffDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.000311356 -0.00301979 0 0.603607 -0.551017 0.576228 2.00346", "1");
}
