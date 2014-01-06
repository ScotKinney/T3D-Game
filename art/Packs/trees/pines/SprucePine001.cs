
singleton TSShapeConstructor(SprucePine001DAE)
{
   baseShape = "./SprucePine001.DAE";
   loadLights = "0";
};

function SprucePine001DAE::onLoad(%this)
{
   %this.addImposter("128", "12", "0", "0", "512", "1", "0");
}
