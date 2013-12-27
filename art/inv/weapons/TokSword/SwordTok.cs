
singleton TSShapeConstructor(SwordTokDts)
{
   baseShape = "./SwordTok.dts";
};

function SwordTokDts::onLoad(%this)
{
   %this.addNode("mountpoint", "Sword_Tok0", "0.0163439 -0.0155421 0.0306244 0 -1 0 1.48347", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Sword_Tok", "4", "30", "30", "32", "30", "30", "30");
}
