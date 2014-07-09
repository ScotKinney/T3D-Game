
singleton TSShapeConstructor(EntryLevel1Dae)
{
   baseShape = "./EntryLevel1.dae";
   adjustFloor = "1";
   loadLights = "0";
};

function EntryLevel1Dae::onLoad(%this)
{
   %this.removeMesh("collision-1 -2");
}
