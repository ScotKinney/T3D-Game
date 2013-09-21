singleton Material(base)
{
   mapTo = "base.horse";
   diffuseMap[0] = "base.horse";
};

singleton Material(arabian)
{
   mapTo = "arabian.horse";
   diffuseMap[0] = "arabian.horse";
};

singleton Material(bay)
{
   mapTo = "bay.horse";
   diffuseMap[0] = "bay.horse";
};

singleton Material(indian)
{
   mapTo = "indian.horse";
   diffuseMap[0] = "indian.horse";
};

singleton Material(light)
{
   mapTo = "light.horse";
   diffuseMap[0] = "light.horse";
};

singleton Material(mustang)
{
   mapTo = "mustang.horse";
   diffuseMap[0] = "mustang.horse";
};

singleton Material(palimino)
{
   mapTo = "palimino.horse";
   diffuseMap[0] = "palimino.horse";
};

new Material(HorseFootprintMaterial)
{
   diffuseMap[0] = "hoofprint";
   vertColor[0] = true;
   translucent = true;
   castShadows = "0";
   translucentZWrite = "1";
};

