
singleton Material(mat_H2HTrans)
{
   mapTo = "H2HWeapon";
   diffuseMap[0] = "H2HWeapon.png";
   translucent = "1";
};

singleton Material(transparent_mat)
{
   mapTo = "transparent";
   diffuseMap[0] = "H2HWeapon.png";
   translucentBlendOp = "None";
};
