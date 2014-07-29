
singleton TSShapeConstructor(MrN_AshTreeDAE)
{
   baseShape = "./MrN_AshTree.DAE";
   lodType = "TrailingNumber";
   loadLights = "0";
};

function MrN_AshTreeDAE::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "256", "0", "0");
}
