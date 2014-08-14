
singleton TSShapeConstructor(WhitePineTestDae)
{
   baseShape = "./whitePineTest.dae";
   lodType = "TrailingNumber";
   loadLights = "0";
};

function WhitePineTestDae::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "256", "0", "0");
}
