new CubemapData(DalRiata_CubeMap)
{
   cubeFace[0] = "art/packs/skyboxes/dalriata/DalRiataRight";
   cubeFace[1] = "art/packs/skyboxes/dalriata/DalRiataLeft";
   cubeFace[2] = "art/packs/skyboxes/dalriata/DalRiataBack";
   cubeFace[3] = "art/packs/skyboxes/dalriata/DalRiataFront";
   cubeFace[4] = "art/packs/skyboxes/dalriata/DalRiataUp";
   cubeFace[5] = "art/packs/skyboxes/dalriata/DalRiataDown";
};

singleton Material(DalRiata_Sky)
{
   cubemap = "DalRiata_CubeMap";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyBoxes";
};