
singleton TSShapeConstructor(DeadStandingPine02DAE)
{
   baseShape = "./DeadStandingPine02.DAE";
};

function DeadStandingPine02DAE::onLoad(%this)
{
   %this.addImposter("64", "6", "0", "0", "128", "1", "0");
}
