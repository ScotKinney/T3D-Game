///////////////////////////////////////////////////////
/////FOOTPRINTS
////////////////////////////////////////////////////////////////

new Material(CommonPlayerFootprint)
{
   diffuseMap[0] = "core/art/effects/footprint";
   normalMap[0] = "core/art/effects/footprint";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "decal";
};

//////////////////////////////////////////////////////////////
singleton Material(DECAL_defaultblobshadow)
{
   diffuseMap[0] = "core/art/effects/defaultblobshadow";
   normalMap[0] = "core/art/effects/defaultblobshadow";
   translucent = "1";
   translucentZWrite = "1";
   materialTag0 = "decal";
};