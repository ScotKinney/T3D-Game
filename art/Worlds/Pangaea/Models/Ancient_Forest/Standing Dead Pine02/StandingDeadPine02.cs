
singleton TSShapeConstructor(StandingDeadPine02DAE)
{
   baseShape = "./StandingDeadPine02.DAE";
};

function StandingDeadPine02DAE::onLoad(%this)
{
   %this.addImposter("64", "6", "0", "0", "1024", "1", "0");
}
