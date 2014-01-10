
singleton TSShapeConstructor(Win_Sequia02DAE)
{
   baseShape = "./Win_Sequia02.DAE";
   loadLights = "0";
};

function Win_Sequia02DAE::onLoad(%this)
{
   %this.addImposter("128", "12", "0", "0", "512", "1", "0");
}
