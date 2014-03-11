
singleton TSShapeConstructor(Bananatree_matureDAE)
{
   baseShape = "./bananatree_mature.DAE";
   loadLights = "0";
};

function Bananatree_matureDAE::onLoad(%this)
{
   %this.addImposter("0", "24", "0", "0", "256", "0", "0");
   %this.setNodeTransform("Null", "0.0169041 0.002303 -0.0196898 1 0 0 0", "1");
}
