
singleton TSShapeConstructor(MaceDts)
{
   baseShape = "./mace.dts";
};

function MaceDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.0022177 -0.0146009 0 0 0 1 1.01787", "1");
}
