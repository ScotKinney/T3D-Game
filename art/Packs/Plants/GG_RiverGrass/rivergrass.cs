
singleton TSShapeConstructor(RivergrassDAE)
{
   baseShape = "./rivergrass.DAE";
};

function RivergrassDAE::onLoad(%this)
{
   %this.addImposter("65", "24", "0", "0", "256", "0", "60");
}
