new Material(mat_medcity_interiors)
{
   mapTo = "medcity_interiors";
   diffuseMap[0] = "medcity_interiors";
   normalMap[0] = "medcity_interiors_NRM";
   translucent[0] = false;
   pixelSpecular[0] = true;
   specular[0] = "0.1 0.1 0.1 1.0";
   specularPower[0] = 32.0;
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "Tortuga_Bldgs";
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
   materialTag0 = "Tortuga_Bldgs";
   useAnisotropic[0] = "1";
   normalMap[0] = "inn_nm.dds";
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
   materialTag0 = "Tortuga_Bldgs";
};

singleton Material(mat_StoneFloor)
{
   mapTo = "stone_floor";
   diffuseMap[0] = "stone_floor";
   useAnisotropic[0] = "1";
   translucent = "0";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "Tortuga_Bldgs";
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
   materialTag0 = "Tortuga_Bldgs";
   useAnisotropic[0] = "1";
};

singleton Material(mat_StableFLoor)
{
   mapTo = "StableFLoor";
   diffuseMap[0] = "StableFLoor.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "Tortuga_Bldgs";
};

singleton Material(mat_hey)
{
   mapTo = "hey";
   diffuseMap[0] = "hey.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepGrass1Sound";
   materialTag0 = "Tortuga_Bldgs";
};

singleton Material(mat_WindowA)
{
   mapTo = "WindowA";
   diffuseMap[0] = "WindowA";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   materialTag0 = "Tortuga_Bldgs";
};

singleton Material(mat_medhouse22)
{
   mapTo = "medhouse22";
   diffuseMap[0] = "medhouse22";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   materialTag0 = "Tortuga_Bldgs";
};

singleton Material(LightHouse_dif)
{
   mapTo = "LightHouse_dif";
   diffuseMap[0] = "LightHouse.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "36";
   translucentBlendOp = "None";
   normalMap[0] = "LightHouse_nm.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "LightHouse_spec.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "Tortuga_Bldgs";
};
