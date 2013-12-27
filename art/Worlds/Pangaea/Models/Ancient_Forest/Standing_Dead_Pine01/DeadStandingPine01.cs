
singleton TSShapeConstructor(DeadStandingPine01DAE)
{
   baseShape = "./DeadStandingPine01.DAE";
};

function DeadStandingPine01DAE::onLoad(%this)
{
   %this.addImposter("128", "6", "0", "0", "1024", "1", "0");
}
