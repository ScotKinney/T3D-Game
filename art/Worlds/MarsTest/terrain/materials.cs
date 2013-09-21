//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

singleton Material(Ter_grass1)
{
   mapto = "grass1";
   footstepSoundId = 1;
   //customFootstepSound = "FootStepWood1Sound";
};

new TerrainMaterial(grass1)
{
   internalName = "grass1";
   diffuseMap = $WorldPath @ "/terrain/Example/grass1";
   detailMap = $WorldPath @ "/terrain/Example/grass1_d";
   detailSize = "10";
   isManaged = "1";
   detailBrightness = "1";
   Enabled = "1";
   diffuseSize = "200";
};

singleton Material(Ter_rocktest)
{
   mapto = "rocktest";
   footstepSoundId = 1;
   //customFootstepSound = "FootStepWood1Sound";
};

new TerrainMaterial(rocktest)
{
   internalName = "rocktest";
   diffuseMap = $WorldPath @ "/terrain/Example/rocktest";
   detailMap = $WorldPath @ "/terrain/Example/rocktest_d";
   detailSize = "4";
   detailDistance = "500";
   isManaged = "1";
   detailBrightness = "1";
   Enabled = "1";
   diffuseSize = "400";
   detailStrength = "1.2";
};

singleton Material(Ter_grass1_dry)
{
   mapto = "grass1_dry";
   footstepSoundId = 1;
   //customFootstepSound = "FootStepWood1Sound";
};

new TerrainMaterial(grass1_dry)
{
   internalName = "grass1_dry";
   diffuseMap = $WorldPath @ "/terrain/Example/grass1-dry";
   detailMap = $WorldPath @ "/terrain/Example/grass1-dry_d";
   detailSize = "10";
   detailDistance = "100";
   isManaged = "1";
   detailBrightness = "1";
   Enabled = "1";
   diffuseSize = "250";
   detailStrength = "2";
};

singleton Material(Ter_dirt_grass)
{
   mapto = "dirt_grass";
   footstepSoundId = 1;
   //customFootstepSound = "FootStepWood1Sound";
};

new TerrainMaterial()
{
   internalName = "dirt_grass";
   diffuseMap = $WorldPath @ "/terrain/Example/dirt_grass";
   detailMap = $WorldPath @ "/terrain/Example/dirt_grass_d";
   detailSize = "2";
   detailDistance = "500";
   isManaged = "1";
   detailBrightness = "1";
   Enabled = "1";
   diffuseSize = "200";
};

singleton Material(Ter_sand)
{
   mapto = "sand";
   footstepSoundId = 1;
   //customFootstepSound = "FootStepWood1Sound";
};

new TerrainMaterial(sand)
{
   internalName = "sand";
   diffuseMap = $WorldPath @ "/terrain/Example/sand";
   detailMap = $WorldPath @ "/terrain/Example/sand_d";
   detailSize = "5";
   detailDistance = "500";
   isManaged = "1";
   detailBrightness = "1";
   Enabled = "1";
   diffuseSize = "200";
   detailStrength = "0.8";
};

