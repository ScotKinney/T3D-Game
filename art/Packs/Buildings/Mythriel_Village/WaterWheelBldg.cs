
singleton TSShapeConstructor(WaterWheelBldgDae)
{
   baseShape = "./WaterWheelBldg.dae";
   unit = "0.05";
   adjustCenter = "1";
   loadLights = "0";
};

function WaterWheelBldgDae::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
