
singleton TSShapeConstructor(TunnelSection001Nx3WwVShoistDts)
{
   baseShape = "./tunnelSection001Nx3WwVShoist.dts";
};

function TunnelSection001Nx3WwVShoistDts::onLoad(%this)
{
   %this.setDetailLevelSize("100", "1000");
   %this.setDetailLevelSize("30", "500");
}
