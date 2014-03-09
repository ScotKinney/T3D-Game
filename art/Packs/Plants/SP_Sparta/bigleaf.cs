
singleton TSShapeConstructor(BigleafDAE)
{
   baseShape = "./bigleaf.DAE";
   loadLights = "0";
};

function BigleafDAE::onLoad(%this)
{
   %this.addImposter("10", "24", "0", "0", "128", "0", "0");
}

function BigleafDae::onLoad(%this)
{
   %this.addImposter("10", "24", "0", "0", "256", "0", "0");
}
