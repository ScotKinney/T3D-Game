
singleton TSShapeConstructor(Longleaf_plantDAE)
{
   baseShape = "./longleaf_plant.DAE";
};

function Longleaf_plantDAE::onLoad(%this)
{
   %this.addImposter("35", "4", "0", "0", "256", "0", "0");
}
