
singleton TSShapeConstructor(Spear_TokDts)
{
   baseShape = "./Spear_Tok.dts";
};

function Spear_TokDts::onLoad(%this)
{
   %this.addNode("TokSpearCol-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.000631249 0.166667 0.00181635 -0.0717969 0.704451 0.706112 3.2647", "0");
   %this.addCollisionDetail("-1", "Box", "Spear_Tok", "4", "30", "30", "32", "30", "30", "30");
}
