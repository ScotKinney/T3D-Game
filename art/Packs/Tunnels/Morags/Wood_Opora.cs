
singleton TSShapeConstructor(Wood_OporaDAE)
{
   baseShape = "./Wood_Opora.DAE";
   lodType = "TrailingNumber";
};

function Wood_OporaDAE::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "256", "0", "0");
}
