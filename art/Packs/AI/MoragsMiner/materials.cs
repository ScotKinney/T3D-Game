
singleton Material(Mat_MinersBody)
{
   mapTo = "MedievalTownsFolk1_ScribeBody";
   diffuseMap[0] = "ScribeBody.dds";
   specularPower[0] = "100";
   translucent = "0";
   normalMap[0] = "ScribeBody_NRM.png";
};

singleton Material(mat_MinersHead)
{
   mapTo = "MedievalTownsFolk1_ScribeHead";
   diffuseMap[0] = "ScribeHead.dds";
   specularPower[0] = "100";
   translucent = "0";
   normalMap[0] = "ScribeHead_NRM.png";
};

singleton Material(DefaultMaterial4)
{
   mapTo = "ScribeHead";
   diffuseMap[0] = "art/Packs/AI/MoragsMiner/ScribeHead";
   normalMap[0] = "art/Packs/AI/MoragsMiner/ScribeHead_NRM.png";
   useAnisotropic[0] = "1";
   specularPower[0] = "1";
   specularStrength[0] = "0";
   pixelSpecular[0] = "0";
};

singleton Material(DefaultMaterial5)
{
   mapTo = "ScribeBody";
   diffuseMap[0] = "art/Packs/AI/MoragsMiner/ScribeBody";
   normalMap[0] = "art/Packs/AI/MoragsMiner/ScribeBody_NRM.png";
   specularPower[0] = "128";
   specularStrength[0] = "0";
   pixelSpecular[0] = "0";
   useAnisotropic[0] = "1";
};
