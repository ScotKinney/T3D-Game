
singleton TSShapeConstructor(Bigrock01Dts)
{
   baseShape = "./bigrock01.dts";
};

function Bigrock01Dts::onLoad(%this)
{
   %this.removeImposter();
}
