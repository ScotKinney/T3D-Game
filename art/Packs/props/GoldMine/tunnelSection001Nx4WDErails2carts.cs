
singleton TSShapeConstructor(TunnelSection001Nx4WDErails2cartsDts)
{
   baseShape = "./tunnelSection001Nx4WDErails2carts.dts";
};

function TunnelSection001Nx4WDErails2cartsDts::onLoad(%this)
{
   %this.setDetailLevelSize("60", "500");
   %this.setDetailLevelSize("30", "100");
}
