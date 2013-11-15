//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

// This is the default save location for any ForestBrush(s) created in 
// the Forest Editor.
// This script is executed from ForestEditorPlugin::onWorldEditorStartup().

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
      internalName = "The Bog";
      canSave = "1";
      canSaveDynamicFields = "1";

      new ForestBrushElement() {
         internalName = "Fern_Vert_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "Fern_Vert_01";
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
