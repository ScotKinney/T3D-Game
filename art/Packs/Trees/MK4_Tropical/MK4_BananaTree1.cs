
singleton TSShapeConstructor(MK4_BananaTree1DAE)
{
   baseShape = "./MK4_BananaTree1.DAE";
   unit = ".1";
   loadLights = "0";
   lodType = "TrailingNumber";
};

function MK4_BananaTree1DAE::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
