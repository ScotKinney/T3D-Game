
singleton TSShapeConstructor(Sword_ValDts)
{
   baseShape = "./Sword_Val.dts";
};

function Sword_ValDts::onLoad(%this)
{
   %this.addNode("mountpoint", "Sword_Val0", "-0.02 -0.06 -0.06 -0.146203 0.965143 0.217081 1.7969", "0");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Sword_Val", "4", "30", "30", "32", "30", "30", "30");
}
