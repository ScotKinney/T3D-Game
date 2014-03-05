singleton Material(mat_fencepostbasic)
{
   mapTo = "fencePostBasic00A";
   diffuseMap[0] = "art/Packs/Props/AV_Targets/fencePostBasic00A.png";
   materialTag0 = "Props_AV";
   normalMap[0] = "art/Packs/props/AV_Targets/fencePostBasic00A_NORM.png";
   specularMap[0] = "art/Packs/props/AV_Targets/fencePostBasic00A_SPEC.png";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
};

singleton Material(mat_Target)
{
   mapTo = "TargetFace";
   diffuseMap[0] = "art/Packs/Props/AV_Targets/TargetFace";
   materialTag0 = "Props_AV";
   specularPower[0] = "100";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
};
