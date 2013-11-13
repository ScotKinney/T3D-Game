
singleton TSShapeConstructor(TunnelSection001Nx4WDErailsDts)
{
   baseShape = "./tunnelSection001Nx4WDErails.dts";
};

function TunnelSection001Nx4WDErailsDts::onLoad(%this)
{
   %this.setDetailLevelSize("60", "1000");
   %this.setDetailLevelSize("30", "500");
}
