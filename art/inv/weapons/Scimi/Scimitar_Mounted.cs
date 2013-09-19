
singleton TSShapeConstructor(Scimitar_MountedDts)
{
   baseShape = "./Scimitar_Mounted.dts";
};

function Scimitar_MountedDts::onLoad(%this)
{
   %this.addNode("mountpoint", "Scimitar700", "0 0 0 0 0 1 0", "0");
}
