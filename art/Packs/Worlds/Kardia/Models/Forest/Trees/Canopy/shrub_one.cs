
singleton TSShapeConstructor(Shrub_oneDAE)
{
   baseShape = "./shrub_one.DAE";
};

function Shrub_oneDAE::onLoad(%this)
{
   %this.setDetailLevelSize("300", "400");
   %this.addImposter("1", "4", "0", "0", "256", "0", "0");
}
