//--- DracoFireball.dae MATERIALS BEGIN ---
singleton Material(mat_DracoFireBall)
{
	mapTo = "PMat_DracoFireBall";

	diffuseMap[0] = "core/art/transparent.png";
	normalMap[0] = "";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0 0 0 1";
	specularPower[0] = 8;

	doubleSided = false;
	translucent = "1";
	translucentBlendOp = "LerpAlpha";
   animFlags[0] = "0x00000002";
   rotSpeed[0] = "-0.2";
   castShadows = "0";
};

//--- DracoFireball.dae MATERIALS END ---

