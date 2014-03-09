
singleton TSShapeConstructor(DTSSequiaDAE)
{
   baseShape = "./DTSSequia.DAE";
   loadLights = "0";
};

function DTSSequiaDAE::onLoad(%this)
{
   %this.addImposter("128", "12", "0", "0", "512", "1", "0");
}
