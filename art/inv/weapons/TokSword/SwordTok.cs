
singleton TSShapeConstructor(SwordTokDts)
{
   baseShape = "./SwordTok.dts";
};

function SwordTokDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00342927 0.526284 0.175693 -0.205178 -0.170752 0.963714 1.60292", "0");
   %this.addCollisionDetail("-1", "Box", "Sword_Tok", "4", "30", "30", "32", "30", "30", "30");
   %this.addNode("mountpoint", "Sword_Tok0", "0.0163439 -0.0155421 0.0306244 0 -1 0 1.48347", "1");
}
