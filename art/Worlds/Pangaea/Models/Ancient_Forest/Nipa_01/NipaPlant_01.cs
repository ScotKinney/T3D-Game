
singleton TSShapeConstructor(NipaPlant_01DAE)
{
   baseShape = "./NipaPlant_01.DAE";
};

function NipaPlant_01DAE::onLoad(%this)
{
   %this.addImposter("100", "8", "0", "0", "512", "1", "0");
}
