
singleton TSShapeConstructor(UmbrellaAcaciaFul_01Dae)
{
   baseShape = "./umbrellaAcaciaFul_01.dae";
   unit = ".0256";
   lodType = "TrailingNumber";
   loadLights = "0";
};

function UmbrellaAcaciaFul_01Dae::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "256", "0", "0");
}
