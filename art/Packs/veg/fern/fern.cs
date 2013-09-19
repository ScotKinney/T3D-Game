
singleton TSShapeConstructor(FernDAE)
{
   baseShape = "./fern.DAE";
};

function FernDAE::onLoad(%this)
{
   %this.addImposter("10", "4", "0", "0", "128", "0", "0");
}
