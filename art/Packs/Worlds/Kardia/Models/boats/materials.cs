

singleton Material(mat_KardBoatSpar)
{
   mapTo = "PMat_KardBoatSpar";
   diffuseMap[0] = "wood1a";
   materialTag0 = "Boats";
};

singleton Material(mat_KardBoatSail)
{
   mapTo = "PMat_KardBoatSail";
   diffuseMap[0] = "shzboatsail1.jpg";
   materialTag0 = "Boats";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   showFootprints = "0";
};

singleton Material(mat_KardBoatRope3)
{
   mapTo = "PMat_KardBoatRope3";
   diffuseMap[0] = "rope1";
   materialTag0 = "Boats";
   useAnisotropic[0] = "0";
   castShadows = "0";
};

singleton Material(mat_KardBoatRope1)
{
   mapTo = "PMat_KardBoatRope1";
   diffuseMap[0] = "rope1";
   materialTag0 = "Boats";
   useAnisotropic[0] = "0";
   castShadows = "0";
};

singleton Material(mat_KardBoatDeck)
{
   mapTo = "PMat_KardBoatDeck";
   diffuseMap[0] = "shzwood2";
   materialTag0 = "Boats";
   useAnisotropic[0] = "0";
   castShadows = "0";
   customFootstepSound = "FootStepWood1Sound";
};

singleton Material(mat_KardBoatBottom)
{
   mapTo = "PMat_KardBoatBottom";
   diffuseMap[0] = "shzwood1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "Boats";
   useAnisotropic[0] = "0";
   castShadows = "0";
};

singleton Material(mat_KardBoatTopEdge_mat)
{
   mapTo = "PMat_KardBoatTopEdge";
   diffuseMap[0] = "shzwood4.jpg";
   translucent = "0";
   useAnisotropic[0] = "0";
   castShadows = "0";
   materialTag0 = "Boats";
};

singleton Material(PMat_KardBoatMast_mat)
{
   mapTo = "PMat_KardBoatMast";
   diffuseMap[0] = "shzwood4.jpg";
   translucent = "0";
   materialTag0 = "Boats";
};

