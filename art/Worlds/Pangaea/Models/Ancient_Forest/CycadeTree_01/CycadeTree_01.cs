
singleton TSShapeConstructor(CycadeTree_01DAE)
{
   baseShape = "./CycadeTree_01.DAE";
};

function CycadeTree_01DAE::onLoad(%this)
{
   %this.addImposter("100", "6", "0", "0", "512", "1", "0");
}
