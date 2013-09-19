
singleton TSShapeConstructor(BigleafDAE)
{
   baseShape = "./bigleaf.DAE";
};

function BigleafDAE::onLoad(%this)
{
   %this.addImposter("10", "4", "0", "0", "128", "0", "0");
}
