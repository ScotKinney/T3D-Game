
singleton Material(mat_WaterFall2)
{
	mapTo = "PMat_WaterFall2";
	diffuseMap[0] = "core/art/transparent.png";
	translucent = 1;
	translucentBlendOp = "LerpAlpha";
	animFlags[0] = "0x00000001";
	scrollDir[0] = "1 0";
	scrollSpeed[0] = "0.353";
   	useAnisotropic[0] = "1";
	materialTag0 = "Props";
};

singleton Material(mat_WaterFall1)
{
	mapTo = "PMat_WaterFall1";
	diffuseMap[0] = "art/Packs/Props/WaterFallWall/scrollingwater.dds";
	translucent = 1;
	translucentBlendOp = "LerpAlpha";
   	animFlags[0] = "0x00000001";
   	scrollDir[0] = "0 -1";
   	scrollSpeed[0] = "0.4";
   	glow[0] = "0";
   	emissive[0] = "1";
   	useAnisotropic[0] = "1";
   	materialTag0 = "Props";
};


