
singleton TSShapeConstructor(Bananatree_matureDAE)
{
   baseShape = "./bananatree_mature.DAE";
};

function Bananatree_matureDAE::onLoad(%this)
{
   %this.addImposter("0", "24", "0", "0", "256", "0", "0");
}
