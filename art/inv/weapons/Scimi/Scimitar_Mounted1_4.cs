
singleton TSShapeConstructor(Scimitar_Mounted1_4Dts)
{
   baseShape = "./Scimitar_Mounted1_4.dts";
};

function Scimitar_Mounted1_4Dts::onLoad(%this)
{
   %this.addNode("mountpoint", "Scimitar700", "0 0.0813901 0.0483723 1 0 0 0", "1");
}
