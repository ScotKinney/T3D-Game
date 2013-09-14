//--- cardboard_boxes.dae MATERIALS BEGIN ---
singleton Material(CardboardBoxes)
{
	mapTo = "CardboardBoxes";

	diffuseMap[0] = $WorldPath @ "/models/props/Cardboard_boxes/Boxes_diff.dds";
	normalMap[0] = $WorldPath @ "/models/props/Cardboard_boxes/Boxes_norm.dds";
	specularMap[0] = $WorldPath @ "/models/props/Cardboard_boxes/Boxes_spec.dds";

	diffuseColor[0] = "0.7 0.7 0.7 0";
	specular[0] = "1 1 1 0";
	specularPower[0] = 50;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
};

singleton Material(CardboardBoxesLOD)
{
	mapTo = "CardboardBoxesLOD";

	diffuseMap[0] = $WorldPath @ "/models/props/Cardboard_boxes/Boxes_diff.dds";
	castShadows = "0";
};

//--- CardboardBoxes MATERIALS END ---


singleton Material(cardboard_boxes_Phong_Preset)
{
   mapTo = "Phong_Preset";
   specular[0] = "1 1 1 0";
   specularPower[0] = "50";
   translucentBlendOp = "None";
};
