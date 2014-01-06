
singleton TSShapeConstructor(DeadbushDae)
{
   baseShape = "./deadbush.dae";
   loadLights = "0";
};

function DeadbushDae::onLoad(%this)
{
   %this.addImposter("35", "24", "0", "0", "256", "0", "60");
}
