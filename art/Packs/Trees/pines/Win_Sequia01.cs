
singleton TSShapeConstructor(Win_Sequia01DAE)
{
   baseShape = "./Win_Sequia01.DAE";
   loadLights = "0";
};

function Win_Sequia01DAE::onLoad(%this)
{
   %this.addImposter("128", "12", "0", "0", "512", "1", "0");
}
