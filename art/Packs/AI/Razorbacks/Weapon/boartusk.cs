
singleton TSShapeConstructor(BoartuskDae)
{
   baseShape = "./boartusk.dae";
   upAxis = "Z_AXIS";
   unit = "0.1";
   loadLights = "0";
};

function BoartuskDae::onLoad(%this)
{
   %this.addNode("muzzlepoint", "S_boartusk", "-0.125093 0 0 1 0 0 0", "1");
   %this.addNode("mountpoint", "S_boartusk", "0.0980549 0 0 1 0 0 0", "1");
}
