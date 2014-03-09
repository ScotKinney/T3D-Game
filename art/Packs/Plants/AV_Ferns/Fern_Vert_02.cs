
singleton TSShapeConstructor(Fern_Vert_02DAE)
{
   baseShape = "./Fern_Vert_02.DAE";
   loadLights = "0";
};

function Fern_Vert_02DAE::onLoad(%this)
{
   %this.addImposter("0", "24", "0", "0", "256", "0", "0");
}
