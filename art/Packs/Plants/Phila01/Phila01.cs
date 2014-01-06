
singleton TSShapeConstructor(Phila01DAE)
{
   baseShape = "./Phila01.DAE";
};

function Phila01DAE::onLoad(%this)
{
   %this.addImposter("0", "24", "0", "0", "256", "0", "0");
}
