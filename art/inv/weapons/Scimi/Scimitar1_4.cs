
singleton TSShapeConstructor(Scimitar1_4Dts)
{
   baseShape = "./Scimitar1_4.dts";
};

function Scimitar1_4Dts::onLoad(%this)
{
   %this.addNode("mountpoint", "Scimitar0", "0.035018 0.125561 0.028142 0 -1 0 1.58064", "1");
}
