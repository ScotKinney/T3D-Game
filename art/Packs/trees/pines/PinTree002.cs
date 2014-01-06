
singleton TSShapeConstructor(PinTree002DAE)
{
   baseShape = "./PinTree002.DAE";
   loadLights = "0";
};

function PinTree002DAE::onLoad(%this)
{
   %this.addImposter("128", "12", "0", "0", "512", "1", "0");
}
