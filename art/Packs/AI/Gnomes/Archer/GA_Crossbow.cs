
singleton TSShapeConstructor(GA_CrossbowDts)
{
   baseShape = "./GA_Crossbow.dts";
};

function GA_CrossbowDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.00571447 0.00877002 -0.0431157 -0.616179 0.528077 0.584344 2.05684", "1");
   %this.addImposter("0", "4", "0", "0", "256", "0", "0");
}
