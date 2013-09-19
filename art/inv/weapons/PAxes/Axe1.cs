
singleton TSShapeConstructor(Axe1Dts)
{
   baseShape = "./Axe1.dts";
};

function Axe1Dts::onLoad(%this)
{
   %this.setBounds("-0.0378793 -0.0604027 -0.0388064 0.0343903 0.752413 0.404007");
   %this.removeNode("Col9");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00204805 0.361412 0.123588 -0.201541 -0.169367 0.964726 1.61106", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.addNode("mountpoint", "Root", "0.030359 0.085538 0.0575851 0.0446958 -0.958908 -0.280176 1.52757", "1");
}
