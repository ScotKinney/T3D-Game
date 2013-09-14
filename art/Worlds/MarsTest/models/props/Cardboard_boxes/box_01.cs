
singleton TSShapeConstructor(Box_01Dae)
{
   baseShape = "./box_01.dae";
   loadLights = "0";
};

function Box_01Dae::onLoad(%this)
{
   %this.setDetailLevelSize("60", "30");
}
