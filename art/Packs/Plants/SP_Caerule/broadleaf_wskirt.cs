
singleton TSShapeConstructor(Broadleaf_wskirtDAE)
{
   baseShape = "./broadleaf_wskirt.DAE";
   loadLights = "0";
};

function Broadleaf_wskirtDAE::onLoad(%this)
{
   %this.addImposter("35", "24", "0", "0", "256", "0", "0");
}
