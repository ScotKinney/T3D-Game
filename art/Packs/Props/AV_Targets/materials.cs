singleton Material(mat_Target)
{
   mapTo = "TargetFace";
   diffuseMap[0] = "art/Packs/Props/AV_Targets/TargetFace";
   materialTag0 = "Props_AV";
   specularPower[0] = "1";
   pixelSpecular[0] = "0";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
};

singleton Material(mat_TargetPost)
{
   mapTo = "TargetPost_dif";
   diffuseMap[0] = "TargetPost_dif";
   normalMap[0] = "TargetPost_nm.dds";
   specularPower[0] = "100";
   specularStrength[0] = "2";
   pixelSpecular[0] = "1";
   specularMap[0] = "TargetPost_spec.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
};
