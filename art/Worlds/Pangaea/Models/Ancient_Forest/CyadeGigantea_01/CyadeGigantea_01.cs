
singleton TSShapeConstructor(CyadeGigantea_01DAE)
{
   baseShape = "./CyadeGigantea_01.DAE";
};

function CyadeGigantea_01DAE::onLoad(%this)
{
   %this.addImposter("80", "6", "0", "0", "512", "1", "0");
}
