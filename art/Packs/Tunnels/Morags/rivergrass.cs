
singleton TSShapeConstructor(RivergrassDAE)
{
   baseShape = "./rivergrass.DAE";
   loadLights = "0";
};

function RivergrassDAE::onLoad(%this)
{
   %this.removeImposter();
}
