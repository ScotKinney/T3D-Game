////////////////////////////////////
/// Mediteranian village structures
////////////////////////////////////

singleton Material(mat_medhouse6)
{
   mapTo = "medhouse6";
   diffuseMap[0] = "medhouse6";
   normalMap[0] = "medhouse6_NRM.jpg";
   specular[0] = "0.909804 0.909804 0.909804 1";
   specularPower[0] = "21";
   pixelSpecular[0] = "1";
   materialTag0 = "MedCity";
   customFootstepSound = FootSteprock1Sound;
};

singleton Material(mat_medhouse18)
{
   mapTo = "medhouse18";
   diffuseMap[0] = "medhouse18";
   normalMap[0] = "medhouse6_NRM.jpg";
   specular[0] = "0.909804 0.909804 0.909804 1";
   specularPower[0] = "21";
   pixelSpecular[0] = "0";
   materialTag0 = "MedCity";
   customFootstepSound = FootSteprock1Sound;
};

singleton Material(mat_newroof)
{
   mapTo = "newroof";
   diffuseMap[0] = "newroof";
   normalMap[0] = "newroof_NRM.jpg";
   specularPower[0] = "61";
   pixelSpecular[0] = "1";
   materialTag0 = "MedCity";
   useAnisotropic[0] = "1";
};

singleton Material(mat_medhouse17)
{
   mapTo = "medhouse17";
   diffuseMap[0] = "medhouse17";
   materialTag0 = "MedCity";
   customFootstepSound = FootSteprock1Sound;
};

singleton Material(mat_medbuilding_tex1)
{
   mapTo = "medbuilding_tex1";
   diffuseMap[0] = "medbuilding_tex1.dds";
   normalMap[0] = "medbuilding_tex1_NRM.jpg";
   specular[0] = "0.741176 0.741176 0.741176 1";
   specularPower[0] = "76";
   pixelSpecular[0] = "1";
   materialTag0 = "MedCity";
   customFootstepSound = FootSteprock1Sound;
   useAnisotropic[0] = "1";
};

singleton Material(mat_medbuilding_tex2)
{
   mapTo = "medbuilding_tex2";
   diffuseMap[0] = "medbuilding_tex2";
   normalMap[0] = "";
   specular[0] = "0.713726 0.713726 0.713726 1";
   specularPower[0] = "61";
   pixelSpecular[0] = "1";
   materialTag0 = "MedCity";
   customFootstepSound = FootSteprock1Sound;
};

singleton Material(mat_medhouse12)
{
   mapTo = "medhouse12";
   diffuseMap[0] = "medhouse12";
   materialTag0 = "MedCity";
   customFootstepSound = FootSteprock1Sound;
};

new Material(mat_medcity_interiors)
{
   mapTo = "medcity_interiors";
   diffuseMap[0] = "medcity_interiors";
   normalMap[0] = "medcity_interiors_NRM";
   translucent[0] = false;
   pixelSpecular[0] = true;
   specular[0] = "0.1 0.1 0.1 1.0";
   specularPower[0] = 32.0;
   customFootstepSound = FootSteprock1Sound;
   materialTag0 = "MedCity";
   useAnisotropic[0] = "1";
};

new Material(mat_inn)
{
   mapTo = "inn";
   diffuseMap[0] = "inn";
   translucent[0] = false;
   pixelSpecular[0] = true;
   specular[0] = "0.1 0.1 0.1 1.0";
   specularPower[0] = 32.0;
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "MedCity";
   useAnisotropic[0] = "1";
};

singleton Material(mat_inn_interior_ceiling)
{
   mapTo = "inn_interior_ceiling";
   diffuseMap[0] = "inn_interior_ceiling";
   customFootstepSound = "FootStepWood1Sound";
   useAnisotropic[0] = "1";
   specular[0] = "0.1 0.1 0.1 1";
   specularPower[0] = "32";
   translucent[0] = false;
   pixelSpecular[0] = "1";
   materialTag0 = "MedCity";
};

new Material(mat_medhouse1)
{
   mapTo = "medhouse1";
   diffuseMap[0] = "medhouse1";
   normalMap[0] = "medhouse1_NRM";
   translucent[0] = false;
   pixelSpecular[0] = true;
   specular[0] = "0.1 0.1 0.1 1.0";
   specularPower[0] = 32.0;
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "MedCity";
};

singleton Material(inn_ext)
{
   mapTo = "inn_ext";
   diffuseMap[0] = "inn";
   specular[0] = "0.82 0.83 0.87 1";
   specularPower[0] = "100";
   translucent = "1";
};

singleton Material(mat_StoneFloor)
{
   mapTo = "stone_floor";
   diffuseMap[0] = "stone_floor";
   useAnisotropic[0] = "1";
   translucent = "0";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "MedCity";
};

new Material(mat_inn_wood)
{
   mapTo = "inn_wood";
   diffuseMap[0] = "inn_wood.dds";
   translucent[0] = false;
   pixelSpecular[0] = true;
   specular[0] = "0.1 0.1 0.1 1.0";
   specularPower[0] = 32.0;
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "MedCity";
   useAnisotropic[0] = "1";
};
