
singleton TSShapeConstructor(Phila01DAE)
{
   baseShape = "./Phila01.DAE";
};

function Phila01DAE::onLoad(%this)
{
   %this.addImposter("30", "4", "0", "0", "256", "0", "0");
   %this.setDetailLevelSize("128", "200");
   %this.setDetailLevelSize("64", "100");
}
