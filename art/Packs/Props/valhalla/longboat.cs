
singleton TSShapeConstructor(LongboatDae)
{
   baseShape = "./longboat.dae";
   singleDetailSize = "0";
   loadLights = "0";
};

function LongboatDae::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "1", "0");
}
