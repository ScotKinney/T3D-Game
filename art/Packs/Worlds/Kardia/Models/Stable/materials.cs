//////////////////////////////////
///Stable
//////////////////////////////////

singleton Material(mat_newroof)
{
   mapTo = "newroof";
   diffuseMap[0] = "newroof";
   normalMap[0] = "newroof_NRM.jpg";
   specularPower[0] = "61";
   pixelSpecular[0] = "1";
   materialTag0 = "stable";
   useAnisotropic[0] = "1";
};

singleton Material(mat_medbuilding_tex1)
{
   mapTo = "medbuilding_tex1";
   diffuseMap[0] = "medbuilding_tex1";
   normalMap[0] = "medbuilding_tex1_NRM.jpg";
   specular[0] = "0.741176 0.741176 0.741176 1";
   specularPower[0] = "76";
   pixelSpecular[0] = "1";
   materialTag0 = "stable";
  customFootstepSound = FootSteprock1Sound;
   useAnisotropic[0] = "1";
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
   materialTag0 = "stable";
   useAnisotropic[0] = "1";
};

