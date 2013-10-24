singleton Material(MatTLScreen)
{
   mapTo = "TapLink";
   diffuseMap[0] = "#TLScreen";
	specular[0] = "0 0 0 1";
	specularPower[0] = "2";
	emissive [0] = true;
	translucentBlendOp = "None";
};

singleton Material(MatTapLink)
{
   mapTo = "tplink01tex";
   diffuseMap[0] = "art/inv/TapLink/tplink01tex.jpg";
};
