
singleton TSShapeConstructor(Lvl3badgeDts)
{
   baseShape = "./lvl3badge.dts";
};

function Lvl3badgeDts::onLoad(%this)
{
   %this.removeImposter();
   %this.renameDetailLevel("detail-1", "collision-1");
   %this.removeDetailLevel("-1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00264413 0.000234772 -0.00788197 0.999976 0.000648114 -0.00693031 3.15641", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "lvl3bdg", "1", "0", "0", "8", "100", "0", "0");
   %this.setBounds("-0.0965576 -0.0121995 -0.141741 0.101846 0.012669 0.125977");
}
