
singleton TSShapeConstructor(DeadStandingPine01DAE)
{
   baseShape = "./DeadStandingPine01.DAE";
   loadLights = "0";
};

function DeadStandingPine01DAE::onLoad(%this)
{
   %this.addImposter("0", "12", "0", "0", "512", "1", "0");
}
