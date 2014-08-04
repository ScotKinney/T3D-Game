singleton Material(Giraffe)
{
   mapTo = "Giraffe";
   diffuseMap[0] = "Giraffe";
   specularPower[0] = "100";
   translucent = "0";
   useAnisotropic[0] = "1";
   specular[0] = "0 0 0 1";
};

singleton Material(GiraffeTail)
{
   mapTo = "GiraffeTail";
   diffuseMap[0] = "GiraffeTail";
   specularPower[0] = "100";
   translucent = "1";
};

new Material(GiraffeFootprint)
{
   diffuseMap[0] = "art/Packs/AI/Giraffe/FP_Giraffe";
   normalMap[0] = "art/Packs/AI/Giraffe/FP_Giraffe";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "footprint";
};