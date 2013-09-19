
singleton TSShapeConstructor(BF_Sword_Kard_MtdDts)
{
   baseShape = "./BF_Sword_Kard_Mtd.dts";
};

function BF_Sword_Kard_MtdDts::onLoad(%this)
{
   %this.addNode("mountpoint", "SpartanSword700", "0.00354553 -0.0130578 -0.0972652 1 0 0 0", "1");
}
