
singleton TSShapeConstructor(BaseWeed_01DAE)
{
   baseShape = "./BaseWeed_01.DAE";
};

function BaseWeed_01DAE::onLoad(%this)
{
   %this.addImposter("200", "6", "0", "0", "512", "1", "0");
}
