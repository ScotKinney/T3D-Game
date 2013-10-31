//--- OBJECT WRITE BEGIN ---
new SimGroup(ForestBrushGroup) {
   canSave = "1";
   canSaveDynamicFields = "1";

   new ForestBrushElement() {
      internalName = "defaulttree";
      canSave = "1";
      canSaveDynamicFields = "1";
      probability = "1";
      rotationRange = "360";
      scaleMin = "1";
      scaleMax = "4";
      scaleExponent = "1";
      sinkMin = "0.01";
      sinkMax = "0.03";
      sinkRadius = "1";
      slopeMin = "0";
      slopeMax = "90";
      elevationMin = "-10000";
      elevationMax = "10000";
   };
   new ForestBrush() {
      internalName = "Kardia";
      canSave = "1";
      canSaveDynamicFields = "1";

      new ForestBrushElement() {
         internalName = "CanopyTree01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "CanopyTree_01_noVines";
         probability = "1";
         rotationRange = "360";
         scaleMin = "1";
         scaleMax = "1";
         scaleExponent = "1";
         sinkMin = "0.01";
         sinkMax = "0.04";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "CanopyTree03";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "canopytree_three";
         probability = "1";
         rotationRange = "360";
         scaleMin = "1";
         scaleMax = "2";
         scaleExponent = "1";
         sinkMin = "0.01";
         sinkMax = "0.1";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "CanopyTree02";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "canopytree_two";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.51";
         scaleMax = "1";
         scaleExponent = "1";
         sinkMin = "0.01";
         sinkMax = "0.01";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "Shrub_Large";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "Shrub_Large";
         probability = "1";
         rotationRange = "360";
         scaleMin = "1";
         scaleMax = "1";
         scaleExponent = "1";
         sinkMin = "0";
         sinkMax = "0";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "bigrock03";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "bigrock03";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.1";
         scaleMax = "0.3";
         scaleExponent = "1";
         sinkMin = "0.2";
         sinkMax = "0.4";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "30";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "bigrock01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "bigrock01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.1";
         scaleMax = "0.3";
         scaleExponent = "1";
         sinkMin = "0.2";
         sinkMax = "0.4";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "30";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "Big_Leaf";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "BigLeaf_Plant";
         probability = "1";
         rotationRange = "360";
         scaleMin = "1.5";
         scaleMax = "2";
         scaleExponent = "1";
         sinkMin = "0.02";
         sinkMax = "0.04";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "rivergrass";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "rivergrass0";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.5";
         scaleMax = "1.5";
         scaleExponent = "1";
         sinkMin = "0";
         sinkMax = "0";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
            clumpCountExponent = "1";
            clumpCountMax = "15";
            clumpCountMin = "10";
            clumpRadius = "0.05";
      };
      new ForestBrushElement() {
         internalName = "Palm_Short";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "PalmTree_Short_01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "1";
         scaleMax = "1.5";
         scaleExponent = "1";
         sinkMin = "0";
         sinkMax = "0";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
            clumpCountExponent = "1";
            clumpCountMax = "1";
            clumpCountMin = "1";
            clumpRadius = "10";
      };
      new ForestBrushElement() {
         internalName = "Palm_Tall_Leaning";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "TallPalmLeaning";
         probability = "1";
         rotationRange = "360";
         scaleMin = "1";
         scaleMax = "2";
         scaleExponent = "1";
         sinkMin = "0";
         sinkMax = "0";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
            clumpCountExponent = "1";
            clumpCountMax = "1";
            clumpCountMin = "1";
            clumpRadius = "10";
      };
      new ForestBrushElement() {
         internalName = "Palm_Tall";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "palmtree_tall";
         probability = "1";
         rotationRange = "360";
         scaleMin = "1";
         scaleMax = "2";
         scaleExponent = "1";
         sinkMin = "0";
         sinkMax = "0";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "BananaMature";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "BananaMature";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.8";
         scaleMax = "1.1";
         scaleExponent = "1";
         sinkMin = "-2.6";
         sinkMax = "-2.6";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
            clumpCountExponent = "1";
            clumpCountMax = "1";
            clumpCountMin = "1";
            clumpRadius = "10";
      };
      new ForestBrushElement() {
         internalName = "TropicFern2";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "TropicFern2";
         probability = "1";
         rotationRange = "360";
         scaleMin = "2";
         scaleMax = "3";
         scaleExponent = "1";
         sinkMin = "0";
         sinkMax = "0";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "Phila2";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "Phila2";
         probability = "1";
         rotationRange = "360";
         scaleMin = "1";
         scaleMax = "1.5";
         scaleExponent = "1";
         sinkMin = "0";
         sinkMax = "0";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "Bush2";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "Bush2";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.5";
         scaleMax = "1";
         scaleExponent = "1";
         sinkMin = "0";
         sinkMax = "0";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
   };
};
//--- OBJECT WRITE END ---
