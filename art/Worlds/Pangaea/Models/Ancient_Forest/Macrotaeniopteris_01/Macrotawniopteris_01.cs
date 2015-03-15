
singleton TSShapeConstructor(Macrotawniopteris_01DAE)
{
   baseShape = "./Macrotawniopteris_01.DAE";
   loadLights = "0";
};

function Macrotawniopteris_01DAE::onLoad(%this)
{
   %this.addImposter("100", "6", "0", "0", "512", "1", "0");
}
