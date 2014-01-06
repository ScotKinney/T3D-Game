
singleton TSShapeConstructor(DeadStandingPine02DAE)
{
   baseShape = "./DeadStandingPine02.DAE";
   loadLights = "0";
};

function DeadStandingPine02DAE::onLoad(%this)
{
   %this.addImposter("64", "12", "0", "0", "512", "1", "0");
}
