//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

// This is the default save location for any ForestBrush(s) created in 
// the Forest Editor.
// This script is executed from ForestEditorPlugin::onWorldEditorStartup().

//--- OBJECT WRITE BEGIN ---
new SimGroup(ForestBrushGroup) {
   canSave = "1";
   canSaveDynamicFields = "1";

   new ForestBrush() {
      internalName = "PrimeForest";
      canSave = "1";
      canSaveDynamicFields = "1";

      new ForestBrushElement() {
         internalName = "Archeopteris_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "Archeopteris_01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.8";
         scaleMax = "1.5";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.2";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "WollemiPine_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "WollemiPine_01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "1";
         scaleMax = "2";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.2";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "Tempskya_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "Tempskya_01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "1";
         scaleMax = "2.5";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.2";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
   };
   new ForestBrush() {
      internalName = "GroundPlants";
      canSave = "1";
      canSaveDynamicFields = "1";

      new ForestBrushElement() {
         internalName = "Macrotawniopteris_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.7";
         scaleMax = "1.7";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.3";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "CyadeGigantea_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "CyadeGigantea_01";
         probability = "0.5";
         rotationRange = "360";
         scaleMin = "1";
         scaleMax = "2";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.2";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "NipaPlant_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "NipaPlant_01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "1";
         scaleMax = "1.5";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.15";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
   };
   new ForestBrush() {
      internalName = "MidPlanesPlants";
      canSave = "1";
      canSaveDynamicFields = "1";

      new ForestBrushElement() {
         internalName = "Fern_Vert_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "Fern_Vert_01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "3";
         scaleMax = "4";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.3";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "Fern_Vert_02";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "Fern_Vert_02";
         probability = "1";
         rotationRange = "360";
         scaleMin = "3";
         scaleMax = "4.25";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.3";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "Bjuvia_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "Bjuvia_01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.5";
         scaleMax = "1.5";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.3";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "CycadeTree_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "CycadeTree_01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.5";
         scaleMax = "2";
         scaleExponent = "1";
         sinkMin = "0.2";
         sinkMax = "0.3";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "Pachypteris_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "Pachypteris_01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.5";
         scaleMax = "2";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.2";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "Williamsonia_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "Williamsonia_01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.5";
         scaleMax = "1.5";
         scaleExponent = "1";
         sinkMin = "0.2";
         sinkMax = "0.4";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
   };
   new ForestBrush() {
      internalName = "GrassesandFerns";
      canSave = "1";
      canSaveDynamicFields = "1";

      new ForestBrushElement() {
         internalName = "BaseWeed_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "BaseWeed_01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.75";
         scaleMax = "1.5";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.15";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "HighGrass_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "HighGrass_01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.5";
         scaleMax = "1.25";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.15";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
   };
   new ForestBrush() {
      internalName = "DeadPlants";
      canSave = "1";
      canSaveDynamicFields = "1";

      new ForestBrushElement() {
         internalName = "DeadStandingPine01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "DeadStandingPine01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "1";
         scaleMax = "1.5";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.3";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
      new ForestBrushElement() {
         internalName = "DownPine002";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "DownPine002";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.5";
         scaleMax = "1.5";
         scaleExponent = "1";
         sinkMin = "0.1";
         sinkMax = "0.3";
         sinkRadius = "1";
         slopeMin = "0";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
   };
   new ForestBrush() {
      internalName = "Rocks";
      canSave = "1";
      canSaveDynamicFields = "1";

      new ForestBrushElement() {
         internalName = "GroundRock_01";
         canSave = "1";
         canSaveDynamicFields = "1";
         ForestItemData = "GroundRock_01";
         probability = "1";
         rotationRange = "360";
         scaleMin = "0.5";
         scaleMax = "2";
         scaleExponent = "1";
         sinkMin = "1";
         sinkMax = "3";
         sinkRadius = "0.1";
         slopeMin = "0.3";
         slopeMax = "90";
         elevationMin = "-10000";
         elevationMax = "10000";
      };
   };
};
//--- OBJECT WRITE END ---
