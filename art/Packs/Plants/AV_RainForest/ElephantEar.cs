
singleton TSShapeConstructor(ElephantEarDAE)
{
   baseShape = "./ElephantEar.DAE";
};

function ElephantEarDAE::onLoad(%this)
{
   %this.addImposter("64", "6", "0", "0", "128", "1", "0");
}
