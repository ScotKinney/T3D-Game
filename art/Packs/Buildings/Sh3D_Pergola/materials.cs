singleton Material(mat_SVPergTrim)
{
   mapTo = "SVPergolaTrim_dif";
   diffuseMap[0] = "SVPergolaTrim_dif";
   normalMap[0] = "SVPergolaTrim_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(mat_SVPergWall)
{
   mapTo = "SVPergolaWall_dif";
   diffuseMap[0] = "SVPergolaWall_dif";
   normalMap[0] = "SVPergolaWall_nm.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
};
