
singleton TSShapeConstructor(GT_AxeDts)
{
   baseShape = "./GT_Axe.dts";
};


function GT_AxeDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "9.48464e-005 0.0489565 0 0.532714 -0.55503 0.638873 1.94869", "1");
}
