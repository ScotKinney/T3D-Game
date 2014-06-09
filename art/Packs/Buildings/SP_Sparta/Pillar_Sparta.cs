
singleton TSShapeConstructor(Pillar_SpartaDAE)
{
   baseShape = "./Pillar_Sparta.DAE";
   loadLights = "0";
   lodType = "TrailingNumber";
};

function Pillar_SpartaDAE::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
