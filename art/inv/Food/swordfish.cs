
singleton TSShapeConstructor(SwordfishDts)
{
   baseShape = "./swordfish.dts";
};

function SwordfishDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "SwordFish", "4", "30", "30", "32", "30", "30", "30");
}
