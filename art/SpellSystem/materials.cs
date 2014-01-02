//**********************************Materials**********************************
singleton Material(ArrowDecalMat)
{
   mapTo = "unmapped_mat";
   diffuseMap[0] = "./Decals/arrows.png";
   specularPower[0] = "1";
   glow[0] = "0";
   translucent = "1";
};

singleton Material(BastardBolt0_Mat)
{
   mapTo = "unmapped_mat";
   diffuseMap[0] = "./ParticleTextures/bastardbolt0.png";
   glow[0] = "1";
   emissive[0] = "1";
};

singleton Material(BastardBolt1_Mat)
{
   mapTo = "unmapped_mat";
   diffuseMap[0] = "./ParticleTextures/bastardbolt1.png";
   glow[0] = "1";
   emissive[0] = "1";
};