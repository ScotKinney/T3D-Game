
singleton TSShapeConstructor(XR75Dae)
{
   baseShape = "./XR75.dts";
};



function XR75Dae::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.0272707 -0.0612657 0.020419 0.0392453 -0.243051 0.969219 0.332421", "1");
}
