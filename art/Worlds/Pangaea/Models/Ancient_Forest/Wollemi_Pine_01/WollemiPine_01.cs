
singleton TSShapeConstructor(WollemiPine_01DAE)
{
   baseShape = "./WollemiPine_01.DAE";
};

function WollemiPine_01DAE::onLoad(%this)
{
   %this.addImposter("75", "6", "0", "0", "512", "1", "0");
}
