
singleton TSShapeConstructor(InnDae)
{
   baseShape = "./inn.dae";
   unit = "0.1";
   adjustCenter = "1";
   loadLights = "0";
};

singleton TSShapeConstructor(InnDts)
{
   baseShape = "./inn.dts";
};

function InnDts::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "512", "0", "0");
}
