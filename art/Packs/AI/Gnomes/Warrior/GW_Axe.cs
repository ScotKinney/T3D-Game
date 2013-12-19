
singleton TSShapeConstructor(GW_AxeDts)
{
   baseShape = "./GW_Axe.dts";
};

function GW_AxeDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.000825653 -0.00166323 0 0.359399 -0.727741 0.584145 2.08175", "1");
}
