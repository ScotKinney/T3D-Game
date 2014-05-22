
singleton TSShapeConstructor(Fort_SpartanDAE)
{
   baseShape = "./Fort_Spartan.DAE";
   lodType = "TrailingNumber";
   loadLights = "0";
};

function Fort_SpartanDAE::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "256", "0", "0");
}
