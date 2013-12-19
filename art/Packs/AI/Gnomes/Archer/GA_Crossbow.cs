
singleton TSShapeConstructor(GA_CrossbowDts)
{
   baseShape = "./GA_Crossbow.dts";
};

function GA_CrossbowDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.00571447 0.00877002 -0.0431157 -0.560465 0.569192 0.601581 2.17287", "1");
}
