
singleton TSShapeConstructor(WeaponShopDAE)
{
   baseShape = "./WeaponShop.DAE";
   lodType = "TrailingNumber";
   loadLights = "0";
};

function WeaponShopDAE::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "512", "0", "0");
}
