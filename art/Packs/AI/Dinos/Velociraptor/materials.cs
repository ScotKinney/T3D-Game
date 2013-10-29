
singleton Material(mat_velociraptor)
{
   mapTo = "velociraptors";
   diffuseMap[0] = "velociraptors";
   normalMap[0] = "velociraptors_n";
   specularMap[0] = "velociraptors_s";
   useAnisotropic[0] = "1";
};

singleton Material(matDeerHideTrans)
{
   mapTo = "transparent";
   diffuseMap[0] = "art/inv/items/deerhide/transparent";
   translucent = "1";
};
