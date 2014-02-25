
singleton Material(mat_BSAnvil)
{
   mapTo = "BS_anvil_dif";
   diffuseMap[0] = "BS_anvil_dif";
   useAnisotropic[0] = "1";
   normalMap[0] = "BS_anvil_nm.dds";
   specularMap[0] = "BS_anvil_spec.dds";
};

singleton Material(mat_BSTable)
{
   mapTo = "BS_Table_dif";
   diffuseMap[0] = "BS_Table_dif";
   customFootstepSound = "FootStepWood1Sound";
   normalMap[0] = "BS_Table_nm.dds";
   specularMap[0] = "BS_Table_spec.dds";
   useAnisotropic[0] = "1";
};

singleton Material(mat_BSVice)
{
   mapTo = "BS_Vise_dif";
   diffuseMap[0] = "BS_Vise_dif";
   normalMap[0] = "BS_Vise_nm.dds";
   specularMap[0] = "BS_Vise_spec.dds";
   useAnisotropic[0] = "1";
};
