
singleton TSShapeConstructor(Brush_WinterDAE)
{
   baseShape = "./Brush_Winter.DAE";
};

function Brush_WinterDAE::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "1", "0");
}
