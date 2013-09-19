
singleton TSShapeConstructor(DeadbushDae)
{
   baseShape = "./deadbush.dae";
};

function DeadbushDae::onLoad(%this)
{
   %this.addImposter("35", "4", "0", "0", "256", "0", "60");
}
