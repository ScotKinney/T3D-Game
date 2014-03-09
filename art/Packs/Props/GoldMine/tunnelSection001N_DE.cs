
singleton TSShapeConstructor(TunnelSection001N_DEDts)
{
   baseShape = "./tunnelSection001N_DE.dts";
};

function TunnelSection001N_DEDts::onLoad(%this)
{
   %this.setDetailLevelSize("60", "1000");
   %this.setDetailLevelSize("30", "500");
}
