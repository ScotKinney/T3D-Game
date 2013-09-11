// buildRights.cs This file defines the mask bits for build rights.
// It is loaded on the client and server so the permissions match.

$Rights::ContentBit =   mPow(2, 1);
$Rights::ObjectBit =    mPow(2, 2);
$Rights::TerrainBit =   mPow(2, 3);
$Rights::ForestBit =    mPow(2, 4);
$Rights::DecalsBit =    mPow(2, 5);
