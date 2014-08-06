
singleton TSShapeConstructor(MercantileDae)
{
   baseShape = "./Mercantile.dae";
   unit = "0.00035";
   lodType = "TrailingNumber";
   loadLights = "0";
};

function MercantileDae::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "512", "0", "0");
}
