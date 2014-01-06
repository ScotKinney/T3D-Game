
singleton TSShapeConstructor(Canopytree_twoDAE)
{
   baseShape = "./canopytree_two.DAE";
};

function Canopytree_twoDAE::onLoad(%this)
{
   %this.setDetailLevelSize("700", "1500");
   %this.setDetailLevelSize("175", "600");
   %this.addImposter("1", "24", "0", "0", "512", "0", "0");
}

singleton TSShapeConstructor(Canopytree_twoDts)
{
   baseShape = "./canopytree_two.dts";
};

function Canopytree_twoDts::onLoad(%this)
{
   %this.removeNode("EnvironmentAmbientLight");
}
