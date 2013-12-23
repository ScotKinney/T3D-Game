
singleton Material(mat_FemWizard)
{
   mapTo = "FemElementalist";
   diffuseMap[0] = "art/Packs/AI/Wizard_F/FemElementalist";
   normalMap[0] = "art/Packs/AI/Wizard_F/FemElementalist_NRM.jpg";
   useAnisotropic[0] = "1";
};

singleton Material(mat_FemWizardTRS)
{
   mapTo = "FemElementalistTRS";
   diffuseMap[0] = "art/Packs/AI/Wizard_F/FemElementalistTRS.png";
   normalMap[0] = "art/Packs/AI/Wizard_F/FemElementalistTRS_NRM.jpg";
   useAnisotropic[0] = "1";
   alphaRef = "40";
};

singleton Material(mat_FemWizardTRS)
{
   mapTo = "FemElementalistTRS";
   diffuseMap[0] = "art/Packs/AI/Wizard_F/FemElementalistTRS.png";
   normalMap[0] = "art/Packs/AI/Wizard_F/FemElementalistTRS_NRM.jpg";
};

singleton Material(mat_FemWizard_Hair)
{
   mapTo = "FemElemHair";
   diffuseMap[0] = "art/Packs/AI/Wizard_F/FemElemHair";
   useAnisotropic[0] = "1";
};

singleton Material(mat_FemWizard_Staff)
{
   mapTo = "ElementalistStaff";
   diffuseMap[0] = "art/Packs/AI/Wizard_F/ElementalistStaff.dds";
   normalMap[0] = "art/Packs/AI/Wizard_F/ElementalistStaff_NRM.jpg";
   useAnisotropic[0] = "1";
   translucent = "0";
};
