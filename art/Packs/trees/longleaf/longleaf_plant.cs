
singleton TSShapeConstructor(Longleaf_plantDAE)
{
   baseShape = "./longleaf_plant.DAE";
   loadLights = "0";
};

function Longleaf_plantDAE::onLoad(%this)
{
   %this.addImposter("0", "24", "0", "0", "256", "0", "0");
}
