
singleton TSShapeConstructor(HighGrass_01DAE)
{
   baseShape = "./HighGrass_01.DAE";
};

function HighGrass_01DAE::onLoad(%this)
{
   %this.addImposter("150", "6", "0", "0", "512", "0", "0");
}
