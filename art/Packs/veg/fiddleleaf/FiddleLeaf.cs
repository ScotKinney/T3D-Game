
singleton TSShapeConstructor(FiddleLeafDAE)
{
   baseShape = "./FiddleLeaf.DAE";
   loadLights = "0";
};

function FiddleLeafDAE::onLoad(%this)
{
   %this.addImposter("0", "24", "0", "0", "256", "1", "0");
}
