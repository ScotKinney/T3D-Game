
singleton Material(Mat_BogToKardScreen)
{
   mapTo = "PMat_BogToKardScreen";
   diffuseMap[0] = "BogToKardScreen";
   specular[0] = "0 0 0 1";
   translucentBlendOp = "None";
   emissive[0] = "1";
   castShadows = "0";
};

singleton Material(material_deadtree_bark_white)
{
  mapTo = "deadtree_bark_white";
  diffuseMap[0] = "deadtree_bark_white";
  normalMap[0] = "deadtree_bark_white_normals";
  translucent[0] = false;
  pixelSpecular[0] = true;
  specular[0] = "0.1 0.1 0.1 1.0";
  specularPower[0] = 32.0;
  customFootstepSound = FootStepWood1Sound;
};

new Material(orcburrow_d)
{
   diffuseMap[0] = "orcburrow_d";
   mapTo = "orcburrow_d";
   customFootstepSound = FootStepWood1Sound;
   normalMap[0] = "orcburrow_normal";
};

new Material(material_orcburrow_sail)
{
  mapTo = "orcburrow_sail";
  diffuseMap[0] = "orcburrow_sail";
  normalMap[0] = "orcburrow_sail_normal";
  translucent[0] = false;
  pixelSpecular[0] = true;
  specular[0] = "0.2 0.2 0.2 1.0";
  specularPower[0] = 12.0;
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_campfire)
{
   mapTo = "campfire";
   diffuseMap[0] = "campfire.dds";
   normalMap[0] = "campfire_normal.dds";
   pixelSpecular[0] = 0;
   specular[0] = "1.0 1.0 1.0 1.0";
   specularPower[0] = 12.0;
   customFootstepSound = FootStepRock1Sound;
};

new Material(material_cottagewall)
{
  mapTo = "cottagewall";
  diffuseMap[0] = "cottagewall";
  normalMap[0] = "cottagewall_normals";
  translucent[0] = false;
  pixelSpecular[0] = true;
  specular[0] = "0.1 0.1 0.1 1.0";
  specularPower[0] = 32.0;
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_WOODWALL2)
{
  mapTo = "WOODWALL2";
  diffuseMap[0] = "WOODWALL2";
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_wood_cottage_blood)
{
  diffuseMap[0] = "wood_cottage_blood";
  mapTo = "wood_cottage_blood";
  normalMap[0] = "wood_cottage_normals";
  translucent[0] = false;
  pixelSpecular[0] = true;
  specular[0] = "0.3 0.3 0.2 1.0";
  specularPower[0] = 32.0;
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_cottageroof_shingle_decay)
{  
  mapTo = "cottageroof_shingle_decay";
  diffuseMap[0] = "cottageroof_shingle_decay";
  normalMap[0] = "cottageroof_shingle_normals";
  translucent[0] = false;
  pixelSpecular[0] = true;
  specular[0] = "0.1 0.1 0.1 1.0";
  specularPower[0] = 32.0;
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_wallpapercottageA)
{
  diffuseMap[0] = "wallpapercottageA";
  mapTo = "wallpapercottageA";
  customFootstepSound = FootStepWood1Sound;
};

singleton Material(mat_ruinswood)
{
   mapTo = "ruinswood";
   diffuseMap[0] = "ruinswood";
   translucent = "0";
};

singleton Material(Mat_cartwreck_details)
{
   mapTo = "cartwreck_details_d";
   diffuseMap[0] = "cartwreck_details_d";
   customFootstepSound = FootStepWood1Sound;
};

singleton Material(Mat_cartwreck_d)
{
   mapTo = "cartwreck_d";
   diffuseMap[0] = "cartwreck_d";
   customFootstepSound = FootStepWood1Sound;
};

new Material(material_dock_cottagewood)
{
   mapTo = "dock_cottagewood";
   diffuseMap[0] = "dock_cottagewood";
   normalMap[0] = "dock_cottagewood_normals";
   translucent[0] = false;
   pixelSpecular[0] = true;
   specular[0] = "0.1 0.1 0.1 1.0";
   specularPower[0] = 32.0;
   customFootstepSound = FootStepWood1Sound;
};

singleton Material(mat_strippedbark)
{
   mapTo = "strippedbark";
   diffuseMap[0] = "strippedbark";
   translucent = "0";
};

new Material(material_cottageroof_shingle)
{
  mapTo = "cottageroof_shingle"; 
  diffuseMap[0] = "cottageroof_shingle";
  normalMap[0] = "cottageroof_shingle_normals";
  translucent[0] = false;
  pixelSpecular[0] = true;
  specular[0] = "0.1 0.1 0.1 1.0";
  specularPower[0] = 32.0;
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_cottageroof_shingle_blood)
{
  mapTo = "cottageroof_shingle_blood";
  diffuseMap[0] = "cottageroof_shingle_blood";
  normalMap[0] = "cottageroof_shingle_normals";
  translucent[0] = false;
  pixelSpecular[0] = true;
  specular[0] = "0.1 0.1 0.1 1.0";
  specularPower[0] = 32.0;
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_wallpapercottageAblood)
{
  diffuseMap[0] = "wallpapercottageAblood";
  mapTo = "wallpapercottageAblood";
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_wallpapercottageB)
{
  diffuseMap[0] = "wallpapercottageB";
  mapTo = "wallpapercottageB";
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_dock_cottagewall)
{
  diffuseMap[0] = "dock_cottagewall";
  mapTo = "dock_cottagewall";
  normalMap[0] = "cottagewall_normals";
  translucent[0] = false;
  pixelSpecular[0] = true;
  specular[0] = "0.1 0.1 0.1 1.0";
  specularPower[0] = 32.0;
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_WOODWALL2blood)
{
  diffuseMap[0] = "WOODWALL2blood";
  mapTo = "WOODWALL2blood";
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_cottageroof_moss)
{
  mapTo = "cottageroof_moss";
  diffuseMap[0] = "cottageroof_moss";
  normalMap[0] = "cottageroof_shingle_normals";
  translucent[0] = false;
  pixelSpecular[0] = true;
  specular[0] = "0.1 0.1 0.1 1.0";
  specularPower[0] = 32.0;
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_dock_cottagewall_blood)
{
  mapTo = "dock_cottagewall_blood";
  diffuseMap[0] = "dock_cottagewall_blood";
  normalMap[0] = "cottagewall_normals";
  translucent[0] = false;
  pixelSpecular[0] = true;
  specular[0] = "0.1 0.1 0.1 1.0";
  specularPower[0] = 32.0;
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_orkburrow)
{
  diffuseMap[0] = "orkburrow";
  mapTo = "orkburrow";
  customFootstepSound = FootStepWood1Sound;
};

new Material(material_watchtower_d)
{
  diffuseMap[0] = "watchtower_d";
  mapTo = "watchtower_d";
  customFootstepSound = FootStepWood1Sound;
};

new Material(watchtower2_D)
{
  diffuseMap[0] = "watchtower2_D";
  mapTo = "watchtower2_D";
  customFootstepSound = FootStepWood1Sound;
};

singleton Material(Mat_KardiaPointer)
{
   mapTo = "KardiaPointer";
   diffuseMap[0] = "KardiaPointer";
};

singleton Material(mat_fencepostbasic01A)
{
   mapTo = "fencePostBasic01A";
   diffuseMap[0] = "fencePostBasic00A.png";
   materialTag0 = "DefaultProps";
};
