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

singleton Material(mat_StableFloor)
{
   mapTo = "StableFLoor";
   diffuseMap[0] = "StableFLoor";
   translucent = "0";
   materialTag0 = "MedCity";
   castShadows = "0";
};

singleton Material(mat_Hey)
{
   mapTo = "hey";
   diffuseMap[0] = "hey";
   translucent = "0";
   materialTag0 = "MedCity";
};