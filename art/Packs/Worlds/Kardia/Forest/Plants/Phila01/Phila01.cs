
singleton TSShapeConstructor(Phila01DAE)
{
   baseShape = "./Phila01.DAE";
};

function Phila01DAE::onLoad(%this)
{
   %this.addImposter("30", "6", "0", "0", "256", "1", "0");
}
