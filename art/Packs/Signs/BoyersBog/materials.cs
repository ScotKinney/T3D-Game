singleton Material(Mat_BoyersBogPointer)
{
   mapTo = "BoyersBogPointer";
   diffuseMap[0] = "BoyersBogPointer";
   materialTag0 = "Signs";
};

singleton Material(Mat_BogSignPost)
{
   mapTo = "BogSignPost";
   diffuseMap[0] = "BogSignPost_dif";
   normalMap[0] = "BogSignPost_nm";
   materialTag0 = "Signs";
};

singleton Material(DefaultMaterial3)
{
   mapTo = "BogSignPost_dif";
   diffuseMap[0] = "art/Packs/Signs/BoyersBog/BogSignPost_dif";
   normalMap[0] = "art/Packs/Signs/BoyersBog/BogSignPost_nm.dds";
   useAnisotropic[0] = "1";
};
