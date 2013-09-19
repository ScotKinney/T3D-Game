
singleton TSShapeConstructor(Medworld_boatDts)
{
   baseShape = "./medworld_boat.dts";
};

function Medworld_boatDts::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "512", "0", "0");
}
