
singleton Material(mat_medworld_boat_a)
{
   mapTo = "medworld_boat_a";
   diffuseMap[0] = "medworld_boat_a";
   doubleSided = "0";
   customFootstepSound = "FootStepWood1Sound";
   useAnisotropic[0] = "1";
};

singleton Material(mat_medworld_boat_b)
{
   mapTo = "medworld_boat_b";
   diffuseMap[0] = "medworld_boat_b";
   doubleSided = "0";
   useAnisotropic[0] = "1";
};

singleton Material(mat_plant)
{
   mapTo = "plant";
   diffuseMap[0] = "plant";
   translucentZWrite = "1";
   alphaRef = "20";
   translucent = "1";
};

singleton Material(PMat_TcaveFromFJ2_mat)
{
   mapTo = "PMat_TcaveFromFJ2";
   diffuseMap[0] = "SmokeScreenTCaves";
};

singleton Material(PMat_TcaveFromFJ1_mat)
{
   mapTo = "PMat_TcaveFromFJ1";
   diffuseMap[0] = "SmokeScreenTCaves";
};
