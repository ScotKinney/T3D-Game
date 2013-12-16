

new Material(mat_5_56_ammo)
{
   mapTo = "tracer";
   diffuseMap[0] = "art/inv/weapons/XR75/tracer";
   emissive = true;
   Glow[0] = true;
   castShadows = "0";
   translucent = "1";
   translucentBlendOp = "Add";
   alphaRef = "0";
   materialTag0 = "Weapons";
};

singleton Material(XR75_mech_01_5)
{
   mapTo = "mech-01-5";
   diffuseMap[0] = "art/inv/weapons/XR75/ma5.body";
   materialTag0 = "Weapons";
};