
singleton Material(mat_wizardstaff)
{
   mapTo = "WizardAStaff";
   diffuseMap[0] = "WizardAStaff";
   useAnisotropic[0] = "1";
};

singleton Material(mat_Fury)
{
   mapTo = "StaffofFury_dif";
   diffuseMap[0] = "StaffofFury_dif";
   normalMap[0] = "StaffofFury_nm.dds";
   specularMap[0] = "StaffofFury_spec.dds";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "161";
};

singleton Material(mat_Havok)
{
   mapTo = "Havok_dif";
   diffuseMap[0] = "Havok_dif";
   normalMap[0] = "Havok_nm.dds";
   specularMap[0] = "Havok_spec.dds";
   useAnisotropic[0] = "1";
};

singleton Material(mat_Doom)
{
   mapTo = "StaffofDoom_dif";
   diffuseMap[0] = "StaffofDoom_dif";
   normalMap[0] = "StaffofDoom_nm.dds";
   specularMap[0] = "StaffofDoom_spec.dds";
   useAnisotropic[0] = "1";
};
