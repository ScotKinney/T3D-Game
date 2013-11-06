function Bananatree_matureDAE::onLoad(%this)
{
   %this.setNodeTransform("Null", "0.0169041 0.002303 -0.0196898 1 0 0 0", "1");
   %this.removeImposter();
}

singleton TSShapeConstructor(Bananatree_matureDAE)
{
   baseShape = "./bananatree_mature.DAE";
   loadLights = "0";
};
