
singleton TSShapeConstructor(Broadleaf_wskirtDAE)
{
   baseShape = "./broadleaf_wskirt.DAE";
};

function Broadleaf_wskirtDAE::onLoad(%this)
{
   %this.addImposter("35", "4", "0", "0", "128", "0", "0");
}
