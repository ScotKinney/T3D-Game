
singleton TSShapeConstructor(AfricanThornBush_02DAE)
{
   baseShape = "./africanThornBush_02.DAE";
};

function AfricanThornBush_02DAE::onLoad(%this)
{
   %this.setDetailLevelSize("64", "0");
   %this.setDetailLevelSize("128", "32");
   %this.setDetailLevelSize("256", "64");
}
